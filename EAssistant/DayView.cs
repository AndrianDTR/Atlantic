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
		dbDataSet.VCalendarInfoDataTable m_calendarData = null;

		private bool showTrainers = false;
		private bool showClientCount = false;

		public DayView()
			: base()
		{
			Logger.Enter();
			Reinit();
			Logger.Leave();
		}

		public void Reinit()
		{
			Logger.Enter();
			try
			{
				dbDataSet.settingsRow opts = Db.Instance.dSet.settings.FindByid(1);
				showTrainers = opts.ShowTrainer;
				showClientCount = opts.ShowClientCount;

				m_calendarData = Db.Instance.Adapters.VCalendarInfoTableAdapter.GetData();
			}
			catch (System.Exception ex)
			{
				Logger.Error(ex.Message);
			}
			Logger.Leave();
		}

		protected override CellInfo GetCellInfo(DateTime dt)
		{
			CellInfo ci = new CellInfo(dt);
			do
			{
				if (null == m_calendarData)
					break;

				DataRow[] drc = m_calendarData.Select(
					String.Format("calDate='{0}-{1}-{2}'", ci.date.Year, ci.date.Month, ci.date.Day));

				if (drc.Length != 1)
					break;

				if (showTrainers)
				{
					ci.sTip += String.Format("Trainer: {0}", drc[0]["trainer"]);
				}

				if (showClientCount)
				{
					if (showTrainers)
						ci.sTip += "\n";

					ci.sTip += String.Format("Clients:{0}", drc[0]["clientsCount"]);
				}

			} while (false);
			return ci;
		}
	}
}
