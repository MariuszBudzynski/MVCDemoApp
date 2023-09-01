using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Demo.Interfaces;
using NWdatabase.Models;

namespace MVC_Demo.Models
{
	public class SelectListItemState
	{
		private readonly IProductsRepository _products;
		public Task<List<SelectListItem>>? ListElements { get; set; }
		public SelectListItemState(IProductsRepository products)
		{
			_products = products;
			ListElements = PupulateListElements();
		}

		public async Task<List<SelectListItem>> PupulateListElements()
		{
			List<SelectListItem>? listofElements = new();
			var listofproducts = _products.GetProductsNameAsync().Result.ToList();

			listofElements.Add(new SelectListItem { Value = "0", Text = "Select" });
			foreach (var productname in listofproducts)
			{
				var prodid = await Task.FromResult(_products.MatchProductIdAsync(productname)).Result;
				listofElements.Add(new SelectListItem { Value = prodid.ToString(), Text = productname });
			}
			return listofElements;
		}

	}
}
