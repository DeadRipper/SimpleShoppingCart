using SimpleShoppingCart.Helpers.InterfacesHelpers;
using SimpleShoppingCart.Models;
using SimpleShoppingCart.Models.DBModels;

namespace SimpleShoppingCart.Helpers
{
    public class Validate : IValidate
    {
        private readonly ILogger<Validate> _logger;
        public Validate(ILogger<Validate> log)
        {
            _logger = log;
        }

        public async Task<bool> IsContainsItem(RegistrationUserModel loginModel)
        {
            if (string.IsNullOrWhiteSpace(loginModel.Login))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(loginModel.Password))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(loginModel.ConfirmPassword))
            {
                return false;
            }

            return true;
        }
    }
}