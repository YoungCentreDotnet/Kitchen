using Kitchen.Backend.Model.Stock;
using Kitchen.Backend.Repastories.Stock;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    
        [ApiController]
        [Route("api/[controller]/[action]")]
        public class KgProductController : ControllerBase
        {
            private readonly IKgProductService _menu;

            public KgProductController(IKgProductService menu)
            {
                _menu = menu;

            }
            [HttpPost]
            public async Task<IActionResult> AddKgProductAsync([FromForm]KgProduct entity)
            {
                var del = await _menu.AddKgProductAsync(entity);
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
            public async Task<IActionResult> GetAlKgProductData()
            {
                var get = await _menu.GetAllKgProductAsync();
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
            public async Task<IActionResult> GetByKgProductName(string name)
            {
                var get = await _menu.GetByKgProductNameAsync(name);
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
            public async Task<IActionResult> DalateKgProductAsync(int id, string name)
            {
                var del = await _menu.DalateKgProductAsync(id, name);
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
            public async Task<IActionResult> UpdateKgProductAsync(string name, [FromForm] KgProduct entity)
            {
                var del = await _menu.UpdateKgProductAsync(name, entity);
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
            public async Task<IActionResult> PlusKgProductAsync(string name, int number)
            {
                var del = await _menu.PlusKgProductAsync(name, number);
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
            public async Task<IActionResult> MinusKgProductAsync(string name, int number)
            {
                var del = await _menu.MinusKgProductAsync(name, number);
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
