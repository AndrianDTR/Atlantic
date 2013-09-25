using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class ManageUsers : Form
	{
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

			m_userRole.Items.Add("");

			foreach (dbDataSet.userPrivilegesRow priv in Db.Instance.dSet.userPrivileges.Rows)
			{
				m_userRole.Items.Add(priv);
			}
			
			ReloadUsers();
		}
		
		private void ReloadUsers()
		{
			userList.Items.Clear();
			foreach (dbDataSet.usersRow user in Db.Instance.dSet.users.Rows)
			{
				ListViewItem it = userList.Items.Add(user.name);
				it.SubItems.Add(user.Role.name);
				it.Tag = user.id;
			}
		}
		
		private void ChangeUser(object sender, EventArgs e)
		{
			m_password.Text = "";
			m_showPass.Checked = false;
			
			if(userList.SelectedItems.Count <= 0)
				return;
			
			Int64 uId = (Int64)userList.SelectedItems[0].Tag;
			dbDataSet.usersRow curItem = Db.Instance.dSet.users.FindByid(uId);

			m_userName.Text = curItem.name;
			dbDataSet.userPrivilegesRow priv = curItem.Role;
			if(priv == null)
			{
				m_userRole.SelectedIndex = 0;
				return;
			}
			
			m_userRole.SelectedItem = priv;
		}

		private void add_Click(object sender, EventArgs e)
		{
			//UserCollection collection = new UserCollection();
			//List<dbDataSet.usersRow> users = collection.Search(m_userName.Text);
			//if(users.Count > 0)
			//{
			//    UIMessages.Error("dbDataSet.usersRow with specified name already exists.");
			//    return;
			//}
			
			//int minPassLen = Session.Instance.PassLen;
			//if(m_password.Text.Length < minPassLen)
			//{
			//    UIMessages.Error(String.Format("Password length should be at least {0} characters.", minPassLen));
			//    return;
			//}
			
			//UserRole role = (UserRole)m_userRole.SelectedItem;
			//Int64 id = 0;
			//if (!collection.Add(m_userName.Text, role.Id, out id))
			//{
			//    UIMessages.Error("dbDataSet.usersRow could not been added.");
			//    return;
			//}
			//ListViewItem it = userList.Items.Add(m_userName.Text);
			//it.SubItems.Add(role.Name);
			//it.Tag = id;
			//new dbDataSet.usersRow(id).Password = m_password.Text;
			//m_password.Text = "";
		}

		private void remove_Click(object sender, EventArgs e)
		{
			//if(userList.SelectedItems.Count < 1)
			//    return;

			//Int64 userId = (Int64)userList.SelectedItems[0].Tag;
			//if (!UserCollection.RemoveById(userId))
			//{
			//    UIMessages.Error("dbDataSet.usersRow could not been removed.");
			//    return;
			//}
			//int ndx = userList.SelectedItems[0].Index - 1;
			//userList.Items.Remove(userList.SelectedItems[0]);
			//if(ndx >= 0)
			//    userList.Items[ndx].Selected = true;
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
	}
}
