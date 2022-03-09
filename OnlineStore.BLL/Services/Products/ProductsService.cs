using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using AutoMapper;
using OnlineStore.BLL.ViewModels.Category;
using OnlineStore.BLL.ViewModels.Product;
using OnlineStore.DAL.Database;
using OnlineStore.DAL.Models.Products;

namespace OnlineStore.BLL.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly OnlineStoreDbContext _context;

        public ProductsService(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public GetProductViewModel Add(CreateProductViewModel model)
        {
            var product = Mapper.Map<Product>(model);

            if (model.MainImage!=null)
            {
                string imageName = model.MainImage.FileName;
                model.ImagePath = Path.Combine("~/Content/images/", imageName);
                var physicalPath = HttpContext.Current.Server.MapPath(model.ImagePath);
                model.MainImage.SaveAs(physicalPath);
                product.ProductImages = new List<ProductImage>
                {
                    new ProductImage
                    {
                        ImagePath = model.ImagePath
                    }
                };
            }
          

            _context.Products.Add(product);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetProductViewModel>(product) : null;
        }


        public bool Delete(int productId)
        {
            var product = _context.Products.Find(productId);

            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);

            return _context.SaveChanges() > 0;
        }

        public ICollection<GetProductViewModel> GetProductByCategoryId(int categoryId)
        {
           var products = _context.Products.Where(z => z.CategoryId == categoryId).ToList();

            return products == null ? null : Mapper.Map<ICollection<GetProductViewModel>>(products);
 
        }

        public GetProductViewModel GetProductById(int productId)
        {
            Product product =_context.Products.Include(x=>x.ProductImages).SingleOrDefault(p=>p.Id==productId);
           
            return product == null ? null : Mapper.Map<GetProductViewModel>(product);
        }

        public ICollection<GetProductViewModel> GetProducts()
        {
            var products = _context.Products.Include(x=>x.ProductImages).ToList();

            return Mapper.Map< ICollection<GetProductViewModel> >(products);
        }

        public bool Update(UpdateProductViewModel model)
        {
            var oldValue = _context.Products.Find(model.Id);
            
            if (oldValue == null)
            {
                return false;
            }

            Mapper.Map(model, oldValue);

            _context.Entry(oldValue).State = EntityState.Modified;

           
            return _context.SaveChanges()>0 ;
        }


        public ICollection<GetProductViewModel> GetProductsByName(string textSearch)
        {
            if (string.IsNullOrWhiteSpace(textSearch))
            {
                return null;
            }

            var searchTerm = textSearch.Trim().ToLower();

            var products = _context.Products.Where(x => x.Name.Trim().ToLower().Contains(searchTerm)).ToList();

            return Mapper.Map<ICollection<GetProductViewModel>>(products);

        }

        //public void AddProduct(Product product)
        //{
        //   _context.Product.Add(product);
        //    _context.SaveChanges();

        //}

        //public void DeleteProduct(int productId)
        //{
        //    Product product = _context.Product.Find(productId);
        //    _context.Product.Remove(product);
        //    _context.SaveChanges();

        //}

        //public ICollection<Product> GetProductByCategoryId(int categoryId)
        //{
        //    var products = _context.Product.Where(c => c.categoryId == categoryId).ToList();
        //    return products;

        //}

        //public Product GetProductById(int productId)
        //{
        //  Product product=  _context.Product.Find(productId);
        //    return product;
        //}

        //public ICollection<Product> GetProducts()
        //{
        //    var product = _context.Product.ToList();
        //    return product;

        //}

        //public void UpdateProduct(Product product)
        //{
        //    Product oldproduct = _context.Product.Find(product.Id);
        //    _context.Entry(oldproduct).CurrentValues.SetValues(product);
        //    _context.SaveChanges();
        //}
    }
}
