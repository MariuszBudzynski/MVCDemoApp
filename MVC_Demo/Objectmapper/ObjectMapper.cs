using MVC_Demo.Models;
using NWdatabase.Models;

namespace MVC_Demo.Objectmapper
{
	public class ObjectMapper
    {
        public async Task<OrderDetail> MappOrderDetail(AddOrderModel addordermodel)
        {
            OrderDetail orderdetails = new OrderDetail()
            {
                OrderId = addordermodel.OrderId,
                ProductId = addordermodel.ProductId,
                UnitPrice = addordermodel.UnitPrice ?? 0,
				Quantity = addordermodel.Quantity,
				Discount = addordermodel.Discount
			};
            return await Task.FromResult(orderdetails);
        }

		public async Task<AddOrderModel> MappAddOrderModel(OrderDetail orderDetail)
		{
			AddOrderModel model = new AddOrderModel();

			if (orderDetail != null)
			{


				model = new AddOrderModel()

				{
					OrderId = orderDetail.OrderId,
					ProductId = orderDetail.ProductId,
					UnitPrice = orderDetail.UnitPrice,
					Quantity = orderDetail.Quantity,
					Discount = orderDetail.Discount
				};
				return await Task.FromResult(model);
			}
			return await Task.FromResult(model);
		}
	}
}
