using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace GAssistant
{
	public partial class ChangePassword : Form
	{
		private User m_user = null;
		
		public ChangePassword()
		{
			InitializeComponent();
			m_user = Session.Instance.User;
		}

		public ChangePassword(Int64 userId)
		{
			InitializeComponent();
			m_user = new User(userId);
		}
		
		private void change_Click(object sender, EventArgs e)
		{
		 	if (password.Text != confirm.Text)
			{
				message.Text = "New password and confirm are different.";
				return;
			}

			if (current.Text == password.Text)
			{
				message.Text = "New password must be different than current.";
				return;
			}

			if (password.Text.Length < Session.Instance.PassLen)
			{
				message.Text = String.Format("Password must be at least {0} characters length.", Session.Instance.PassLen);
				return;
			}
			
			if(!m_user.ChangePassword(current.Text, password.Text))
			{
				message.Text = "Password has not been changed.";
				return;
			}
			
			MessageBox.Show("Password has been changed successfully.");
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
