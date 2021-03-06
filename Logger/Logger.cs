﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Diagnostics;

namespace AY
{
	namespace Log
	{
		public class Logger
		{
			private String m_userName = "";
			private bool m_bClose = true;
			
			public enum LogLevel
			{
				All = 0,
				Trace,
				Debug,
				Info,
				Warning,
				Error,
				Critical,
				Emergency,
				None,
			}
			private bool m_freeze = false;
			private static String[] m_szLogLevels = {"","Trace","Debug","Info","Warning","Error","Critical","Emergency"};
			private LogLevel m_level = LogLevel.None;
			private String m_szFile = null;
			private FileStream m_fs = null;
			private Queue<String> m_messages = null;
			private Thread m_LogThread = null;
			private bool m_bStop = false;
			private int m_sleepTime = 1000;
			
			private Logger(String file, LogLevel flags)
			{
				m_bClose = false;
				m_level = flags;
				m_szFile = file;
				m_messages = new Queue<String>();
				m_fs = new FileStream(file, FileMode.Create);
				m_LogThread = new Thread(LogMain);
				m_LogThread.Start(m_hInstance);
			}
			
			private static Logger m_hInstance = null;
			public static Logger Create(String file, LogLevel level)
			{
				if(null == m_hInstance)
				{
					m_hInstance = new Logger(file, level);
				}
				return m_hInstance;
			}
			
			public String User
			{
				get
				{
					return m_userName;
				}
				set
				{
					m_userName = value;
				}
			}

			public static String FilePath
			{
				get
				{
					return m_hInstance.m_szFile;
				}
			}

			public static void Flush()
			{
				if (m_hInstance.m_bClose)
					return;
					
				m_hInstance.m_fs.Flush();
			}

			public static void Freeze()
			{
				lock (new object())
				{
					m_hInstance.m_freeze = true;

					if (m_hInstance.m_bClose)
						return;
						
					m_hInstance.m_fs.Flush();
					m_hInstance.m_fs.Close();
					m_hInstance.m_bClose = true;
				}
			}

			public static void Continue()
			{
				lock (new object())
				{
					m_hInstance.m_fs = new FileStream(FilePath, FileMode.Append);
					m_hInstance.m_freeze = false;
					m_hInstance.m_bClose = false;
					
				}
			}

			public static void Close()
			{
				lock (new object())
				{
					if (null != m_hInstance)
					{
						m_hInstance.m_bStop = true;

						// finish logging
						while (true)
						{
							if (m_hInstance.m_messages.Count > 0)
							{
								String msg = m_hInstance.m_messages.Dequeue();
								byte[] buf = m_hInstance.GetBytes(msg);
								m_hInstance.m_fs.Write(buf, 0, buf.Length);
							}
							else
							{
								break;
							}
						}
						
						m_hInstance.m_fs.Flush();
						m_hInstance.m_fs.Close();
						m_hInstance.m_bClose = true;
					}
				}
			}
			
			public static Logger Instance
			{
				get { return m_hInstance; }
			}

			private byte[] GetBytes(String str)
			{
				byte[] bytes = new byte[str.Length * sizeof(char)];
				System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
				return bytes;
			}

			private String GetString(byte[] bytes)
			{
				char[] chars = new char[bytes.Length / sizeof(char)];
				System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
				return new String(chars);
			}
			
			private void LogMain(object opts)
			{
				while(true)
				{
					if (!m_bClose && !m_freeze && m_messages.Count > 0)
					{
						String msg = m_messages.Dequeue();
						byte[] buf = GetBytes(msg);
						m_fs.Write(buf, 0, buf.Length);
					}
					else
					{
						Thread.Sleep(m_sleepTime);
					}
					
					if(m_bStop)
						break;
				}
			}
			
			public static void AddMsg(String msg, LogLevel level)
			{
				if(null == m_hInstance)
					return;

				if (level >= m_hInstance.m_level)
				{
					if (msg.Length > 1024)
						msg = msg.Substring(0, 1024);
					DateTime dt = DateTime.UtcNow;
					String message = String.Format("{0} ({1}) [{2}]: {3}\n"
						, dt.ToString()
						, m_hInstance.m_userName
						, m_szLogLevels[(int)level]
						, msg);
					m_hInstance.m_messages.Enqueue(message);
				}	
			}

			public static void Trace(String msg)
			{
				if (null == m_hInstance)
					return;

				DateTime dt = DateTime.UtcNow;
				String message = String.Format("{0} [{1}]: {2}\n"
					, dt.ToString()
					, m_szLogLevels[(int)LogLevel.Trace]
					, msg);
				m_hInstance.m_messages.Enqueue(message);
			}

			public static void Enter() 
			{
				StackFrame stack = new StackFrame(1, true);
				Logger.AddMsg(String.Format("Enter {0}, {1}:{2}"
					, stack.GetMethod().Name
					, stack.GetFileName()
					, stack.GetFileLineNumber())
				, LogLevel.Debug); 
			}
			
			public static void Leave()
			{
				StackFrame stack = new StackFrame(1, true);
				Logger.AddMsg(String.Format("Leave {0}, {1}:{2}"
					, stack.GetMethod().Name
					, stack.GetFileName()
					, stack.GetFileLineNumber())
				, LogLevel.Debug); 
			}

			public static void Debug(String msg) { Logger.AddMsg(msg, LogLevel.Debug); }
			public static void Info(String msg) { Logger.AddMsg(msg, LogLevel.Info); }
			public static void Warning(String msg) { Logger.AddMsg(msg, LogLevel.Warning); }
			public static void Error(String msg) { Logger.AddMsg(msg, LogLevel.Error); }
			public static void Critical(String msg) { Logger.AddMsg(msg, LogLevel.Critical); }
			public static void Emergency(String msg) { Logger.AddMsg(msg, LogLevel.Emergency); }
		}
	}
}