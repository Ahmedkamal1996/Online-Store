using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStore.DAL.Models.Products;
using OnlineStore.DAL.Models.User;

namespace OnlineStore.DAL.Models.FeedBacks
{
    [Table(nameof(FeedBack))]
    public class FeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }
        public double Rate { get; set; }

        [Required] 
        [ForeignKey(nameof(User))] 
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Product))] 
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    };
}
