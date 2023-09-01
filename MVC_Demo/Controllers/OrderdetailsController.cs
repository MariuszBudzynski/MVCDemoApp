using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Interfaces;
using MVC_Demo.Models;
using NWdatabase.Models;
using System.Diagnostics;

namespace MVC_Demo.Controllers
{
	public class OrderdetailsController : Controller
	{
		private readonly ILogger<OrderdetailsController> _logger;
		private readonly IOrderDetailsRepository _orderdetailsrepository;
		public OrderDetailsModel Orderdetails { get; }

		public OrderdetailsController(ILogger<OrderdetailsController> logger,IOrderDetailsRepository orderrepository,OrderDetailsModel orderdetails)
		{
			_logger = logger;
			_orderdetailsrepository = orderrepository;
			Orderdetails = orderdetails;
		}

		public async Task<IActionResult> Index()
		{
			
			return View(Orderdetails);
		}

		[HttpPost]
		public IActionResult UpdatePage(int button)
		{
			var conversion = button * 100;
			Orderdetails.ItemsToSkip = conversion <= 100 ? 0 : conversion - 100;
			return View("Index", Orderdetails);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}