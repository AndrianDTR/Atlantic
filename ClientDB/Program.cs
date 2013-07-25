using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ClientDB
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
			Logger.Create(szLogFile, Logger.LogLevel.All);
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
