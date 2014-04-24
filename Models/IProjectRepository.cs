using System;
using System.Collections.Generic;

namespace Cuppster.WebApiExample.Models
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAllProducts ();

		Product GetProduct (string id);
	}
}

