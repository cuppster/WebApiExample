using System;
using System.Collections.Generic;
using System.Linq;

namespace Cuppster.WebApiExample.Models
{
	public class ProductMockRepository : IProductRepository
	{
		Product[] _products = new Product[] { 
			new Product { Id = "1", Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
			new Product { Id = "2", Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
			new Product { Id = "3", Name = "Hammer", Category = "Hardware", Price = 16.99M } 
		};

		public IEnumerable<Product> GetAllProducts ()
		{
			return _products;
		}

		public Product GetProduct (string id)
		{
			return _products.FirstOrDefault ((p) => p.Id == id);
		}
	}
}

