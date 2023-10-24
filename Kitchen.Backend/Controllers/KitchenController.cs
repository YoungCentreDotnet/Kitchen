using Kitchen.Backend.Repastories;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class KitchenController : ControllerBase
    {
        private readonly IService _service;

        public KitchenController(IService service) 
        {
            _service = service;
        
        }

        
    }
}
