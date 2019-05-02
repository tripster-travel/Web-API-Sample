using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Api.Models
{
	public class Booking
	{
		public string Status { get; set; }
		public string OrderId { get; set; }
		public DateTime Arrival { get; set; }
		public DateTime Departure { get; set; }
		public Customer Customer { get; set; }
		public List<Item> Items { get; set; }
		public string Comments { get; set; }
	}
}
	
