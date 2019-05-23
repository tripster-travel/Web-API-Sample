using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.WebClient
{
	public class TravelApixception : System.Exception
	{
		public TravelApixception() : base() { }
		public TravelApixception(string message) : base(message) { }
		public TravelApixception(string message, Exception innerException) : base(message, innerException) { }

		public string StatusCode { get; private set; }
		public string Response { get; private set; }
		public System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

		public TravelApixception(string message, string statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
			: base(message, innerException)
		{
			StatusCode = statusCode;
			Response = response;
			Headers = headers;
		}

		public override string ToString()
		{
			return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
		}
	}


	public class TravelApixception<TResult> : TravelApixception
	{
		public TResult Result { get; private set; }

		public TravelApixception(string message, string statusCode, string response, System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
			: base(message, statusCode, response, headers, innerException)
		{
			Result = result;
		}
	}
}