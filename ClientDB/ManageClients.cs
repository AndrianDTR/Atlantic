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
			if (gridClients.SelectedRows.Count != 1)
				return 0;
				
			dbDataSet.vClientsRow cr = (dbDataSet.vClientsRow)((DataRowView)gridClients.SelectedRows[0].DataBoundItem).Row;
			return cr.id;
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
			DialogResult = DialogResult.OK;
			Close();
		}
		
		private void EditClient()
		{
			dbDataSet.vClientsRow cr = GetSelectedRow();
			long id = 0;
			if(null != cr)
			{
				id = cr.id;
			}
			ClientInfo ci = new ClientInfo(id);
			if (DialogResult.OK != ci.ShowDialog(this))
				return;

			Db.Instance.Adapters.vClientsTableAdapter.Fill(Db.Instance.dSet.vClients);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in gridClients.SelectedRows)
			{
				row.Selected = false;
			}
			EditClient();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			EditClient();			
		}

		private void OnEditClient(object sender, EventArgs e)
		{
			EditClient();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			dbDataSet.vClientsRow vcr = GetSelectedRow();
			if (null != vcr)
			{
				dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(vcr.id);
				if(cr != null)
				{
					vcr.Delete();
					cr.Delete();
					cr.AcceptChanges();
					Db.Instance.dSet.vClients.AcceptChanges();
					Db.Instance.Adapters.clientsTableAdapter.Update(cr);
					Db.Instance.dSet.clients.AcceptChanges();
					
					Db.Instance.Adapters.vClientsTableAdapter.Fill(Db.Instance.dSet.vClients);
				}
			}
			
		}
	}
}
