using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
