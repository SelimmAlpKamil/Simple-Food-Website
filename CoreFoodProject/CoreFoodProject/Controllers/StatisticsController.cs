using CoreFoodProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Linq;

namespace CoreFoodProject.Controllers
{
    public class StatisticsController : Controller
    {
        Context c = new Context();  

        public IActionResult Index()
        {
            var value1= c.Foods.Count();
            ViewBag.totalFood = value1;

            var value2= c.Categories.Count();
            ViewBag.totalCategories = value2;

            var value3= c.Foods.OrderBy(x=>x.FootStock).Select(x=>x.FootName).FirstOrDefault();
            ViewBag.minimumStockFood = value3;

            var value4 = c.Foods.OrderByDescending(x => x.FootStock).Select(x => x.FootName).FirstOrDefault();
            ViewBag.maksimumStockFood = value4;

            var value5 = c.Foods.OrderByDescending(x => x.FootStock).Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.maksimumStockFoodCategory = value5;

            var value6 = c.Foods.Average(x => x.FootPrice);
            ViewBag.averageFood = value6;

            var value7 = c.Foods.OrderByDescending(x => x.FootPrice).Select(x => x.FootName).FirstOrDefault();
            ViewBag.maksimumPriceFood = value7;



            var value8 = c.Foods.OrderBy(x => x.FootPrice).Select(x => x.FootName).FirstOrDefault();
            ViewBag.minimumPriceFood = value8;


            

            //var value9 = c.Foods.Where(x => x.CategoryId == (c.Categories.Where(x => x.CategoryName == "Sebze").Select(x => x.CategoryId).FirstOrDefault())).Count();
            //ViewBag.filterCount = value9;



            return View();
        }
    }
}
