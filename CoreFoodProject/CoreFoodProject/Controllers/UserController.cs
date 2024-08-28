using CoreFoodProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFoodProject.Controllers
{
    

        
    public class UserController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

		[AllowAnonymous]
		public IActionResult FoodDetails(int id)
		{
            FootRepository footRepository = new FootRepository();

            var foodCategory = footRepository.FootCategory(id);

            var categoryFoodList = footRepository.FootListCategory(x=>x.CategoryId==id);

            ViewBag.foodCategory = foodCategory.Category.CategoryName;

			return View(categoryFoodList);
		}
	}
}
