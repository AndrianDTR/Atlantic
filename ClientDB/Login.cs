using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace ClientDB
{
    public partial class Login : Form
    {
		private ClientDBDataSet m_db = null;
		public long m_userId = -1;
		public UserPrivilege m_userPriv = new UserPrivilege();
		private int m_loginAttempt = 0;
		
		public Login()
        {
			m_db = DbAdapter.Instance.ClientDataSet;
            InitializeComponent();
        }

		private void loginBtn_Click(object sender, EventArgs e)
		{
			if (m_loginAttempt == 0)
				m_loginAttempt = 3;
			
			DataTable privs = m_db.userPrivileges;
			DataTable users = m_db.users;
			
			var q = from user in users.AsEnumerable()
			//join priv in privs.AsEnumerable() on user["privilege"] equals priv["id"] into j1
			//from j2 in j1.DefaultIfEmpty() 
			select user;

			foreach (var user in q)
			{
				Debug.WriteLine("User ID: {0}", user["Id"].ToString());				
			}

			/*
			if (-1 != user.Key)
			{
				this.DialogResult = DialogResult.OK;
				m_userId = user.Key;
				m_userPriv = m_db.GetUserPrivilegeById(user.Value);
				this.Close();
			}
			else
			{
				message.Text = "Login failed.\nPlease check username and password.";
				password.Text = "";
			}
			//*/

			m_loginAttempt--;

			if (m_loginAttempt == 0)
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}
    }
}
