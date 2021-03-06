using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.DAL.Enums;
using OnlineStore.DAL.Models.FeedBacks;
using OnlineStore.DAL.Models.Orders;

namespace OnlineStore.DAL.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Gender Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<FeedBack> FeedBacks { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}