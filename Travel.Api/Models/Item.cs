using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Api.Models
{
	public class Item
	{
		public string ProductCode { get; set; }
		public DateTime StartTimeLocal { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }
	}
}
