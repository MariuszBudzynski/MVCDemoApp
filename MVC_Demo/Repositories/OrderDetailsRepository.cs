using Microsoft.EntityFrameworkCore;
using MVC_Demo.Interfaces;
using MVC_Demo.Models;
using MVC_Demo.Objectmapper;
using NWdatabase.Models;

namespace MVC_Demo.Repositories
{
	public class OrderDetailsRepository : IOrderDetailsRepository
	{
		private readonly NorthwindContext _db;
		private readonly ObjectMapper mapper;

		public OrderDetailsRepository(NorthwindContext db)
		{
			_db = db;
			mapper = new ObjectMapper();
		}
		public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
		{
			IQueryable<OrderDetail> query = await Task.FromResult(_db.OrderDetails);
			var orderDetails = await query.ToListAsync();
			return orderDetails;
		}

		public async Task<AddOrderModel> GetSingleOrderAsync(int id)
		{
			IQueryable<OrderDetail> query = _db.OrderDetails;
			var order = await query.SingleOrDefaultAsync(o=>o.OrderId==id);
			var mappedorder = await mapper.MappAddOrderModel(order);
			return await Task.FromResult(mappedorder);
		}

		public IEnumerable<int> GetOrdersID()
		{
			IQueryable<int> query = _db.OrderDetails.Select(o => o.OrderId).Distinct();
			return query;
		}

		public async Task<IEnumerable<int>> GetOrdersIDAsync()
		{
			var query = await Task.FromResult(_db.OrderDetails.Select(o => o.OrderId).Distinct());
			return await Task.FromResult(query);
		}

		public async Task SaveOrderDetails(AddOrderModel data)
		{
			var mappeddata = await mapper.MappOrderDetail(data);
			_db.OrderDetails.Add(mappeddata);
			await _db.SaveChangesAsync();
		}

		public async Task DeleteOrder(int orderid)
		{ 
			if (orderid !=0)
			{
				IQueryable<OrderDetail> query = _db.OrderDetails;
				var order = query.FirstOrDefaultAsync(o=>o.OrderId==orderid).Result;
				_db.Remove(order);
				await _db.SaveChangesAsync();
			}
		}

		public async Task<int> GetMaxIdOrder()
		{
			IQueryable<OrderDetail> query = await Task.FromResult(_db.OrderDetails);
			var listofids = await query.Select(o => o.OrderId).ToListAsync();
			return listofids.Count;
			//var id = 0;
			//if (!listofids.Any())
			//{
			//	id = 1;
			//	return id;
			//}
			//else
			//{
			//	id = await Task.FromResult(listofids.Max());
			//	return id;
			//} 
		}

		public async Task UpdateData(AddOrderModel data)
		{
			var dataobjc = await _db.OrderDetails.AsNoTracking().FirstOrDefaultAsync(od => od.OrderId == data.OrderId);
			var mappedobj = mapper.MappOrderDetail(data).Result;

			_db.OrderDetails.Remove(dataobjc);
			_db.OrderDetails.Add(mappedobj);

			await _db.SaveChangesAsync();
		}


	}
}
