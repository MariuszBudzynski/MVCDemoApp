using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Interfaces;
using MVC_Demo.Models;
using MVC_Demo.Repositories;

namespace MVC_Demo.Controllers
{
	public class AddOrderController : Controller
	{
		private readonly AddOrderModel _addorder;
		private readonly IProductsRepository _products;
		private readonly IOrderDetailsRepository _orderDetailsRepository;

		public OrderDetailsModel Orderdetails { get; }

		public AddOrderController(IOrderDetailsRepository orderrepository,
			AddOrderModel addorder,
			IProductsRepository products,
			IOrderDetailsRepository orderDetailsRepository)
		{
			_addorder = addorder;
			_products = products;
			_orderDetailsRepository = orderDetailsRepository;
		}
	
		public async Task<IActionResult> Index()
		{
			return View(_addorder);
		}

		[HttpPost]
		public async Task<IActionResult> Index(AddOrderModel order)
		{
			return View(order);
		}

		[HttpPost]
		public async Task<IActionResult> PriceRefresh(AddOrderModel order)
		{
			var unitprice = await _products.GetSingleUnitPriceAsync(order.ProductId);
			order.UnitPrice = unitprice.HasValue ? decimal.Round(unitprice.Value, 2) : decimal.Zero;
			return View("Index", order);
		}

		[HttpPost]
		public async Task<IActionResult> SaveData(AddOrderModel order)
		{
			if (ModelState.IsValid)
			{
				await _orderDetailsRepository.SaveOrderDetails(order);
				return RedirectToAction("Index");
			}
			ModelState.AddModelError("", "Please slect the missing inputs");
			return View("Index", order);
		}
	}
}
