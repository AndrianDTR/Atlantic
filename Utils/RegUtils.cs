using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Management;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace AY.Utils
{
	public class RegUtils
	{
		public enum DataOffsets
		{
			Data = 8,
			Serial = 128,
			PubKey = 1024,
			PrivKey = 3072,
			ActKey = 1024,
		}
		
		private static RegistryKey GetAppKey()
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			GuidAttribute guid = (GuidAttribute)asm.GetCustomAttributes(typeof(GuidAttribute), true)[0];
			String subKey = "Software\\" + guid.Value;
			return Registry.LocalMachine.CreateSubKey(subKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
		}
		
		public static byte[] RegData
		{
			get
			{
				byte[] data = null;
				
				try
				{
					RegistryKey key = GetAppKey();
					data = (byte[])key.GetValue(@"data");
				}
				catch (System.Exception)
				{
				}
				
				return data;
			}
			set
			{
				RegistryKey key = GetAppKey();
				key.SetValue(@"data", value, RegistryValueKind.Binary);
			}
		}

		public static String GetSerialNumber()
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

		public static String CryptSerialNumber(String serial)
		{
			String sn = SecUtils.md5(serial);

			sn += SecUtils.md5(sn).Substring(0, 10);

			int n = sn.Length % 5;
			if (n != 0)
			{
				sn = sn.Substring(0, sn.Length - n);
			}

			sn = Regex.Replace(sn, ".{5}", "$0-");
			sn = sn.Substring(0, sn.Length - 1);

			return sn;
		}

		public static String GetSerialNumberCrypted()
		{
			String serial = GetSerialNumber();
			return CryptSerialNumber(serial);
		}

		public static String RandomString(int size)
		{
			Random random = new Random(Environment.TickCount);
			var data = new byte[size];
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = (byte)random.Next(32, 127);
			}
			var encoding = new ASCIIEncoding();
			return encoding.GetString(data);
		}

		public static DateTime GetRegDate(byte[] data)
		{
			int pos = 0;
			byte[] dat = GetKey(data, ref pos, DataOffsets.Data);
			Int64 ticks = BitConverter.ToInt64(dat, 0);
			return new DateTime(ticks);
		}

		public static String GetRegSerialNumber(byte[] data)
		{
			int pos = (int)DataOffsets.Data;
			byte[] snm = GetKey(data, ref pos, DataOffsets.Serial);
			String serial = Encoding.ASCII.GetString(snm);
			return CryptSerialNumber(serial.Split('\0')[0]);
		}

		public static String GetRegInfo(byte[] data)
		{
			int pos = (int)DataOffsets.Data
				+ (int)DataOffsets.Serial
				+ (int)DataOffsets.PubKey
				+ (int)DataOffsets.PrivKey;
			byte[] act = GetKey(data, ref pos, DataOffsets.ActKey);

			String curSN = GetSerialNumberCrypted();

			for (int n = 0; n < act.Length; n++)
			{
				RegUtils.ROR(ref act[n], n % 8);
			}

			String msg = Encoding.UTF8.GetString(act).Split('\0')[0];
			if (msg.Length < (int)DataOffsets.ActKey / 4)
				throw new Exception("Error! Activation key is too short.");

			msg = msg.Split('|')[0];

			if (!msg.StartsWith("This application copy is registered to:") || !msg.EndsWith(curSN))
				throw new Exception("Error! Invalid activation key.");

			return msg;
		}

		public static bool CheckRegInfo(byte[] data)
		{
			bool res = false;

			try
			{
				int pos = (int)DataOffsets.Data
					+ (int)DataOffsets.Serial;
				byte[] pub = GetKey(data, ref pos, DataOffsets.PubKey);
				byte[] prv = GetKey(data, ref pos, DataOffsets.PrivKey);

				// Get Reg date
				DateTime regDate = GetRegDate(data);

				// Get Serial number
				String curSN = GetSerialNumberCrypted();
				String serial = GetRegSerialNumber(data);

				for (int n = 0; n < curSN.Length; n++)
				{
					if (curSN[n] == serial[n])
						continue;

					throw new Exception("Error! Invalid serial number.");
				}

				// Get reg msg
				String msg = GetRegInfo(data);

				res = true;
			}
			catch (System.Exception)
			{
			}

			return res;
		}

		private static byte[] GetKey(byte[] data, ref int offset, DataOffsets keyLen)
		{
			byte[] key = new byte[(int)keyLen];
			Array.Copy(data, offset, key, 0, (int)keyLen);
			offset += (int)keyLen;

			return key;
		}

		public static void ROL(ref byte val, int nBits)
		{
			val = (byte)((val >> nBits) | (val << (8 - nBits)));
		}

		public static void ROR(ref byte val, int nBits)
		{
			val = (byte)((val << nBits) | (val >> (8 - nBits)));
		}
	}
}
