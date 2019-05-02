using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Api.Shared
{
	public class CryptographyHelper
	{
		public static string Base64Encode(string plainText)
		{
			var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
			return System.Convert.ToBase64String(plainTextBytes);
		}

		public static string Base64Decode(string base64EncodedData)
		{
			var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
			return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
		}

		public static string CreateClientSecret()
		{
			using (var cryptoProvider = new RNGCryptoServiceProvider())
			{
				byte[] secretKeyByteArray = new byte[32]; //256 bit
				cryptoProvider.GetBytes(secretKeyByteArray);
				var APIKey = Convert.ToBase64String(secretKeyByteArray);
				return APIKey;
			}
		}
	}
}
