using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace GAssistant
{
    public partial class Login : Form
    {
		private int m_loginAttempt = 0;
		
		public Login()
        {
            InitializeComponent();
            m_loginAttempt = 3;
        }
		
		private void loginBtn_Click(object sender, EventArgs e)
		{
			if (m_loginAttempt == 0)
			{
				Logger.Error("Login failed, no attempt left");
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
			
			Logger.Debug("Try login, attempt left: "+ m_loginAttempt.ToString());
			
			User user = User.Authenticate(userName.Text, password.Text);
			
			if(user != null)
			{
				Session.Instance.User = user;
				Logger.Info(String.Format("User {0} login.", userName.Text));
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				Logger.Warning("Login failed, user: " + userName.Text + " password: " + password.Text);
				message.Text = "Login failed.\nPlease check username and password.";
				password.Text = "";
			}

			m_loginAttempt--;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Logger.Warning("Clear DB by user request.");
			DbAdapter.ClearDB();
		}
    }
}
