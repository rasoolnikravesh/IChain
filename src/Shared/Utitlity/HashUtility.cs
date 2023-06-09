using System.Security.Cryptography;
using System.Text;

namespace Utility
{
	public class HashUtility
	{
		public static string ComputeSha256Hash(string rawData)
		{
			using SHA256 sha256Hash = SHA256.Create();

			byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

			// Convert byte array to a string
			StringBuilder builder = new();
			foreach (byte b in bytes)
				builder.Append(b.ToString("x2"));

			return builder.ToString();
		}
	}
}
