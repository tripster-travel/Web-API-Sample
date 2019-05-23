using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Travel.Api.Models
{
	public class Product
	{
		public int ProductNumber { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Savings { get; set; }
		public bool Available { get; set; }
		public List<AdmissionDate> Availability { get; set; }
		public List<MediaObject> Media { get; set; }

		public Product()
		{
			this.Availability = new List<AdmissionDate>();
			this.Media = new List<MediaObject>();
		}
	}

	public enum MediaType { Image, Video }

	public class MediaObject
	{
		public string Title { get; set; }
		public string Url { get; set; }
		public MediaType MediaType { get; set; }
		public MediaObject() { }
	}

	public class AdmissionDate
	{
		public DateTime Date { get; set; }
		public decimal Price { get; set; }
		public decimal Savings { get; set; }
		public bool Available { get; set; }
		public AdmissionDate() { }
	}

	public class ProductResponse
	{
		public List<Product> Products { get; set; }
		public ProductResponse()
		{
			this.Products = new List<Product>();
		}
	}
}