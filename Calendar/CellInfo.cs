using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AY
{
	namespace Calendar
	{
		public class CellInfo
		{
			public bool bSelected = false;
			public bool bCurMonth = false;
			public DateTime date;
			public string sTitle = "";
			public string sTip = "";
			public object plan = null;
			
			
			public CellInfo(DateTime date)
			{
				this.date = date;
				sTitle = date.Day.ToString();
				bSelected = false;
				bCurMonth = false;
				sTip = "";
				plan = null;
			}
		}
	}
}
