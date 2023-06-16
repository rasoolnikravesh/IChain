using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Utility
{
	public class Account
	{
		private readonly RSA _rsa;

		public Account(int keySize)
		{
			_rsa = RSA.Create(keySize);
		}

		public Account()
		{
			_rsa = RSA.Create();

		}


		public Account SetPrivateKey(string privateKeyHex)
		{
			_rsa.ImportRSAPrivateKey(new ReadOnlySpan<byte>(Convert.FromHexString(privateKeyHex)), out _);
			return this;
		}

		public Account SetPublicKey(string publicKeyHex)
		{
			_rsa.ImportRSAPublicKey(new ReadOnlySpan<byte>(Convert.FromHexString(publicKeyHex)), out _);
			return this;
		}

		public string GetPrivateKey() => HexUtility.ByteToString(_rsa.ExportRSAPrivateKey());

		public string GetPublicKey() => HexUtility.ByteToString(_rsa.ExportRSAPublicKey());

		public string GetAddress()
		{
			using SHA256 sha = SHA256.Create();
			var publicHash = sha.ComputeHash(_rsa.ExportRSAPublicKey());
			publicHash = sha.ComputeHash(publicHash);
			var publicHashStr = HexUtility.ByteToString(publicHash);
			var accountAddress = publicHashStr[16..];
			return Convert.ToBase64String(Convert.FromHexString(accountAddress));
		}

		public string Decrypt(string data)
		{

			var dataByte = Convert.FromHexString(data);

			var decryptedByte = _rsa.Decrypt(dataByte, RSAEncryptionPadding.Pkcs1);
			return Encoding.UTF8.GetString(decryptedByte);
		}

		public string Encrypt(string data)
		{
			var dataToEncrypt = Encoding.UTF8.GetBytes(data);
			var encryptedByteArray = _rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1).ToArray();
			return HexUtility.ByteToString(encryptedByteArray);
		}

		
		public (string sign, string publicKey) Sign(string data)
		{
			var dataBytes = Encoding.UTF8.GetBytes(data);
			using SHA256 sha = SHA256.Create();
			var dataHash = sha.ComputeHash(dataBytes);
			var sign = _rsa.SignHash(dataHash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
			return (HexUtility.ByteToString(sign), GetPublicKey());
		}

		public bool VerifySign(string data, string sign)
		{
			var dataBytes = Encoding.UTF8.GetBytes(data);
			using SHA256 sha = SHA256.Create();
			var dataHash = sha.ComputeHash(dataBytes);

			var signBytes = Convert.FromHexString(sign);
			return _rsa.VerifyHash(new ReadOnlySpan<byte>(dataHash),
				new ReadOnlySpan<byte>(signBytes),
				HashAlgorithmName.SHA256,
				RSASignaturePadding.Pkcs1);
		}


		public static string DecryptWithPrivateKey(string data, string privateKey)
		{
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
			rsa.ImportRSAPrivateKey(new ReadOnlySpan<byte>(Convert.FromHexString(privateKey)), out _);
			var dataByte = Convert.FromHexString(data);

			var decryptedByte = rsa.Decrypt(dataByte, false);
			return Encoding.UTF8.GetString(decryptedByte);

		}

		public static string EncryptWithPublicKey(string data, string publicKey)
		{
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
			rsa.ImportRSAPublicKey(new ReadOnlySpan<byte>(Convert.FromHexString(publicKey)), out _);
			var dataToEncrypt = Encoding.UTF8.GetBytes(data);
			var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();

			return HexUtility.ByteToString(encryptedByteArray);
		}

	}
}
