using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;
using System.Data;

namespace EAssistant
{
	public partial class ManageUserRoles : Form
	{
		public ManageUserRoles()
		{
			InitializeComponent();
			userPrivilegesBindingSource.DataSource = Db.Instance.dSet.userPrivileges;
		}

		private void OnLoad(object sender, EventArgs e)
		{
			ReloadRoles();	
		}
		
		private void ReloadRoles()
		{
			Db.Instance.Adapters.userPrivilegesTableAdapter.Fill(Db.Instance.dSet.userPrivileges);
		}

		private void OnChangeCell(object sender, DataGridViewCellEventArgs e)
		{
			if (gridRoles.SelectedRows.Count < 1)
				return;

			if(gridRoles.SelectedRows[0].IsNewRow)
			{
				privilegesGrid.Rows.Clear();
				return;
			}
			dbDataSet.userPrivilegesRow row = (dbDataSet.userPrivilegesRow)((DataRowView)gridRoles.SelectedRows[0].DataBoundItem).Row;
			FillPrivileges(row);
		}
		
		private object[] GetRightsRow(String name, long rights)
		{
			object[] res = new object[5];
			
			res[0] = (object)name;
			res[1] = ((rights & (long)UserRights.Read) == (long)UserRights.Read) ? "X" : " ";
			res[2] = ((rights & (long)UserRights.Write) == (long)UserRights.Write) ? "X" : " ";
			res[3] = ((rights & (long)UserRights.Create) == (long)UserRights.Create) ? "X" : " ";
			res[4] = ((rights & (long)UserRights.Delete) == (long)UserRights.Delete) ? "X" : " ";
			
			return res;
		}

		private void FillPrivileges(dbDataSet.userPrivilegesRow priv)
		{
			privilegesGrid.Rows.Clear();
			int nRow = 0;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Users management", priv.users));
			privilegesGrid.Rows[nRow].Tag = priv.users;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage privileges", priv.privileges));
			privilegesGrid.Rows[nRow].Tag = priv.privileges;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage backup data", priv.backup));
			privilegesGrid.Rows[nRow].Tag = priv.backup;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage clients", priv.clients));
			privilegesGrid.Rows[nRow].Tag = priv.clients;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage payments", priv.payments));
			privilegesGrid.Rows[nRow].Tag = priv.payments;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage trainers", priv.trainers));
			privilegesGrid.Rows[nRow].Tag = priv.trainers;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage schedules", priv.schedule));
			privilegesGrid.Rows[nRow].Tag = priv.schedule;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage statistics", priv.statistics));
			privilegesGrid.Rows[nRow].Tag = priv.statistics;
		}
		
		private void CellValChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0
			&& e.RowIndex < privilegesGrid.Rows.Count
			&& e.ColumnIndex >= 0
			&& e.ColumnIndex < privilegesGrid.Rows[e.RowIndex].Cells.Count)
			{
				object o = privilegesGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
			}
		}

		private void OnClick(object sender, EventArgs e)
		{
			if (gridRoles.SelectedRows.Count < 1 || gridRoles.SelectedRows[0].IsNewRow)
				return;
				
			if (privilegesGrid.CurrentCell != null 
			&& privilegesGrid.CurrentCell.ColumnIndex > 0)
			{
				dbDataSet.userPrivilegesRow role = (dbDataSet.userPrivilegesRow)((DataRowView)gridRoles.SelectedRows[0].DataBoundItem).Row;
				
				long rights = (long)privilegesGrid.CurrentRow.Tag;
				String val = privilegesGrid.CurrentCell.Value.ToString();
				val = val == "X" ? " " : "X";
				privilegesGrid.CurrentCell.Value = val;
				
				if(val == "X")
					rights |= (1 << privilegesGrid.CurrentCell.ColumnIndex - 1);
				else
					rights ^= (1 << privilegesGrid.CurrentCell.ColumnIndex - 1);
				
				switch(privilegesGrid.CurrentRow.Index)
				{
					case 0:
						role.users = rights;
						break;
					case 1:
						role.privileges = rights;
						break;
					case 2:
						role.backup = rights;
						break;
					case 3:
						role.clients = rights;
						break;
					case 4:
						role.payments = rights;
						break;
					case 5:
						role.trainers = rights;
						break;
					case 6:
						role.schedule = rights;
						break;
					case 7:
						role.statistics = rights;
						break;
				}
				privilegesGrid.CurrentRow.Tag = rights;
			}
		}

		private void OnClosing(object sender, FormClosingEventArgs e)
		{
			Db.Instance.AcceptChanges();
		}
	}
}
