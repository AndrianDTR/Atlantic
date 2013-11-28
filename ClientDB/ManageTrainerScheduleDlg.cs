using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AY.db;

namespace EAssistant
{
	public partial class ManageTrainerScheduleDlg : Form
	{
		private bool bDateChange = false;

		private Dictionary<DateTime, long> m_date2TrainerMap = new Dictionary<DateTime, long>();
		private SelectionRange m_rng = null;
	
		public ManageTrainerScheduleDlg()
		{
			InitializeComponent();
			
			Init();

			InitDateRange();
			
			OnDateChanged(null, null);
		}
	
		private void Init()
		{
			comboTrainers.Items.Clear();
			
			dbDataSet.trainersDataTable tdt = Db.Instance.Adapters.trainersTableAdapter.GetData();
			
			foreach (dbDataSet.trainersRow tr in tdt)
			{
				comboTrainers.Items.Add(tr);
			}
		}
		
		private void InitDateRange()
		{
			m_rng = monthCalendar.GetDisplayRange(true);
			String where = String.Format("id >= '{0}' and id <= '{1}'"
				, m_rng.Start
				, m_rng.End);

			foreach (dbDataSet.trainersScheduleRow tsr in Db.Instance.dSet.trainersSchedule.Select(where))
			{
				m_date2TrainerMap[tsr.id] = tsr.trainerId;
			}
			
			for(DateTime dt = m_rng.Start; dt <= m_rng.End; dt = dt.AddDays(1))
			{
				if(!m_date2TrainerMap.ContainsKey(dt))
				{
					monthCalendar.AddAnnuallyBoldedDate(dt);
				}
			}
			monthCalendar.UpdateBoldedDates();
		}

		private void SelectTrainer(Int64 nTrainerId)
		{
			comboTrainers.SelectedItem = nTrainerId;
			
			foreach(Object it in comboTrainers.Items)
			{
				dbDataSet.trainersRow tr = (dbDataSet.trainersRow)it;
				if(tr.id == nTrainerId)
				{
					comboTrainers.SelectedItem = it;
					break;
				}
			}
		}
		
		private void OnDateChanged(object sender, DateRangeEventArgs e)
		{
			bDateChange = true;
			SelectionRange rng = monthCalendar.GetDisplayRange(true);
			if (m_rng.Start != rng.Start || m_rng.End != rng.End)
				InitDateRange();
				
			DateTime currDate = monthCalendar.SelectionStart;
			if(!m_date2TrainerMap.ContainsKey(currDate))
			{
				if (comboTrainers.Items.Count > 0)
					comboTrainers.SelectedIndex = -1;
				bDateChange = false;
				return;
			}
			
			SelectTrainer(m_date2TrainerMap[currDate]);
			bDateChange = false;
		}

		private void OnTrainerChanged(object sender, EventArgs e)
		{
			if(bDateChange || comboTrainers.SelectedIndex == -1)
				return;
			
			DateTime currDate = monthCalendar.SelectionStart;

			dbDataSet.trainersRow it = (dbDataSet.trainersRow)(comboTrainers.SelectedItem);
			m_date2TrainerMap[currDate] = it.id;
			
			dbDataSet.trainersScheduleRow tsr = Db.Instance.dSet.trainersSchedule.FindByid(currDate);
			if(null == tsr)
			{
				tsr = Db.Instance.dSet.trainersSchedule.AddtrainersScheduleRow(currDate, it.id);
			}
			else
			{
				tsr.trainerId = it.id;
			}
			monthCalendar.RemoveBoldedDate(currDate);
			monthCalendar.UpdateBoldedDates();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Db.Instance.AcceptChanges();
			Session.Instance.UpdateMain();
			DialogResult = DialogResult.OK;
			Close();		
		}
	}
}
