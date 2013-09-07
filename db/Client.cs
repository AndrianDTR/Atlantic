using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class Client : DbTableRow
		{
			private String m_name = String.Empty;
			private String m_phone = String.Empty;
			private String m_comment = String.Empty;
			private String m_extraInfo = String.Empty;
			private String m_scheduleDays = String.Empty;
			private DateTime m_scheduleTime;
			private DateTime m_lastEnter;
			private DateTime m_lastLeave;
			private DateTime m_openTicket;
			private Int64 m_trainer = 0;
			private int m_timesLeft = 0;
			
			public static bool CodeExists(Int64 id)
			{
				return CodeExists(id.ToString());
			}

			public static bool CodeExists(String id)
			{
				String where = String.Format("id = '{0}'", id);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Clients, where, new List<string>());

				if (data == null)
				{
					return false;
				}
				return true;
			}
			
			public Client(Int64 id):base(DbTable.Clients, id)
			{
				m_name = Row["name"].ToString();
				m_phone = Row["phone"].ToString();
				m_comment = Row["comment"].ToString();
				m_extraInfo = Row["extraInfo"].ToString();
				m_scheduleDays = Row["scheduleDays"].ToString();
				m_scheduleTime = DateTime.Parse(Row["scheduleTime"].ToString());
				m_lastEnter = DateTime.Parse(Row["lastEnter"].ToString());
				m_lastLeave = DateTime.Parse(Row["lastLeave"].ToString());
				m_openTicket = DateTime.Parse(Row["openTicket"].ToString());
				m_trainer = Int64.Parse(Row["trainer"].ToString());
				m_timesLeft = int.Parse(Row["timesLeft"].ToString());
			}

			public Client(DataRow data)
			{
				Row = data;
				m_name = Row["name"].ToString();
				m_phone = Row["phone"].ToString();
				m_comment = Row["comment"].ToString();
				m_extraInfo = Row["extraInfo"].ToString();
				m_scheduleDays = Row["scheduleDays"].ToString();
				m_scheduleTime = DateTime.Parse(Row["scheduleTime"].ToString());
				m_lastEnter = DateTime.Parse(Row["lastEnter"].ToString());
				m_lastLeave = DateTime.Parse(Row["lastLeave"].ToString());
				m_openTicket = DateTime.Parse(Row["openTicket"].ToString());
				m_trainer = Int64.Parse(Row["trainer"].ToString());
				m_timesLeft = int.Parse(Row["timesLeft"].ToString());
			}
			
			public String Code
			{
				get
				{
					return m_id.ToString();
				}
			}
			
			public String Name
			{
				get
				{
					return DbUtils.Dequote(m_name);
				}
			}

			public String Phone
			{
				get
				{
					return DbUtils.Dequote(m_phone);
				}
			}

			public String Comment
			{
				get
				{
					return DbUtils.Dequote(m_comment);
				}
			}

			public String ExtraInfo
			{
				get
				{
					return m_extraInfo;
				}
				set
				{
					String data = value;
					
					Logger.Debug(String.Format("Set extraInfo for client '{0}'", m_name));
					if (m_id > 0)
					{
						DbAdapter ad = new DbAdapter();
						Dictionary<string, Object> fields = new Dictionary<string, Object>();
						fields["extraInfo"] = data;

						if (ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
						{	
							m_extraInfo = data;
						}
					}
				}
			}
			
			public int TimesLeft
			{
				get
				{
					return m_timesLeft;
				}
				set
				{
					int data = value;

					Logger.Debug(String.Format("Set times left for client '{0}'", m_name));
					if (m_id > 0)
					{
						DbAdapter ad = new DbAdapter();
						Dictionary<string, Object> fields = new Dictionary<string, Object>();
						fields["timesLeft"] = data;

						if (ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
						{
							m_timesLeft = data;
						}
					}
				}
			}

			public int DecHours
			{
				get
				{
					Trigger tlt = new Trigger(ExtraInfo);
					if (tlt.HasAttribute(TriggerFields.DecHours))
						return tlt[TriggerFields.DecHours];
					return 0;
				}
			}

			public DateTime LastEnter
			{
				get
				{
					return m_lastEnter;
				}
				set
				{
					DateTime enter = value;

					Logger.Debug(String.Format("Set last enter time for client '{0}'", m_id));
					if (m_id > 0)
					{
						DbAdapter ad = new DbAdapter();
						Dictionary<string, Object> fields = new Dictionary<string, Object>();
						fields["lastEnter"] = enter;

						if (ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
						{
							m_lastEnter = enter;
						}
					}
				}
			}

			public DateTime LastLeave
			{
				get
				{
					return m_lastLeave;
				}
				set
				{
					DateTime leave = value;

					Logger.Debug(String.Format("Set last leave time for client '{0}'", m_id));
					if (m_id > 0)
					{
						DbAdapter ad = new DbAdapter();
						Dictionary<string, Object> fields = new Dictionary<string, Object>();
						fields["lastLeave"] = leave;

						if (ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
						{
							m_lastEnter = leave;
						}
					}
				}
			}

			public DateTime OpenTicket
			{
				get
				{
					return m_openTicket;
				}
				set
				{
					DateTime enter = value;

					Logger.Debug(String.Format("Set open ticket time for client '{0}'", m_id));
					if (m_id > 0)
					{
						DbAdapter ad = new DbAdapter();
						Dictionary<string, Object> fields = new Dictionary<string, Object>();
						fields["openTicket"] = enter;

						if (ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
						{
							m_openTicket = enter;
						}
					}
				}
			}
			
			public String[] LastPayment
			{
				get
				{
					String[] res = new String[2];
					
					if(m_id == 0)
						return res;
						
					String where = String.Format("clientId = {0} order by date desc", m_id);
					DataRow data = new DbAdapter().GetFirstRow(
						  DbTable.Payments
						, where
						, new List<string>{"sum","date"});

					if (data != null)
					{
						res[0] = data["sum"].ToString();
						res[1] = data["date"].ToString();
					}

					return res;
				}
			}

			public String ScheduleDays
			{
				get
				{
					return DbUtils.Dequote(m_scheduleDays);
				}
			}
			
			public Trainer Trainer
			{
				get
				{
					return new Trainer(m_trainer);
				}
			}

			public Int64 TrainerId
			{
				get
				{
					return m_trainer;
				}
			}

			public DateTime ScheduleTime
			{
				get
				{
					return m_scheduleTime;
				}
			}

			public bool SetData(Int64 code, String name, String phone, String scheduleDays, DateTime scheduleTime, Int64 trainerId, String comment)
			{
				Logger.Debug(String.Format("Set data for client '{0}'", m_name));
				if (m_id <= 0)
				{
					return false;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, Object> fields = new Dictionary<string, Object>();
				fields["id"] = code.ToString();
				fields["name"] = DbUtils.Quote(name);
				fields["phone"] = DbUtils.Quote(phone);
				fields["scheduleDays"] = DbUtils.Quote(scheduleDays);
				fields["scheduleTime"] = scheduleTime.ToString("HH:mm:ss");
				fields["trainer"] = trainerId.ToString();
				fields["comment"] = DbUtils.Quote(comment);

				if (!ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
				{
					return false;
				}

				return true;
			}
			
			public void ProcessEnter()
			{
				Trigger tClient = new Trigger(ExtraInfo);
				Trigger tRule = null;

				if (tClient.HasAttribute(TriggerFields.RuleId))
				{
					Int64 ruleId = tClient[TriggerFields.RuleId];
					tRule = new Trigger(new ScheduleRule(ruleId).Rule);
				}

				TimesLeft--;

				if (tClient.HasAttribute(TriggerFields.HoursLeft))
				{
					int val = tClient[TriggerFields.HoursLeft];
					if (tRule != null && tRule.HasAttribute(TriggerFields.UCIDecHours))
						val -= tRule[TriggerFields.UCIDecHours];
					else
						val--;

					tClient[TriggerFields.HoursLeft] = val;
				}
				
				new StatisticsCollection().Add(Id, LastEnter, LastLeave);
				
				ExtraInfo = tClient.ToString();
			}
		}

		public class ClientCollection : DbTableRowCollection<Client> 
		{
			private CountChangedEventHandler m_countChanged = null;
			private CollectionChangedEventHandler m_collectionChanged = null;

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
				
				foreach (DataRow dr in dt.Rows)
				{
					Client client = new Client(dr);
					Items.Add(client.Id, client);
					OnCollectionChanged();
				}	
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

				Items[id] = new Client(id);
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.Clients, where);
			}
			
			public bool Remove(Int64 id)
			{
				if(!RemoveById(id))
					return false;
				return Items.Remove(id);
			}

			public bool Remove(Client item)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", item.Id);
				da.Delete(DbTable.Clients, where);
				return Items.Remove(item.Id);
			}

			public Client Search(Int64 id)
			{
				if (Items.ContainsKey(id))
					return Items[id];
				return null;
			}	
			
			public List<Client> Search(String name)
			{
				return Search(name, false);
			}

			public List<Client> Search(String name, Boolean contains)
			{
				List<Client> collection = new List<Client>();
				foreach (KeyValuePair<Int64, Client> client in Items)
				{
					if((contains && client.Value.Name.Contains(name)) || client.Value.Name.StartsWith(name))
					{
						collection.Add(client.Value);
					}
				}
				return collection;
			}
		}
	}
}
