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
	public partial class TrainerScheduleDlg : Form
	{
		/*
		private Dictionary<Int64, Trainer> m_trainerId2ObjMap = new Dictionary<Int64, Trainer>();
		
		private Dictionary<DateTime, Trainer> m_newTrainerDate2ObjMap = new Dictionary<DateTime, Trainer>();
		 */

		private Dictionary<DateTime, long> m_date2TrainerMap = new Dictionary<DateTime, long>();
		private SelectionRange m_rng = null;
	
		public TrainerScheduleDlg()
		{
			InitializeComponent();

			trainersBindingSource.DataSource = Db.Instance.dSet.trainers;

			comboTrainers.DataBindings.Add(new Binding("Text", this.trainersBindingSource, "name", true));
			comboTrainers.DataBindings.Add(new Binding("SelectedItem", this.trainersBindingSource, "id", true));
			comboTrainers.DataSource = this.trainersBindingSource;
			comboTrainers.DisplayMember = "name";

			InitDateRange();
			
			OnDateChanged(null, null);
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

		private void SelectTrainer(dbDataSet.trainersRow trainer)
		{
			for(int nItem = 1; nItem < comboTrainers.Items.Count; nItem++)
			{
				dbDataSet.trainersRow tr = (dbDataSet.trainersRow)comboTrainers.Items[nItem];
				if(tr == trainer)
				{
					comboTrainers.SelectedItem = tr;
					break;
				}
			}
		}
		
		private void OnDateChanged(object sender, DateRangeEventArgs e)
		{
			SelectionRange rng = monthCalendar.GetDisplayRange(true);
			if (m_rng.Start != rng.Start || m_rng.End != rng.End)
				InitDateRange();
				
			DateTime currDate = monthCalendar.SelectionStart;
			if(!m_date2TrainerMap.ContainsKey(currDate))
			{
				if (comboTrainers.Items.Count > 0)
					comboTrainers.SelectedIndex = -1;
				return;
			}
			
			comboTrainers.SelectedItem = m_date2TrainerMap[currDate];
		}

		private void OnTrainerChanged(object sender, EventArgs e)
		{
			if(comboTrainers.SelectedIndex == -1)
				return;
			
			DateTime currDate = monthCalendar.SelectionStart;

			dbDataSet.trainersRow row = (dbDataSet.trainersRow)((DataRowView)comboTrainers.SelectedItem).Row;
			m_date2TrainerMap[currDate] = row.id;
			
			dbDataSet.trainersScheduleRow tsr = Db.Instance.dSet.trainersSchedule.FindByid(currDate);
			if(null == tsr)
			{
				tsr = Db.Instance.dSet.trainersSchedule.AddtrainersScheduleRow(currDate, row.id);
			}
			else
			{
				tsr.trainerId = row.id;
			}
			monthCalendar.RemoveBoldedDate(currDate);
			monthCalendar.UpdateBoldedDates();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Db.Instance.AcceptChanges();
			DialogResult = DialogResult.OK;
			Close();		
		}

		private void TrainerScheduleDlg_Load(object sender, EventArgs e)
		{
			Db.Instance.Adapters.trainersTableAdapter.Fill(Db.Instance.dSet.trainers);
			comboTrainers.SelectedIndex = -1;
		}
	}
}
