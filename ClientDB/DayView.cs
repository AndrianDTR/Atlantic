using System;
using System.Text;
using AY.Log;
using AY.db;
using AY.Calendar;
using AY.Utils;
using System.Collections.Generic;

namespace GAssistant
{
	public class DayView : Calendar
	{
		private ClientCollection m_clients = null;
		private int[] m_days = null;
		private Dictionary<DateTime, String> m_trainerDate2NameMap = new Dictionary<DateTime, String>();
		
		public DayView():base()
		{
			Reinit();
		}
		
		public void Reinit()
		{
			m_days = CultureInfoUtils.RShift<int>(
				  new int[7] { 0, 1, 2, 3, 4, 5, 6 }
				, (int)CultureInfoUtils.GetWeekStart());
			m_clients = new ClientCollection("timesLeft > 0");
			
			Dictionary<Int64, String> trainerId2NameMap = new Dictionary<Int64, String>();
			foreach (Trainer tr in new TrainerCollection())
			{
				trainerId2NameMap[tr.Id] = tr.Name;
			}
			m_trainerDate2NameMap.Clear();
			foreach (TrainerSchedule tr in new TrainerScheduleCollection())
			{
				m_trainerDate2NameMap[tr.Date] = trainerId2NameMap[tr.TrainerId];
			}
		}

		protected override CellInfo GetCellInfo(DateTime dt)
		{
			Logger.Enter();
			CellInfo ci = new CellInfo(dt);
			
			int clCount = 0;
			foreach(Client client in m_clients)
			{
				int ndx = m_days[(int)ci.date.DayOfWeek];
				if (client.ScheduleDays[ndx] == 'X')
					clCount++;
			}
			String trainer = m_trainerDate2NameMap.ContainsKey(ci.date) 
				? m_trainerDate2NameMap[ci.date] 
				: "";
			ci.sTip = String.Format("Trainer: {0}\nClients:{1}"
				, trainer
				, clCount);
			
			Logger.Leave();
			return ci;
		}
	}
}
