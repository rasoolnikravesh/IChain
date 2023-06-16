using System.Text;

namespace Utility;

public class HexUtility
{
	public static string ByteToString(byte[] bytes)
	{
		StringBuilder builder = new();
		foreach (byte b in bytes)
			builder.Append(b.ToString("x2"));

		return builder.ToString();
	}

	
}