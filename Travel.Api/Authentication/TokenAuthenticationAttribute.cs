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
using Travel.Api.Shared;

namespace Travel.Api
{
	public class TokenAuthenticationAttribute : Attribute, IAuthenticationFilter
	{
		public TokenAuthenticationAttribute() { }

		public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			var request = context.Request;

			string scheme = "Token";
			string parameter = null;
			ClientAccess client = null;

			if (request.Headers.Authorization != null)
			{
				scheme = request.Headers.Authorization.Scheme;
				parameter = context.Request.Headers.Authorization.Parameter;

				// look for client
				if (!string.IsNullOrWhiteSpace(parameter))
				{
					client = TestData.Current.ClientAccess.Find(x => x.AuthValueEncoded == parameter || x.AuthValue == parameter);
				}
			}
			else
			{
				parameter = GetApiKey(context);
				if (!string.IsNullOrWhiteSpace( parameter))
				{
					client = TestData.Current.ClientAccess.Find(x => x.AuthType == AuthTypeEnum.Token && x.ApiKey != null && x.ApiKey == parameter);
				}
			}
			

			// Check for client
			if (client != null)
			{
				string ip = request.GetClientIpAddress();
				
				// create identity for client
				var identity = new CleintIdentity(client.Username, scheme, client);

				// create principal with identity and roles
				context.Principal = new GenericPrincipal(identity, client.Roles.ToArray());

				return Task.FromResult(0);
			}

			// Not Authorized
			context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);

			return Task.FromResult(0);
		}

		public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			context.Result = new ResultWithChallenge(context.Result);
			return Task.FromResult(0);
		}

		public bool AllowMultiple
		{
			get { return false; }
		}


		public string GetApiKey(HttpAuthenticationContext context)
		{
			var headers = context.Request.Headers;

			var test = headers.FirstOrDefault(x => x.Key == "api_key");
			if (test.Value != null)
			{
				return test.Value.FirstOrDefault();
			}

			var list = context.Request.GetQueryNameValuePairs().ToList();
			string token = null;
			// look for api key
			if (list.Any(x => string.Compare(x.Key, "api_key", true) == 0))
			{
				var obj = list.Find(x => string.Compare(x.Key, "api_key", true) == 0);
				token = obj.Value;
			}
			return token;
		}
	}

	public class CleintIdentity : GenericIdentity
	{
		public ClientAccess Client { get; set; }

		public CleintIdentity(string name, ClientAccess client)
			: base(name)
		{
			Client = client;
		}

		public CleintIdentity(string name, string type, ClientAccess client)
			: base(name, type)
		{
			Client = client;
		}
	}

	public class ResultWithChallenge : IHttpActionResult
	{
		private readonly string authenticationScheme = "Basic";
		private readonly IHttpActionResult next;

		public ResultWithChallenge(IHttpActionResult next)
		{
			this.next = next;
		}

		public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			var response = await next.ExecuteAsync(cancellationToken);

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(authenticationScheme));
			}

			return response;
		}
	}
}
