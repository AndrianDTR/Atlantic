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
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colPlan;
		private DataGridViewTextBoxColumn colHoursLeft;
		
		
		WaitDialog wd = new WaitDialog(0,0,1);
		
		public ManageClients()
		{
			InitializeComponent();
			Init();
		}
		
		private void Init()
		{
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colPlan = new DataGridViewTextBoxColumn();
			colHoursLeft = new DataGridViewTextBoxColumn();

			clientsBindingSource.DataSource = Db.Instance.dSet.vClients;
			
			// 
			// idDataGridViewTextBoxColumn
			// 
			colId.DataPropertyName = "id";
			colId.HeaderText = "id";
			colId.Name = "idDataGridViewTextBoxColumn";
			colId.Visible = false;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			colName.DataPropertyName = "name";
			colName.HeaderText = "Name";
			colName.Name = "nameDataGridViewTextBoxColumn";
			colName.ReadOnly = true;
			// 
			// planDataGridViewTextBoxColumn
			// 
			colPlan.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colPlan.DataPropertyName = "rule";
			colPlan.HeaderText = "Plan";
			colPlan.Name = "ruleDataGridViewTextBoxColumn";
			colPlan.ReadOnly = true;
			// 
			// hoursLeftDataGridViewTextBoxColumn
			// 
			colHoursLeft.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colHoursLeft.DataPropertyName = "hoursLeft";
			colHoursLeft.HeaderText = "Hours left";
			colHoursLeft.Name = "hoursLeftDataGridViewTextBoxColumn";
			colHoursLeft.ReadOnly = true;

			gridClients.Columns.AddRange(new DataGridViewColumn[] {
				colId,
				colName,
				colPlan,
				colHoursLeft});
		}
		
		private void OnLoad(object sender, EventArgs e)
		{
			Db.Instance.Adapters.vClientsTableAdapter.Fill(Db.Instance.dSet.vClients);
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

		private dbDataSet.vClientsRow GetSelectedRow()
		{
			if (gridClients.SelectedRows.Count != 1)
				return null;

			return (dbDataSet.vClientsRow)((DataRowView)gridClients.SelectedRows[0].DataBoundItem).Row;
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

		private void btnOk_Click(object sender, EventArgs e)
		{
			Db.Instance.AcceptChanges();
		}
		
		private void EditClient()
		{
			dbDataSet.vClientsRow cr = GetSelectedRow();
			ClientInfo ci = new ClientInfo(cr.id);
			if (DialogResult.OK != ci.ShowDialog(this))
				return;

			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
		}

		private void OnRemoveRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			;
		}

		private void OnAddRow(object sender, DataGridViewRowEventArgs e)
		{
			dbDataSet.clientsRow row = (dbDataSet.clientsRow)((DataRowView)e.Row.DataBoundItem).Row;
			ClientInfo ci = new ClientInfo(row);

			if (DialogResult.OK != ci.ShowDialog())
				return;
			
			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			EditClient();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			EditClient();			
		}
	}
}
