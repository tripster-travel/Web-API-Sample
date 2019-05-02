using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Api.Models
{
	public class AdmissionTime
	{
		public TimeSpan Time { get; set; }
		public bool Available { get; set; }
		public string ProductUrl { get; set; }
		public AdmissionTime() { }
	}
}
