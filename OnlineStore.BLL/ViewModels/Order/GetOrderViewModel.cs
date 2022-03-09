using OnlineStore.DAL.Enums;
using System;
using System.Collections.Generic;
using OnlineStore.BLL.ViewModels.OrderItem;
using OnlineStore.DAL.Models.User;

namespace OnlineStore.BLL.ViewModels.Order
{
   public class GetOrderViewModel
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }
       
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get;  set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<GetOrderItemViewModel> OrderItems { get; set; }
    }
}
