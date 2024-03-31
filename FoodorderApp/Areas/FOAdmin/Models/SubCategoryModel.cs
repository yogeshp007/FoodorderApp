using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodorderApp.EF;

namespace FoodorderApp.Areas.FOAdmin.Models
{
    public class SubCategoryModel
    {
        public int subcatid { get; set; }
        public string subname { get; set; }
        public string subdesc { get; set; }
        public string subcatimg { get; set; }
        public int catid { get; set; }
        public CategoryModel category { get; set; }
        public bool isactive { get; set; }


        public bool AddEditSubCatgory()
        {
            int count = 0;
            using (FoodOrderDBEntities db = new FoodOrderDBEntities())
            {
                count = db.AddeditSubcat(subcatid,subname,subdesc,subcatimg,catid);
            }
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<SubCategoryModel> GetSubCategories()
        {
            List<SubCategoryModel> li = new List<SubCategoryModel>();
            using (FoodOrderDBEntities db = new FoodOrderDBEntities())
            {
                foreach (tblFoodSubCat item in db.tblFoodSubCats.ToList())
                {
                    SubCategoryModel sm = new SubCategoryModel();
                    sm.subcatid = item.subcatid;
                    sm.subname = item.subname;
                    sm.subdesc = item.subdesc;
                    sm.subcatimg = item.subcatimg;
                    sm.catid = (int)item.catid;
                    CategoryModel cm = new CategoryModel();
                    tblFoodCategory tfc = db.tblFoodCategories.Find(sm.catid);
                    cm.catname = tfc.catname;
                    sm.category = cm;
                    sm.isactive = Convert.ToBoolean(item.isactive);
                    li.Add(sm);
                }
            }
            return li;
        }
    }
}