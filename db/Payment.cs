using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public partial class dbDataSet
		{
			public partial class paymentsRow
			{
				private void UpdateClientInfo(dbDataSet.clientsRow client)
				{
					dbDataSet.scheduleRulesRow hoursAdd = Db.Instance.dSet.scheduleRules.FindByid(client.plan);
					
					client.hoursLeft += hoursAdd.hoursAdd;
					
					Db.Instance.AcceptChanges();
				}
			}
		}
	}
}