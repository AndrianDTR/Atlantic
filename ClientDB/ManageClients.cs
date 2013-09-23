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
		WaitDialog wd = new WaitDialog(0,0,1);
		
		public ManageClients()
		{
			InitializeComponent();
		}
		
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	
		private void OnLoad(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'clientDataSet.clientsList' table. You can move, or remove it, as needed.
			this.clientsListTableAdapter.Fill(this.clientDataSet.clientsList);
		}

		private object[] parseClient(Client client)
		{
			object[] row = new object[5];

			row[0] = client.Id;
			row[1] = client.Name;
			row[2] = client.LastEnter;
			row[3] = client.TimesLeft;
			row[4] = client.ScheduleTime;

			return row;
		}
		
		private Int64 GetSelectedClientId()
		{
			if (gridClients.SelectedRows.Count < 1)
				return -1;
		
			int index = gridClients.SelectedRows[0].Index;
			DataGridViewRow row = gridClients.Rows[index];
			Int64 id = (Int64)row.Cells[0].Value;
			
			return id;
		}
		
		private void btnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void OnSearch(object sender, EventArgs e)
		{
			//Search();
		}
		
		private void Search()
		{
			String val = textToSearch.Text;
			if (0 == val.Trim().Length)
			{
				clientsListBindingSource.Filter = "";
				return;
			}

			String pattern = "%{0}%";
			if (checkStartWith.Checked)
				pattern = "{0}%";

			String query = String.Format("id = '{0}'", val);
			if (checkNames.Checked)
				query += String.Format(" or name like '{0}'", pattern);

			clientsListBindingSource.Filter = String.Format(query, val);
		}
		
		private void btnAdd_Click(object sender, EventArgs e)
		{
			ClientInfo ci = new ClientInfo(0);
			if (DialogResult.OK != ci.ShowDialog(this))
				return;

			clientDataSet.clientsRow cr = clientDataSet.clients.FindByid(ci.Id);
			gridClients.Rows.Add(parseClient(new Client(ci.Id)));
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			Int64 id = GetSelectedClientId();

			if (-1 == id)
				return;
			
			if(DialogResult.Yes != UIMessages.Warning("Client will be removed. Do you agree?", MessageBoxButtons.YesNo))
				return;
				
			if (!ClientCollection.RemoveById(id))
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
			Int64 id = GetSelectedClientId();

			if (-1 == id)
				return;
			
		}

		private void btnPayments_Click(object sender, EventArgs e)
		{
			Int64 id = GetSelectedClientId();

			if (-1 == id)
				return;
			
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
			Int64 id = GetSelectedClientId();
			
			if(-1 == id)
				return;
				
			ClientInfo ci = new ClientInfo(id);
			
			if (DialogResult.OK != ci.ShowDialog())
				return;
			
			int index = gridClients.SelectedRows[0].Index;
			DataGridViewRow row = gridClients.Rows[index];
			row.SetValues(parseClient(new Client(ci.Id)));
		}
	}
}
