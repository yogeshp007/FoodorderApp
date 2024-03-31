using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodorderApp.Areas.FOAdmin.Models;

namespace FoodorderApp.Areas.FOAdmin.Controllers
{
    public class ManageCategoryController : Controller
    {
        CategoryModel cm = new CategoryModel();

        public ActionResult AddEditCategory()
        {
            ViewBag.categories = cm.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult AddEditCategory(FormCollection fc, HttpPostedFileBase catimg)
        {
            cm.catid = 0;
            cm.catname = fc["cname"];
            cm.catdesc = fc["cdesc"];
            if (catimg!=null)
            {
                cm.catimg = catimg.FileName;
            }
            else
            {
                ViewBag.status = 0;
                ViewBag.msg = "Please upload category image...";
                return View();

            }
            bool b = cm.AddEditCatgory();
            if (b)
            {
                ViewBag.status = 1;
                ViewBag.msg = "Category " + cm.catname + " Added Succesfully";
                catimg.SaveAs(Server.MapPath("~/Areas/FOAdmin/images/CategoryImages/" + cm.catimg));
            }
            else
            {
                ViewBag.status = 0;
                ViewBag.msg = "Category " + cm.catname + " Not Added Succesfully! Try Again";
            }
            ViewBag.categories = cm.GetCategories();
            return View();
        }
    }
}