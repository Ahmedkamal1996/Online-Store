using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using OnlineStore.BLL.ViewModels.OrderItem;
using OnlineStore.DAL.Database;
using OnlineStore.DAL.Models.OrderItems;

namespace OnlineStore.BLL.Services.OrderItems
{
    public class OrderItemsService : IOrderItemsService
    {
        private readonly OnlineStoreDbContext _context;

        public OrderItemsService(OnlineStoreDbContext context)
        {
            _context = context;
        }

        
        public ICollection<GetOrderItemViewModel> GetOrderItems()
        {
            var orderItems = _context.OrderItems.ToList();
            return Mapper.Map<ICollection<GetOrderItemViewModel>>(orderItems);
        }

        public GetOrderItemViewModel GetOrderItemById(int orderItemId)
        {
            var orderItem = _context.OrderItems.Find(orderItemId);
            return orderItem==null ? null : Mapper.Map<GetOrderItemViewModel>(orderItem);
        }

        public GetOrderItemViewModel Add(CreateOrderItemViewModel model)
        {
            var orderItem = Mapper.Map<OrderItem>(model);
            _context.OrderItems.Add(orderItem);
            return _context.SaveChanges()>0 ? Mapper.Map<GetOrderItemViewModel>(orderItem) : null;
        }

        public bool Update(UpdateOrderItemViewModel model)
        {
            var oldOrderItem = _context.OrderItems.Find(model.Id);

            if (oldOrderItem == null)
            {
                return false;
            }

            Mapper.Map( model, oldOrderItem);

            _context.Entry(oldOrderItem).State = EntityState.Modified;

            return _context.SaveChanges() > 0;

        }

        public bool Delete(int orderItemId)
        {
            var orderItem = _context.OrderItems.Find(orderItemId);

            if (orderItem==null)
            {
                return false;
            }

            _context.OrderItems.Remove(orderItem);

            return _context.SaveChanges() > 0;
        }
    }
}
