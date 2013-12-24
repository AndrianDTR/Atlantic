using System;
using System.Windows.Forms;
using System.IO;
using AY.Log;
using AY.db;
using AY.Utils;
using System.Data.Common;
using System.Data;
using System.Threading;

namespace EAssistant
{
    static class Program
    {
		/// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			String szLogFile = "SessionLog.txt";
			Logger.Create(szLogFile, Logger.LogLevel.Debug);
			Logger.Enter();

			bool sendReport = false;
			Logger.Info("App start.");
			
			try
			{
				Thread.CurrentThread.CurrentUICulture = Session.Instance.Culture;
			
				UIMessages.Error("AAAAA");
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}		
			catch(Exception ex)
			{
				Logger.Critical(ex.ToString());
				Logger.Trace(ex.StackTrace);

#if !DEBUG
				String msg = Session.Instance.GetResStr("abnormal_termination");				
				if(DialogResult.Yes == UIMessages.Error(msg, MessageBoxButtons.YesNo))
				{
					sendReport = true;
				}
#else
				throw ex;
#endif

			}
			Logger.Info("App end.");
			Logger.Leave();
			Logger.Close();
			
            if(sendReport)
            {
				new SendReport(false);
            }
        }
    }
}
