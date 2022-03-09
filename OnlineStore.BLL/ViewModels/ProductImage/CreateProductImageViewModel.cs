using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OnlineStore.BLL.ViewModels.Product;

namespace OnlineStore.BLL.ViewModels.ProductImage
{
   public class CreateProductImageViewModel
    {

        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Image Is Required")]
        public HttpPostedFileBase MainImage { get; set; }
        public int ProductId { get; set; }
    }
}
