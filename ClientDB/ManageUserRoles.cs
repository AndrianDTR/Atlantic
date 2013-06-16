using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
	public partial class ManageUserRoles : Form
	{
		UserRole edit = null;
		
		public ManageUserRoles()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			ReloadRoles();	
		}
		
		private void ReloadRoles()
		{
			UserRolesCollection collection = new UserRolesCollection();
			privilegesGrid.Rows.Clear();

			foreach (UserRole priv in collection)
			{
				ListViewItem it = listRoles.Items.Add(priv.Name);
				it.Tag = priv.Id;
			}
		}
		
		private object[] GetRightsRow(String name, UserRights rights)
		{
			object[] res = new object[5];
			
			res[0] = (object)name;
			res[1] = ((rights & UserRights.Read) == UserRights.Read) ? "X" : " ";
			res[2] = ((rights & UserRights.Write) == UserRights.Write) ? "X" : " ";
			res[3] = ((rights & UserRights.Create) == UserRights.Create) ? "X" : " ";
			res[4] = ((rights & UserRights.Delete) == UserRights.Delete) ? "X" : " ";
			
			return res;
		}
		
		private void FillPrivileges(UserRole priv)
		{
			privilegesGrid.Rows.Clear();
			int nRow = 0;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Users management", priv.Users));
			privilegesGrid.Rows[nRow].Tag = priv.Users;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage privileges", priv.Privileges));
			privilegesGrid.Rows[nRow].Tag = priv.Privileges;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage backup data", priv.Backup));
			privilegesGrid.Rows[nRow].Tag = priv.Backup;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage clients", priv.Clients));
			privilegesGrid.Rows[nRow].Tag = priv.Clients;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage payments", priv.Payments));
			privilegesGrid.Rows[nRow].Tag = priv.Payments;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage trainers", priv.Trainers));
			privilegesGrid.Rows[nRow].Tag = priv.Trainers;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage schedules", priv.Schedule));
			privilegesGrid.Rows[nRow].Tag = priv.Schedule;
			nRow = privilegesGrid.Rows.Add(GetRightsRow("Manage statistics", priv.Statistics));
			privilegesGrid.Rows[nRow].Tag = priv.Statistics;
		}
		
		private void listRoles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(listRoles.SelectedItems.Count < 1)
				return;

			UserRole priv = new UserRole((Int64)listRoles.SelectedItems[0].Tag);
			FillPrivileges(priv);
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

		private void AfterEdit(object sender, LabelEditEventArgs e)
		{
			if (edit == null && listRoles.SelectedItems.Count > 0)
			{
				edit = new UserRole((Int64)listRoles.SelectedItems[0].Tag);
			}
			
			if(e.Label != null)
			{
				edit.Name = e.Label;
				listRoles.SelectedItems[0].Text = e.Label;
				edit = null;
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			String name = "New role";
			Int64 id = 0;

			UserRolesCollection collection = new UserRolesCollection();
			if(!collection.Add(name, out id))
			{	
				UIMessages.Error("New role could not been added.");
				return;
			}
			
			UserRole role = new UserRole(id);
			
			ListViewItem it = listRoles.Items.Add(name);
			edit = role;
			it.Tag = id;
			it.BeginEdit();
		}

		private void delButton_Click(object sender, EventArgs e)
		{
			if (listRoles.SelectedItems.Count > 0)
			{
				Int64 id = (Int64)listRoles.SelectedItems[0].Tag;
				if(!UserRolesCollection.RemoveById(id))
				{
					UIMessages.Error("Role could not been removed.");
					return;
				}
				listRoles.Items.Remove(listRoles.SelectedItems[0]);
				privilegesGrid.Rows.Clear();
			}
		}

		private void OnClick(object sender, EventArgs e)
		{
			if (listRoles.SelectedItems.Count <= 0)
				return;
				
			if (privilegesGrid.CurrentCell != null 
			&& privilegesGrid.CurrentCell.ColumnIndex > 0)
			{
				UserRole role = new UserRole((Int64)listRoles.SelectedItems[0].Tag);
				
				UserRights rights = (UserRights)privilegesGrid.CurrentRow.Tag;
				String val = privilegesGrid.CurrentCell.Value.ToString();
				val = val == "X" ? " " : "X";
				privilegesGrid.CurrentCell.Value = val;
				
				if(val == "X")
					rights |= (UserRights)(1 << privilegesGrid.CurrentCell.ColumnIndex - 1);
				else
					rights ^= (UserRights)(1 << privilegesGrid.CurrentCell.ColumnIndex - 1);
				
				switch(privilegesGrid.CurrentRow.Index)
				{
					case 0:
						role.Users = rights;
						break;
					case 1:
						role.Privileges = rights;
						break;
					case 2:
						role.Backup = rights;
						break;
					case 3:
						role.Clients = rights;
						break;
					case 4:
						role.Payments = rights;
						break;
					case 5:
						role.Trainers = rights;
						break;
					case 6:
						role.Schedule = rights;
						break;
					case 7:
						role.Statistics = rights;
						break;
				}
				privilegesGrid.CurrentRow.Tag = rights;
			}
		}
	}
}
