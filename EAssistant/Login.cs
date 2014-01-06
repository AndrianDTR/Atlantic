﻿using System;
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
			Logger.Enter();
			InitializeComponent();
			m_loginAttempt = 2;
#if DEBUG
			userName.Text = "admin";
			password.Text = "administrator";
#endif
			Logger.Leave();
		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			if (m_loginAttempt == 0)
			{
				Logger.Error("Login failed, no attempt left.");
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}

			dbDataSet.usersRow user = dbDataSet.usersRow.Authenticate(userName.Text, password.Text);
			if (user != null && user.Role != null)
			{
				if (null == Db.Instance.dSet.userPrivileges.FindByid(user.privilege))
				{
					UIMessages.Error(Session.GetResStr("LI_NO_ACCESS_RIGHTS_RESOLVED"));
					this.DialogResult = DialogResult.Cancel;
					this.Close();
				}

				Session.Instance.SetUserInfo(user.id, user.privilege);

				Logger.Instance.User = user.name;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				Logger.Warning("Login failed, user: " + userName.Text + " password: " + password.Text);
				message.Text = Session.GetResStr("LI_LOGIN_FAILED");
				password.Text = "";
			}

			m_loginAttempt--;
			Logger.Leave();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Logger.Enter();
#if DEBUG
			Logger.Warning("Clear DB by user request.");
			Db.Instance.ResetDB();
#endif
			Logger.Leave();
		}
	}
}
