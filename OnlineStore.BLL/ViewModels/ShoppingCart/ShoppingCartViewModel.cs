using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.BLL.ViewModels.Product;

namespace OnlineStore.BLL.ViewModels.ShoppingCart
{
   public class ShoppingCartViewModel
    {
        public string UserId { get; set; }
        public ICollection<ShoppingCartItemViewModel> Items { get; set; }

    }
}
