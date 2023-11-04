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
        [HttpGet]
        public async Task<IActionResult> GetAllAdminData()
        {
            var get = await _account.GetAllDataAsync();
            if (get.Code == 200 && get.Data is not null)
            {
                return Ok(get);

            }
            if (get.Code == 500 && get.Data is null)
            {
                return BadRequest(get);

            }
            return NotFound(get);

        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var get = await _account.GetByIdAsync(id);
            if(get.Code == 200 && get.Data is not null)
            {
                return Ok(get); 
            }
            if (get.Code == 500 && get.Data is null)
            {
                return BadRequest(get);

            }
            return NotFound(get);
        }
        [HttpDelete]
        public async Task<IActionResult> AccDalateAsync(string login, string password) 
        {
            var del = await _account.DalateAsync(login,password);
            {
                if(del.Code == 202 && del.Data is true)
                {
                     return Ok(del);
                }
                if(del.Code == 500 && del.Data is false)
                {
                    return Ok(del);
                }
                return NotFound(del);
            }
        
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAdminAsync([FromForm]Admin entity)
        {
            var del = await _account.SignUpAsync(entity);
            if (del.Code == 302 && del.Data is not null)
            {
                return StatusCode(StatusCodes.Status302Found, del);

            }
            else if (del.Code == 201 && del.Data is not null)
            {
                return StatusCode(StatusCodes.Status201Created, del);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, del);

        }
        [HttpGet]
        public async Task<IActionResult> LigInAdminAsync(string login, string password)
        {
            var del = await _account.LogInAsync(login,password);
            {
                if (del.Code == 200 && del.Data is not null)
                {
                    return Ok(del);
                }
                if (del.Code == 500 && del.Data is null)
                {
                    return Ok(del);
                }
                return NotFound(del);
            }
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAdminAsync(int id,[FromForm] Admin entity)
        {
            var del = await _account.UpdateAsync(id, entity);
            if (del.Code == 200 && del.Data is true)
            {
                return Ok(del);
            }
            if (del.Code == 500 && del.Data is false)
            {
                return Ok(del);
            }
            return NotFound(del);
        
        }
    }
}
