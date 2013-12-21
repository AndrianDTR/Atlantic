using System;
using System.Text;
using AY.Log;
using System.IO;
using System.Net.Mail;
using AY.Packer;
using System.Net;
using System.ComponentModel;

namespace EAssistant
{
	class SendReport
	{
		String __to = "bug@pro100soft.eu";
		String __from = "mandaryn.club@gmail.com";
		String __password = "Welcom!985";
		
		String szSubj = "";
		String szText = "";
						
		public SendReport(String subj, String body)
		{
			szSubj = subj;
			szText = body;
			
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork +=
				new DoWorkEventHandler(bw_DoWork);
			bw.RunWorkerCompleted +=
				new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

			if (bw.IsBusy != true)
			{
				bw.RunWorkerAsync();
			}
		}
		
		public SendReport()
			: this("BUG", "This mail is auto-generated.")
		{
		}
		
		private void SendEmail(string To, string Subject, string Msg, String reportFile)
		{
			Logger.Enter();
			
			var loginInfo = new NetworkCredential(__from, __password);
			var msg = new MailMessage();
			var smtpClient = new SmtpClient("smtp.gmail.com", 587);

			msg.From = new MailAddress(__from);
			msg.To.Add(new MailAddress(__to));
			msg.Subject = Subject;
			msg.Body = Msg;
			msg.IsBodyHtml = true;
			msg.Attachments.Add(new Attachment(reportFile));

			smtpClient.EnableSsl = true;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = loginInfo;
			smtpClient.Send(msg);

			Logger.Leave();
		}

		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Logger.Enter();

			BackgroundWorker worker = sender as BackgroundWorker;

			Logger.Freeze();

			FileInfo f = new FileInfo(Logger.FilePath);
			String archName = "Bug-report.gz";

			Archive.Compress(f, archName);
			SendEmail(__to, szSubj, szText, archName);

			Logger.Leave();
		}

		private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Logger.Enter();
			if ((e.Cancelled == true))
			{
				Logger.Info("Send report canceled.");
			}
			else if (!(e.Error == null))
			{
				Logger.Info("Error: " + e.Error.Message);
			}
			else
			{
				Logger.Continue();
			}
			Logger.Leave();
		}	
	}
}