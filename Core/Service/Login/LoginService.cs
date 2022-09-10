using Domain.DataModels.Models;
using Core.Repository.Login;
using System.Linq;

namespace Core.Service.Login
{
    public class LoginService
    {
        public LoginRepo LoginRepo = new LoginRepo();
        public async Task<UserModel?> GetById(UserModel user)
        {
            UserModel userModel = new UserModel();
            var task = await LoginRepo.GetList(user);
            return task.SingleOrDefault();
        }
        public async Task<bool> Login(UserModel user)
        {   
            // Hash Password HERE

            var task = await LoginRepo.GetList(user);
            var userDetails = task.Count() > 0 ? task.SingleOrDefault() : null;

            if (userDetails == null || user.Password != userDetails.Password) return false;
            return true;
        }
        public async Task<List<UserModel>?> GetList(UserModel user)
        {
            return await LoginRepo.GetList(user);
        }
        public async Task<long?> Insert(UserModel user)
        {
            // HASH PASSWORD HERE
            return await LoginRepo.Insert(user);
        }
        public async Task<long?> Update(UserModel user)
        {
            return await LoginRepo.Update(user);
        }
        public async Task<long?> Delete(UserModel user)
        {
            return await LoginRepo.Delete(user.UserId);
        }

    }
}
