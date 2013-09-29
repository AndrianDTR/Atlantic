using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EAssistant
{
	public partial class SetPassword : Form
	{
		public SetPassword()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (textPass.Text.Length < Session.Instance.PassLen)
			{
			    String msg = String.Format("Password must be at least {0} characters length.", Session.Instance.PassLen);
			    UIMessages.Warning(msg);
			    return;
			}
		 	DialogResult = DialogResult.OK;
			Close();
		}
		
		public String Password
		{
			get{ return textPass.Text; }
		}

		private void OnShowPass(object sender, EventArgs e)
		{
			textPass.UseSystemPasswordChar = !checkShowPass.Checked;
		}
	}
}
