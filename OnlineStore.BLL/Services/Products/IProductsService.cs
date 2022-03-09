using OnlineStore.BLL.ViewModels.Product;
using System.Collections.Generic;
using OnlineStore.BLL.ViewModels.Category;

namespace OnlineStore.BLL.Services.Products
{
    public interface IProductsService
    {
        ICollection<GetProductViewModel> GetProducts();

        ICollection<GetProductViewModel> GetProductsByName(string textSearch);
        GetProductViewModel GetProductById(int productId);
        ICollection<GetProductViewModel> GetProductByCategoryId(int categoryId);
        GetProductViewModel Add(CreateProductViewModel model);

     
        bool Update(UpdateProductViewModel model);
        bool Delete(int productId);

        //ICollection<Product> GetProducts();
        //Product GetProductById(int productId);
        //ICollection<Product> GetProductByCategoryId(int categoryId);
        //void AddProduct(Product product);
        //void UpdateProduct(Product product);
        //void DeleteProduct(int productId);
    }
}
