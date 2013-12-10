using System;
using System.Windows.Forms;
using System.IO;
using AY.Log;
using AY.db;
using AY.Utils;
using System.Data.Common;
using System.Data;

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
			bool sendReport = false;
			String szLogFile = "SessionLog.txt";
			Logger.Create(szLogFile, Logger.LogLevel.Debug);
			Logger.Info("App start.");

			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}		
			catch(Exception ex)
			{
				Logger.Critical(ex.ToString());
				Logger.Trace(ex.StackTrace);

#if !DEBUG
				if(DialogResult.Yes == UIMessages.Error("Program has been exited abnormally.\n"
					+ "Would you like to send report about this situation?"
					, MessageBoxButtons.YesNo))
				{
					sendReport = true;
				}
#else
				throw ex;
#endif

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
