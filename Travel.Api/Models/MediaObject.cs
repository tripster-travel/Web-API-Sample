using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Api.Models
{
	public enum MediaType { Image, Video }

	public class MediaObject
	{
		public int MediaId { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public MediaType MediaType { get; set; }
		public MediaObject() { }
	}
}