using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
	public partial class ChangePassword : Form
	{
		private User m_user = null;
		
		public ChangePassword()
		{
			InitializeComponent();
			m_user = Session.Instance.User;
		}

		public ChangePassword(UInt64 userId)
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

			if (password.Text.Length < Properties.Settings.Default.PassLen)
			{
				message.Text = String.Format("Password must be at least {0} characters length.", Properties.Settings.Default.PassLen);
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
