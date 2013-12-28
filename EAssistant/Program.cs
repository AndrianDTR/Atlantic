using System;
using System.Windows.Forms;
using System.IO;
using AY.Log;
using AY.Utils;
using System.Data.Common;
using System.Data;
using System.Threading;
using AY.Updater;
using AY.db;

namespace EAssistant
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static int Main(String[] args)
		{
			//String[] args = Environment.GetCommandLineArgs();

			String szLogFile = "SessionLog.txt";
			Logger.LogLevel logLvl = Logger.LogLevel.Warning;
#if DEBUG
			logLvl = Logger.LogLevel.Debug;
#endif

			Logger.Create(szLogFile, logLvl);
			Logger.Enter();

			bool sendReport = false;
			Logger.Info("App start.");

			try
			{
				do
				{
					Thread.CurrentThread.CurrentUICulture = CultureInfoUtils.CurrentCulture;

					if (args.Length != 0)
					{
						if ("-u" == args[0]
						|| "/u" == args[0]
						|| "--update" == args[0])
						{
							Logger.Info("Update application.");
							
							String prefix = DateTime.Now.ToString("yyyyMMdd");
							String ext = "dub";
							String archName = String.Format("{0}.{1}"
								, prefix
								, ext);
							Db.Instance.ExportData(archName);

							Updater.CheckNewVersion("http://pro100soft.eu/E-Assistant/updates/latest.xml");
						
							break;
						}
					}

					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new MainForm());
				} while (false);

			}
			catch (Exception ex)
			{
				Logger.Critical(ex.ToString());
				Logger.Trace(ex.StackTrace);

#if !DEBUG
				String msg = Session.GetResStr("abnormal_termination");				
				if(DialogResult.Yes == UIMessages.Error(msg
					, MessageBoxButtons.YesNo))
				{
					sendReport = true;
				}
#else
				throw ex;
#endif

			}
			Logger.Info("App end.");
			Logger.Leave();
			Logger.Flush();
			Logger.Close();

			if (sendReport)
			{
				new SendReport(false);
			}

			return 0;
		}
	}
}
