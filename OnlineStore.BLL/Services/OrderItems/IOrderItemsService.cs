using System.Collections.Generic;
using OnlineStore.BLL.ViewModels.OrderItem;
using OnlineStore.DAL.Models.OrderItems;

namespace OnlineStore.BLL.Services.OrderItems
{
   public interface IOrderItemsService
    {
        ICollection<GetOrderItemViewModel> GetOrderItems();
       GetOrderItemViewModel GetOrderItemById(int orderItemId);
        GetOrderItemViewModel Add(CreateOrderItemViewModel model);
        bool Update(UpdateOrderItemViewModel model);
        bool Delete(int orderItemId);
    }
}
