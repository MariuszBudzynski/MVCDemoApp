using NWdatabase.Models;

namespace MVC_Demo.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
        Task<List<string>> GetProductsNameAsync();
        Task<int> MatchProductIdAsync(string productname);
        Task<decimal?> GetSingleUnitPriceAsync(int productid);
	}
}