using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Management;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using AY.Log;

namespace AY.Utils
{
	public class RegUtils : Singleton<RegUtils>
	{
		private byte[] m_data = null;
		
		public enum DataOffsets
		{
			// field				Len
			Date = 0,				// 8 bytes
			CustomerId = 8,			// 4 bytes
			Serial = 12,			// 128
			PubKey = 140,			// 1024
			PrivKey = 1164,			// 3072
			Message = 4236,			// 2048
			_end = 6284,			// end marker
		}
		
		public enum ActKeyOffsets
		{
			//Field					// Len
			CustomerId = 0,			// 4
			Serial = 4,				// 128
			Message = 132,			// 2048
			_end = 2180,			// end marker
		}

		private RegUtils()
		{
			ReadData();
		}
		
		public void ReadData()
		{
			try
			{
				RegistryKey key = GetAppKey();
				m_data = (byte[])key.GetValue(@"data");
			}
			catch (System.Exception ex)
			{
				Logger.Error(ex.Message);
				m_data = null;
			}
		}
		
		public static void ROL(ref byte val, int nBits)
		{
			val = (byte)((val >> nBits) | (val << (8 - nBits)));
		}

		public static void ROR(ref byte val, int nBits)
		{
			val = (byte)((val << nBits) | (val >> (8 - nBits)));
		}

		private byte[] GetKey(byte[] data, int offset, int keyLen)
		{
			byte[] key = new byte[keyLen];
			Array.Copy(data, offset, key, 0, keyLen);
			
			return key;
		}
		
		private RegistryKey GetAppKey()
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			GuidAttribute guid = (GuidAttribute)asm.GetCustomAttributes(typeof(GuidAttribute), true)[0];
			String subKey = "Software\\" + guid.Value;
			return Registry.LocalMachine.CreateSubKey(subKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
		}

		public byte[] SavedData
		{
			get
			{
				if(null == m_data)
				{
					Logger.Warning("No registration info.");
					m_data = FillRegInfo();
				}
					
				return m_data;
			}
			set
			{
				m_data = value;
				RegistryKey key = GetAppKey();
				key.SetValue(@"data", m_data, RegistryValueKind.Binary);
				key.Flush();
				key.Close();
			}
		}

		public byte[] FillRegInfo()
		{
			int bufSize = (int)DataOffsets._end;

			byte[] buf = new byte[bufSize];
			Array.Clear(buf, 0, bufSize);

			byte[] srcDate = BitConverter.GetBytes((Int64)DateTime.Now.Ticks);
			byte[] serial = Encoding.ASCII.GetBytes(SecUtils.SerialNumber);
			byte[] pub = null;
			byte[] prv = null;
			SecUtils.RSA(out pub, out prv);

			Array.Copy(srcDate, 0, buf, (int)DataOffsets.Date, srcDate.Length);
			Array.Copy(serial, 0, buf, (int)DataOffsets.Serial, serial.Length);
			Array.Copy(pub, 0, buf, (int)DataOffsets.PubKey, pub.Length);
			Array.Copy(prv, 0, buf, (int)DataOffsets.PrivKey, prv.Length);

			return buf;
		}
		
		public String GenerateRandomString(int length)
		{
			Random random = new Random(Environment.TickCount);
			var data = new byte[length];
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = (byte)random.Next(32, 127);
			}
			var encoding = new ASCIIEncoding();
			return encoding.GetString(data);
		}

		public DateTime RegDate
		{
			get
			{
				byte[] dat = GetKey(SavedData
					, (int)DataOffsets.Date
					, (int)(DataOffsets.Serial - DataOffsets.Date));
				Int64 ticks = BitConverter.ToInt64(dat, 0);
				return new DateTime(ticks);
			}
		}

		public Int32 CustomerId
		{
			get
			{
				byte[] dat = GetKey(m_data
					, (int)DataOffsets.CustomerId
					, (int)(DataOffsets.Serial - DataOffsets.CustomerId));
				Int32 num = BitConverter.ToInt32(dat, 0);
				
				return num;
			}
		}

		public String SerialNumber
		{
			get
			{
				byte[] snm = GetKey(SavedData
					, (int)DataOffsets.Serial
					, (int)(DataOffsets.PubKey - DataOffsets.Serial));
				return Encoding.UTF8.GetString(snm);
			}
		}

		public String RegInfo
		{
			get
			{
				int len = (int)(DataOffsets._end - DataOffsets.Message);
				byte[] bytesMsgt = GetKey(SavedData, (int)DataOffsets.Message, len);
				for (int n = 0; n < bytesMsgt.Length; n++)
				{
					ROR(ref bytesMsgt[n], n % 8);
				}

				String msg = Encoding.UTF8.GetString(bytesMsgt).Split('\0')[0];
				if (msg.Length < (int)(DataOffsets._end - DataOffsets.Message))
				{
					throw new Exception("Error! Activation key is too short.");
				}

				msg = msg.Substring(0, msg.IndexOf(MsgSplitter));

				return msg;
			}
		}

		public String MsgSplitter
		{
			get {return "-=|=-";}
		}
		
		public bool CheckRegistrationInfo()
		{
			bool res = false;

			try
			{
				byte[] pub = GetKey(SavedData
					, (int)DataOffsets.PubKey
					, (int)(DataOffsets.PrivKey - DataOffsets.PubKey));

				byte[] prv = GetKey(SavedData
					, (int)DataOffsets.PrivKey
					, (int)(DataOffsets.Message - DataOffsets.PrivKey));

				// Get Reg date
				DateTime regDate = RegDate;

				// Get Reg id
				Int32 id = CustomerId;

				// Get Serial number
				String curSN = SecUtils.CryptString(SecUtils.SerialNumber);
				String serial = SerialNumber;

				for (int n = 0; n < curSN.Length; n++)
				{
					if (curSN[n] == serial[n])
						continue;

					throw new Exception("Error! Invalid serial number.");
				}

				// Get reg msg
				String msg = RegInfo;

				res = true;
			}
			catch (System.Exception ex)
			{
				Logger.Error(ex.Message);
			}

			return res;
		}
	}
}
