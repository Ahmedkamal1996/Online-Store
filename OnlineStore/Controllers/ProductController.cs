using OnlineStore.BLL.Services.Categories;
using OnlineStore.BLL.Services.FeedBacks;
using OnlineStore.BLL.Services.Orders;
using OnlineStore.BLL.Services.Products;
using OnlineStore.BLL.ViewModels.Product;
using OnlineStore.DAL.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore.BLL.Exceptions;
using OnlineStore.BLL.Helpers;
using OnlineStore.BLL.Services.ProductImages;
using OnlineStore.BLL.ViewModels.ProductImage;
using OnlineStore.DAL.Models.Categories;
using OnlineStore.DAL.Models.Products;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ProductController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductImageService _productImageService;

        private readonly IProductsService _productsService;
        private readonly IOrdersService _ordersService;
        private readonly IFeedBacksService _feedBackService;

        public ProductController()
        {
           
            var dbContext = OnlineStoreDbContext.Create();
            _productImageService = new ProductImageService(dbContext);
            _categoriesService = new CategoriesService(dbContext);
            _productsService = new ProductsService(dbContext);
            _ordersService = new OrdersService(dbContext);
            _feedBackService = new FeedBacksService(dbContext);
        }


        // GET: Product
        [AllowAnonymous]
        public ActionResult Index(string textSearch)
        {
            if (textSearch == null)
            {
                var products = _productsService.GetProducts().ToList();
                return View(products);
            }
            else
            {
                var products = _productsService.GetProductsByName(textSearch).ToList();
                return View(products);
            }
            
            
        }
        [AllowAnonymous]
        public ActionResult ProductDetails(int id)
        {
            var product = _productsService.GetProductById(id);
            
            return View(product);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var category = _categoriesService.GetCategories().ToList();
            var viewmodel = new CreateProductViewModel()
            {
                Category = category
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddProduct(CreateProductViewModel newProduct)
        {
            if (ModelState.IsValid)
            {

                //string imageName =newProduct.MainImage.FileName;
                //var imagePath = Path.Combine("~/Content/images/" , imageName);
                //var  physicalPath=Server.MapPath(imagePath);
                //newProduct.MainImage.SaveAs(physicalPath);
                //var imagePath = "~/Content/images/" + imageName;
                //newProduct.ProductImages.ImagePath = imagePath;
                //newProduct.ProductImages.ProductId = newProduct.Id;
                //_productImageService.Add(new CreateProductImageViewModel()
                //{
                //    ImagePath = imagePath
                    
                //});
                //newProduct.ImagePath = imagePath;
           var result = _productsService.Add(newProduct);
           if (result !=null)
           {
               return RedirectToAction("Index", "Home");
           }

           ModelState.AddModelError("","Error");
            }
            return View(newProduct);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var product = _productsService.GetProductById(id);
            var category = _categoriesService.GetCategories().Where(x=>x.CategoryId!=null).ToList();
            var viewmodel = new UpdateProductViewModel()
            {
                

                Price = product.Price,
                InventoryQuantity = product.InventoryQuantity,
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Categories = category
                
                

            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditProduct(UpdateProductViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _productsService.Update(model);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    if (ex is ProductNameAlreadyExisted)
                    {
                        ModelState.AddModelError(nameof(Product.Name), ex.Message);
                    }
                }
            }
            return View(model);
        }

        public ActionResult DeleteProduct(int id)
        {
            if (id == default)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = _productsService.Delete(id);

            return RedirectToAction("Index", "Home", result);
        }




        [HttpGet]
        public ActionResult ProductImages(int productId)
        {
            var images = _productImageService.GetProductImageByProductId(productId);
            return PartialView(images);
        }





        [HttpGet]
        public ActionResult AddImage(int productId)
        {
            var model = new CreateProductImageViewModel()
            {
                ProductId = productId
            };
            ViewBag.ProductId = productId;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddImage(CreateProductImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _productImageService.Add(model);
                if (result!=null)
                {
                    var images = _productImageService.GetProductImageByProductId(model.ProductId);
                    return PartialView("ProductImages",images);
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public ActionResult DeleteImage(int productId,int imageId)
        {
            if (productId==default||imageId==default)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = _productImageService.Delete(imageId);
            if (result)
            {
                var images = _productImageService.GetProductImageByProductId(productId);
            return PartialView("ProductImages", images);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

        }

    }
}