using CoreFoodProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreFoodProject.Repository
{
	public class GenericRepository<T> where T : class,new()
	{
		Context c = new Context();
		
		public List<T> TList()
		{
			return c.Set<T>().ToList();
		}

		public List<T> TList(Func<T,bool> filter) 
		{
			return c.Set<T>().Where(filter).ToList();
		}

		public void TAdd(T t)
		{
			c.Set<T>().Add(t);
			c.SaveChanges();
		}
		public void TRemove(T t)
		{
			c.Set<T>().Remove(t);
			c.SaveChanges();
		}
		public void TUppdate(T t)
		{
			c.Set<T>().Update(t);
			c.SaveChanges();
		}

		public T TGet(int id) {

			return c.Set<T>().Find(id);	
		}
	}
}
