using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Interfaces;
using MVC_Demo.Models;
using MVC_Demo.Repositories;
using NWdatabase.Models;

namespace MVC_Demo.Controllers
{
	public class DeleteOrderController : Controller
	{
		private readonly IOrderDetailsRepository _orderrepository;

		public DeleteOrderController(IOrderDetailsRepository orderrepository)
		{
			_orderrepository = orderrepository;
		}


		[HttpPost]
		public async Task<IActionResult> Delete(int orderid)
		{
			await _orderrepository.DeleteOrder(orderid);
			return RedirectToAction("Index", "Orderdetails");
		}
	}
}
