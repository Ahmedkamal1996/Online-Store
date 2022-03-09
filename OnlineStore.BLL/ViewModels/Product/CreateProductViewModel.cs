using OnlineStore.BLL.ViewModels.ProductImage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OnlineStore.BLL.ViewModels.Category;
using OnlineStore.BLL.ViewModels.FeedBack;

namespace OnlineStore.BLL.ViewModels.Product
{
    public class CreateProductViewModel
    {

        [Required(ErrorMessage = "Product Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InventoryQuantity { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<GetCategoryViewModel> Category { get; set; }          
        public string ImagePath { get; set; }
        public HttpPostedFileBase MainImage { get; set; }
        public ICollection<CreateFeedBackViewModel> FeedBacks { get; set; }

    }
}
