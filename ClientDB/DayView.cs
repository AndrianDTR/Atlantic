using System;
using System.Text;
using System.Data;
using AY.Log;
using AY.db;
using AY.Calendar;
using AY.Utils;
using System.Collections.Generic;

namespace EAssistant
{
	public class DayView : Calendar
	{
		private ClientCollection m_clients = null;
		private int[] m_days = null;
		private Dictionary<DateTime, String> m_trainerDate2NameMap = new Dictionary<DateTime, String>();
		private Opts m_opt = new Opts();
		
		private bool showTrainers = false;
		private bool showClientCount = false;
		
		public DayView():base()
		{
			Reinit();
		}
		
		public void Reinit()
		{
			try
			{
				showTrainers = m_opt.ShowTrainer;
				showClientCount = m_opt.ShowClientCount;
				
				m_days = CultureInfoUtils.RShift<int>(
					  new int[7] { 0, 1, 2, 3, 4, 5, 6 }
					, (int)CultureInfoUtils.GetWeekStart());
				m_clients = new ClientCollection();
				m_clients.Refresh("timesLeft > 0");
				
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
			catch (System.Exception)
			{
			}
		}

		protected override CellInfo GetCellInfo(DateTime dt)
		{
			Logger.Enter();
			CellInfo ci = new CellInfo(dt);
			try
			{
				int clCount = 0;
				foreach(DataRow dr in m_clients.Items)
				{
					Client client = new Client(dr);
					int ndx = m_days[(int)ci.date.DayOfWeek];
					if (client.ScheduleDays[ndx] == 'X')
						clCount++;
				}
				String trainer = m_trainerDate2NameMap.ContainsKey(ci.date) 
					? m_trainerDate2NameMap[ci.date] 
					: "";

				if (showTrainers)	
				{
					ci.sTip += String.Format("Trainer: {0}", trainer);
				}
				
				if (showClientCount)
				{
					if (showTrainers)
						ci.sTip += "\n";
							
					ci.sTip += String.Format("Clients:{0}", clCount);
				}
			}
			catch (System.Exception)
			{

			}
			
			Logger.Leave();
			return ci;
		}
	}
}
