using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Api.Models
{
	public class Booking
	{
		public string OrderId { get; set; }
		public string Status { get; set; }
		public Customer Customer { get; set; }
		public List<BookingItem> Items { get; set; }
		public Booking()
		{
			this.Items = new List<BookingItem>();
		}
	}

	public class BookingItem
	{
		public int ProductNumber { get; set; }
		public int Quantity { get; set; }
		public DateTime? UseDate { get; set; }
		public List<Ticket> Tickets { get; set; }
		public BookingItem()
		{
			this.Tickets = new List<Ticket>();
		}
	}

	public class Ticket
	{
		public string TicketNumber { get; set; }
		public string Barcode { get; set; }
		public string Instructions { get; set; }
		public string Terms { get; set; }
	}

	public class Customer
	{
		public string Email { get; set; }
		public string Phone { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

	//public class BookingRequest
	//{
	//	public Booking Booking { get; set; }
	//}

	//public class BookingResponse
	//{
	//	public Booking Booking { get; set; }
	//}
}