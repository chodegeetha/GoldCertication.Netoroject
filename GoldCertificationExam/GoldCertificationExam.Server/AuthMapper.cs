using GoldCertificationExam.Server.Models;
using GoldCertificationExam.Server.RequestModels;

namespace GoldCertificationExam.Server
{
    public class AuthMapper
    {
        public static User MaptogetUser(AuthRequestModel model)
        {
            User mm = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password
            };
            return mm;
        }

        
    }
}
