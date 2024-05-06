using GoldCertificationExam.Server.Authentication;
using GoldCertificationExam.Server.Repositories;
using GoldCertificationExam.Server.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoldCertificationExam.Server.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository AuthRepositoryImpl;

        public AuthController(IAuthRepository authRepository)
        {
            AuthRepositoryImpl = authRepository;

        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> Register([FromBody] AuthRequestModel model)
        {
            try
            {
                var data = AuthMapper.MaptogetUser(model);
                var result = await AuthRepositoryImpl.SignUp(data);
                var final = await AuthRepositoryImpl.AddUserRoles(result.Id);


                return Ok(final);
            }
            catch (Exception ex)
            {
                return BadRequest("User Not Found");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Loginuser([FromBody] LoginRequestModel model)
        {

            try
            {
                var user = await AuthRepositoryImpl.Loginuser(model.Email, model.Password);
                if (user != null)
                {

                    var roleIds = AuthRepositoryImpl.GetRolesByUserId(user.Id);
                    List<string> roleNames = new List<string>();
                    foreach (var role in roleIds)
                    {
                        roleNames.Add(AuthRepositoryImpl.GetRoleByRoleId(role));
                    }

                    var tokenPayload = new Dictionary<string, string>
                    {
                        { "userId", user.Id.ToString() },
                        { "userName", user.UserName.ToString() },
                        { "userEmail", user.Email.ToString() },
                        { "Roles", string.Join(",", roleNames) }
                    };

                    var token = JwtTokenGeneration.GenerateToken(tokenPayload);


                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddHours(4)
                    };

                    Response.Cookies.Append("jwt", token, cookieOptions);

                    return Ok(new
                    {
                        success = true,
                        body = new
                        {
                            user = new
                            {
                                userId = user.Id.ToString(),
                                email = user.Email.ToString(),
                                roles = string.Join(",", roleNames)
                            },
                            token = token
                        }
                    });
                }
                else
                {
                    return Ok(new { success = false });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { error = "Login Failed" });
            }
        }

    }
}

        

