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
	public partial class ManageUsers : Form
	{
		UserCollection userCollection = new UserCollection();
		UserPrivilegesCollection privCollection = new UserPrivilegesCollection();
		
		public ManageUsers()
		{
			InitializeComponent();
			
		}

		private void save_Click(object sender, EventArgs e)
		{

		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{

		}
		
		private void close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			userList.Items.Clear();
			m_userRole.Items.Clear();
			
			foreach (UserPrivileges priv in privCollection)
			{
				int nItem = m_userRole.Items.Add(priv);
			}
			
			foreach (User user in userCollection)
			{
				ListViewItem it = userList.Items.Add(user.Name);
				it.SubItems.Add(user.Privileges.m_Name);
				it.Tag = user;
			}
		}

		private void ChangeUser(object sender, EventArgs e)
		{
			if(userList.SelectedItems.Count <= 0)
				return;
				
			User curItem = (User)userList.SelectedItems[0].Tag;

			m_userName.Text = curItem.Name;
		}
	}
}
