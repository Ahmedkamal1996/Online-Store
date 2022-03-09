using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineStore.BLL.Services.Categories;
using OnlineStore.BLL.Services.FeedBacks;
using OnlineStore.BLL.Services.Orders;
using OnlineStore.BLL.Services.ProductImages;
using OnlineStore.BLL.Services.Products;
using OnlineStore.BLL.ViewModels.ShoppingCart;
using OnlineStore.DAL.Database;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductImageService _productImageService;
        private readonly IOrdersService _ordersService;
        private readonly IProductsService _productsService;
        private OnlineStoreDbContext _context;
        public ShoppingCartController()
        {
            var dbContext = OnlineStoreDbContext.Create();
            _productImageService = new ProductImageService(dbContext);
            _categoriesService = new CategoriesService(dbContext);
            _productsService = new ProductsService(dbContext);
            _ordersService = new OrdersService(dbContext);
            _context = new OnlineStoreDbContext();
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Buy(int productId)
        {
            var userId = User.Identity.GetUserId();
            var item = _productsService.GetProductById(productId);

            if (Session["cart"] == null)
            {

                var cart = new ShoppingCartViewModel()
                {
                    Items = new List<ShoppingCartItemViewModel>()
                    {
                        new ShoppingCartItemViewModel() {Product = item, Quantity = 1}
                    },
                    UserId = userId
                };
                Session["cart"] = cart;
            }
            else
            {
                var cart = (ShoppingCartViewModel)Session["cart"];
                int index = IsExist(productId);
                if (index != -1)
                {
                    cart.Items.ToList()[index].Quantity++;
                }
                else
                {
                    cart.Items.Add(new ShoppingCartItemViewModel() { Product = item, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int productId)
        {
            ShoppingCartViewModel cart = (ShoppingCartViewModel)Session["cart"];
            int index = IsExist(productId);
            cart.Items.ToList().RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        
        public ActionResult AddOrder()
        {
            ShoppingCartViewModel cart = (ShoppingCartViewModel)Session["cart"];
            _ordersService.Add(cart);

            Session["cart"] = null;
            return RedirectToAction("Index");
        }
        private int IsExist(int productId)
        {
            var cart = (ShoppingCartViewModel)Session["cart"];
            for (int i = 0; i < cart.Items.Count; i++)
                if (cart.Items.ToList()[i].Product.Id.Equals(productId))
                        return i;
            return -1;
        }

    }
}