using System.ComponentModel.DataAnnotations;

namespace OnlineStore.BLL.ViewModels.ProductImage
{
   public class UpdateProductImageViewModel
    {
        [Required(ErrorMessage = "ProductImageId is Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "productImage Is Required")]
        public string ImagePath { get; set; }

        public int ProductId { get; set; }
    }
}
