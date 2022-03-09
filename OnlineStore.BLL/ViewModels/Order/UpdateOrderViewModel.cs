using OnlineStore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.DAL.Models.OrderItems;

namespace OnlineStore.BLL.ViewModels.Order
{
   public class UpdateOrderViewModel
    {
        [Required(ErrorMessage ="Order Id Is required")]
        public int Id { get; set; }
        
      
        public decimal TotalPrice { get; set; }
       
        public OrderStatus Status { get; set; }

        public string UserId { get; set; }
    }
}
