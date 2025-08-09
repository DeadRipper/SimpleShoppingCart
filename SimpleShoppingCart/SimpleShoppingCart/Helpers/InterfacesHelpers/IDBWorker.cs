using SimpleShoppingCart.Models;
using SimpleShoppingCart.Models.DBModels;

namespace SimpleShoppingCart.Helpers.InterfacesHelpers
{
    public interface IDBWorker
    {
        Task<DBResultType> SaveDataInDB(RegistrationUserModel registrationUserModel);
        Task<bool> CheckUserContainsInDB(string login, string password);
    }
}