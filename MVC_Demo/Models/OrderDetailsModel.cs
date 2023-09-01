using MVC_Demo.Interfaces;
using NWdatabase.Models;

namespace MVC_Demo.Models
{
	public class OrderDetailsModel
	{
		public int ItemsToShow { get; set; } = 100;
		public int ItemsToSkip { get; set; } = 0;
		public bool Confirmation { get; set; } = false;

	}
}
