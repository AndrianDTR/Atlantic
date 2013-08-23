using System;
using System.Text;
using AY.Log;
using AY.db;
using AY.Calendar;
using AY.Utils;

namespace GAssistant
{
	public class DayView : Calendar
	{
		private ClientCollection m_collect = null;
		private int[] m_days = null;
		
		public DayView():base()
		{
			Reinit();
		}
		
		private void Reinit()
		{
			m_collect = new ClientCollection("timesLeft > 0");
			m_days = CultureInfoUtils.RShift<int>(
				  new int[7] { 0, 1, 2, 3, 4, 5, 6 }
				, (int)CultureInfoUtils.GetWeekStart());
		}

		protected override CellInfo GetCellInfo(DateTime dt)
		{
			Logger.Enter();
			CellInfo ci = new CellInfo(dt);
			
			int clCount = 0;
			foreach(Client client in m_collect)
			{
				int ndx = m_days[(int)ci.date.DayOfWeek];
				if (client.ScheduleDays[ndx] == 'X')
					clCount++;
			}
			
			ci.sTip = String.Format("Trainer: {0}\nClients:{1}"
				, ""
				, clCount);
			
			Logger.Leave();
			return ci;
		}
	}
}
