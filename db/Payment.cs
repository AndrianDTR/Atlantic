using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class Payment
		{
			private Int64 m_id = 0;
			private Int64 m_client = 0;
			private Int64 m_schedule = 0;
			private Int64 m_creator = 0;
			private DateTime m_date = new DateTime();
			private float m_sum = 0.0F;
			private String m_comment = String.Empty;
			
			public Payment(Int64 id)
			{
				String where = String.Format("id = {0}", id);
				DataRow dataRow = new DbAdapter().GetFirstRow(DbTable.Payments
					, where
					, new List<string> { "id", "clientId", "scheduleId", "creatorId", "date", "sum", "comment" });

				if (dataRow == null)
				{
					throw new Exception("Error! No such payment.");
				}

				m_id = id;
				m_client = Int64.Parse(dataRow["clientId"].ToString());
				m_schedule = Int64.Parse(dataRow["scheduleId"].ToString());
				m_creator = Int64.Parse(dataRow["creatorId"].ToString());
				m_date = DateTime.Parse(dataRow["date"].ToString());
				m_sum = float.Parse(dataRow["sum"].ToString());
				m_comment = dataRow["comment"].ToString();
			}

			public Int64 Id
			{
				get
				{
					return m_id;
				}
			}

			public Int64 ClientId
			{
				get
				{
					return m_client;
				}
			}

			public Int64 ScheduleId
			{
				get
				{
					return m_schedule;
				}
			}
			
			public Int64 CreatorId
			{
				get
				{
					return m_creator;
				}
			}
			
			public DateTime Date
			{
				get
				{
					return m_date;
				}
			}

			public float Sum
			{
				get
				{
					return m_sum;
				}
			}

			public String Comment
			{
				get
				{
					return m_comment;
				}
			}
		}

		public class PaymentsCollection : IEnumerable<Payment>
		{
			Dictionary<Int64, Payment> Items = new Dictionary<Int64, Payment>();

			public PaymentsCollection(): this(0)
			{
			}

			public PaymentsCollection(Int64 clientId)
			{
				DbAdapter da = new DbAdapter();
				String query = String.Format("select id from {0};"
					, DbUtils.GetTableName(DbTable.Payments));
				if(clientId != 0)
				{
					query = String.Format("select id from {0} where clientId = {1};"
						, DbUtils.GetTableName(DbTable.Payments)
						, clientId);
				}
				
				DataTable dt = da.ExecuteQuery(query);
				foreach (DataRow dr in dt.Rows)
				{
					Payment item = new Payment(Int64.Parse(dr["id"].ToString()));
					Items[item.Id] = item;
				}
			}

			public Boolean Add(Int64 client, Int64 service, Int64 creator, float sum, String comment)
			{
				Int64 id = 0;
				return Add(client, service, creator, sum, comment, out id);
			}
			
			private void UpdateClientInfo(Int64 clientId, Int64 ruleId)
			{
				Client client = new Client(clientId);
				ScheduleRule rule = new ScheduleRule(ruleId);
				Trigger tClient = new Trigger(client.ExtraInfo);
				Trigger tRule = new Trigger(rule.Rule);

				if (tRule.HasAttribute(TriggerFields.CPUTimesLeft))
				{
					client.TimesLeft += tRule[TriggerFields.CPUTimesLeft];
				}

				if (tRule.HasAttribute(TriggerFields.CPUHoursLeft))
				{
					Object val = tClient[TriggerFields.HoursLeft];
					if (val != null)
						tClient[TriggerFields.HoursLeft] = int.Parse(val.ToString()) + int.Parse(tRule[TriggerFields.CPUHoursLeft]);
					else
						tClient[TriggerFields.HoursLeft] = tRule[TriggerFields.CPUHoursLeft];
				}

				if (tRule.HasAttribute(TriggerFields.UCIDecHours))
				{
					tClient[TriggerFields.DecHours] = tRule[TriggerFields.UCIDecHours];
				}
				else
				{
					tClient.Remove(TriggerFields.DecHours);
				}

				tClient[TriggerFields.RuleId] = rule.Id;
				
				client.ExtraInfo = tClient.ToString();
			}
			
			public Boolean Add(Int64 client, Int64 service, Int64 creator, float sum, String comment, out Int64 id)
			{
				DbAdapter da = new DbAdapter();
				Dictionary<string, Object> fields = new Dictionary<string, Object>();
				fields["clientId"] = client.ToString();
				fields["scheduleId"] = service.ToString();
				fields["creatorId"] = creator.ToString();
				fields["sum"] = sum.ToString();
				fields["comment"] = DbUtils.Quote(comment);
				
				id = 0;

				if (!da.Insert(DbTable.Payments, fields, out id))
					return false;

				UpdateClientInfo(client, service);
				
				Items[id] = new Payment(id);
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.Payments, where);
			}

			public bool Remove(Int64 id)
			{
				if (!RemoveById(id))
					return false;
				return Items.Remove(id);
			}

			public bool Remove(Payment item)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", item.Id);
				da.Delete(DbTable.Payments, where);
				return Items.Remove(item.Id);
			}

			public Payment Search(Int64 id)
			{
				if (Items.ContainsKey(id))
					return Items[id];
				return null;
			}

			public int Count
			{
				get { return Items.Count; }
			}

			public IEnumerator<Payment> GetEnumerator()
			{
				return Items.Values.GetEnumerator();
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return Items.Values.GetEnumerator();
			}
		}
	}
}