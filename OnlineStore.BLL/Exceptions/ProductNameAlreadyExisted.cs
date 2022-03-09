using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Exceptions
{
    public class ProductNameAlreadyExisted : Exception
    {
        public ProductNameAlreadyExisted() : base("Product is already exist")
        {

        }
    }
}
