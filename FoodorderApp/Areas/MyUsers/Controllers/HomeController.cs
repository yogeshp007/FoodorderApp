using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodorderApp.EF;

namespace FoodorderApp.Areas.MyUsers.Controllers
{
    public class HomeController : Controller
    {

        FoodOrderDBEntities db = new FoodOrderDBEntities();

        public ActionResult Index()
        {
            ViewBag.cats = db.tblFoodCategories.ToList();
            return View();
        }

        public ActionResult SubCats(int id)
        {
            ViewBag.subcats = db.tblFoodSubCats.Where(aa=>aa.catid==id).ToList();
            return View();
        }

        public ActionResult foods(int id)
        {
            ViewBag.foodlist = db.tblFoods.Where(aa => aa.subcatid == id).ToList();
            return View();
        }

        public ActionResult food(int id)
        {
            ViewBag.foodlist = db.tblFoods.Where(aa => aa.foodid == id).ToList();
            return View();
        }

        public JsonResult AddFood(string uname,string address,string contactno,string amnt,int quant)
        {
            tblOrder to = new tblOrder();
            to.uname = uname;
            to.uaddress = address;
            to.ucontact = contactno;
            to.amnt = amnt;
            to.qnty = quant;
            to.orderstatus = false;
            db.tblOrders.Add(to);
            db.SaveChanges();
            return Json("food order placed successfully...", JsonRequestBehavior.AllowGet);
        }
    }
}