using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CoreFoodProject.Models
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-VC77BM0\\SQLEXPRESS; database=CoreFoodDB; integrated security=true;");
		}

		public DbSet<Foot> Foods { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Admin> Admins { get; set; }

	}
}
