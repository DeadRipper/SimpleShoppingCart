using SimpleShoppingCart.Models;
using SimpleShoppingCart.Models.DBModels;

namespace SimpleShoppingCart.Helpers.InterfacesHelpers
{
    public interface IValidate
    {
        Task<bool> IsContainsItem(RegistrationUserModel loginModel);
    }
}