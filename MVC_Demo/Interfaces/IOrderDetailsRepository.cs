using MVC_Demo.Models;
using NWdatabase.Models;

namespace MVC_Demo.Interfaces
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetails();
		IEnumerable<int> GetOrdersID();
		Task<IEnumerable<int>> GetOrdersIDAsync();
        Task SaveOrderDetails(AddOrderModel data);
        Task DeleteOrder(int orderid);
        Task<int> GetMaxIdOrder();
        Task<AddOrderModel> GetSingleOrderAsync(int id);
        Task UpdateData(AddOrderModel data);

	}
}