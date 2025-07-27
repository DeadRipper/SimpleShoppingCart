using System.ComponentModel.DataAnnotations;

namespace SimpleShoppingCart.Models
{
    public class ShopModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}