using OnlineStore.DAL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.User
{
    public class UserRpo : IUser
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public void Add(ApplicationUser applicationUser)
        {
            _context.Users.Add(applicationUser);
            _context.SaveChanges();
        }

        public void Delete(int userId)
        {
            var applicationuser = _context.Users.Find(userId);
            _context.Users.Remove(applicationuser);
            _context.SaveChanges();
        }

        public ApplicationUser GetApplicationUserById(int userId)
        {
            var user = _context.Users.Find(userId);
            return user;
        }

        public ICollection<ApplicationUser> GetApplicationUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public void Update(ApplicationUser applicationUser)
        {
            var olduser = _context.Users.Find(applicationUser.Id);
            _context.Entry(olduser).CurrentValues.SetValues(applicationUser);
            _context.SaveChanges();
        }
    }
}
