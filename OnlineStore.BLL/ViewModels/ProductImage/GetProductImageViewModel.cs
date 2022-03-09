using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.BLL.ViewModels.Product;

namespace OnlineStore.BLL.ViewModels.ProductImage
{
    public class GetProductImageViewModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public int ProductId { get; set; }
        public GetProductViewModel Product { get; set; }
    }
}
