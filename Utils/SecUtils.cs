using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Management;

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

		public static void RSA(out byte[] pub, out byte[] priv)
		{
			RSA(out pub, out priv, new RSACryptoServiceProvider(512));
		}
		
		public static void RSA(out byte[] pub, out byte[] priv, RSACryptoServiceProvider rsa)
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

		public static String CryptString(String szData)
		{
			String res = SecUtils.md5(szData);

			res += SecUtils.md5(res).Substring(0, 10);

			int n = res.Length % 5;
			if (n != 0)
			{
				res = res.Substring(0, res.Length - n);
			}

			res = Regex.Replace(res, ".{5}", "$0-");
			res = res.Substring(0, res.Length - 1);

			return res;
		}

		public static String SerialNumber
		{
			get
			{
				String sn = String.Empty;
				ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
				scope.Connect();
				ManagementObject wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions());

				foreach (PropertyData propData in wmiClass.Properties)
				{
					if (propData.Name == "SerialNumber")
						sn = Convert.ToString(propData.Value);
				}

				return sn;
			}
		}
	}
}
