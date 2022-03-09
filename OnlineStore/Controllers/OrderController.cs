using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineStore.BLL.Exceptions;
using OnlineStore.BLL.Helpers;
using OnlineStore.BLL.Services.Orders;
using OnlineStore.DAL.Database;
using OnlineStore.DAL.Enums;
using OnlineStore.DAL.Models.Products;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrdersService _ordersService;

        public OrderController()
        {
            var dbContext = OnlineStoreDbContext.Create();
            _ordersService = new OrdersService(dbContext);
        }

        // GET: Order
        [Authorize(Roles = nameof(Roles.Admin))]
        public ActionResult Index()
        {
            var orders = _ordersService.GetOrders().ToList();           
            return View(orders);
        }
        public ActionResult ChangeStatus(int orderId )
        {

            if (ModelState.IsValid)
            {
                try
                {

                    _ordersService.ChangeStatus(orderId);
                    return RedirectToAction("Index");

                  
                }
                catch (Exception ex)
                {
                    if (ex is ProductQuantityIsLessThanOrderQuantity)
                    {
                        ModelState.AddModelError(nameof(Product.InventoryQuantity), ex.Message);
                    }
                }
            }

            return RedirectToAction("Index");

        }
        public ActionResult CancelStatus(int orderId)
        {
            if (User.IsInRole(nameof(Roles.Admin)))
            {
                _ordersService.CancelStatus(orderId);
               return RedirectToAction("Index");
            }

            _ordersService.CancelStatus(orderId);
            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult UserOrder()
        {
            var userId = User.Identity.GetUserId();
            var orders = _ordersService.GetUserOrders(userId).ToList();
            return View(orders);
        }
    }
}