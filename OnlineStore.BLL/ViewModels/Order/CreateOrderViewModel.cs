using OnlineStore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.ViewModels.Order
{
   public class CreateOrderViewModel
    {
      
        public decimal TotalPrice { get; set; }
     
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string UserId { get; set; }
    }
}
