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
					client = TravelData.Current.ClientAccess.Find(x => x.AuthValue == parameter);
				}
			}
			else
			{
				parameter = GetApiKey(context);
				if (!string.IsNullOrWhiteSpace( parameter))
				{
					client = TravelData.Current.ClientAccess.Find(x => x.AuthType == AuthTypeEnum.Token && x.ApiKey != null && x.ApiKey == parameter);
				}
			}
			

			// Check for client
			if (client != null)
			{
				string ip = request.GetClientIpAddress();

				// Default roles
				List<string> roles = new List<string>() { "api.access", "api.public.access" };
				roles.AddRange(client.Roles);

				// Create user / principal using roles
				//var currentPrincipal = new GenericPrincipal(new GenericIdentity(client.ClientId), roles.ToArray());

				string username = client.Username;

				// create identity for client
				var identity = new CleintIdentity(username, scheme, client);

				// create principal with identity and roles
				context.Principal = new GenericPrincipal(identity, roles.ToArray());

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

		///// <summary>
		///// Check Token Auth Header: https://tools.ietf.org/html/draft-hammer-http-token-auth-01
		/////	Authorization: Token token="h480djs93hd8", coverage="base",	 timestamp="137131200",	 nonce="dj83hs9s", auth="djosJKDKJSD8743243/jdk33klY="
		/////	Authorization: Token "h480djs93hd8"
		///// </summary>
		///// <param name="context"></param>
		///// <returns></returns>
		//public ClientAccess CheckTokenAuth(HttpAuthenticationContext context)
		//{
		//	var tokens = TravelData.Current.ClientAccess;
		//	var authHeader = context.Request.Headers.Authorization.Parameter;

		//	if (!string.IsNullOrEmpty(authHeader))
		//	{
		//		var autherizationHeaderArray = authHeader.Split(',');
		//		if (autherizationHeaderArray.Any())
		//		{
		//			string token = null;

		//			foreach (var item in autherizationHeaderArray)
		//			{
		//				token = item;
		//			}

		//			if (!string.IsNullOrWhiteSpace(token))
		//			{
		//				return tokens.Find(x => token.Equals(x.AuthToken, StringComparison.OrdinalIgnoreCase));
		//			}
		//		}
		//	}
		//	return null;
		//}


		public string GetApiKey(HttpAuthenticationContext context)
		{
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


		//public ClientAccess CheckTokenProperty(HttpAuthenticationContext context)
		//{
		//	var tokens = TravelData.Current.ClientAccess;

		//	var list = context.Request.GetQueryNameValuePairs().ToList();

		//	string token = null;

		//	// look for api key
		//	if (list.Any(x => string.Compare(x.Key, "api_key", true) == 0))
		//	{
		//		var obj = list.Find(x => string.Compare(x.Key, "api_key", true) == 0);
		//		token = obj.Value;
		//	}

		//	if (!string.IsNullOrWhiteSpace(token))
		//	{
		//		return tokens.Find(x => token.Equals(x.ApiKey, StringComparison.OrdinalIgnoreCase));
		//	}

		//	return null;
		//}

		///// <summary>
		///// Check Basic Auth Header
		///// Authorization: Basic base64encodeed(login:password)
		///// </summary>
		///// <param name="context"></param>
		///// <returns></returns>
		//public ClientAccess CheckBasicAuth(HttpAuthenticationContext context)
		//{
		//	var authHeader = context.Request.Headers.Authorization.Parameter;

		//	try
		//	{
		//		if (!string.IsNullOrWhiteSpace(authHeader))
		//		{

		//			string decodedString = Encoding.Default.GetString(Convert.FromBase64String(authHeader));

		//			// decode base 64	
		//			//string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader));

		//			// split login & pass
		//			string[] list = decodedString.Split(':');

		//			if (list.Length == 1)
		//			{
		//				var tokens = TravelData.Current.ClientAccess;

		//				string login = list[0];

		//				Guid authToken;
		//				if (Guid.TryParse(login, out authToken))
		//				{
		//					return tokens.Find(x => x.ClientToken == authToken);
		//				}

		//				// find matching token
		//				//return tokens.Find(x => x.ClientId.Equals(login, StringComparison.OrdinalIgnoreCase));
		//			}

		//			if (list.Length == 2)
		//			{
		//				string login = list[0];
		//				string password = list[1];

		//				var tokens = TravelData.Current.ClientAccess;

		//				// find matching token
		//				return tokens.Find(x => x.ClientId.Equals(login, StringComparison.OrdinalIgnoreCase) && x.ClientSecret.Equals(password));
		//			}

		//		}
		//	}
		//	catch
		//	{
		//		return null;
		//	}

		//	return null;
		//}
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
