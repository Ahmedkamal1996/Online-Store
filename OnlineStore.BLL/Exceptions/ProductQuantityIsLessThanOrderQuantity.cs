using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Exceptions
{
   public class ProductQuantityIsLessThanOrderQuantity:Exception
    {
        public ProductQuantityIsLessThanOrderQuantity():base("Product Quantity Less Than Order Quantity Please Check product Quantity in Inventory")
        {

        }
    }
}
