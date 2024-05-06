using GoldCertificationExam.Server.Models;

namespace GoldCertificationExam.Server.Repositories
{
    public interface IAuthRepository
    {
        public Task<User> SignUp(User model);
        public Task<bool> AddUserRoles(int Id);


        public Task<User> Loginuser(string email, string password);
        public string GetRoleByRoleId(int roleId);
        public List<int> GetRolesByUserId(int userId);
    }
}
