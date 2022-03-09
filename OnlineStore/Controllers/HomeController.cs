using OnlineStore.BLL.Services.Categories;
using OnlineStore.BLL.Services.Orders;
using OnlineStore.BLL.Services.Products;
using OnlineStore.DAL.Database;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;
        private readonly IOrdersService _ordersService;

        public HomeController()
        {
            var dbContext = OnlineStoreDbContext.Create();

            _categoriesService = new CategoriesService(dbContext);
            _productsService = new ProductsService(dbContext);
            _ordersService = new OrdersService(dbContext);
        }
        public ActionResult Index(string textSearch)
        {
            if (textSearch == null)
            {
                var test = _categoriesService.GetCategories();
                return View(test);
            }
            else
            {
                var test1 = _categoriesService.GetCategoriesByName(textSearch);
                return View(test1);
            }
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}