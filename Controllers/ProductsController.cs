using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Cors;
using Cuppster.WebApiExample.Models;
using Cuppster.WebApiExample.Security;

namespace Cuppster.WebApiExample.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class ProductsController : ApiController
    {
        private static readonly IProductRepository _products = new ProductMongoDBRepository();

        [Route("products")]
        public IEnumerable<Product> GetAllProducts()
        {
            return _products.GetAllProducts();
        }

        [Route("products/{id}")]
        [BasicAuthenticationFilter]
        public IHttpActionResult GetProduct(string id)
        {
            var product = _products.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        //		public HttpResponseMessage PostProduct(Product item)
        //		{
        //			item = repository.Add(item);
        //			var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);
        //
        //			string uri = Url.Link("DefaultApi", new { id = item.Id });
        //			response.Headers.Location = new Uri(uri);
        //			return response;
        //		}
    }
}
