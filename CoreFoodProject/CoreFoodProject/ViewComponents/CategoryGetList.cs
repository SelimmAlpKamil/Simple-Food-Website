using CoreFoodProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreFoodProject.viewComponents
{
	public class CategoryGetList:ViewComponent
	{
		CategoryRepository categoryRepository = new CategoryRepository();

		public IViewComponentResult Invoke()
		{
			var categoryList = categoryRepository.TList();

			return View(categoryList);
		}


	}
}
