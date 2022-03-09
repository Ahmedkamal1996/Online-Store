using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStore.BLL.Helpers;
using OnlineStore.DAL.Database;

namespace OnlineStore.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class RoleController : Controller
    {
        private OnlineStoreDbContext _context;

        public RoleController()
        {
            _context = new OnlineStoreDbContext();
        }


        // GET: Role
        public ActionResult Index()
        {

            var roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public ActionResult CreateRole()
        {

            var roles = new IdentityRole();
            return View(roles);
        }

        [HttpPost]
        public ActionResult CreateRole(IdentityRole role)
        {

             _context.Roles.Add(role);
             _context.SaveChanges();
             return RedirectToAction("Index");
        }
    }
}