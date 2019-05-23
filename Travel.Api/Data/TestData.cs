using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Api.Models;

namespace Travel.Api
{
	/// Test Travel Data 
	public class TestData
	{
		public List<Booking> Bookings { get; set; }
		public List<Product> Products { get; set; }
		public List<ClientAccess> ClientAccess { get; set; }
		public static TestData Current = new TestData();

		public TestData()
		{
			// access 
			this.ClientAccess = new List<ClientAccess>()
			{
				new ClientAccess() { Name = "ReadOnlyClient",	ApiKey = "F47978ABEE234A628B77FDE182EA2038", Roles = new List<string>() { "api.access" } },
				new ClientAccess() { Name = "UpdateClient",		ApiKey = "C6DFA0B215B2CF24EF04794F718A3FC8", Roles = new List<string>() { "api.access", "api.update" } }
			};

			// product data
			this.Products = new List<Product>()
			{
				new Product()  { ProductNumber= 1001,  Name = "BOUT EARLY BIRD",       Price = 26.54m, Savings = 0m, Available = true, Description = "Ticket Includes: One Regular Park Admission Welcome to Canada's Wonderland",
					Availability = new List<AdmissionDate>()
					{
						new AdmissionDate() { Available = true, Date = DateTime.Today.AddDays(1), Price = 26.54m, Savings = 0m },
						new AdmissionDate() { Available = true, Date = DateTime.Today.AddDays(2), Price = 26.54m, Savings = 0m },
						new AdmissionDate() { Available = true, Date = DateTime.Today.AddDays(3), Price = 26.54m, Savings = 0m },
						new AdmissionDate() { Available = true, Date = DateTime.Today.AddDays(4), Price = 26.54m, Savings = 0m },
						new AdmissionDate() { Available = true, Date = DateTime.Today.AddDays(5), Price = 26.54m, Savings = 0m }
					},
					Media = new List<MediaObject>()
					{
					   new MediaObject() { MediaType = MediaType.Image, Url = "//cdn-cloudfront.cfauthx.com/binaries/content/gallery/cw-en-ca/products/daily-tickets/cw-dailyadmissiontickets-vi-ticketlistingv2.jpg" }
					}
				},
				new Product()  { ProductNumber= 1002,  Name = "BOUT REGULAR",          Price = 32.76m, Savings = 0m, Available = false },
				new Product()  { ProductNumber= 1101,  Name = "CAT SPRING REG ADM-P",  Price = 27.69m, Savings = 0m, Available = false },
				new Product()  { ProductNumber= 1102,  Name = "CAT SPRING JS ADM-P",   Price = 27.69m, Savings = 0m, Available = false },
				new Product()  { ProductNumber= 1201,  Name = "CAT SUMMER REG ADM-P",  Price = 31.08m, Savings = 0m, Available = false },
				new Product()  { ProductNumber= 1202,  Name = "CAT SUMMER JS ADM-P",   Price = 31.08m, Savings = 0m, Available = false },
				new Product()  { ProductNumber= 1301,  Name = "CAT FALL REG ADM-P",    Price = 27.69m, Savings = 0m, Available = false },
				new Product()  { ProductNumber= 1302,  Name = "CAT FALL JS ADM-P",     Price = 27.69m, Savings = 0m, Available = false },
				new Product()  { ProductNumber= 2401,  Name = "GAD REG",               Price = 43m,    Savings = 0m, Available = false },
				new Product()  { ProductNumber= 2402,  Name = "GAD JS",                Price = 38m,    Savings = 0m, Available = false },
				new Product()  { ProductNumber= 3305,  Name = "SD Group Sales Parking",Price = 20m,    Savings = 0m, Available = false },
				new Product()  { ProductNumber= 4501,  Name = "GAD LGAD FALL REG",     Price = 39m,    Savings = 0m, Available = false }
			};

			// Test bookings
			this.Bookings = new List<Booking>()
			{
				new Booking()
				{
					OrderId = "TEST-0000",
					Customer = new Customer() { FirstName = "Test", LastName = "Customer"  },
					Items = new List<BookingItem>()
					{
						new BookingItem() { ProductNumber = 1001, Quantity = 1,
							Tickets =	new List<Ticket>()
							{
								 new Ticket()
								 {
									TicketNumber = "40311219705414559359",
									Barcode = Guid.NewGuid().ToString(),
									Instructions = "1. PRESENT THIS E-TICKET AT THE MAIN ENTRANCE: This e-ticket contains a unique barcode valid for one entry only to Canada’s Wonderland on the date specified on this ticket. Valid for everyone aged 3 years and over 2. GO DIRECTLY TO THE TURNSTILES AT THE FRONT GATE: Please note that you do not need to go to the Admission Sales windows or Guest Services windows. ENJOY YOUR DAY AT CANADA’S WONDERLAND",
									Terms = "Not valid in conjunction with any other discount offer. Not for resale. Cedar Fair reserves the right to refuse admission and control occupancy. Holder assumes all risk of personal injury and loss of property, agrees to the posted conditions of usage, rider safety guidelines and ride admission policies and grants Cedar Fair permission to use his/her photograph or video image in any advertising and promotion without payment to holder. No rain checks, refunds, exchanges or replacements if lost or stolen. Not valid for separately ticketed events or special events. Not valid for Halloween Haunt or WinterFest. Some attractions require an additional charge. Height and physical restrictions may apply on some rides. Please visit the park’s website or call the park to confirm operating dates and hours and learn more about park rules, ride admission policies and rider safety guidelines. Picnic baskets and coolers are welcome at the pavilion located outside Wonderland near the Main Entrance. With the exception of plastic water bottles, outside food and beverages are not allowed in the park"
								}
							}
						}
					}
				}
			};
		}
	}
}
