using Kitchen.Backend.Model;
using Kitchen.Backend.Repastories.Account;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserControllers : ControllerBase
    {
        private readonly IUserAccountService _account;

        public UserControllers(IUserAccountService account)
        {
            _account = account;

        }
        

        
    }
}
