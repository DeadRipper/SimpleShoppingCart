using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShoppingCart.Models
{
    public class ShopItems
    {
        public int Id { get; set; }
        public string FirmBadge { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductSubTitle { get; set; }        
        public decimal Price { get; set; }
        public decimal ProductWeight { get; set; }
    }
}