using CoreFoodProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreFoodProject.ViewComponents
{
	public class FoodGetList:ViewComponent
	{
		FootRepository footRepository = new FootRepository();

		public IViewComponentResult Invoke()
		{
			var foodList = footRepository.TList();

			return View(foodList);
		}

	}
}
