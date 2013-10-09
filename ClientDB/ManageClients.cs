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
		private DataGridViewTextBoxColumn colPhone;
		private DataGridViewTextBoxColumn colSchedule;
		private DataGridViewTextBoxColumn colScheduleTime;
		private DataGridViewTextBoxColumn colLastEnter;
		private DataGridViewTextBoxColumn colLastLeave;
		private DataGridViewTextBoxColumn colOpenTicket;
		private DataGridViewTextBoxColumn colTrainer;
		private DataGridViewTextBoxColumn colComment;
		private DataGridViewTextBoxColumn colPlanId;
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
			colPhone = new DataGridViewTextBoxColumn();
			colSchedule = new DataGridViewTextBoxColumn();
			colScheduleTime = new DataGridViewTextBoxColumn();
			colLastEnter = new DataGridViewTextBoxColumn();
			colLastLeave = new DataGridViewTextBoxColumn();
			colOpenTicket = new DataGridViewTextBoxColumn();
			colTrainer = new DataGridViewTextBoxColumn();
			colComment = new DataGridViewTextBoxColumn();
			colPlanId = new DataGridViewTextBoxColumn();
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
			// 
			// phoneDataGridViewTextBoxColumn
			// 
			colPhone.DataPropertyName = "phone";
			colPhone.HeaderText = "phone";
			colPhone.Name = "phoneDataGridViewTextBoxColumn";
			colPhone.Visible = false;
			// 
			// scheduleDaysDataGridViewTextBoxColumn
			// 
			colSchedule.DataPropertyName = "scheduleDays";
			colSchedule.HeaderText = "Days";
			colSchedule.Name = "scheduleDaysDataGridViewTextBoxColumn";
			colSchedule.Visible = false;
			// 
			// scheduleTimeDataGridViewTextBoxColumn
			// 
			colScheduleTime.DataPropertyName = "scheduleTime";
			colScheduleTime.HeaderText = "Time";
			colScheduleTime.Name = "scheduleTimeDataGridViewTextBoxColumn";
			colScheduleTime.Visible = false;
			// 
			// lastEnterDataGridViewTextBoxColumn
			// 
			colLastEnter.DataPropertyName = "lastEnter";
			colLastEnter.HeaderText = "Last enter";
			colLastEnter.Name = "lastEnterDataGridViewTextBoxColumn";
			colLastEnter.Visible = false;
			// 
			// lastLeaveDataGridViewTextBoxColumn
			// 
			colLastLeave.DataPropertyName = "lastLeave";
			colLastLeave.HeaderText = "lastLeave";
			colLastLeave.Name = "lastLeaveDataGridViewTextBoxColumn";
			colLastLeave.Visible = false;
			// 
			// openTicketDataGridViewTextBoxColumn
			// 
			colOpenTicket.DataPropertyName = "openTicket";
			colOpenTicket.HeaderText = "openTicket";
			colOpenTicket.Name = "openTicketDataGridViewTextBoxColumn";
			colOpenTicket.Visible = false;
			// 
			// trainerDataGridViewTextBoxColumn
			// 
			colTrainer.DataPropertyName = "trainer";
			colTrainer.HeaderText = "trainer";
			colTrainer.Name = "trainerDataGridViewTextBoxColumn";
			colTrainer.Visible = false;
			// 
			// commentDataGridViewTextBoxColumn
			// 
			colComment.DataPropertyName = "comment";
			colComment.HeaderText = "comment";
			colComment.Name = "commentDataGridViewTextBoxColumn";
			colComment.Visible = false;
			// 
			// planIdDataGridViewTextBoxColumn
			// 
			colPlanId.DataPropertyName = "plan";
			colPlanId.HeaderText = "Plan ID";
			colPlanId.Name = "planIdDataGridViewTextBoxColumn";
			colPlanId.Visible = false;
			// 
			// planDataGridViewTextBoxColumn
			// 
			colPlan.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colPlan.DataPropertyName = "rule";
			colPlan.HeaderText = "Plan";
			colPlan.Name = "ruleDataGridViewTextBoxColumn";
			// 
			// hoursLeftDataGridViewTextBoxColumn
			// 
			colHoursLeft.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colHoursLeft.DataPropertyName = "hoursLeft";
			colHoursLeft.HeaderText = "Hours left";
			colHoursLeft.Name = "hoursLeftDataGridViewTextBoxColumn";

			gridClients.Columns.AddRange(new DataGridViewColumn[] {
				colId,
				colName,
				colPhone,
				colSchedule,
				colScheduleTime,
				colLastEnter,
				colLastLeave,
				colOpenTicket,
				colTrainer,
				colComment,
				colPlanId,
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
				//clientsBindingSource.Filter = "";
				return;
			}

			String pattern = "%{0}%";
			if (checkStartWith.Checked)
				pattern = "{0}%";

			String query = String.Format("id = '{0}'", val);
			if (checkNames.Checked)
				query += String.Format(" or name like '{0}'", pattern);

			//clientsBindingSource.Filter = String.Format(query, val);
		}
		
		private void btnAdd_Click(object sender, EventArgs e)
		{
			ClientInfo ci = new ClientInfo(null);
			if (DialogResult.OK != ci.ShowDialog(this))
			    return;

			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Db.Instance.AcceptChanges();
		}
		
		private void OnEdit(object sender, EventArgs e)
		{
			EditClient();
		}
		
		private void EditClient()
		{
			/*Int64 id = GetSelectedClientId();
			
			if(-1 == id)
			    return;
				
			ClientInfo ci = new ClientInfo(id);
			
			if (DialogResult.OK != ci.ShowDialog())
			    return;
			
			int index = gridClients.SelectedRows[0].Index;
			
			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
			*/
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
	}
}
