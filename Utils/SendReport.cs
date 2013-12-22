using System;
using System.Text;
using AY.Log;
using System.IO;
using System.Net.Mail;
using AY.Packer;
using System.Net;
using System.ComponentModel;

namespace AY.Utils
{
	public class SendReport
	{
		String __to = "bug@pro100soft.eu";
		String __from = "mandaryn.club@gmail.com";
		String __password = "Welcom!985";
		
		String szSubj = "";
		String szText = "";
						
		public SendReport(String subj, String body, bool bg)
		{
			Logger.Enter();
			
			szSubj = subj;
			szText = body;
			
			if(bg)
			{
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
			else
			{
				__Send();
				Logger.Continue();
			}
			
			Logger.Leave();
		}
		
		public SendReport(bool bg)
			: this("BUG", "This mail is auto-generated.", bg)
		{
			Logger.Enter();
			Logger.Leave();
		}

		public SendReport()
			: this(true)
		{
			Logger.Enter();
			Logger.Leave();
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

			__Send();

			Logger.Leave();
		}
		
		private void __Send()
		{
			Logger.Enter();

			Logger.Freeze();

			FileInfo f = new FileInfo(Logger.FilePath);
			String archName = "Bug-report.gz";

			Archive.Compress(f, archName);
#if !DEBUG
			SendEmail(__to, szSubj, szText, archName);
#endif

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