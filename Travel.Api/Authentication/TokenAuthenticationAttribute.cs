using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Travel.Api.Models;

namespace Travel.Api
{

	/// Authenticate using api_key in header or query string
	public class TokenAuthenticationAttribute : Attribute, IAuthenticationFilter
	{
		public TokenAuthenticationAttribute() { }

		public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			var request = context.Request;

			// look for token
			var parameter = GetToken(context, "api_key");
			if (!string.IsNullOrWhiteSpace(parameter))
			{
				// find matching client
				var client = TestData.Current.ClientAccess.Find(x => x.ApiKey == parameter);

				if (client != null)
				{
					// create identity for client
					var identity = new CleintIdentity(client.Name, "Token", client);

					// create principal with identity and roles
					context.Principal = new GenericPrincipal(identity, client.Roles.ToArray());

					return Task.FromResult(0);
				}
			}

			// Not Authorized
			context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
			return Task.FromResult(0);
		}
		

		public string GetToken(HttpAuthenticationContext context, string key)
		{
			var headers = context.Request.Headers;

			// get token from header
			var header = headers.FirstOrDefault(x => x.Key == key);
			if (header.Value != null)
			{
				return header.Value.FirstOrDefault();
			}

			// get token from request
			var list = context.Request.GetQueryNameValuePairs().ToList();
			string token = null;
			if (list.Any(x => string.Compare(x.Key, key, true) == 0))
			{
				var obj = list.Find(x => string.Compare(x.Key, key, true) == 0);
				token = obj.Value;
			}

			return token;
		}

		public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			//context.Result = new ResultWithChallenge(context.Result);
			return Task.FromResult(0);
		}

		public bool AllowMultiple { get { return false; } }
	}
}