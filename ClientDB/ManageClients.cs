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
			this.clientsBindingSource.DataSource = Db.Instance.dSet;
			Init();
		}
		
		private void Init()
		{
			colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colTimesLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colScheduleTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colLastEnter = new System.Windows.Forms.DataGridViewTextBoxColumn();
			
			colId.DataPropertyName = "id";
			colId.HeaderText = "ID";
			colId.Name = "dataGridViewTextBoxColumn1";
			colId.ReadOnly = true;

			colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			colName.DataPropertyName = "name";
			colName.HeaderText = "Name";
			colName.Name = "dataGridViewTextBoxColumn2";
			colName.ReadOnly = true;
			
			colTimesLeft.DataPropertyName = "hoursLeft";
			colTimesLeft.HeaderText = "Times left";
			colTimesLeft.Name = "dataGridViewTextBoxColumn3";
			colTimesLeft.ReadOnly = true;
			
			colScheduleTime.DataPropertyName = "scheduleTime";
			colScheduleTime.DefaultCellStyle.Format = "t";
			colScheduleTime.DefaultCellStyle.NullValue = null;
			colScheduleTime.HeaderText = "Time";
			colScheduleTime.Name = "dataGridViewTextBoxColumn4";
			colScheduleTime.ReadOnly = true;
			
			colLastEnter.DataPropertyName = "lastEnter";
			colLastEnter.HeaderText = "Last enter";
			colLastEnter.Name = "dataGridViewTextBoxColumn5";
			colLastEnter.ReadOnly = true;

			gridClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				colId, colName, colTimesLeft, colScheduleTime, colLastEnter});
		}
		
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	
		private void OnLoad(object sender, EventArgs e)
		{
			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
		}

		private object[] parseClient(dbDataSet.clientsRow client)
		{
			object[] row = new object[5];

			row[0] = client.id;
			row[1] = client.name;
			row[2] = client.lastEnter;
			row[3] = client.hoursLeft;
			row[4] = client.scheduleTime;

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
				clientsBindingSource.Filter = "";
				return;
			}

			String pattern = "%{0}%";
			if (checkStartWith.Checked)
				pattern = "{0}%";

			String query = String.Format("id = '{0}'", val);
			if (checkNames.Checked)
				query += String.Format(" or name like '{0}'", pattern);

			clientsBindingSource.Filter = String.Format(query, val);
		}
		
		private void btnAdd_Click(object sender, EventArgs e)
		{
			ClientInfo ci = new ClientInfo(0);
			if (DialogResult.OK != ci.ShowDialog(this))
			    return;

			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			//Int64 id = GetSelectedClientId();

			//if (-1 == id)
			//    return;
			
			//if(DialogResult.Yes != UIMessages.Warning("Client will be removed. Do you agree?", MessageBoxButtons.YesNo))
			//    return;
				
			//if (!ClientCollection.RemoveById(id))
			//{
			//    UIMessages.Error("Client could not been removed.");
			//    return;
			//}
			//int ndx = gridClients.SelectedRows[0].Index - 1;
			//gridClients.Rows.Remove(gridClients.SelectedRows[0]);
			//if(ndx >= 0)
			//    gridClients.Rows[ndx].Selected = true;
			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
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
			
			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
		}
	}
}
