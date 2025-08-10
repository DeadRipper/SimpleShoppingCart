using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShoppingCart.Models.DBModels
{
    public class BoughtedProductsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18, 8)")]
        public decimal ProductPrice { get; set; }
        public string SendAdress { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateDelivered { get; set; }
    }
}