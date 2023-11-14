using Kitchen.Backend.Model;
using Kitchen.Backend.Model.Post;
using Kitchen.Backend.Repastories.Account;
using Kitchen.Backend.Repastories.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Kitchen.Backend.Controllers
{
   
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _account;

        public PostController(IPostService account)
        {
            _account = account;

        }
        [HttpDelete]
        public async Task<IActionResult> DalatePostAsync(int id, string postfoto)
        {
            var del = await _account.DalatePostAsync(id, postfoto);
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
        public async Task<IActionResult> AddPostAsync([FromForm] Post entity)
        {
            var del = await _account.AddPostAsync(entity);
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

    }
    
}
