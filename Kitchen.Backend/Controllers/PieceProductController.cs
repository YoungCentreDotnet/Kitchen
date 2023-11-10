using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Backend.Controllers
{
    public class PieceProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
