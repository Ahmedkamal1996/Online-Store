using OnlineStore.BLL.ViewModels.Product;
using OnlineStore.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.ViewModels.FeedBack
{
    public class GetFeedBackViewModel
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength = 3,ErrorMessage = " your comment should be less than 100 letters")]
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int ProductId { get; set; }
        public GetProductViewModel Product { get; set; }
    }
}
