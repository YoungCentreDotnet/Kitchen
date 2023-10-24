using Kitchen.Backend.Model;
using Kitchen.Backend.Repastories.AccountRepository;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountControllers:ControllerBase
    {
        private readonly IAccountService _account;

        public AccountControllers(IAccountService account)
        {
            _account = account;

        }
        [HttpPost]
        public async Task<IActionResult> SignUp( User user)
        {
            var res = await _account.SignUpAsync(user);
            if (res == false)
            {
                return NotFound();
            }
            return Ok(res);
        }
        


    }
}
