using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Management;
using System.Text.RegularExpressions;
using System.Text;

namespace AY.Utils
{
	public class ExeUtils
	{
		private static int m_dataBufLen = 6144;
		
		private static char[] m_sign = "AYED01".ToCharArray();

		public enum DataOffsets
		{
			Data = 8,
			Serial = 128,
			PubKey = 1024,
			PrivKey = 3072,
			ActKey = 1024,				
		}
		
		public static int BufSize
		{
			get{ return m_dataBufLen; }
		}
		
		public static void SetExeData(FileInfo file, byte[] buf)
		{
			SetExeData(file, buf, file.Length);
		}

		public static void SetExeData(FileInfo file, byte[] buf, Int64 orgSize)
		{
			do
			{
				Array.Resize<byte>(ref buf, BufSize);

				FileStream fs = file.Open(FileMode.Open, FileAccess.ReadWrite);
				BinaryWriter br = new BinaryWriter(fs);
				br.Seek((int)orgSize, SeekOrigin.Begin);
				br.Write(buf, 0, buf.Length);
				br.Write(file.Length);
				br.Write(m_sign);
				br.Close();
				fs.Close();
			} while (false);
		}
		
		public static bool GetExeData(FileInfo file, ref byte[] buf, ref Int64 offset)
		{
			bool res = false;
			
			do
			{
				FileStream fs = file.Open(FileMode.Open, FileAccess.Read);
				BinaryReader br = new BinaryReader(fs);
				int szFoot = BufSize + 8 + m_sign.Length;
				fs.Seek(-szFoot, SeekOrigin.End);
				byte[] tmpBuf = br.ReadBytes(BufSize);
				Int64 orgSize = br.ReadInt64();
				char[] sign = br.ReadChars(m_sign.Length);
				br.Close();
				fs.Close();
				
				
				if(sign.Length != sign.Length)
					break;
				
				bool flag = true;
				for(int n = 0; n < m_sign.Length; n++)
				{
					if(m_sign[n] == sign[n])
						continue;
					flag = false;
				}
				
				if(flag)
				{
					buf = tmpBuf;
					offset = orgSize;
					res = true;
				}
				
			}while(false);

			return res;
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
		
		public static bool CheckRegInfo(byte[] data)
		{
			bool res = false;
			int pos = 0;
			try
			{
				Int64 ticks = BitConverter.ToInt64(data, pos);
				pos += (int)DataOffsets.Data;
				DateTime regDate = new DateTime(ticks);

				String curSN = GetSerialNumberCrypted();
				String serial = Encoding.ASCII.GetString(data, pos, (int)DataOffsets.Serial);
				serial = CryptSerialNumber(serial.Split('\0')[0]);
				pos += (int)DataOffsets.Serial;
				
				for (int n = 0; n < curSN.Length; n++)
				{
					if (curSN[n] == serial[n])
						continue;
					
					throw new Exception("Error! Invalid serial number.");
				}
				
				byte[] pub = new byte[(int)DataOffsets.PubKey];
				Array.Copy(data, pos, pub, 0, (int)DataOffsets.PubKey);
				pos += (int)DataOffsets.PubKey;

				byte[] prv = new byte[(int)DataOffsets.PrivKey];
				Array.Copy(data, pos, prv, 0, (int)DataOffsets.PrivKey);
				pos += (int)DataOffsets.PrivKey;

				byte[] act = new byte[(int)DataOffsets.ActKey];
				Array.Copy(data, pos, act, 0, (int)DataOffsets.ActKey);
				pos += (int)DataOffsets.ActKey;

				for (int n = 0; n < act.Length; n++)
				{
					ExeUtils.ROR(ref act[n], n % 8);
				}
				
				String msg = Encoding.UTF8.GetString(act).Split('\0')[0];
				if (msg.Length < (int)DataOffsets.ActKey / 4)
					throw new Exception("Error! Activation key is too short.");
				
				msg = msg.Split('|')[0];
				
				if (!msg.StartsWith("Registered to ") || !msg.EndsWith(curSN))
					throw new Exception("Error! Invalid activation key.");
				
				res = true;
			}
			catch (System.Exception)
			{
			}
			
			return res;
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
