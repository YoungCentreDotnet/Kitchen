using Kitchen.Backend.Model;
using Kitchen.Backend.Repastories.Account;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountControllers:ControllerBase
    {
        private readonly IAdminAccountService _account;

        public AccountControllers(IAdminAccountService account)
        {
            _account = account;

        }
        


    }
}
