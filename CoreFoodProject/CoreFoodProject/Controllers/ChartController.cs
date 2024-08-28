using CoreFoodProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoreFoodProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult VizualProductResult() 
        //{
        //    return Json(ProductList());
        //}

        //public List<ChartStatic> ProductList()
        //{
        //    List<ChartStatic> c = new List<ChartStatic>();

        //    c.Add(new ChartStatic()
        //    {
        //        ProductName = "Bilgisayar",
        //        ProductStock = 54
        //    });
        //    c.Add(new ChartStatic()
        //    {
        //        ProductName = "Telefon",
        //        ProductStock = 120
        //    });
        //    c.Add(new ChartStatic()
        //    {
        //        ProductName = "kulaklık",
        //        ProductStock = 230
        //    });

        //    return c;
        //}


        public IActionResult VizualProductResult() 
        {
            return Json(FoodList());
        }

        public List<Chart> FoodList()
        {
            List<Chart> list = new List<Chart>();    

            using(var c = new Context())
            {
                list = c.Foods.Select(x=> new Chart
                {
                    FoodName = x.FootName,
                    FoodStock = x.FootStock
                }).ToList();
            }

            return list;    

        }


    }
}
