using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Text;
using Travel.Api.Models;

namespace Travel.Api.Models.Controllers
{
	[RoutePrefix("api/products")]
	public class ProductsController : ApiController
	{
		[HttpGet, Route("list")]
		public ProductResponse List()
		{
			var response = new ProductResponse();

			response.Products = TestData.Current.Products;

			return response;
		}
	}		
}