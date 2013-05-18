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
		private long uid = -1;
		private DbAdapter m_db = null;
		
		public long UserId
		{
			set
			{
				uid = value;
			}
		}
		
		public ChangePassword()
		{
			InitializeComponent();
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

			if (password.Text.Length < 8)
			{
				message.Text = "Password must be at least 8 characters length.";
				return;
			}
			
			if(!DbAdapter.Instance.SetUserPassword(uid, current.Text, password.Text))
			{
				message.Text = "Password could not been changed.";
			}
		}
	}
}
