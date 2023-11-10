using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Repastories.Menu;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DessertControllers : ControllerBase
    {
        private readonly IDessertService _menu;

        public DessertControllers(IDessertService menu)
        {
            _menu = menu;

        }
        [HttpPost]
        public async Task<IActionResult> AddDessertAsync([FromForm] Dessert entity)
        {
            var del = await _menu.AddDessertAsync(entity);
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
        public async Task<IActionResult> GetAllDessertData()
        {
            var get = await _menu.GetAllDessertAsync();
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
        public async Task<IActionResult> GetByDessertName(string name)
        {
            var get = await _menu.GetByDessertNameAsync(name);
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
        public async Task<IActionResult> DalateDessertAsync(string type, string name)
        {
            var del = await _menu.DalateDessertAsync(type, name);
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
        public async Task<IActionResult> UpdateDessertAsync(string type, string name, [FromForm] Dessert entity)
        {
            var del = await _menu.UpdateDessertAsync(type, name, entity);
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
        public async Task<IActionResult> PlusDessertAsync(string name, int number)
        {
            var del = await _menu.PlusDessertAsync(name, number);
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
        public async Task<IActionResult> MinusDessertAsync(string name, int number)
        {
            var del = await _menu.MinusDessertAsync(name, number);
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
