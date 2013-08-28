using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace AY.Utils
{
	public class SecUtils
	{
		public static string md5(string input)
		{
			// step 1, calculate MD5 hash from input
			MD5 md5 = MD5.Create();
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);

			// step 2, convert byte array to hex string
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}

			return sb.ToString();
		}

		public static void RSA(ref byte[] pub, ref byte[] priv)
		{
			RSA(ref pub, ref priv, new RSACryptoServiceProvider());
		}
		
		public static void RSA(ref byte[] pub, ref byte[] priv, RSACryptoServiceProvider rsa)
		{
			if(rsa == null)
				rsa = new RSACryptoServiceProvider();
				
			pub = rsa.ExportCspBlob(false);
			priv = rsa.ExportCspBlob(true); 
		}

		public static byte[] Encrypt(byte[] pubKey, byte[] data)
		{
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
			rsa.ImportCspBlob(pubKey);
			return rsa.Encrypt(data, false);
		}

		public static byte[] Decrypt(byte[] privKey, byte[] data)
		{
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
			rsa.ImportCspBlob(privKey);
			byte[] x = rsa.Decrypt(data, false);
			return x;
		}
	}
}
