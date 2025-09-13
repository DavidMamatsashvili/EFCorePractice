using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFandDBPractise.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("product_name")]
        public string? ProductName { get; set; }
        [Column("brand_id")]
        public int BrandId { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("model_year")]
        public short ModelYear { get; set; }
        [Column("list_price")]
        public decimal Price { get; set; }

        //one-to-many
        //one product can be in many orders but every order has only one product
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
