using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using OnlineStore.BLL.ViewModels.ProductImage;
using OnlineStore.DAL.Database;
using OnlineStore.DAL.Models.Products;

namespace OnlineStore.BLL.Services.ProductImages
{
   public class ProductImageService:IProductImageService
    {
        private readonly OnlineStoreDbContext _context;

        public ProductImageService(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public ICollection<GetProductImageViewModel> GetProductImages()
        {
            var productImages = _context.ProductImages.ToList();
            return Mapper.Map<ICollection<GetProductImageViewModel>>(productImages);
        }

        public GetProductImageViewModel GetProductImageById(int productImageId)
        {
            var productImage = _context.ProductImages.Find(productImageId);

            return productImage==null ? null : Mapper.Map<GetProductImageViewModel>(productImage);
        }

        public ICollection<GetProductImageViewModel> GetProductImageByProductId(int productId)
        {
            var productImage = _context.ProductImages.Where(p => p.ProductId == productId).ToList();

            return  Mapper.Map<ICollection<GetProductImageViewModel>>(productImage);
        }

        public GetProductImageViewModel Add(CreateProductImageViewModel model)
        {
            var productImage = Mapper.Map<ProductImage>(model);
            if (model.MainImage == null)
            {

                return null;
            }

            string imageName = model.MainImage.FileName;

            model.ImagePath = Path.Combine("~/Content/images/", imageName);

            var physicalPath = HttpContext.Current.Server.MapPath(model.ImagePath);

            model.MainImage.SaveAs(physicalPath);

            productImage.ImagePath = model.ImagePath;

            _context.ProductImages.Add(productImage);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetProductImageViewModel>(productImage) : null;
        }

        public bool Update(UpdateProductImageViewModel model)
        {
            var oldProductImage = _context.ProductImages.Find(model.Id);
            if (oldProductImage==null)
            {
                return false;
            }

            Mapper.Map(model, oldProductImage);
            _context.Entry(oldProductImage).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int productImageId)
        {
            var productImage = _context.ProductImages.Find(productImageId);
            if (productImage==null)
            {
                return false;
            }

            _context.ProductImages.Remove(productImage);

            return _context.SaveChanges() > 0;
        }
    }
}
