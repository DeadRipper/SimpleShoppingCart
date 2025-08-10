using SimpleShoppingCart.Models;
using SimpleShoppingCart.Models.DBModels;
using System.Net;

namespace SimpleShoppingCart.Helpers.InterfacesHelpers
{
    public interface IDBWorker
    {
        Task<DBResultType> SaveDataInDB(RegistrationUserModel registrationUserModel);
        Task<bool> CheckUserContainsInDB(string login, string password);
        Task<bool> CheckAdminAuth(string login, string password);
        Task<List<LoginModel>> UsersInDb();
        Task<List<BoughtedProductsModel>> BoughtedProductsInDb();
        Task<List<ShopItems>> ListOfAvailableProducts();
    }
}