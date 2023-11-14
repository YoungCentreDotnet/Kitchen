using Kitchen.Backend.Model;
using Kitchen.Backend.Repastories.Account;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    
        [ApiController]
        [Route("api/[controller]/[action]")]
        public class TableController : ControllerBase
        {
            private readonly ITableAccountService _account;

            public TableController(ITableAccountService account)
            {
                _account = account;

            }
            [HttpGet]
            public async Task<IActionResult> GetAllTableData()
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
            [HttpDelete]
            public async Task<IActionResult> DalateTableAsync(string login, string password)
            {
                var del = await _account.DalateAsync(login, password);
                {
                    if (del.Code == 202 && del.Data is true)
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
            [HttpPost]
            public async Task<IActionResult> AddTableAsync([FromForm] Tables entity)
            {
                var del = await _account.AddAsync(entity);
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
            
            [HttpPatch]
            public async Task<IActionResult> UpdateTableAsync(int id, [FromForm] Tables entity)
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
