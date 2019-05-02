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
	[RoutePrefix("api/example/v1/products")]
	public class ExampleProductsController : ApiController
	{
		[HttpGet, Route("list")]
		[TokenAuthentication()]
		[Authorize(Roles="api.access")]
		public ProductResponse List()
		{
			var response = new ProductResponse();

			response.Products = TravelData.Current.Products;

			return response;
		}
	}		
}