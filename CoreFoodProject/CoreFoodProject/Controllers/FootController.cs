using CoreFoodProject.Models;
using CoreFoodProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace CoreFoodProject.Controllers
{
    
    public class FootController : Controller
    {
        FootRepository footRepository = new FootRepository();  
        Context c = new Context();  

        public IActionResult Index(int page=1)
        {
            

            var footList = footRepository.FootListCategoryName().ToPagedList(page,3);

            return View(footList);
        }

        [HttpGet]
        public IActionResult AddFoot()
        {
            List<SelectListItem> CategoryList = (from x in c.Categories.ToList() select new SelectListItem{
                Text = x.CategoryName,
                Value = x.CategoryId.ToString(),

            }).ToList();
            
            ViewBag.CategoryList = CategoryList;    

            return View();
        }
        [HttpPost]
        public IActionResult AddFoot(Foot foot)
        {
            List<SelectListItem> CategoryList = (from x in c.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString(),

                                                 }).ToList();

            ViewBag.CategoryList = CategoryList;

            if (!ModelState.IsValid)
            {
                return View(foot);
            }


            footRepository.TAdd(foot);  

            return RedirectToAction("Index","Foot");
        

        }


        public IActionResult DeleteFood(int id)
        {
            footRepository.TRemove(footRepository.TGet(id));

            return RedirectToAction("Index", "Foot");
        }

        [HttpGet]
        public IActionResult UppdateFood(int id) 
        {
            var findFood = footRepository.TGet(id);

            List<SelectListItem> categoryList = (from x in c.Categories.ToList() select new SelectListItem
            {
                Text=x.CategoryName,
                Value=x.CategoryId.ToString(),
            }).ToList();

            ViewBag.CategoryList = categoryList;
            return View(findFood);


        }
        [HttpPost]
        public IActionResult UppdateFood(Foot foot)
        {
            var findFood = footRepository.TGet(foot.FootId);

            
            List<SelectListItem> categoryList = (from x in c.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString(),
                                                 }).ToList();

            ViewBag.CategoryList = categoryList;

            findFood.FootName = foot.FootName;
            findFood.Description = foot.Description;
            findFood.FootPrice = foot.FootPrice;
            findFood.FootImageURl = foot.FootImageURl;
            findFood.CategoryId = foot.CategoryId;
            findFood.FootStock = foot.FootStock;

            footRepository.TUppdate(findFood);




            return RedirectToAction("Index", "Foot"); 


        }



    }
}
