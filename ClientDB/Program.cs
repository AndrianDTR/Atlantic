using System;
using System.Windows.Forms;
using System.IO;
using AY.Log;
using AY.db;
using AY.Utils;

namespace GAssistant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			FileInfo fi = new FileInfo("reporter.exe");
			FileInfo exe = new FileInfo("G-Assistant.exe");
			byte[] buf = new byte[100];
			Int64 orgSize = 0;
			
			if (!ExeUtils.GetExeData(fi, ref buf, ref orgSize))
			{
				byte[] srcDate = BitConverter.GetBytes((Int64)DateTime.Now.Ticks);
				byte[] srcFailStr = BitConverter.GetBytes((Int64)35768);
				
				Array.Copy(srcDate, buf, srcDate.Length);
				Array.Copy(srcFailStr, 0, buf, srcDate.Length, srcFailStr.Length);
				ExeUtils.SetExeData(fi, buf);
			}
			
			if(!ExeUtils.CheckRegInfo(buf))
			{
				Int64 ticks = BitConverter.ToInt64(buf, 0);
				DateTime regDate = new DateTime(ticks);
				TimeSpan daysLeft = regDate.AddDays(30).Subtract(DateTime.Now);
				if(daysLeft.Days > 0)
				{
					DialogResult res = UIMessages.Warning(
						String.Format(
							  "You using unregistered copy of the application.\n"
							+ "Evaluation period will expire after {0} days.\n"
							+ "Please contact support and register it.\n\n"
							+ "If you want register your copy of the application now press \"Yes\"."
							, daysLeft.Days)
						, MessageBoxButtons.YesNo);
					if (DialogResult.Yes == res)
					{
						// TODO: Show registration dialog
					}
				}
				else
				{
					DialogResult res = UIMessages.Error(
						  "Evaluation period is expired!\n"
						+ "Do you wish register your copy of application?"
						, MessageBoxButtons.YesNo
						);
					if(DialogResult.Yes != res)
					{
						Application.Exit();
					}
					// TODO: Show registration dialog
				}
			}
			
			bool sendReport = false;
			String szLogFile = "SessionLog.txt";
			Logger.Create(szLogFile, Logger.LogLevel.Debug);
			Logger.Info("App start.");
			try
			{
				DbAdapter ad = new DbAdapter();
				if( !ad.CheckTables())
				{
					Logger.Critical("DB is corrupt.");
					DialogResult res = UIMessages.Error("Database is corrupt.", MessageBoxButtons.YesNo);
					if(res == DialogResult.Yes)
					{
						Logger.Warning("Clear DB after corrupt.");
						DbAdapter.ClearDB();
					}
				}
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}		
			catch(Exception ex)
			{
				Logger.Critical(ex.ToString());
				Logger.Trace(ex.StackTrace);
				if(DialogResult.Yes == UIMessages.Error("Program exited abnormally. Would you like to send report about this?", MessageBoxButtons.YesNo))
				{
					sendReport = true;
				}
			}
			
			Logger.Info("App end.");
            Logger.Close();
            
            if(sendReport)
            {
				SaveFileDialog dlg = new SaveFileDialog();
				if(DialogResult.OK == dlg.ShowDialog())
				{
					File.Copy(szLogFile, dlg.FileName, true);
					UIMessages.Info(String.Format("Report file has been saved to '{0}'. Please show this file to application developer.", dlg.FileName));
				}
            }
        }
    }
}
