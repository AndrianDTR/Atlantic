using System;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using AY.Log;
using AY.db;
using System.ComponentModel;

namespace EAssistant
{
	public partial class ManageClients : Form
	{
		System.Windows.Forms.Timer m_timerFilterChanged = new System.Windows.Forms.Timer();
		ClientCollection m_collection = new ClientCollection();
		WaitDialog wd = new WaitDialog(0,0,1);
		BackgroundWorker backgroundWorker = new BackgroundWorker();
		
		public ManageClients()
		{
			InitializeComponent();
			
			backgroundWorker.DoWork += BackgroundWorkerDoWork;
			
			m_timerFilterChanged.Interval = 1000;
			m_timerFilterChanged.Tick += new System.EventHandler(this.OnTimerFilter);
		}
		
		private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
			m_collection.Refresh(String.Format("id like '%{0}%'", textToSearch.Text));
			if(!wd.IsDisposed)
				wd.Close();
        }
		
		private void Reinit()
		{
			if (wd.IsDisposed)
				wd = new WaitDialog(0, 1, 1);
			wd.Show();
			wd.Refresh();
			String pattern = "%{0}%";
			if(checkStartWith.Checked)
				pattern = "{0}%";
				
			String query = String.Format("id like '{0}'", pattern);
			if (checkNames.Checked)
				query += String.Format(" or name like '{0}'", pattern);
			m_collection.Refresh(String.Format(query, textToSearch.Text));
			wd.StepIt();
			wd.Close();
		}
		
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private object[] parseClient(Client client)
		{
			object[] row = new object[5];
			
			row[0] = client.Code;
			row[1] = client.Name;
			row[2] = client.Phone;
			row[3] = client.TimesLeft.ToString();
			row[4] = client.ScheduleTime.ToString("HH:mm");
			
			return row;
		}
	
		private void FillGrid()
		{
			gridClients.SuspendLayout();
			Reinit();
			gridClients.Rows.Clear();

			if (wd.IsDisposed)
				wd = new WaitDialog(0, m_collection.Items.Count, 1);
			else
				wd.Max = m_collection.Items.Count;
				
			wd.Show();
			wd.Refresh();
			
			foreach (DataRow dr in m_collection.Items)
			{
				Client client = new Client(dr);
				wd.StepIt();
				wd.Refresh();
				
				int nRow = gridClients.Rows.Add(parseClient(client));
				gridClients.Rows[nRow].Tag = client.Id;
			}
			wd.Close();
			gridClients.ResumeLayout();
		}

		private void OnTimerFilter(object sender, EventArgs e)
		{
			m_timerFilterChanged.Stop();
			FillGrid();
		} 
		
		private void OnLoad(object sender, EventArgs e)
		{
			FillGrid();
		}
		
		private void btnSearch_Click(object sender, EventArgs e)
		{
			FillGrid();
		}

		private void OnSearch(object sender, EventArgs e)
		{
			//m_timerFilterChanged.Stop();
			//m_timerFilterChanged.Start();
		}
		
		private void btnAdd_Click(object sender, EventArgs e)
		{
			ClientInfo ci = new ClientInfo(0);
			if (DialogResult.OK != ci.ShowDialog(this))
				return;

			int nRow = gridClients.Rows.Add(parseClient(new Client(ci.Id)));
			gridClients.Rows[nRow].Tag = ci.Id;	
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if(gridClients.SelectedRows.Count < 1)
				return;

			if(DialogResult.Yes != UIMessages.Warning("Client will be removed. Do you agree?", MessageBoxButtons.YesNo))
				return;
				
			Int64 clientId = (Int64)gridClients.SelectedRows[0].Tag;
			if (!ClientCollection.RemoveById(clientId))
			{
				UIMessages.Error("Client could not been removed.");
				return;
			}
			int ndx = gridClients.SelectedRows[0].Index - 1;
			gridClients.Rows.Remove(gridClients.SelectedRows[0]);
			if(ndx >= 0)
				gridClients.Rows[ndx].Selected = true;
		}

		private void btnHistory_Click(object sender, EventArgs e)
		{
			if(gridClients.SelectedRows.Count < 1)
				return;

			Int64 clientId = (Int64)gridClients.SelectedRows[0].Tag;
		}

		private void btnPayments_Click(object sender, EventArgs e)
		{
			if(gridClients.SelectedRows.Count < 1)
				return;

			Int64 clientId = (Int64)gridClients.SelectedRows[0].Tag;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			EditClient();
		}
		
		private void OnEdit(object sender, EventArgs e)
		{
			EditClient();
		}
		
		private void EditClient()
		{
			if (gridClients.SelectedRows.Count < 1)
				return;
			
			Int64 id = (Int64)gridClients.SelectedRows[0].Tag;
			ClientInfo ci = new ClientInfo(id);
			
			if (DialogResult.OK != ci.ShowDialog())
				return;

			gridClients.SelectedRows[0].SetValues(parseClient(new Client(id)));
		}
	}
}
