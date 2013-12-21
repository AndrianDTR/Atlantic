using System;
using System.Text;
using AY.Log;
using System.IO;
using System.Net.Mail;
using AY.Packer;
using System.Net;

namespace EAssistant
{
	class SendReport
	{
		String __to = "bug@pro100soft.eu";
		String __subj = "BUG";
		String __msg = "This mail is auto-generated.";
		String __from = "mandaryn.club@gmail.com";
		String __password = "Welcom!985";
		
		public SendReport(String filePath)
		{
			FileInfo f = new FileInfo(filePath);
			String archName = "Bug-report.gz";
			
			Archive.Compress(f, archName);
			FileInfo f2 = new FileInfo(archName);
			
			SendEmail(__to, __subj, __msg, archName);
			
			f.Delete();
			f2.Delete();
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
	}
}