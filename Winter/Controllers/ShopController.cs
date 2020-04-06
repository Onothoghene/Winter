using Microsoft.AspNetCore.Mvc;

namespace Winter.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }
    }
}