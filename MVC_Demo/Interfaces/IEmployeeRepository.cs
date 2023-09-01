using NWdatabase.Models;

namespace MVC_Demo.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}