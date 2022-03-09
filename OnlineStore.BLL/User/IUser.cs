
using OnlineStore.DAL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.User
{
   public interface IUser
    {
        ICollection<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(int userId);
        void Add(ApplicationUser applicationUser);
        void Update(ApplicationUser applicationUser);
        void Delete(int userId);
    }
}
