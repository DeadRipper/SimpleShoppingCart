using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingCart.Models;

namespace SimpleShoppingCart.Data
{
    public class SimpleShoppingCartContext : DbContext
    {
        public SimpleShoppingCartContext (DbContextOptions<SimpleShoppingCartContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleShoppingCart.Models.ShopModel> ShopModel { get; set; } = default!;
    }
}
