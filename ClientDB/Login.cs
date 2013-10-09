using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;
using System.Data;

namespace EAssistant
{
    public partial class Login : Form
    {
		private int m_loginAttempt = 0;
		
		public Login()
        {
            InitializeComponent();
            m_loginAttempt = 2;
#if DEBUG
			userName.Text = "admin";
			password.Text = "administrator";
#endif
		}
		
		private void loginBtn_Click(object sender, EventArgs e)
		{
			if (m_loginAttempt == 0)
			{
				Logger.Error("Login failed, no attempt left.");
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
			
			Logger.Debug("Try login, attempt left: "+ m_loginAttempt.ToString());
			
			clientDataSet.usersRow user = clientDataSet.usersRow.Authenticate(userName.Text, password.Text);
			if(user != null && user.Role != null)
			{
				if (null == Db.Instance.dSet.userPrivileges.FindByid(user.privilege))
				{
					UIMessages.Error("Access rights could not be resolved for specified user.");
					this.DialogResult = DialogResult.Cancel;
					this.Close();
				}

				Session.Instance.SetUserInfo(user.id, user.privilege);

				Logger.Instance.User = user.name;
				Logger.Info(String.Format("dbDataSet.usersRow {0} login.", user.name));
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
#if DEBUG
			Logger.Warning("Clear DB by user request.");
			DbAdapter.ClearDB();
#endif
		}
    }
}
