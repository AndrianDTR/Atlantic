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
		UserRolesCollection privCollection = new UserRolesCollection();
		
		public ManageUsers()
		{
			InitializeComponent();
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
			UserCollection userCollection = new UserCollection();
			userList.Items.Clear();
			foreach (User user in userCollection)
			{
				ListViewItem it = userList.Items.Add(user.Name);
				it.SubItems.Add(user.Role.Name);
				it.Tag = user.Id;
			}
		}
		
		private void ChangeUser(object sender, EventArgs e)
		{
			m_password.Text = "";
			m_showPass.Checked = false;
			
			if(userList.SelectedItems.Count <= 0)
				return;
				
			User curItem = new User((Int64)userList.SelectedItems[0].Tag);

			m_userName.Text = curItem.Name;
			UserRole priv = privCollection.Search(curItem.Role.Id);
			if(priv == null)
			{
				UIMessages.Error("Invalid user role has been specified.");
				return;
			}
			
			m_userRole.SelectedItem = priv;
		}

		private void add_Click(object sender, EventArgs e)
		{
			UserCollection collection = new UserCollection();
			List<User> users = collection.Search(m_userName.Text);
			if(users.Count > 0)
			{
				UIMessages.Error("User with specified name already exists.");
				return;
			}
			
			UserRole role = (UserRole)m_userRole.SelectedItem;
			Int64 id = 0;
			if (!collection.Add(m_userName.Text, role.Id, out id))
			{
				UIMessages.Error("User could not been added.");
				return;
			}
			ListViewItem it = userList.Items.Add(m_userName.Text);
			it.SubItems.Add(role.Name);
			it.Tag = id;
		}

		private void remove_Click(object sender, EventArgs e)
		{
			if(userList.SelectedItems.Count < 1)
				return;

			Int64 userId = (Int64)userList.SelectedItems[0].Tag;
			if (!UserCollection.RemoveById(userId))
			{
				UIMessages.Error("User could not been removed.");
				return;
			}
			int ndx = userList.SelectedItems[0].Index - 1;
			userList.Items.Remove(userList.SelectedItems[0]);
			if(ndx >= 0)
				userList.Items[ndx].Selected = true;
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
			
			User user =  new User((Int64)userList.SelectedItems[0].Tag);
			user.Password = m_password.Text;
			
		}
	}
}
