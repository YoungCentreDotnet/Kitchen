using Kitchen.Backend.Model.Stock;
using Kitchen.Backend.Repastories.Stock;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PieceProductController : ControllerBase
    {
        private readonly IPieceProductServices _menu;

        public PieceProductController(IPieceProductServices menu)
        {
            _menu = menu;

        }
        [HttpPost]
        public async Task<IActionResult> AddPieceProductAsync([FromForm] PieceProduct entity)
        {
            var del = await _menu.AddPieceProductAsync(entity);
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
        public async Task<IActionResult> GetAllPieceProductData()
        {
            var get = await _menu.GetAllPieceProductAsync();
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
        public async Task<IActionResult> GetByPieceProductName(string name)
        {
            var get = await _menu.GetByPieceProductNameAsync(name);
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
        public async Task<IActionResult> DalatePieceProductAsync(int id, string name)
        {
            var del = await _menu.DalatePieceProductAsync(id, name);
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
        public async Task<IActionResult> UpdatePieceProductAsync(string name, [FromForm] PieceProduct entity)
        {
            var del = await _menu.UpdatePieceProductAsync(name, entity);
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
        public async Task<IActionResult> PlusPieceProductAsync(string name, int number)
        {
            var del = await _menu.PlusPieceProductAsync(name, number);
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
        public async Task<IActionResult> MinusPieceProductAsync(string name, int number)
        {
            var del = await _menu.MinusPieceProductAsync(name, number);
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
