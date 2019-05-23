using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Travel.Api.Models
{
	public partial class ClientAccess 
	{
		public string Name { get; set; }
		public string ApiKey { get; set; }
		public bool Active { get; set; }
		public List<string> Roles { get; set; }

		public ClientAccess()
		{
			this.Roles = new List<string>();
			this.Active = true;
		}
	}

	public class CleintIdentity : GenericIdentity
	{
		public ClientAccess Client { get; set; }

		public CleintIdentity(string name, ClientAccess client) : base(name)
		{
			Client = client;
		}
		public CleintIdentity(string name, string type, ClientAccess client) : base(name, type)
		{
			Client = client;
		}
	}
}
