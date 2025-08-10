using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingCart.Models.DBModels;

namespace SimpleShoppingCart.Data
{
    public class SimpleShoppingCartContext : DbContext
    {
        public SimpleShoppingCartContext (DbContextOptions<SimpleShoppingCartContext> options)
            : base(options)
        {
        }

        public DbSet<ShopModel> ShopModel { get; set; } = default!;
        public DbSet<LoginModel> LoginModel { get; set; } = default!;
        public DbSet<BoughtedProductsModel> BoughtedProductsModel { get; set; } = default!;
        public DbSet<VendorCompaniesModel> VendorCompaniesModel { get; set; } = default!;
    }
}