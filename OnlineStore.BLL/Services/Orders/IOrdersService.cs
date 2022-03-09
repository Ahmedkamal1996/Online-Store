using OnlineStore.BLL.ViewModels.Order;
using System.Collections.Generic;
using OnlineStore.BLL.ViewModels.ShoppingCart;
using OnlineStore.DAL.Enums;

namespace OnlineStore.BLL.Services.Orders
{
    public interface IOrdersService
    {
        ICollection<GetOrderViewModel> GetOrders();
        ICollection<GetOrderViewModel> GetUserOrders(string userId);
        GetOrderViewModel GetOrderById(int orderId);
       GetOrderViewModel Add(CreateOrderViewModel model);
       GetOrderViewModel Add(ShoppingCartViewModel model);
        bool Update(UpdateOrderViewModel model);
        bool ChangeStatus(int orderId);
        bool CancelStatus(int orderId);
        bool Delete(int orderId);
    }
}
