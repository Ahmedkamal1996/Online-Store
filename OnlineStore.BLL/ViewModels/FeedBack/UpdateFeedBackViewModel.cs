using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.ViewModels.FeedBack
{
    public class UpdateFeedBackViewModel
    {
        [Required(ErrorMessage = "FeedBack Id is required")]
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = " your comment should be less than 100 letters")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Rate For Product is required")]
        [Range(0, 5, ErrorMessage = "enter number in rang (0,5)")]
        public decimal Rate { get; set; }
        public string UserId { get; set; }
        
        public int? ProductId { get; set; }
    }
}
