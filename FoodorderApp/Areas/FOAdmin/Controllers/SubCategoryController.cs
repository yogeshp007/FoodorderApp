using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodorderApp.Areas.FOAdmin.Models;

namespace FoodorderApp.Areas.FOAdmin.Controllers
{
    public class SubCategoryController : Controller
    {
        SubCategoryModel sm = new SubCategoryModel();
        CategoryModel cm = new CategoryModel();

        public ActionResult AddEditSubCategory()
        {
           
            sm.category = cm;
            ViewBag.drpCategory =new SelectList(sm.category.GetCategories(),"catid","catname");
            ViewBag.subcats = sm.GetSubCategories();
            return View();
        }

        [HttpPost]
        public ActionResult AddEditSubCategory(FormCollection fc,HttpPostedFileBase subcatimg)
        {
            sm.subcatid = 0;
            sm.subname = fc["scname"];
            sm.subdesc = fc["sdesc"];
            sm.catid = fc["drpCategory"] !="Select Category"?Convert.ToInt32(fc["drpCategory"]):0;
            if (subcatimg != null)
            {
             sm.subcatimg = subcatimg.FileName;
            }
            else
            {
                ViewBag.subcats = sm.GetSubCategories();
                sm.category = cm;
                ViewBag.drpCategory = new SelectList(sm.category.GetCategories(), "catid", "catname");
                ViewBag.status = 0;
                ViewBag.msg = "Please upload subcategory image...";
                return View();

            }
            bool b = sm.AddEditSubCatgory();
            if (b)
            {
                ViewBag.status = 1;
                ViewBag.msg = "Sub Category " + sm.subname + " Added Succesfully";
                subcatimg.SaveAs(Server.MapPath("~/Areas/FOAdmin/images/SubCategoryImages/" + sm.subcatimg));
            }
            else
            {
                ViewBag.status = 0;
                ViewBag.msg = "Sub Category " + sm.subname + "Not Added Succesfully...Try Again";
            }

            ViewBag.subcats = sm.GetSubCategories();
            sm.category = cm;
            ViewBag.drpCategory = new SelectList(sm.category.GetCategories(), "catid", "catname");
            return View();
        }
    }
}