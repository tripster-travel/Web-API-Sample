using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Api.Models
{
	public class AdmissionDate
	{
		public DateTime Date { get; set; }
		public decimal Price { get; set; }
		public decimal Savings { get; set; }
		public bool Available { get; set; }
		public List<AdmissionTime> Times { get; set; }

		public AdmissionDate()
		{
			this.Times = new List<AdmissionTime>();
		}
	}
}
