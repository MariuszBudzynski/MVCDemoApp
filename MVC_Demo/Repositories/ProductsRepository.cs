using Microsoft.EntityFrameworkCore;
using MVC_Demo.Interfaces;
using NWdatabase.Models;

namespace MVC_Demo.Repositories
{
    public class ProductsRepository : IProductsRepository
	{
		private readonly NorthwindContext _db;

		public ProductsRepository(NorthwindContext db)
		{
			_db = db;
		}
		public IEnumerable<Product> GetProducts()
		{
			IQueryable<Product> query = _db.Products;
			return query;
		}

		public async Task<List<string>> GetProductsNameAsync()
		{
			var query = _db.Products.Select(p=>p.ProductName);
			return await query.ToListAsync();
		}

		public async Task<int> MatchProductIdAsync(string productname)
		{
			IQueryable<Product> query = await Task.FromResult(_db.Products);
			var productId = await Task.FromResult(query.First(pr => pr.ProductName == productname).ProductId);
			return await Task.FromResult(productId);
		}

		public async Task<decimal?> GetSingleUnitPriceAsync(int productid)
		{
			IQueryable<Product> query = _db.Products;

			var unitprice = await ((query.Where(p => p.ProductId == productid)).Select(up=>up.UnitPrice)).FirstOrDefaultAsync();
			return unitprice;
		}
	}
}
