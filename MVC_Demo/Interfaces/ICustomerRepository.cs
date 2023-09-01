using NWdatabase.Models;

namespace MVC_Demo.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}