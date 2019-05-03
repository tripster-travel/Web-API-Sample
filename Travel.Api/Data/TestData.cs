using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Api.Models;

namespace Travel.Api
{
	/// <summary>
	/// Test Travel Data 
	/// </summary>
	public class TestData
	{
		public static TestData Current { get { return new TestData(); } }
		public List<ProductItem> Products { get; set; }
		public List<ClientAccess> ClientAccess { get; set; }

		public TestData()
		{
			// access 
			this.ClientAccess = new List<ClientAccess>()
			{
				new ClientAccess() { Username = "test", ApiKey = "C6DFA0B215B2CF24EF04794F718A3FC8", AuthType = AuthTypeEnum.Token, Roles = new List<string>() { "api.access" } }
			};

			// product data
			this.Products = new List<ProductItem>()
			{
				new ProductItem()  { ProductCode = "ANYDAY", Available = true, Name = "Any Day Ticket", Price = 46.00m, Savings = 19.02m },
				new ProductItem()  { ProductCode = "2DAY", Available = true, Name = "Two Day Ticket - Pay Once Visit Twice", Price = 56.81m, Savings = 9.19m }
			};

			foreach (var item in this.Products)
			{
				for (int i = 0; i < 100; i++)
				{
					var date = new AdmissionDate()
					{
						Available = true,
						Price = 45.98m,
						Date = DateTime.Today.AddDays(i),
						Times = new List<AdmissionTime> {
							new AdmissionTime() { Time = new TimeSpan(12, 00, 0),  Available = true, },
							new AdmissionTime() { Time = new TimeSpan(16, 00, 0), Available = true   },
						}
					};
				}
			}
		}
	}
}
