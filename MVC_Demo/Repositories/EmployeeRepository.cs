using MVC_Demo.Interfaces;
using NWdatabase.Models;

namespace MVC_Demo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
	{

		private readonly NorthwindContext _db;

		public EmployeeRepository(NorthwindContext db)
		{
			_db = db;
		}
		public IEnumerable<Employee> GetEmployees()
		{
			IQueryable<Employee> query = _db.Employees;
			return query;
		}
	}
}
