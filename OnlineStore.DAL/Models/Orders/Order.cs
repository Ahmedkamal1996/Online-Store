using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStore.DAL.Enums;
using OnlineStore.DAL.Models.OrderItems;
using OnlineStore.DAL.Models.User;

namespace OnlineStore.DAL.Models.Orders
{
    [Table(nameof(Order))]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        //public int Amount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;

        [ForeignKey(nameof(User))] 
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
