using MVC_Demo.Interfaces;
using NWdatabase.Models;

namespace MVC_Demo.Repositories
{
    public class CategoryRepository : ICategoryRepository
	{
		private readonly NorthwindContext _db;

		public CategoryRepository(NorthwindContext db)
		{
			_db = db;
		}
		public IEnumerable<Category> GetCategories()
		{
			IQueryable<Category> query = _db.Categories;
			return query;
		}
	}
}
