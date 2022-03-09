using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.BLL.ViewModels.Order;
using OnlineStore.BLL.ViewModels.Product;

namespace OnlineStore.BLL.ViewModels.OrderItem
{
   public class GetOrderItemViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public virtual GetOrderViewModel Order { get; set; }
        public int ProductId { get; set; }
        public virtual GetProductViewModel Product { get; set; }
    }
}
