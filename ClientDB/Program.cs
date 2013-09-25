using System;
using System.Windows.Forms;
using System.IO;
using AY.Log;
using AY.db;
using AY.Utils;

namespace EAssistant
{
    static class Program
    {
		private static void test()
		{
			Int64 newId = 1111000;
			Int64 id = 2200000000006;
			dbDataSet.clientsRow cr0 = Db.Instance.dSet.clients.FindByid(newId);
			dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(id);

			cr.BeginEdit();
			cr.name = "AAAAA";
			cr.EndEdit();
			cr.AcceptChanges();
			
			Db.Instance.Adapters.clientsTableAdapter.Update(Db.Instance.dSet.clients);
			
			dbDataSet.clientsRow ucr = Db.Instance.dSet.clients.FindByid(id);

			UIMessages.Info(ucr.name);
			Db.Instance.Adapters.clientsTableAdapter.Update(Db.Instance.dSet.clients);
		}
		
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
#if !DEBUG			
			try
			{
#endif

				test();
				/*DbAdapter ad = new DbAdapter();
				if( !ad.CheckTables())
				{
				
					Logger.Critical("DB is corrupt or not found.");
					DialogResult res = UIMessages.Error("Database is corrupt or not found.\n"
						+ "Do you wish to recreate database with default options?"
						, MessageBoxButtons.YesNo);
					if(res != DialogResult.Yes)
					{
						throw new Exception("Database is corrupt.");	
					}
					
					Logger.Warning("Clear DB after corrupt.");
					DbAdapter.ClearDB();
				}
				*/
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
#if !DEBUG
			}		
			catch(Exception ex)
			{
				Logger.Critical(ex.ToString());
				Logger.Trace(ex.StackTrace);
				if(DialogResult.Yes == UIMessages.Error("Program has been exited abnormally.\n"
					+ "Would you like to send report about this situation?"
					, MessageBoxButtons.YesNo))
				{
					sendReport = true;
				}
			}
#endif				
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
            
            Session.Instance.Dispose();
        }
    }
}
