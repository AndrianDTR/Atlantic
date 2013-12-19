using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class ChangePassword : Form
	{
		private dbDataSet.usersRow m_user = null;

		public ChangePassword()
		{
			Logger.Enter();
			InitializeComponent();
			m_user = Db.Instance.dSet.users.FindByid(Session.Instance.UserId);
			Logger.Leave();
		}

		public ChangePassword(Int64 userId)
		{
			Logger.Enter();
			InitializeComponent();
			m_user = Db.Instance.dSet.users.FindByid(userId);
			Logger.Leave();
		}

		private void change_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				if (password.Text != confirm.Text)
				{
					message.Text = "New password and confirm are different.";
					break;
				}

				if (current.Text == password.Text)
				{
					message.Text = "New password must be different than current.";
					break;
				}

				if (password.Text.Length < Session.Instance.PassLen)
				{
					message.Text = String.Format("Password must be at least {0} characters length.", Session.Instance.PassLen);
					break;
				}

				if (!m_user.ChangePassword(current.Text, password.Text))
				{
					message.Text = "Password has not been changed.";
					break;
				}

				MessageBox.Show("Password has been changed successfully.");
				this.DialogResult = DialogResult.OK;
				this.Close();
			} while (false);
			Logger.Leave();
		}
	}
}
