using OnlineStore.BLL.Services.Categories;
using OnlineStore.BLL.Services.OrderItems;
using OnlineStore.BLL.Services.Orders;
using OnlineStore.BLL.Services.Products;
using OnlineStore.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineStore.BLL.Services.FeedBacks;
using OnlineStore.BLL.ViewModels.FeedBack;

namespace OnlineStore.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;
        private readonly IOrderItemsService _orderItemsService;
        private readonly IFeedBacksService _feedBacksService;




        public FeedBackController()
        {
            var dbContext = OnlineStoreDbContext.Create();

            _categoriesService = new CategoriesService(dbContext);
            _productsService = new ProductsService(dbContext);
            _orderItemsService = new OrderItemsService(dbContext);
            _feedBacksService = new FeedBacksService(dbContext);
        }


        // GET: FeedBack
        public ActionResult Index()
        {
            var feedBacks = _feedBacksService.GetFeedBacks().ToList();
            return View(feedBacks);
        }

        [HttpGet]
        public ActionResult CreateFeedBack(int id)
        {
            
            var viewmodel = new CreateFeedBackViewModel()
            {
                UserId = User.Identity.GetUserId(),
                ProductId =id
                
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult CreateFeedBack(CreateFeedBackViewModel model)
        {

            var feedBack = _feedBacksService.Add(model);
            if (feedBack != null)
            {
                return RedirectToAction("Index", "Product");
            }
            ModelState.AddModelError("", "Error");
            return View(model);
        }
    }

}