using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.ViewModels.OrderItem
{
    public class UpdateOrderItemViewModel
    {
        [Required(ErrorMessage = "Id Is Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Quantity Is Required")]
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }

   
}
