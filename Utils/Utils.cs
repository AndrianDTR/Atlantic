using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Win32;
using AY.Log;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AY
{
	namespace Utils
	{
		public class CultureInfoUtils
		{
			public static T[] Shift<T>(T[] array, int positions)
			{
				T[] copy = new T[array.Length];
				Array.Copy(array, 0, copy, array.Length - positions, positions);
				Array.Copy(array, positions, copy, 0, array.Length - positions);
				return copy;
			}

			public static T[] RShift<T>(T[] array, int positions)
			{
				return Shift<T>(array, array.Length-positions);
			}
			
			public static string[] GetWeekDayNames()
			{
				string[] names = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
				return Shift(names, (int)GetWeekStart());
			}
			
			public static DayOfWeek GetWeekStart()
			{
				return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
			}

			public static RegistryKey GetAppKey()
			{
				Logger.Enter();
				Assembly asm = Assembly.GetExecutingAssembly();
				GuidAttribute guid = (GuidAttribute)asm.GetCustomAttributes(typeof(GuidAttribute), true)[0];
				String subKey = "Software\\" + guid.Value;
				Logger.Leave();
				return Registry.LocalMachine.CreateSubKey(subKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}
		
			public static CultureInfo CurrentCulture
			{
				get
				{
					Logger.Enter();
					CultureInfo culture = CultureInfo.CurrentCulture;
					
					try
					{
						RegistryKey key = GetAppKey();
						String lang = (String)key.GetValue(@"language");
						culture = new CultureInfo(lang);
					}
					catch (System.Exception ex)
					{
						culture = CultureInfo.CurrentCulture;
						Logger.Error(String.Format("Get language error. Internal msg: {0}", ex.Message));
					}
					Logger.Leave();
					return culture;
				}
				set
				{
					Logger.Enter();
					try
					{
						RegistryKey key = GetAppKey();
						CultureInfo cul = value;
						key.SetValue("language", cul.Name, RegistryValueKind.String);
					}
					catch (System.Exception ex)
					{
						Logger.Error(String.Format("Set language error. Internal msg: {0}", ex.Message));
					}
					Logger.Leave();
				}
			}
		}

		public abstract class Singleton<DerivedType>
		{
			private static DerivedType m_instance;

			public static DerivedType Instance
			{
				get
				{
					if (m_instance == null)
					{
						m_instance = (DerivedType)
						Activator.CreateInstance(typeof(DerivedType), true);
					}
					return m_instance;
				}
			}
		}
	}
}