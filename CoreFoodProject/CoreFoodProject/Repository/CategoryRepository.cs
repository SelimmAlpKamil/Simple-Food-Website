using CoreFoodProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreFoodProject.Repository
{
	public class CategoryRepository:GenericRepository<Category>
	{
		Context c = new Context();	

		public List<Foot> CategoryFootList(int id) {

			return c.Foods.Where(x=>x.CategoryId==id).ToList();
		}

        public List<Category> CategorySearch(string p)
        {

            return c.Categories.Where(x=>x.CategoryName.Contains(p)).ToList();
        }


    }
}
