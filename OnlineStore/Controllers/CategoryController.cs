using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineStore.BLL.Exceptions;
using OnlineStore.BLL.Helpers;
using OnlineStore.BLL.Services.Categories;
using OnlineStore.BLL.Services.Orders;
using OnlineStore.BLL.Services.Products;
using OnlineStore.BLL.ViewModels.Category;
using OnlineStore.DAL.Database;
using OnlineStore.DAL.Models.Categories;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class CategoryController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;
        private readonly IOrdersService _ordersService;

        public CategoryController()
        {
            var dbContext = OnlineStoreDbContext.Create();

            _categoriesService = new CategoriesService(dbContext);
            _productsService = new ProductsService(dbContext);
            _ordersService = new OrdersService(dbContext);
        }

        [AllowAnonymous]
        // GET: Category
        public ActionResult Index(int id)
        {
            //var isInRole = User.IsInRole(Roles.User);
            //var userId = User.Identity.GetUserId();
            //var userEmail = User.Identity.GetUserName();
            var category = _categoriesService.GetCategoryById(id);

            return View(category);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var category = _categoriesService.GetCategoryById(id);
            return View(category);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            var mainCategory = _categoriesService.GetCategories().ToList();
            var viewmodel = new CreateCategoryViewModel()
            {
               MainCategory = mainCategory
            };
            return View("AddCategory",viewmodel);
        }

        [HttpPost]
        public ActionResult AddCategory(CreateCategoryViewModel formCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var x = _categoriesService.Add(formCategory);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    if (ex is CategoryNameAlreadyExistException)
                    {
                        ModelState.AddModelError(nameof(Category.Name), ex.Message);
                    }
                }
            }

            return View(formCategory);
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = _categoriesService.GetCategoryById(id);
            var mainCategory = _categoriesService.GetMCategoriesForUpdateModel(id);
            var viewmodel = new UpdateCategoryViewModel()
            {
                MainCategory = mainCategory,
                Id = category.Id,
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
                
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditCategory(UpdateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoriesService.Update(model);
                return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    if (ex is CategoryNameAlreadyExistException )
                    {
                        ModelState.AddModelError(nameof(Category.Name),ex.Message);
                    }
                }
            }

            return View(model);
        }

        public ActionResult DeleteCategory(int id)
        {
            if (id == default)
            {
                return RedirectToAction("Index","Home");
            }

            var result = _categoriesService.Delete(id);

            return RedirectToAction("Index","Home",result);
        }
    }
}