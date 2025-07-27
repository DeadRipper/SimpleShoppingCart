using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingCart.Data;
using SimpleShoppingCart.Models;

namespace SimpleShoppingCart.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly SimpleShoppingCartContext _context;

        public ShopCartController(SimpleShoppingCartContext context)
        {
            _context = context;
        }

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
            return View();
        }

        // GET: ShopCart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopModel == null)
            {
                return NotFound();
            }

            return View(shopModel);
        }

        // GET: ShopCart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopCart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] ShopModel shopModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopModel);
        }

        // GET: ShopCart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModel.FindAsync(id);
            if (shopModel == null)
            {
                return NotFound();
            }
            return View(shopModel);
        }

        // POST: ShopCart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] ShopModel shopModel)
        {
            if (id != shopModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopModelExists(shopModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shopModel);
        }

        // GET: ShopCart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopModel = await _context.ShopModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopModel == null)
            {
                return NotFound();
            }

            return View(shopModel);
        }

        // POST: ShopCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopModel = await _context.ShopModel.FindAsync(id);
            if (shopModel != null)
            {
                _context.ShopModel.Remove(shopModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopModelExists(int id)
        {
            return _context.ShopModel.Any(e => e.Id == id);
        }
    }
}
