using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.DAL.Models.Categories;
using OnlineStore.DAL.Models.FeedBacks;
using OnlineStore.DAL.Models.OrderItems;
using OnlineStore.DAL.Models.Orders;
using OnlineStore.DAL.Models.Products;
using OnlineStore.DAL.Models.User;

namespace OnlineStore.DAL.Database
{
    public class OnlineStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineStoreDbContext()
            : base("OnlineStoreDbConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasOptional(o => o.MainCategory)
                .WithMany(o => o.SubCategories)
                .HasForeignKey(o => o.CategoryId);
        }

        public static OnlineStoreDbContext Create()
        {
            return new OnlineStoreDbContext();
        }
    }
}