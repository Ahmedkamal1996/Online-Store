using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OnlineStore.DAL.Models.User;
using Owin;
using  OnlineStore.DAL.Database;
using  OnlineStore.BLL.Helpers;


[assembly: OwinStartupAttribute(typeof(OnlineStore.Startup))]
namespace OnlineStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //private void createRolesandUsers()
        //{
        //    OnlineStoreDbContext context = new OnlineStoreDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


        //    // In Startup iam creating first Admin Role and creating a default Admin User     
        //    if (!roleManager.RoleExists("Admin"))
        //    {

        //        // first we create Admin role    
        //        var role = new IdentityRole();
        //        role.Name = nameof(Roles.Admin);
        //        roleManager.Create(role);

        //        //Here we create a Admin super user who will maintain the website                   

        //        var user = new ApplicationUser();
        //        user.UserName = nameof(Roles.Admin);


        //        var chkUser = UserManager.Create(user);

        //        //Add default User to Role Admin    
        //        if (chkUser.Succeeded)
        //        {
        //            var result1 = UserManager.AddToRole(user.Id, nameof(Roles.Admin));

        //        }
        //    }

        //    // creating Creating Manager role     
        //    if (!roleManager.RoleExists(nameof(Roles.Admin)))
        //    {
        //        var role = new IdentityRole();
        //        role.Name = nameof(Roles.Admin);
        //        roleManager.Create(role);

        //    }

        //    // creating Creating Employee role     
        //    if (!roleManager.RoleExists(nameof(Roles.User)))
        //    {
        //        var role = new IdentityRole();
        //        role.Name = nameof(Roles.User);
        //        roleManager.Create(role);

        //    }
        //}
    }
}
