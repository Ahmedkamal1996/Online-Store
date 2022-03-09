using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.BLL.ViewModels.Product;

namespace OnlineStore.BLL.ViewModels.ShoppingCart
{
   public class ShoppingCartItemViewModel
    {
        public GetProductViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
