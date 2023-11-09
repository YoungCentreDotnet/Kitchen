using Kitchen.Backend.Model;
using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Repastories.Menu;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;


namespace Kitchen.Backend.Controllers
{
 

        [ApiController]
        [Route("api/[controller]/[action]")]
        public class MenuControllers :ControllerBase
        {
            private readonly IMenuService _menu;

            public MenuControllers(IMenuService menu)
            {
                _menu = menu;

            }
            [HttpPost]
            public async Task<IActionResult> AddFoodAsync([FromForm] Beverages entity)
            {
                var del = await _menu.AddFoodAsync(entity);
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
            public async Task<IActionResult> GetAllMenuData()
            {
                var get = await _menu.GetAllAsync();
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
            public async Task<IActionResult> GetByName(string name)
            {
                var get = await _menu.GetByNameAsync(name);
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
            public async Task<IActionResult> DalateFoodAsync(string type, string name)
            {
                var del = await _menu.DalateFoodAsync(type, name);
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
            public async Task<IActionResult> UpdateFoodAsync(string type, string name, [FromForm] Beverages entity)
            {
                var del = await _menu.UpdateAsync(type, name, entity);
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
            public async Task<IActionResult> PlusFoodAsync(string name, int number)
            {
                var del = await _menu.PlusFoodAsync(name, number);
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
            public async Task<IActionResult> MinusFoodAsync(string name, int number)
            {
                var del = await _menu.MinusFoodAsync(name, number);
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
