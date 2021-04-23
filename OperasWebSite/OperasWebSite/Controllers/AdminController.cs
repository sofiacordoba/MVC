using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperasWebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //GET /Admin/Login/10/Administrator
        public ActionResult Login(int Id, string Role)
        {
            ViewBag.Id = Id;
            ViewBag.Roles = Role;

            return View();
        }

        //GET /Admin/Gaby
        public ActionResult SearchByName(string Name)
        {
            ViewBag.Name = "Name: " + Name;

            return View();
        }

    }
}