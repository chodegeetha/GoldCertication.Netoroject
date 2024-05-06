using GoldCertificationExam.Server.Contexts;
using GoldCertificationExam.Server.Models;

namespace GoldCertificationExam.Server.Repositories
{
    public class AuthRepositoryImpl:IAuthRepository
    {
        private readonly ApplicationDbContext context;

        public AuthRepositoryImpl(ApplicationDbContext _context)
        {
            context = _context;

        }


        public async Task<User> SignUp(User model)
        {
            try
            {
                context.User.AddAsync(model);

                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddUserRoles(int Id)
        {
            try
            {

                UserRoles userRole = new UserRoles { UserID = Id, RoleID = 1 };
                await context.UserRoles.AddAsync(userRole);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> Loginuser(string email, string password)
        {
            try
            {
                var user = context.User.FirstOrDefault(e => e.Email == email && e.Password == password);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetRoleByRoleId(int roleId)
        {
            try
            {
                var role = context.Roles.FirstOrDefault(r => r.Id == roleId);
                if (role != null)
                {
                    return role.RoleName;
                }
                else
                {
                    return "";
                }

            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<int> GetRolesByUserId(int userId)
        {
            try
            {
                var roles = context.UserRoles.Where(ur => ur.UserID == userId).Select(ur => ur.RoleID).ToList();
                if (roles.Any())
                {
                    return roles;
                }
                else
                {
                    return new List<int>();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}

    
