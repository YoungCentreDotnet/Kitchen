using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Repastories.Menu;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FastFoodControllers : ControllerBase
    {
        private readonly IFastFoodService _menu;

        public FastFoodControllers(IFastFoodService menu)
        {
            _menu = menu;

        }
        [HttpPost]
        public async Task<IActionResult> AddFastFoodAsync([FromForm] FastFood entity)
        {
            var del = await _menu.AddFastFoodAsync(entity);
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
        public async Task<IActionResult> GetAllFastFoodData()
        {
            var get = await _menu.GetAllFastFoodAsync();
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
        public async Task<IActionResult> GetByFastFoodName(string name)
        {
            var get = await _menu.GetByFastFoodNameAsync(name);
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
        public async Task<IActionResult> DalateFastFoodAsync(string type, string name)
        {
            var del = await _menu.DalateFastFoodAsync(type, name);
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
        public async Task<IActionResult> UpdateFastFoodAsync(string type, string name, [FromForm] FastFood entity)
        {
            var del = await _menu.UpdateFastFoodAsync(type, name, entity);
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
