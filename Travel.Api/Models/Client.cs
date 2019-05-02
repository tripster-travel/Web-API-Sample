using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Api.Shared;

namespace Travel.Api.Models
{
	public enum AuthTypeEnum { Basic, Token }

	public partial class ClientAccess 
	{
		public bool Active { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string ApiKey { get; set; }
		public AuthTypeEnum AuthType { get; set; }

		// auth 
		public string AuthValue { get { return AuthType == AuthTypeEnum.Basic ? AuthBasic : AuthToken; } }
		// login / password basic auth
		private string AuthBasic { get { return CryptographyHelper.Base64Encode(this.Username + ":" + this.Password); } }
		private string AuthToken { get { return this.ApiKey == null ? null : CryptographyHelper.Base64Encode(this.ApiKey); } }

		public List<string> Roles { get; set; }

		public ClientAccess()
		{
			this.Roles = new List<string>();
			this.Active = true;
		}

		public ClientAccess(string username, string apiKey, AuthTypeEnum authType = AuthTypeEnum.Token)
		{
			this.Username = username;
			this.ApiKey = apiKey;
			this.AuthType = authType;
		}
	}
}
