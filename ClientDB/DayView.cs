using System;
using System.Text;
using AY.Log;
using AY.db;
using AY.Calendar;

namespace GAssistant
{
	class DayView : Calendar
	{
		public override CellInfo GetCellInfo(DateTime dt)
		{
			Logger.Enter();
			CellInfo ci = new CellInfo(dt);
			
			ci.sTip = "AAAAAAA";
			
			Logger.Leave();
			return ci;
		}
	}
}
