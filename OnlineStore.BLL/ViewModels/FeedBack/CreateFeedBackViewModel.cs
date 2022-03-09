using OnlineStore.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.ViewModels.FeedBack
{
   public class CreateFeedBackViewModel
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = " your comment should be less than 100 letters and more than 3 letters")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Rate For One Product is required")]
        [Range(0,5,ErrorMessage ="enter number in rang (0,5)")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage ="Product Id is required")]
        public int? ProductId { get; set; }

        public string UserId { get; set; }

    }
}
