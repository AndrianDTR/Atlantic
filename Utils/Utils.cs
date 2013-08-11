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
			
			public static string[] GetWeekDayNames()
			{
				int shift = 0;
				string[] names = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
				switch (System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
				{
					case (DayOfWeek.Sunday):
						shift = 0;
						break;
					case (DayOfWeek.Monday):
						shift = 1;
						break;
					case (DayOfWeek.Tuesday):
						shift = 2;
						break;
					case (DayOfWeek.Wednesday):
						shift = 3;
						break;
					case (DayOfWeek.Thursday):
						shift = 4;
						break;
					case (DayOfWeek.Friday):
						shift = 5;
						break;
					case (DayOfWeek.Saturday):
						shift = 6;
						break;
				}
				return Shift(names, shift);
			}
		}
	}
}