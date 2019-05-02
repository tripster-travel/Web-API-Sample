using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Api.Models
{
	public class ProductResponse
	{
		public List<ProductItem> Products { get; set; }

		public ProductResponse()
		{
			this.Products = new List<ProductItem>();
		}
	}
}