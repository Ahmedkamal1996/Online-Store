using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.BLL.ViewModels.ProductImage;

namespace OnlineStore.BLL.Services.ProductImages
{
    public interface IProductImageService
    {
        ICollection<GetProductImageViewModel> GetProductImages();
        GetProductImageViewModel GetProductImageById(int productImageId);
        ICollection<GetProductImageViewModel> GetProductImageByProductId(int productId);
        GetProductImageViewModel Add(CreateProductImageViewModel model);
        bool Update(UpdateProductImageViewModel model);
        bool Delete(int productImageId);
    }
}
