using CoreFoodProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreFoodProject.Repository
{
	public class FootRepository:GenericRepository<Foot>
	{
		Context c = new Context();	

		public List<Foot> FootListCategoryName() 
		{
			
			return c.Foods.Include(x=>x.Category).ToList();
		}

		public List<Foot> FootListCategory(Func<Foot,bool>filter)
		{

			return c.Foods.Include(x => x.Category).Where(filter).ToList();
		}

        public Foot FootCategory(int id)
        {

            return c.Foods.Include(x => x.Category).FirstOrDefault(x=>x.CategoryId==id);
        }


    }
}
