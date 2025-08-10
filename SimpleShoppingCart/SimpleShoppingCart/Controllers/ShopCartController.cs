using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingCart.Data;
using SimpleShoppingCart.Helpers.InterfacesHelpers;
using SimpleShoppingCart.Models.DBModels;

namespace SimpleShoppingCart.Controllers
{
    public class ShopCartController(SimpleShoppingCartContext _context, IDBWorker _dBWorker) : Controller
    {
        // GET: ShopCart
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopModel.ToListAsync());
        }

        public async Task<IActionResult> Suppliers()
        {
            return View("UIElements/Suppliers");
        }

        public async Task<IActionResult> About()
        {
            return View("UIElements/About");
        }

        public async Task<IActionResult> Contact()
        {
            return View("UIElements/Contact");
        }

        public async Task<IActionResult> Main()
        {
            ViewBag.Products = _dBWorker.ListOfAvailableProducts().GetAwaiter().GetResult();
            return View("UIElements/Main");
        }

        public async Task<IActionResult> AdminMain()
        {
            ViewBag.Users = _dBWorker.UsersInDb().Result;
            ViewBag.BoughtedProducts = _dBWorker.BoughtedProductsInDb().Result;
            return View("AdminUi/AdminMain");
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }
    }
}
