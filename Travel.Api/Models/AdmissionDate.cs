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
		public bool Available { get; set; }
		public TimeSpan? Open { get; set; }
		public TimeSpan? Close { get; set; }
		public decimal Rate { get; set; }
		public decimal BaseRate { get; set; }
		public List<AdmissionTime> Times { get; set; }

		public AdmissionDate()
		{
			this.Times = new List<AdmissionTime>();
		}
	}
}
