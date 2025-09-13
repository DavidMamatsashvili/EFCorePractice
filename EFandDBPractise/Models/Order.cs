using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFandDBPractise.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        //Navigation property (ForeignKey relationship)
        public Product? Product { get; set; }
    }
}
