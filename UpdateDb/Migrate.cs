using System;
using System.Collections.Generic;
using AY.Log;
using AY.db;
using AY.Utils;

namespace MigrateDb
{
	class Migrate 
	{
		public Migrate()
		{
			Logger.Enter();
			
			//Db.Instance.ExportData("AAA.gz");
			
			Logger.Leave();
		}
	}
}
