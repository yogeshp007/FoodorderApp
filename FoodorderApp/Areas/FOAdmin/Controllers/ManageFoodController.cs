using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodorderApp.Areas.FOAdmin.Models;

namespace FoodorderApp.Areas.FOAdmin.Controllers
{
    public class ManageFoodController : Controller
    {
        FoodModel fm = new FoodModel();
        CategoryModel cm = new CategoryModel();

        public ActionResult ListFood()
        {
            ViewBag.foodlist = fm.GetFoods();
            return View();
        }

        public ActionResult AddNewFood()
        {
            fm.category = cm;
            ViewBag.drpCategory = new SelectList(fm.category.GetCategories(), "catid", "catname");
            return View();
        }

        [HttpPost]
        public ActionResult AddNewFood(FormCollection fc,HttpPostedFileBase pic)
        {
            fm.foodid = 0;
            fm.food = fc["fname"];
            fm.fooddesc = fc["fdesc"];
            fm.catid = fc["drpCategory"]!=""?Convert.ToInt32(fc["drpCategory"]):0;
            fm.subcatid = fc["drpSubCategory"] != "" ? Convert.ToInt32(fc["drpSubCategory"]) : 0;
            //fm.subcatid = Convert.ToInt32(Request.Form["sid"]);
            fm.price = fc["price"]!=""?Convert.ToInt32(fc["price"]):0;
            
            if (pic != null)
            {
                fm.foodimg = pic.FileName;
            }
            else
            {
                fm.category = cm;
                ViewBag.drpCategory = new SelectList(fm.category.GetCategories(), "catid", "catname");
                ViewBag.status = 0;
                ViewBag.msg = "Please upload food image...";
                return View();
            }

            bool b = fm.AddEditFood();
            if (b)
            {
                ViewBag.status = 1;
                ViewBag.msg = "Food " + fm.food + " Added Succesfully";
                pic.SaveAs(Server.MapPath("~/Areas/FOAdmin/images/FoodImages/" + fm.foodimg));
            }
            else
            {
                ViewBag.status = 0;
                ViewBag.msg = "Food " + fm.food + " Not Added Succesfully! Try Again";
            }
            fm.category = cm;
            ViewBag.drpCategory = new SelectList(fm.category.GetCategories(), "catid", "catname");
            return View();
        }

        public JsonResult GetSubCatByCat(int id)
        {
            return Json(fm.GetSubCatByCat(id), JsonRequestBehavior.AllowGet);
        }
    }
}