using System;
using System.Collections.Generic;
using System.Globalization;

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