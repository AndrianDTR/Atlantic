using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AY.Log;
using AY.db;

namespace EAssistant
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

			m_userRole.Items.Add(new UserRole());
			
			foreach (UserRole priv in privCollection)
			{
				m_userRole.Items.Add(priv);
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
				m_userRole.SelectedIndex = 0;
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
			
			int minPassLen = Session.Instance.PassLen;
			if(m_password.Text.Length < minPassLen)
			{
				UIMessages.Error(String.Format("Password length should be at least {0} characters.", minPassLen));
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
			new User(id).Password = m_password.Text;
			m_password.Text = "";
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

			if (m_password.Text.Length < Session.Instance.PassLen)
			{
				String msg = String.Format("Password must be at least {0} characters length.", Session.Instance.PassLen);
				UIMessages.Warning(msg);
				return;
			}
			
			User user =  new User((Int64)userList.SelectedItems[0].Tag);
			user.Password = m_password.Text;
			
		}
	}
}
