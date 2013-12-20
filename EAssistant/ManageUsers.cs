using System;
using System.Windows.Forms;
using System.Data;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class ManageUsers : Form
	{
		private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewComboBoxColumn privilegeDataGridViewTextBoxColumn;
		private DataGridViewButtonColumn passDataGridViewTextBoxColumn;

		public ManageUsers()
		{
			Logger.Enter();
			InitializeComponent();
			Init();

			usersBindingSource.DataSource = Db.Instance.dSet.users;
			userPrivilegesBindingSource.DataSource = Db.Instance.dSet.userPrivileges;
			Logger.Leave();
		}

		private void Init()
		{
			Logger.Enter();
			idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			privilegeDataGridViewTextBoxColumn = new DataGridViewComboBoxColumn();
			passDataGridViewTextBoxColumn = new DataGridViewButtonColumn();

			gridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				idDataGridViewTextBoxColumn,
				nameDataGridViewTextBoxColumn,
				privilegeDataGridViewTextBoxColumn,
				passDataGridViewTextBoxColumn
				});

			// 
			// idDataGridViewTextBoxColumn
			// 
			idDataGridViewTextBoxColumn.DataPropertyName = "id";
			idDataGridViewTextBoxColumn.HeaderText = "ID";
			idDataGridViewTextBoxColumn.Name = "colId";
			idDataGridViewTextBoxColumn.Visible = false;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			nameDataGridViewTextBoxColumn.HeaderText = "Name";
			nameDataGridViewTextBoxColumn.Name = "colName";
			// 
			// passDataGridViewTextBoxColumn
			// 
			passDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			passDataGridViewTextBoxColumn.DataPropertyName = "pass";
			passDataGridViewTextBoxColumn.HeaderText = "Pass";
			passDataGridViewTextBoxColumn.Name = "colPass";
			passDataGridViewTextBoxColumn.Text = "Change";
			passDataGridViewTextBoxColumn.UseColumnTextForButtonValue = true;
			// 
			// privilegeDataGridViewTextBoxColumn
			// 
			privilegeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			privilegeDataGridViewTextBoxColumn.DataPropertyName = "privilege";
			privilegeDataGridViewTextBoxColumn.DataSource = userPrivilegesBindingSource;
			privilegeDataGridViewTextBoxColumn.DisplayMember = "name";
			privilegeDataGridViewTextBoxColumn.HeaderText = "Role";
			privilegeDataGridViewTextBoxColumn.Name = "colPriv";
			privilegeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			privilegeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			privilegeDataGridViewTextBoxColumn.ValueMember = "id";
			Logger.Leave();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			Logger.Enter();
			Db.Instance.Adapters.usersTableAdapter.Fill(Db.Instance.dSet.users);
			Db.Instance.Adapters.userPrivilegesTableAdapter.Fill(Db.Instance.dSet.userPrivileges);
			Logger.Leave();
		}

		private void OnCellClick(object sender, DataGridViewCellEventArgs e)
		{
			Logger.Enter();
			do
			{
				if (gridUsers.SelectedRows[0].IsNewRow || gridUsers.SelectedRows.Count < 1)
					break;

				if (gridUsers.Columns[e.ColumnIndex].Name != "colPass")
					break;

				SetPassword passDlg = new SetPassword();
				if (passDlg.ShowDialog() != DialogResult.OK)
					break;

				dbDataSet.usersRow user = (dbDataSet.usersRow)((DataRowView)gridUsers.SelectedRows[0].DataBoundItem).Row;
				user.pass = AY.Utils.SecUtils.md5(passDlg.Password);
			} while (false);
			Logger.Leave();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			Db.Instance.AcceptChanges();
			DialogResult = DialogResult.OK;
			Close();
			Logger.Leave();
		}

		private void OnDataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			Logger.Enter();
			UIMessages.Info(e.Exception.Message);
			Logger.Leave();
		}
	}
}
