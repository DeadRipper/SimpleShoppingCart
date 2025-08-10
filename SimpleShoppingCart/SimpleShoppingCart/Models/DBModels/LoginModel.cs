using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SimpleShoppingCart.Models.DBModels
{
    public class LoginModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Login is required")]
        [StringLength(50, ErrorMessage = "Login cannot be longer than 50 characters")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string Password { get; set; }
        public string? Email { get; set; }
    }
}