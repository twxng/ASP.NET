using Microsoft.AspNetCore.Mvc;
using Lr8.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lr8.Controllers
{
	public class ProductController : Controller
	{
		private readonly List<Product> _products;

		public ProductController()
		{
			_products = new List<Product>
			{
		new Product { Id = 1, Name = "Dell XPS 13 Laptop", Price = 1299.99m, CreatedDate = DateTime.Now.AddDays(-10) },
		new Product { Id = 2, Name = "iPhone 15 Pro", Price = 999.00m, CreatedDate = DateTime.Now.AddDays(-5) },
		new Product { Id = 3, Name = "iPad Air 5th Gen", Price = 599.99m, CreatedDate = DateTime.Now.AddDays(-2) },
		new Product { Id = 4, Name = "Samsung Galaxy S24", Price = 849.99m, CreatedDate = DateTime.Now.AddDays(-7) },
		new Product { Id = 5, Name = "MacBook Pro 14", Price = 1999.00m, CreatedDate = DateTime.Now.AddDays(-15) },
		new Product { Id = 6, Name = "Surface Pro 9", Price = 1099.99m, CreatedDate = DateTime.Now.AddDays(-3) },
		new Product { Id = 7, Name = "AirPods Pro 2", Price = 249.99m, CreatedDate = DateTime.Now.AddDays(-1) },
		new Product { Id = 8, Name = "Sony WH-1000XM5", Price = 399.99m, CreatedDate = DateTime.Now.AddDays(-8) }
};
		}

		public IActionResult List()
		{
			return View(_products);
		}

		public IActionResult Table()
		{
			return View(_products);
		}

		public IActionResult Details(int id)
		{
			var product = _products.FirstOrDefault(p => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		public IActionResult Search(string query)
		{
			var searchResults = _products;
			if (!string.IsNullOrEmpty(query))
			{
				searchResults = _products.Where(p => p.Name != null && p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
			}
			return View("List", searchResults);
		}
	}
}