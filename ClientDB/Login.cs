using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Diagnostics;

namespace ClientDB
{
    public partial class Login : Form
    {
		private int m_loginAttempt = 0;
		
		public Login()
        {
            InitializeComponent();
        }
		
		private void loginBtn_Click(object sender, EventArgs e)
		{
			if (m_loginAttempt == 0)
				m_loginAttempt = 3;

			User user = User.Authenticate(userName.Text, password.Text);
			
			if(user != null)
			{
				Session.Instance.User = user;
				this.DialogResult = DialogResult.OK;
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
