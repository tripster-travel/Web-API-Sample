using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Travel.WebClient
{
	partial class TravelApi
	{
		public TravelApi() : this("https://travel-web-api.azurewebsites.net/", new HttpClient())
		{
			this.BaseUrl = "https://travel-web-api.azurewebsites.net/";

            // add auth header
            _httpClient.DefaultRequestHeaders.Add("api_key", "C6DFA0B215B2CF24EF04794F718A3FC8");
		}
	}
}