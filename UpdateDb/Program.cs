using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AY.Log;
using AY.Utils;

namespace MigrateDb
{
	class Program
	{
		static void Main(string[] args)
		{
			String szLogFile = "MigrateLog.txt";
			Logger.Create(szLogFile, Logger.LogLevel.Debug);
			Logger.Enter();
			
			bool sendReport = false;
			
			try
			{
				Logger.Info("App start.");
				Migrate mig = new Migrate();
			}
			catch(Exception ex)
			{
				Logger.Emergency(ex.Message);
				sendReport = true;
			}
			
			Logger.Info("App end.");
			Logger.Leave();
		
			if(sendReport)
			{
				new SendReport(false);
			}

			Logger.Close();
		}
	}
}
