using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Interfaces;
using MVC_Demo.Models;
using MVC_Demo.Repositories;
using NWdatabase.Models;

namespace MVC_Demo.Controllers
{
	public class EditOrderController : Controller
	{
		private readonly AddOrderModel _addorder;

		private readonly IOrderDetailsRepository _orderDetailsRepository;
		private readonly IProductsRepository _products;

		public OrderDetailsModel Orderdetails { get; }

		public EditOrderController(AddOrderModel addorder,
			IOrderDetailsRepository orderDetailsRepository,
			IProductsRepository products)
		{
			_addorder = addorder;
			_orderDetailsRepository = orderDetailsRepository;
			_products = products;
		}

		public IActionResult Index()
		{
			return View(_addorder);
		}
		[HttpPost]
		public async Task<IActionResult> Details(int order)
		{
			var getorder = await _orderDetailsRepository.GetSingleOrderAsync(order);
			return View("Index", getorder);
		}

		[HttpPost]
		public async Task<ActionResult> UpdateData(AddOrderModel ordertosave)
		{
			if (ModelState.IsValid)
			{
				await _orderDetailsRepository.UpdateData(ordertosave);
				return RedirectToAction("Index", "Orderdetails");
			}
			ModelState.AddModelError("", "Please slect the missing inputs");
			return RedirectToAction("Index", "EditOrder", ordertosave);
		}

		[HttpPost]
		public async Task<IActionResult> PriceRefresh(AddOrderModel order)
		{
			var unitprice = await _products.GetSingleUnitPriceAsync(order.ProductId);
			order.UnitPrice = unitprice.HasValue ? decimal.Round(unitprice.Value, 2) : decimal.Zero;
			return View("Index", order);
		}
	}
}
