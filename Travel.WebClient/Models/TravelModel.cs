using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.WebClient
{
	public class TravelModel
	{
		public List<Product> Products { get; set; }
		public List<Booking> Bookings { get; set; }

		public TravelModel()
		{
			this.Products = new List<Product>();
			this.Bookings = new List<Booking>();
		}
	}
}