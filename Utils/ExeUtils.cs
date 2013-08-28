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
				ExeUtils.ROR(ref act[n], n % 8);
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
