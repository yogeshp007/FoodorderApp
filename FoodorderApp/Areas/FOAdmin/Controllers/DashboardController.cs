using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodorderApp.Areas.FOAdmin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: FOAdmin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}