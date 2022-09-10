using Microsoft.AspNetCore.Mvc;
using Core.Service.Login;
using Domain.DataModels.Models;
using Web.Dto.User;

namespace MyTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [Route("Login")]
        [HttpPost]
        public async Task<UserDto> GetItemList(UserModel item)
        {
            LoginService login = new LoginService();
            return await login.Login(item);
        }
        
        [Route("SignUp")]
        [HttpPost]
        public int CreateItem(UserModel item)
        {
            LoginService itemService = new LoginService();
            itemService.InsertItem(item);
            return 1;
        }

        [Route("ChangePassword")]
        [HttpPost]
        public int ChangePassword(UserModel item)
        {
            LoginService itemService = new LoginService();
            itemService.InsertItem(item);
            return 1;
        }
    }
}
