using System;
using System.Text;
using AY.Log;
using AY.db;

namespace GAssistant
{
	class DayView : Calendar.Calendar
	{
		public DayView()
		{
		
		}

		public override Calendar.CellInfo GetCellInfo(DateTime dt)
		{
			Logger.Enter();
			Calendar.CellInfo ci = new Calendar.CellInfo(dt);
			
			Logger.Leave();
			return ci;
		}
		
	}
}
