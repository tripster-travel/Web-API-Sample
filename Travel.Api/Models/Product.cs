using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Travel.Api.Models
{
	public class ProductItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Savings { get; set; }
		public string Type { get; set; }
		public bool Available { get; set; }
		public List<AdmissionDate> Calendar { get; set; }
		public List<MediaObject> Media { get; set; }

		public ProductItem()
		{
			this.Calendar = new List<AdmissionDate>();
		}
	}
}