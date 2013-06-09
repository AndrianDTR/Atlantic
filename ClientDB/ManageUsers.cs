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
		UserRolesCollection privCollection = new UserRolesCollection();
		
		public ManageUsers()
		{
			InitializeComponent();
			
		}

		private void save_Click(object sender, EventArgs e)
		{

		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			m_password.UseSystemPasswordChar = !m_showPass.Checked;
		}
		
		private void close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			m_userRole.Items.Clear();
			
			foreach (UserRole priv in privCollection)
			{
				int nItem = m_userRole.Items.Add(priv);
			}
			
			ReloadUsers();
		}
		
		private void ReloadUsers()
		{
			userCollection = new UserCollection();
			userList.Items.Clear();
			foreach (User user in userCollection)
			{
				ListViewItem it = userList.Items.Add(user.Name);
				it.SubItems.Add(user.Role.Name);
				it.Tag = user;
			}
		}
		
		private void ChangeUser(object sender, EventArgs e)
		{
			m_password.Text = "";
			m_showPass.Checked = false;
			
			if(userList.SelectedItems.Count <= 0)
				return;
				
			User curItem = (User)userList.SelectedItems[0].Tag;

			m_userName.Text = curItem.Name;
			List<UserRole> priv = privCollection.Search(curItem.Role.ToString());
			if(priv.Count > 0)
				m_userRole.SelectedItem = priv[0];
		}

		private void add_Click(object sender, EventArgs e)
		{
			List<User> users = userCollection.Search(m_userName.Text);
			if(users.Count > 0)
			{
				UIMessages.Error("User with specified name already exists.");
				return;
			}
			UserRole role = (UserRole)m_userRole.SelectedItem;
			
			if(!userCollection.Add(m_userName.Text, role.Id))
			{
				UIMessages.Error("User could not been added.");
				return;
			}
			ReloadUsers();
		}

		private void remove_Click(object sender, EventArgs e)
		{
			if(userList.SelectedItems.Count < 1)
				return;
				
			User user = (User)userList.SelectedItems[0].Tag;

			if (!userCollection.Remove(user))
			{
				UIMessages.Error("User could not been removed.");
				return;
			}
			ReloadUsers();
		}

		private void ChangePass(object sender, EventArgs e)
		{
			if (userList.SelectedItems.Count <= 0)
				return;

			if (m_password.Text.Length < Properties.Settings.Default.PassLen)
			{
				String msg = String.Format("Password must be at least {0} characters length.", Properties.Settings.Default.PassLen);
				UIMessages.Warning(msg);
				return;
			}
			
			User curUser = (User)userList.SelectedItems[0].Tag;
			curUser.Password = m_password.Text;
			
		}
	}
}
