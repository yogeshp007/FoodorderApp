using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodorderApp.EF;

namespace FoodorderApp.Areas.FOAdmin.Models
{
    public class CategoryModel
    {
        public int catid { get; set; }
        public string catname { get; set; }
        public string catdesc { get; set; }
        public string catimg { get; set; }
        public bool isactive { get; set; }


        public bool AddEditCatgory()
        {
            int count = 0;
            using (FoodOrderDBEntities db = new FoodOrderDBEntities())
            {
                count = db.AddEditCategory(catid, catname, catdesc, catimg);
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

        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> li = new List<CategoryModel>();
            using (FoodOrderDBEntities db = new FoodOrderDBEntities())
            {
                foreach (tblFoodCategory item in db.tblFoodCategories.OrderByDescending(a=>a.catid).ToList())
                {
                    CategoryModel cm = new CategoryModel();
                    cm.catid = item.catid;
                    cm.catname = item.catname;
                    cm.catdesc = item.catdesc;
                    cm.catimg =  item.catimg;
                    cm.isactive = Convert.ToBoolean(item.isactive);
                    li.Add(cm);
                }
            }
            return li;
        }


    }
}