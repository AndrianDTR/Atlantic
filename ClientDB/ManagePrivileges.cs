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
	public partial class ManagePrivileges : Form
	{
		UserPrivilegesCollection collection = new UserPrivilegesCollection();
		
		public ManagePrivileges()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			privilegesGrid.Rows.Clear();
			
			foreach (UserPrivileges priv in collection)
			{
				ListViewItem it = listRoles.Items.Add(priv.ToString());
				it.Tag = priv;
			}
		}
		
		private object[] GetRightsRow(String name, UserRights rights)
		{
			object[] res = new object[5];
			
			res[0] = (object)name;
			res[1] = (rights & UserRights.Read) == UserRights.Read;
			res[2] = (rights & UserRights.Write) == UserRights.Write;
			res[3] = (rights & UserRights.Create) == UserRights.Create;
			res[4] = (rights & UserRights.Delete) == UserRights.Delete;
			
			return res;
		}
		
		private void FillPrivileges(UserPrivileges priv)
		{
			privilegesGrid.Rows.Add(GetRightsRow("Users management", priv.users));
			privilegesGrid.Rows.Add(GetRightsRow("Manage privileges", priv.privileges));
			privilegesGrid.Rows.Add(GetRightsRow("Manage backup data", priv.backup));
			privilegesGrid.Rows.Add(GetRightsRow("Clients", priv.clients));
			privilegesGrid.Rows.Add(GetRightsRow("Manage payments", priv.payments));
			privilegesGrid.Rows.Add(GetRightsRow("Manage trainers", priv.trainers));
			privilegesGrid.Rows.Add(GetRightsRow("Manage schedules", priv.schedule));
			privilegesGrid.Rows.Add(GetRightsRow("Manage statistics", priv.statistics));
		}
		
		private void listRoles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(listRoles.SelectedItems.Count < 1)
				return;
			
			UserPrivileges priv = (UserPrivileges)listRoles.Items[0].Tag;
			FillPrivileges(priv);
		}
		
		private void CellValChanged(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void AfterEdit(object sender, LabelEditEventArgs e)
		{

		}

		private void addButton_Click(object sender, EventArgs e)
		{
			ListViewItem it = listRoles.Items.Add("New role");
			it.BeginEdit();
		}

		private void delButton_Click(object sender, EventArgs e)
		{

		}
	}
}
