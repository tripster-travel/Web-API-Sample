using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Api.Models;

namespace Travel.Api
{
	public class TravelData
	{
		public static TravelData Current { get { return new TravelData(); } }

		public List<ProductItem> Products { get; set; }

		public List<ClientAccess> ClientAccess { get; set; }

		public TravelData()
		{
			this.ClientAccess = new List<ClientAccess>()
			{
				new ClientAccess("	", ""),
				new ClientAccess("", "")
			};

			this.Products = new List<ProductItem>()
			{
				new ProductItem()
				{
					Available = true,
					Name = "Test",
					Price = 100
				}
			};

			foreach (var item in this.Products)
			{
				for (int i = 0; i < 100; i++)
				{
					var date = new AdmissionDate()
					{
						Available = true,
						Rate = 100,
						Date = DateTime.Today.AddDays(i),
						Times = new List<AdmissionTime> {
							 new AdmissionTime(){
								  Time = new TimeSpan(12, 30, 0),
								  Available = true
							 },
							 new AdmissionTime(){
								  Time = new TimeSpan(1, 00, 0),
								  Available = true,
							 }
						}
					};
				}
			}
		}
	}
}
