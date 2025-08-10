using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SimpleShoppingCart.Models
{
    public class RegistrationUserModel
    {
        [Required(ErrorMessage = "Login is required")]
        [StringLength(50, ErrorMessage = "Login cannot be longer than 50 characters")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]        
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string ConfirmPassword { get; set; }
        public string? Email { get; set; }
    }
}