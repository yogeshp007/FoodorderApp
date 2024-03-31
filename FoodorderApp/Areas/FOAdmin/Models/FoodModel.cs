using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodorderApp.EF;
using System.Web.Mvc;

namespace FoodorderApp.Areas.FOAdmin.Models
{
    public class FoodModel
    {
        public int foodid { get; set; }
        public string food { get; set; }
        public string fooddesc { get; set; }
        public int catid { get; set; }
        public int subcatid { get; set; }
        public string foodimg { get; set; }
        public int price { get; set; }
        public bool foodstatus { get; set; }

        public CategoryModel category { get; set; }
        public SubCategoryModel subcategory { get; set; }


        public List<SelectListItem> GetSubCatByCat(int catid)
        {
            List<SelectListItem> li = new List<SelectListItem>();
            using (FoodOrderDBEntities db = new FoodOrderDBEntities())
            {
                foreach (tblFoodSubCat item in db.tblFoodSubCats.Where(a => a.catid == catid).ToList())
                {
                    li.Add(new SelectListItem { Value = item.subcatid.ToString(), Text = item.subname });
                }
            }
            return li;
        }


        public bool AddEditFood()
        {
            int i = 0;
            using (FoodOrderDBEntities db = new FoodOrderDBEntities())
            {
                i = db.AddEditfood(foodid, food, fooddesc, catid, subcatid, foodimg, price);
            }
            if (i > 0)
            {
                return true;
            }
            else
            { return false; }
        }

        public List<FoodModel> GetFoods()
        {
            List<FoodModel> li = new List<FoodModel>();
            using (FoodOrderDBEntities db = new FoodOrderDBEntities())
            {
                foreach (tblFood item in db.tblFoods.ToList())
                {
                    FoodModel fm = new FoodModel();
                    fm.foodid = item.foodid;
                    fm.food = item.food;
                    fm.fooddesc = item.fooddesc;
                    fm.foodimg = item.foodimg;
                    fm.price = (int)item.price;
                    CategoryModel cm = new CategoryModel();
                    tblFoodCategory tfc = db.tblFoodCategories.Find(item.catid);
                    cm.catname = tfc.catname;
                    fm.category = cm;

                    SubCategoryModel sm = new SubCategoryModel();
                    tblFoodSubCat tfsc = db.tblFoodSubCats.Find(item.subcatid);
                    sm.subname = tfsc.subname;
                    fm.subcategory = sm;

                    fm.foodstatus = Convert.ToBoolean(item.foodstatus);
                    li.Add(fm);
                }
            }
            return li;
        }
    }
}