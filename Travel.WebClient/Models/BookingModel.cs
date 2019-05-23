using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.WebClient
{
	public class BookingModel
	{
		public int ProductNumber { get; set; }
		public int Quantity { get; set; }
		public string Email { get; set; }

		public Booking Booking { get; set; }
	}
}