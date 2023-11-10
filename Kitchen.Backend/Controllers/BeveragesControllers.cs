using Kitchen.Backend.Model;
using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Repastories.Menu;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;


namespace Kitchen.Backend.Controllers
{
 

        [ApiController]
        [Route("api/[controller]/[action]")]
        public class BeveragesControllers :ControllerBase
        {
            private readonly IBeveragesService _menu;

            public BeveragesControllers(IBeveragesService menu)
            {
                _menu = menu;

            }
            [HttpPost]
            public async Task<IActionResult> AddBeveragesAsync([FromForm] Beverages entity)
            {
                var del = await _menu.AddBeveragesAsync(entity);
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
            public async Task<IActionResult> GetAllBeveragesData()
            {
                var get = await _menu.GetAllBeveragesAsync();
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
            public async Task<IActionResult> GetByBeveragesName(string name)
            {
                var get = await _menu.GetByBeveragesNameAsync(name);
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
            public async Task<IActionResult> DalateBeveragesAsync(string type, string name)
            {
                var del = await _menu.DalateBeveragesAsync(type, name);
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
            [HttpPatch]
            public async Task<IActionResult> UpdateBeveragesAsync(string type, string name, [FromForm] Beverages entity)
            {
                var del = await _menu.UpdateBeveragesAsync(type, name, entity);
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
            [HttpPatch]
            public async Task<IActionResult> PlusBeveragesAsync(string name, int number)
            {
                var del = await _menu.PlusBeveragesAsync(name, number);
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
            [HttpPatch]
            public async Task<IActionResult> MinusBeveragesAsync(string name, int number)
            {
                var del = await _menu.MinusBeveragesAsync(name, number);
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

    
}
