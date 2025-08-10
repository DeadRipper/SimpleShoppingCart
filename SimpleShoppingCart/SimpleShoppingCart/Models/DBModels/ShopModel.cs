using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShoppingCart.Models.DBModels
{
    public class ShopModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }        
        public int FirmBadge { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductSubTitle { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductWeight { get; set; }
    }
}