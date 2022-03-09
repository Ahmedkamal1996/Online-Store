using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.ViewModels.OrderItem
{
   public class CreateOrderItemViewModel
   {
       [Required(ErrorMessage = "Quantity Is Required")]
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
