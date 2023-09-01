using MVC_Demo.Interfaces;
using NWdatabase.Models;

namespace MVC_Demo.Repositories
{
    public class CustomerRepository : ICustomerRepository
	{
		private readonly NorthwindContext _db;

		public CustomerRepository(NorthwindContext db)
        {
			_db = db;
        }
        public IEnumerable<Customer> GetCustomers()
		{
			IQueryable<Customer> query = _db.Customers;
			return query;
		}
	}
}
