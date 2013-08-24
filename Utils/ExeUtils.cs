using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace AY.Utils
{
	public class ExeUtils
	{
		private static char[] m_sign = "AYED01".ToCharArray();

		public static void SetExeData(FileInfo file, byte[] buf)
		{
			do 
			{
				Array.Resize<byte>(ref buf, 4096);

				FileStream fs = file.Open(FileMode.Open, FileAccess.ReadWrite);
				BinaryWriter br = new BinaryWriter(fs);
				br.Seek(0, SeekOrigin.End);
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
				int szFoot = 4096 + 8 + m_sign.Length;
				fs.Seek(-szFoot, SeekOrigin.End);
				byte[] tmpBuf = br.ReadBytes(4096);
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
			
			return sn;
		}
		
		public static bool CheckRegInfo(byte[] data)
		{
			bool res = false;
			
			return res;
		}
	}
}
