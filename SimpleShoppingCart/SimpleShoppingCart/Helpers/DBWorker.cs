using Microsoft.EntityFrameworkCore;
using SimpleShoppingCart.Controllers;
using SimpleShoppingCart.Data;
using SimpleShoppingCart.Helpers.InterfacesHelpers;
using SimpleShoppingCart.Models;
using SimpleShoppingCart.Models.DBModels;

namespace SimpleShoppingCart.Helpers
{
    public class DBWorker(SimpleShoppingCartContext _context, ILogger<DBWorker> _logger) : IDBWorker
    {
        public async Task<DBResultType> SaveDataInDB(RegistrationUserModel registrationUserModel)
        {
            _context.LoginModel.AddAsync(new LoginModel()
            {
                Login = registrationUserModel.Login,
                Password = registrationUserModel.Password,
                Email = registrationUserModel.Email
            });
            _context.SaveChangesAsync();

            return 0;
        }

        public async Task<bool> CheckUserContainsInDB(string login, string password)
        {
            if (_context.LoginModel.Where(x => x.Login == login)?.FirstOrDefault() != null || _context.LoginModel.Where(x => x.Password == password)?.FirstOrDefault() != null)
            {
                _logger.LogWarning("user registered");
                return true;
            }

            return false;
        }

        public async Task<bool> CheckAdminAuth(string login, string password)
        {
            var adminAuth = _context.LoginModel.Where(x => x.Login == "admin").FirstOrDefault();

            if (adminAuth.Password == password)
            {
                _logger.LogWarning("admin detected");
                return true;
            }

            return false;
        }

        public async Task<List<LoginModel>> UsersInDb()
        {
            return _context.LoginModel.ToList();
        }

        public async Task<List<BoughtedProductsModel>> BoughtedProductsInDb()
        {
            return _context.BoughtedProductsModel.ToList();
        }

        public async Task<List<ShopItems>> ListOfAvailableProducts()
        {
            var shopItems = await _context.ShopModel.ToListAsync(); // materialize first
            var products = new List<ShopItems>();

            foreach (var item in shopItems)
            {
                var firmBadge = await _context.VendorCompaniesModel
                    .Where(xx => xx.Id == item.Id)
                    .Select(xxx => xxx.CompanyName)
                    .FirstOrDefaultAsync();
                products.Add(new ShopItems()
                {
                    Id = item.Id,
                    FirmBadge = firmBadge,
                    Price = item.Price,
                    ProductSubTitle = item.ProductSubTitle,
                    ProductTitle = item.ProductTitle,
                    ProductWeight = item.ProductWeight
                });
            }
            return products;
        }
    }
}