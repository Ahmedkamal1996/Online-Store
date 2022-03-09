using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStore.DAL.Models.Categories;
using OnlineStore.DAL.Models.FeedBacks;
using OnlineStore.DAL.Models.OrderItems;

namespace OnlineStore.DAL.Models.Products
{
    [Table(nameof(Product))]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InventoryQuantity { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<FeedBack> FeedBacks { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual  ICollection<ProductImage> ProductImages { get; set; }
    }
}
