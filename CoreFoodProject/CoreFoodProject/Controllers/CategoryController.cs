using CoreFoodProject.Models;
using CoreFoodProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CoreFoodProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(categoryRepository.CategorySearch(p));
            }


            var categoryList = categoryRepository.TList(x=>x.CategoriyStatus==true);

            return View(categoryList);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);

            }

            categoryRepository.TAdd(category);

            return RedirectToAction("Index", "Category");
        }

        public IActionResult DeleteCategory(int id) {

            var findCategory = categoryRepository.TGet(id);

            findCategory.CategoriyStatus = false;

            categoryRepository.TUppdate(findCategory);

            return RedirectToAction("Index", "Category");
        }


        [HttpGet]
        public IActionResult UppdateCategory(int id)
        {
            var findCategory = categoryRepository.TGet(id);

            return View(findCategory);
        }

        [HttpPost]
        public IActionResult UppdateCategory(Category category)
        {


            categoryRepository.TUppdate(category);

            return RedirectToAction("Index", "Category");
        }

        public IActionResult GetCategoryFoot(int id)
        {
            var footList = categoryRepository.CategoryFootList(id);

            return View(footList);
        }



    }
}
