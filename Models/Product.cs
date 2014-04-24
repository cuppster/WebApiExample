using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Cuppster.WebApiExample.Models
{

	public class Product
	{
		[BsonId]
		public string Id { get; set; }

		public string Name { get; set; }

		public string Category { get; set; }

		public decimal Price { get; set; }
	}
}
	