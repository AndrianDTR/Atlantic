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
						DataRow[] data = Db.Instance.dSet.payments.Select(where);

						if (data != null && data.Length > 1)
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
					/*
					Trigger tClient = new Trigger(plan.ToString());
					Trigger tRule = null;

					if (tClient.HasAttribute(TriggerFields.RuleId))
					{
						Int64 ruleId = tClient[TriggerFields.RuleId];
						tRule = new Trigger(new ScheduleRule(ruleId).Rule);
					}

					hoursLeft--;

					if (tClient.HasAttribute(TriggerFields.HoursLeft))
					{
						int val = tClient[TriggerFields.HoursLeft];
						if (tRule != null && tRule.HasAttribute(TriggerFields.UCIDecHours))
							val -= tRule[TriggerFields.UCIDecHours];
						else
							val--;

						tClient[TriggerFields.HoursLeft] = val;
					}
					
					// TODO: Add entry to statistics table
					//new StatisticsCollection().Add(id, lastEnter, lastLeave);
					
					plan = tClient.ToString();
					*/
					Db.Instance.AcceptCahnges();
				}
			}
		}
	}
}
