using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStore.DAL.Models.Orders;
using OnlineStore.DAL.Models.Products;

namespace OnlineStore.DAL.Models.OrderItems
{
    [Table(nameof(OrderItem))]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Quantity { get; set; }


        [ForeignKey(nameof(Order))] 
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    };
}
