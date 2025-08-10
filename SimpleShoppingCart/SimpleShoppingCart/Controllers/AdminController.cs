using Microsoft.AspNetCore.Mvc;

namespace SimpleShoppingCart.Controllers
{
    public class AdminController(ILogger<AdminController> logger) : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("AdminMain", "ShopCart");
        }
    }
}