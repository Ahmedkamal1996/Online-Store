using System;
using AutoMapper;
using OnlineStore.BLL.ViewModels.Order;
using OnlineStore.DAL.Database;
using OnlineStore.DAL.Models.Orders;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineStore.BLL.ViewModels.ShoppingCart;
using OnlineStore.DAL.Enums;
using OnlineStore.DAL.Models.OrderItems;
using OnlineStore.DAL.Models.Products;

namespace OnlineStore.BLL.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly OnlineStoreDbContext _context;

        public OrdersService(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public GetOrderViewModel Add(CreateOrderViewModel model)
        {
            var order = Mapper.Map<Order>(model);

            _context.Orders.Add(order);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetOrderViewModel>(order) : null;
        }

        public GetOrderViewModel Add(ShoppingCartViewModel model)
        {
            var order = new Order()
            {
                Status = OrderStatus.Ordered,
                TotalPrice =  model.Items.Sum(x=>x.Product.Price * x.Quantity),
                UserId = model.UserId,
                OrderItems = model.Items.Select(x=> new OrderItem()
                {
                    ProductId = x.Product.Id,
                    Quantity = x.Quantity
                } ).ToList()
            };
            _context.Orders.Add(order);
            //var product = new Product();
            //product.InventoryQuantity = product.InventoryQuantity - product.OrderItems.Sum(x => x.Quantity);
           

            return _context.SaveChanges() > 0 ? Mapper.Map<GetOrderViewModel>(order) : null;
            //var x = model.Items.Select(x => x.Product.Name);
        }

        public bool ChangeStatus(int orderId)
        {
            var order = _context.Orders.Find(orderId);

            if (order == null)
            {
                return false;
            }

            switch (order.Status)
            {
                case OrderStatus.Ordered:
                    order.Status = OrderStatus.Confirmed;

                    foreach (var item in order.OrderItems)
                    {
                        var product = _context.Products.Find(item.ProductId);
                        if (product==null)
                        {
                           continue;
                        }

                        if (product.InventoryQuantity == 0 || product.InventoryQuantity < item.Quantity)
                        {
                            return false;
                        }
                        product.InventoryQuantity -= item.Quantity;

                        _context.Entry(product).State = EntityState.Modified;
                    }
                    break;
                case OrderStatus.Confirmed:
                    order.Status = OrderStatus.Picked;

                    break;
                case OrderStatus.Picked:
                    order.Status = OrderStatus.Delivered;
                    break;

                case OrderStatus.Delivered:
                    break;
               
                default:
                    throw new ArgumentOutOfRangeException();
            }
            

            _context.Entry(order).State = EntityState.Modified;

            return _context.SaveChanges() > 0;
        }

        public bool CancelStatus(int orderId)
        {
            var order = _context.Orders.Find(orderId);

            if (order == null ||order.Status==OrderStatus.Picked||order.Status==OrderStatus.Delivered)
            {
                return false;
            }
            foreach (var item in order.OrderItems)
            {
                var product = _context.Products.Find(item.ProductId);
                if (product == null)
                {
                    continue;
                }

                product.InventoryQuantity += item.Quantity;

                _context.Entry(product).State = EntityState.Modified;
            }

            _context.Orders.Remove(order);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int orderId)
        {
            var order = _context.Orders.Find(orderId);

            if(order==null)
            {
                return false;
            }
            _context.Orders.Remove(order);

            return _context.SaveChanges() > 0;
        }

        public ICollection<GetOrderViewModel> GetUserOrders(string userId)
        {
            var orders = _context.Orders.Where(x=>x.UserId==userId).ToList();
            return Mapper.Map<ICollection<GetOrderViewModel>>(orders);
        }

        public GetOrderViewModel GetOrderById(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            return order == null ? null : Mapper.Map<GetOrderViewModel>(order);
        }

        public ICollection<GetOrderViewModel> GetOrders()
        {
            var orders = _context.Orders.ToList();
            return Mapper.Map<ICollection<GetOrderViewModel>>(orders);
        }

        public bool Update(UpdateOrderViewModel model)
        {
            var oldOrder = _context.Orders.Find(model.Id);

            if(oldOrder==null)
            {
                return false;
            }

            Mapper.Map(model, oldOrder);

            _context.Entry(oldOrder).State = EntityState.Modified;

            return _context.SaveChanges() > 0;
        }

       
    }
}
