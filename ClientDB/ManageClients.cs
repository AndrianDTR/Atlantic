using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class ManageClients : Form
	{
		Timer m_timerFilterChanged = new Timer();
		ClientCollection m_collection = new ClientCollection();
		WaitDialog wd = new WaitDialog(0,0,1);
		
		public ManageClients()
		{
			InitializeComponent();
			Init();
			m_timerFilterChanged.Interval = 1000;
			m_timerFilterChanged.Tick += new System.EventHandler(this.OnTimerFilter);
		}
		
		public void UpdateRange(Int64 maxCount)
		{
			wd.Max = (int)maxCount;
		}
		
		private void StepIt()
		{
			wd.StepIt();
		}
		
		private void Init()
		{
			wd.Show();
			wd.Refresh();
			m_collection.CountChangedHandler = UpdateRange;
			m_collection.CollectionChangedHandler = StepIt;
			m_collection.Refresh();
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
			m_collection.Refresh(String.Format("id like '%{0}%'", textToSearch.Text));
			
			wd = new WaitDialog(0, m_collection.Count, 1);
			wd.Show();
			wd.Refresh();
			gridClients.Rows.Clear();
			
			foreach (Client client in m_collection)
			{
				wd.StepIt();
				int nRow = gridClients.Rows.Add(parseClient(client));
				gridClients.Rows[nRow].Tag = client.Id;
			}
			wd.Close();
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
			m_timerFilterChanged.Stop();
			m_timerFilterChanged.Start();
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
