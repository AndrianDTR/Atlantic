using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
    public partial class Login : Form
    {
		private DbAdapter m_db = null;
		public long m_userId = -1;
		public UserPrivilege m_userPriv = new UserPrivilege();
		private int m_loginAttempt = 0;
		
		public Login()
        {
			m_db = DbAdapter.Instance;
            InitializeComponent();
        }

		private void loginBtn_Click(object sender, EventArgs e)
		{
			if (m_loginAttempt == 0)
				m_loginAttempt = 3;
			
			KeyValuePair<long, int> user = m_db.CheckUser(userName.Text, password.Text);
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

			m_loginAttempt--;

			if (m_loginAttempt == 0)
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}
    }
}
