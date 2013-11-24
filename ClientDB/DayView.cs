﻿using System;
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
		private int[] m_days = null;
		private Dictionary<DateTime, String> m_trainerDate2NameMap = new Dictionary<DateTime, String>();
		
		private bool showTrainers = false;
		private bool showClientCount = false;
		
		public DayView():base()
		{
			Reinit();
		}
		
		public void Reinit()
		{
//#if !DEBUG
/*
select trainersSchedule.id as ID, trainersSchedule.trainerId, DT.dt from trainersSchedule left outer join 
(select date('2013-11-13') as dt) as DT on DT.[dt]=trainersSchedule.id
--(select count(R) as cc, dID from (select SUBSTR(scheduleDays, strftime('%w', date(ID)), 1) As R, date(ID) as dID from clients where R='X')) as CC on dID = ID where ID = date('2013-11-14')  
*/

			try
			{
				dbDataSet.settingsRow opts = Db.Instance.dSet.settings.FindByid(1);
				showTrainers = opts.ShowTrainer;
				showClientCount = opts.ShowClientCount;
				
				m_days = CultureInfoUtils.RShift<int>(
					  new int[7] { 0, 1, 2, 3, 4, 5, 6 }
					, (int)CultureInfoUtils.GetWeekStart());
				//m_clients = new ClientCollection();
				//m_clients.Refresh("hoursLeft > 0");
				/*
				Dictionary<Int64, String> trainerId2NameMap = new Dictionary<Int64, String>();
				foreach (Trainer tr in new TrainerCollection())
				{
					trainerId2NameMap[tr.Id] = tr.Name;
				}
				m_trainerDate2NameMap.Clear();
				foreach (TrainerSchedule tr in new TrainerScheduleCollection())
				{
					m_trainerDate2NameMap[tr.Date] = trainerId2NameMap[tr.TrainerId];
				}*/
			}
			catch (System.Exception)
			{
			}
//#endif
		}

		protected override CellInfo GetCellInfo(DateTime dt)
		{
			Logger.Enter();
			CellInfo ci = new CellInfo(dt);
#if !DEBUG
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
#endif
			return ci;
		}
	}
}
