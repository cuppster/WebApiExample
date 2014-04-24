using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization.Conventions;

namespace Cuppster.WebApiExample.Models
{
	public class ProductMongoDBRepository : IProductRepository
	{
		MongoCollection<Product> _products;

		public ProductMongoDBRepository ()
		{
			// fields whould start with lower-case
			var camelCaseConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
			ConventionRegistry.Register("CamelCase", camelCaseConventionPack, type => true);

			// setup connections
			var connection = "mongodb://localhost:27017";
			var client = new MongoClient(connection);
			var server = client.GetServer();
			var database = server.GetDatabase ("Products");

			// collection
			_products = database.GetCollection<Product> ("products");

			// init
			_products.RemoveAll ();

			// mock products
			Product[] mockProducts = new Product[] { 
				new Product { Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
				new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
				new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M } 
			};

			// add mock products to collection
			foreach (var product in mockProducts) {
				AddProduct (product);
			}
		}

		public Product AddProduct (Product item)
		{
			item.Id = ObjectId.GenerateNewId ().ToString ();	
			_products.Insert (item);
			return item;
		}

		public IEnumerable<Product> GetAllProducts ()
		{
			return _products.FindAll();
		}

		public Product GetProduct (string id)
		{
			IMongoQuery query = Query.EQ("_id", id);
			return _products.Find(query).FirstOrDefault();
		}
	}

}

