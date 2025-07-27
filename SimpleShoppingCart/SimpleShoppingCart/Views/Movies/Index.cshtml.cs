using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingCart.Data;
using SimpleShoppingCart.Models;

namespace SimpleShoppingCart.Views.Movies
{
    public class IndexModel : PageModel
    {
        private readonly SimpleShoppingCart.Data.SimpleShoppingCartContext _context;

        public IndexModel(SimpleShoppingCart.Data.SimpleShoppingCartContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
