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
		public string Comments { get; set; }
		public DateTime Arrival { get; set; }
		public DateTime Departure { get; set; }
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
		public DateTime StartTimeLocal { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }
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
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public Address Address { get; set; }
	}

	public class Address
	{
		public string Street { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
	}

	public class BookingRequest
	{
		public Booking Booking { get; set; }
	}

	public class BookingResponse
	{
		public Booking Booking { get; set; }
	}
}