using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class Client : dbDataSet.clientsRow
		{
			public static bool Exists(Int64 id)
			{
				bool res = false;
				return res;
			}

			public Client(DataRowBuilder bldr)
				: base(bldr)
			{
			}

			public int DecHours
			{
				get
				{
					Trigger tlt = new Trigger(plan);
					if (tlt.HasAttribute(TriggerFields.DecHours))
						return tlt[TriggerFields.DecHours];
					return 0;
				}
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
				Trigger tClient = new Trigger(plan);
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
				AcceptChanges();
				Db.Instance.Adapters.clientsTableAdapter.Update(this);
			}
		}
/*
		public class ClientCollection : DbTableRowCollectionBase
		{
			private CountChangedEventHandler m_countChanged = null;
			private CollectionChangedEventHandler m_collectionChanged = null;
			private DataRowCollection m_Items = null;
			
			public CollectionChangedEventHandler CollectionChangedHandler
			{
				get
				{
					return m_collectionChanged;
				}
				set
				{
					m_collectionChanged = value;
				}
			}
			
			public CountChangedEventHandler CountChangedHandler
			{
				get
				{
					return m_countChanged;
				}
				set
				{
					m_countChanged = value;
				}
			}

			public override void OnCollectionChanged()
			{
				if (null != m_collectionChanged)
					m_collectionChanged();
			}
			
			public override void OnCountChanged(Int64 newCount)
			{
				if(null != m_countChanged)
					m_countChanged(newCount);
			}

			public ClientCollection()
			{
			}
			
			public void Refresh()
			{
				Refresh("");
			}

			public void Refresh(String filter)
			{
				DbAdapter da = new DbAdapter();
				
				if(filter.Length > 0)
					filter = "where " + filter;
				
				DataTable dt = da.ExecuteQuery(
					  String.Format("select * from {0} {1};"
					, DbUtils.GetTableName(DbTable.Clients)
					, filter));

				OnCountChanged(dt.Rows.Count);
				
				m_Items = dt.Rows;
			}

			public Boolean Add(Int64 code, String name, String phone, String scheduleDays, DateTime scheduleTime, String comment, Int64 trainer)
			{
				Int64 id = 0;
				return Add(code, name, phone, scheduleDays, scheduleTime, trainer, comment, out id);
			}

			public Boolean Add(Int64 code, String name, String phone, String scheduleDays, DateTime scheduleTime, Int64 trainer, String comment, out Int64 id)
			{
				DbAdapter da = new DbAdapter();
				Dictionary<string, Object> fields = new Dictionary<string, Object>();
				fields["id"] = code.ToString();
				fields["name"] = DbUtils.Quote(name);
				fields["phone"] = DbUtils.Quote(phone);
				fields["scheduleDays"] = DbUtils.Quote(scheduleDays);
				fields["scheduleTime"] = scheduleTime.ToString("HH:mm:ss");
				fields["trainer"] = trainer.ToString();
				fields["comment"] = DbUtils.Quote(comment);
				id = 0;

				if (!da.Insert(DbTable.Clients, fields, out id))
					return false;
				
				DataRow dr = da.GetFirstRow(DbTable.Clients, String.Format("id = {0}", id), new List<string>{});
				m_Items.Add(dr);
				
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.Clients, where);
			}
			
			public bool Remove(DataRow row)
			{
				Int64 id = Int64.Parse(row["id"].ToString());
				if(!RemoveById(id))
					return false;
				m_Items.Remove(row);
				return true;
			}

			public DataRow Search(Int64 id)
			{
				foreach (DataRow dr in m_Items)
				{
					if(Int64.Parse(dr["id"].ToString()) == id)
						return dr;
				}
				return null;
			}	
			
			public DataRowCollection Items
			{
				get{ return m_Items; }
			}
		}*/
	}
}
