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
						/*	
						String where = String.Format("clientId={0}", id);
						Db.Instance.Adapters.paymentsTableAdapter.Fill(Db.Instance.dSet.payments);
						DataRow[] data = Db.Instance.dSet.payments.Select(where, "date desc");

						if (data.Length != 0)
						{
							res[0] = data[0]["sum"].ToString();
							res[1] = data[0]["date"].ToString();
						}
						*/
						return res;
					}
				}

				public void ProcessEnter()
				{
					Logger.Enter();
					Logger.Info("Deprecated.");
					/*
					dbDataSet.scheduleRulesRow sr = Db.Instance.dSet.scheduleRules.FindByid(plan);
					if(sr.Equals(null))
					{
						Logger.Error(String.Format("Schedule rule could not been found. Client: {0}, schedule rule: {1}.", id, plan));
						return;
					}
					
					hoursLeft -= sr.hoursPerLesson;

					int statsId = Db.Instance.Adapters.statisticsTableAdapter.Insert(id, openTicket, lastLeave);
					if(statsId == 0)
					{
						Logger.Error(String.Format("Statistic record could not be added. Client: {0}.", id));
						return;
					}
					*/
					Logger.Leave();
				}
			}
		}
	}
}
