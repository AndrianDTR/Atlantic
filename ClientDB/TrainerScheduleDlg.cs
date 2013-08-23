using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AY.db;

namespace GAssistant
{
	public partial class TrainerScheduleDlg : Form
	{
		private Dictionary<Int64, Trainer> m_trainerId2ObjMap = new Dictionary<Int64, Trainer>();
		private Dictionary<DateTime, Trainer> m_trainerDate2ObjMap = new Dictionary<DateTime, Trainer>();
		private Dictionary<DateTime, Trainer> m_newTrainerDate2ObjMap = new Dictionary<DateTime, Trainer>();
		private SelectionRange m_rng = null;
		
		public TrainerScheduleDlg()
		{
			InitializeComponent();

			m_trainerDate2ObjMap.Clear();

			InitTrainerList();
			InitDateRange();
			
			OnDateChanged(null, null);
		}
		
		private void InitTrainerList()
		{
			comboTrainers.Items.Clear();
			comboTrainers.Items.Add("None");
			comboTrainers.SelectedIndex = 0;

			foreach (Trainer tr in new TrainerCollection())
			{
				m_trainerId2ObjMap[tr.Id] = tr;
				comboTrainers.Items.Add(tr);
			}
		}
		
		private void InitDateRange()
		{
			m_rng = monthCalendar.GetDisplayRange(true);
			String where = String.Format("date >= '{0}' and date <= '{1}'"
				, m_rng.Start
				, m_rng.End);
			
			foreach (TrainerSchedule tr in new TrainerScheduleCollection(where))
			{
				m_trainerDate2ObjMap[tr.Date] = m_trainerId2ObjMap[tr.TrainerId];
			}
		}
		
		private void SelectTrainer(Trainer trainer)
		{
			for(int nItem = 1; nItem < comboTrainers.Items.Count; nItem++)
			{
				Trainer tr = (Trainer)comboTrainers.Items[nItem];
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
			if(!m_trainerDate2ObjMap.ContainsKey(currDate))
			{
				comboTrainers.SelectedIndex = 0;
				return;
			}
			
			SelectTrainer(m_trainerDate2ObjMap[currDate]);
		}

		private void OnTrainerChanged(object sender, EventArgs e)
		{
			DateTime currDate = monthCalendar.SelectionStart;
			
			int ndx = comboTrainers.SelectedIndex;
			if(0 >= ndx)
			{	
				if(0 == ndx 
					&& m_trainerDate2ObjMap.ContainsKey(currDate))
				{
					m_trainerDate2ObjMap.Remove(currDate);
					m_newTrainerDate2ObjMap[currDate] = null;
				}
				return;
			}
			
			Trainer tr = comboTrainers.SelectedItem as Trainer;
			m_trainerDate2ObjMap[currDate] = tr;
			m_newTrainerDate2ObjMap[currDate] = tr;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			WaitDialog dlg = new WaitDialog(0, m_newTrainerDate2ObjMap.Count, 1);
			dlg.Show();
			dlg.Refresh();

			foreach (KeyValuePair<DateTime, Trainer> kv in m_newTrainerDate2ObjMap)
			{
				TrainerSchedule ts = new TrainerSchedule(kv.Key);

				Trainer tr = kv.Value;
				
				if(null == (Object)tr)
				{
					TrainerScheduleCollection.RemoveById(ts.Id);
				}
				else
				{

					if(0 == ts.Id)
					{
						Int64 id = 0;
						TrainerSchedule.Add(tr.Id, kv.Key, out id);
					}
					else
					{
						ts.TrainerId = tr.Id;
					}
				}
				dlg.StepIt();
			}
			
			dlg.Close();
		}
	}
}
