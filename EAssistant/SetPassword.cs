using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AY.Log;

namespace EAssistant
{
	public partial class SetPassword : Form
	{
		public SetPassword()
		{
			Logger.Enter();
			InitializeComponent();
			Logger.Leave();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				if (textPass.Text.Length < Session.Instance.PassLen)
				{
					String msg = String.Format("Password must be at least {0} characters length.", Session.Instance.PassLen);
					UIMessages.Warning(msg);
					break;
				}
				DialogResult = DialogResult.OK;
				Close();
			} while (false);
			Logger.Leave();
		}

		public String Password
		{
			get { return textPass.Text; }
		}

		private void OnShowPass(object sender, EventArgs e)
		{
			Logger.Enter();
			textPass.UseSystemPasswordChar = !checkShowPass.Checked;
			Logger.Leave();
		}
	}
}
