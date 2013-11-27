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
			public partial class clientsRow
			{
				public static bool Exists(Int64 id)
				{
					bool res = false;
					return res;
				}

				public String[] LastPayment
				{
					get
					{
						String[] res = new String[2];
						
						if(id == 0)
							return res;
							
						String where = String.Format("clientId={0}", id);
						Db.Instance.Adapters.paymentsTableAdapter.Fill(Db.Instance.dSet.payments);
						DataRow[] data = Db.Instance.dSet.payments.Select(where, "date desc");

						if (data.Length != 0)
						{
							res[0] = data[0]["sum"].ToString();
							res[1] = data[0]["date"].ToString();
						}

						return res;
					}
				}

				public dbDataSet.trainersRow Trainer
				{
					get
					{
						return Db.Instance.dSet.trainers.FindByid(trainer);
					}
				}
				
				public void ProcessEnter()
				{
					dbDataSet.scheduleRulesRow sr = Db.Instance.dSet.scheduleRules.FindByid(plan);
					if(sr.Equals(null))
					{
						return;
					}
					
					hoursLeft -= sr.hoursPerLesson;

					// TODO: Add entry to statistics table
					//new StatisticsCollection().Add(id, lastEnter, lastLeave);
					AcceptChanges();
				}
			}
		}
	}
}
