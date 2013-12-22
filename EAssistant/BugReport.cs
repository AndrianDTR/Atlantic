using System;
using System.Windows.Forms;
using AY.Log;
using AY.Utils;

namespace EAssistant
{
	public partial class BugReport : Form
	{
		private object m_lock = new object();
		
		public BugReport()
		{
			Logger.Enter();
			InitializeComponent();
			Logger.Leave();
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			Logger.Enter();

			String text = String.Format("From: {0}<br/><br/>Problem: {1}"
				, textEmail.Text
				, textIssue.Text);
			new SendReport("Issue", text);
			
			DialogResult = DialogResult.OK;
			
			Logger.Leave();
			this.Close();
		}
	}
}
