using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Demo.Interfaces;
using MVC_Demo.Repositories;
using NWdatabase.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Demo.Models
{
	public class AddOrderModel
	{
		[Key]
		public int OrderId { get; set; }
		[Range(1, 77, ErrorMessage = "Please select a product")]
		public int ProductId { get; set; }

		public decimal? UnitPrice { get; set; } =0m;
		[Range(1,double.MaxValue,ErrorMessage = "Quantity needs to be greater than 0")]
		public short Quantity { get; set; }

		public float Discount { get; set; }
		
	}
}
