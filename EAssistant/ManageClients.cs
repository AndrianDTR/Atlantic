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

		public ManageClients()
		{
			Logger.Enter();
			InitializeComponent();
			Init();
			Logger.Leave();
		}

		private void Init()
		{
			Logger.Enter();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colPlan = new DataGridViewTextBoxColumn();
			colHoursLeft = new DataGridViewTextBoxColumn();

			clientsBindingSource.DataSource = Db.Instance.dSet.VClients;

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

			Logger.Leave();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			Logger.Enter();
			Db.Instance.Adapters.VClientsTableAdapter.Fill(Db.Instance.dSet.VClients);
			Logger.Leave();
		}

		private Int64 GetSelectedClientId()
		{
			Logger.Enter();
			Int64 res = 0;
			do
			{
				if (gridClients.SelectedRows.Count != 1)
					break;

				dbDataSet.VClientsRow cr = (dbDataSet.VClientsRow)((DataRowView)gridClients.SelectedRows[0].DataBoundItem).Row;
				res = cr.id;
			} while (false);
			Logger.Leave();
			return res;
		}

		private dbDataSet.VClientsRow GetSelectedRow()
		{
			dbDataSet.VClientsRow row = null;
			Logger.Enter();
			do
			{
				if (gridClients.SelectedRows.Count != 1)
					break;
				row = (dbDataSet.VClientsRow)((DataRowView)gridClients.SelectedRows[0].DataBoundItem).Row;

			} while (false);
			Logger.Leave();
			return row;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			Search();
			Logger.Leave();
		}

		private void OnSearch(object sender, EventArgs e)
		{
			Logger.Enter();
			//Search();
			Logger.Leave();
		}

		private void Search()
		{
			Logger.Enter();
			do
			{
				String val = textToSearch.Text.Trim();
				if (0 == val.Length)
				{
					clientsBindingSource.Filter = "";
					break;
				}

				if (radioId.Checked)
				{
					Int32 iVal = 0;
					if(!Int32.TryParse(val, out iVal))
					{
						UIMessages.Error("Client ID should be an integer value.");
						break;
					}
				}
				
				String pattern = "%{0}%";
				if (checkStartWith.Checked)
					pattern = "{0}%";
				
				String query = String.Format("id like '{0}'", pattern);

				if (radioName.Checked)
					query = String.Format("name like '{0}'", pattern);

				clientsBindingSource.Filter = String.Format(query, val);
			} while (false);
			Logger.Leave();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			Db.Instance.AcceptChanges();
			Session.Instance.UpdateMain();
			DialogResult = DialogResult.OK;
			Close();
			Logger.Leave();
		}

		private void EditClient()
		{
			Logger.Enter();
			do
			{
				dbDataSet.VClientsRow cr = GetSelectedRow();
				Int32 id = 0;
				if (null != cr)
				{
					id = cr.id;
				}
				ClientInfo ci = new ClientInfo(id);
				if (DialogResult.OK != ci.ShowDialog(this))
					break;

				Db.Instance.Adapters.VClientsTableAdapter.Fill(Db.Instance.dSet.VClients);
			} while (false);
			Logger.Leave();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			foreach (DataGridViewRow row in gridClients.SelectedRows)
			{
				row.Selected = false;
			}
			EditClient();
			Logger.Leave();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			EditClient();
			Logger.Leave();
		}

		private void OnEditClient(object sender, EventArgs e)
		{
			Logger.Enter();
			EditClient();
			Logger.Leave();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				dbDataSet.VClientsRow vcr = GetSelectedRow();
				if (null == vcr)
					break;

				if (DialogResult.No == UIMessages.Warning("Selected client record will be deleted.\nDo you want to proceed?", MessageBoxButtons.YesNo))
					break;

				Db.Instance.Adapters.VClientsTableAdapter.DeleteQuery(vcr.id);
				Db.Instance.AcceptChanges();
				Db.Instance.Adapters.VClientsTableAdapter.Fill(Db.Instance.dSet.VClients);
			} while (false);
			Logger.Leave();
		}

		private void btnPayments_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				dbDataSet.VClientsRow vcr = GetSelectedRow();
				if (null == vcr)
					break;

				PaymentsHistory hist = new PaymentsHistory();
				hist.ClientId = vcr.id;
				hist.ShowDialog();
			} while (false);
			Logger.Leave();
		}

		private void BtnEntrance_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			UIMessages.NotImplementedFeature();
			Logger.Leave();
		}
	}
}
