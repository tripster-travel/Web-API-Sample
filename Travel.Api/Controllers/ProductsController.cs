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

		/// <summary>
		/// Get All Products
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("")]
		public List<Product> List()
		{
			// create response
			var products = TestData.Current.Products;

			return products;
		}

		/// <summary>
		/// Get Single Product
		/// </summary>
		/// <param name="productNumber"></param>
		/// <returns></returns>
		[HttpGet, Route("{productNumber}")]
		public List<Product> Detail(int productNumber)
		{
			// create response
			var products = TestData.Current.Products.FindAll(x => x.ProductNumber == productNumber);

			return products;
		}
	}		
}