using NWdatabase.Models;

namespace MVC_Demo.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}