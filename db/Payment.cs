using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public partial class clientDataSet
		{
			public partial class paymentsRow
			{
				private void UpdateClientInfo(clientDataSet.clientsRow client)
				{
					clientDataSet.scheduleRulesRow hoursAdd = Db.Instance.dSet.scheduleRules.FindByid(client.plan);
					
					client.hoursLeft += hoursAdd.hoursAdd;
					
					Db.Instance.AcceptChanges();
				}
			}
		}
	}
}