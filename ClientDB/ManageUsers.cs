using System;
using System.Windows.Forms;
using System.Collections.Generic;
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
			InitializeComponent();
			Init();
			
			usersBindingSource.DataSource = Db.Instance.dSet.users;
			userPrivilegesBindingSource.DataSource = Db.Instance.dSet.userPrivileges;
		}

		private void Init()
		{
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
			
			
		}
		
		private void OnLoad(object sender, EventArgs e)
		{
			Db.Instance.Adapters.usersTableAdapter.Fill(Db.Instance.dSet.users);
			Db.Instance.Adapters.userPrivilegesTableAdapter.Fill(Db.Instance.dSet.userPrivileges);
		}
		
		private void ChangePass(object sender, EventArgs e)
		{
			//if (userList.SelectedItems.Count <= 0)
			//    return;

			//if (m_password.Text.Length < Session.Instance.PassLen)
			//{
			//    String msg = String.Format("Password must be at least {0} characters length.", Session.Instance.PassLen);
			//    UIMessages.Warning(msg);
			//    return;
			//}
			
			//dbDataSet.usersRow user =  new dbDataSet.usersRow((Int64)userList.SelectedItems[0].Tag);
			//user.Password = m_password.Text;
			
		}

		private void OnClosing(object sender, FormClosingEventArgs e)
		{
			Db.Instance.AcceptChanges();
		}

		private void OnCellClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
