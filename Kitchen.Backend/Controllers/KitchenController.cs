using Kitchen.Backend.Model;
using Kitchen.Backend.Repastories;
using Kitchen.Backend.Repastories.Account;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class KitchenController : ControllerBase
    {
        private readonly IUserAccountService _account;
        ////////////////////////////////////////////////////
        public KitchenController(IUserAccountService account)
        {
            _account = account;

        }
        [HttpGet]
        ////////////////////////////////////////////////////Admin
        public async Task<IActionResult> GetAllUserData()
        {
            var get = await _account.GetAllDataAsync();
            if (get.Code == 200 && get.Data is not null)
            {
                return Ok(get.Data);

            }
            if (get.Code == 500 && get.Data is not null)
            {
                return BadRequest(get);

            }
            return NotFound(get);

        }
        [HttpGet]
        ////////////////////////////////////////////////////
        public async Task<IActionResult> GetById(int id)
        {
            var get = await _account.GetByIdAsync(id);
            if (get.Code == 200 && get.Data is not null)
            {
                return Ok(get.Data);
            }
            if (get.Code == 500 && get.Data is not null)
            {
                return BadRequest(get);

            }
            return NotFound(get);
        }
        [HttpDelete]
        ////////////////////////////////////////////////////
        public async Task<IActionResult> AccDalateAsync(string login, string password)
        {
            var del = await _account.DalateAsync(login, password);
            {
                if (del.Code == 200 && del.Data is true)
                {
                    return Ok(del.Data);
                }
                if (del.Code == 500 && del.Data is false)
                {
                    return Ok(del);
                }
                return NotFound(del);
            }

        }
        [HttpPost]
        ////////////////////////////////////////////////////
        public async Task<IActionResult> SignUpUserAsync([FromForm] User entity)
        {
            var del = await _account.SignUpAsync(entity);
            {
                if (del.Code == 200 && del.Data is not null)
                {
                    return Ok(del.Data);
                }
                if (del.Code == 500 && del.Data is not null)
                {
                    return Ok(del);
                }
                return NotFound(del);
            }

        }
        [HttpGet]
        ////////////////////////////////////////////////////
        public async Task<IActionResult> LigInUserAsync(string login, string password)
        {
            var del = await _account.LogInAsync(login, password);
            {
                if (del.Code == 200 && del.Data is not null)
                {
                    return Ok(del);
                }
                if (del.Code == 500 && del.Data is not null)
                {
                    return Ok(del);
                }
                return NotFound(del);
            }

        }
        
        ////////////////////////////////////////////////////


    }
}
