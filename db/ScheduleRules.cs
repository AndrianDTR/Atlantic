using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class ScheduleRule
		{
			private Int64 m_id = 0;
			private String m_Name = String.Empty;
			private String m_Rule = String.Empty;
			private float m_Price = 0.0F;

			public static bool operator ==(ScheduleRule p1, ScheduleRule p2)
			{
				return p1.Id == p2.Id;
			}

			public static bool operator !=(ScheduleRule p1, ScheduleRule p2)
			{
				return !(p1.Id == p2.Id);
			}
			
			public ScheduleRule()
			{
			
			}
			
			public ScheduleRule(Int64 id)
			{
				String where = String.Format("id = {0}", id);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.ScheduleRules, where, new List<String>());

				if (data != null)
				{
					m_id = id;
					m_Name = data["name"].ToString();
					m_Rule = data["rule"].ToString();
					m_Price = float.Parse(data["price"].ToString());
				}
			}

			public ScheduleRule(String name)
			{
				String where = String.Format("name = '{0}'", name);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.ScheduleRules, where, new List<String>());

				if (data != null)
				{
					m_id = Int64.Parse(data["id"].ToString());
					m_Name = data["name"].ToString();
					m_Rule = data["rule"].ToString();
					m_Price = float.Parse(data["price"].ToString());
				}
			}
			
			public override String ToString()
			{
				return m_Name;
			}

			public Int64 Id
			{
				get
				{
					return m_id;
				}
			}
			
			public String Name
			{
				get
				{ 
					return m_Name;
				}
			}

			public String Rule
			{
				get
				{
					return m_Rule;
				}
			}
			
			public float Price
			{
				get
				{
					return m_Price;
				}
			}
			
			
			public void SetData(String name, String rule, float price)
			{
				Logger.Debug(String.Format("Set data for SheduleRules '{0}': name='{1}', phone='{2}', price={3}", m_Name, name, rule, price));
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["name"] = name;
				fields["rule"] = rule;
				fields["price"] = price.ToString();
				if (!ad.Update(DbTable.ScheduleRules, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Data could not been changed.");
				}
				m_Rule = rule;
				m_Name = name;
				m_Price = price;
			}
		}

		public class ScheduleRulesCollection : IEnumerable<ScheduleRule>
		{
			Dictionary<Int64, ScheduleRule> Items = new Dictionary<Int64, ScheduleRule>();

			public ScheduleRulesCollection()
			{
				DbAdapter da = new DbAdapter();
				DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.ScheduleRules)));
				foreach (DataRow dr in dt.Rows)
				{
					ScheduleRule rule = new ScheduleRule(Int64.Parse(dr["id"].ToString()));
					Items[rule.Id] = rule;
				}
			}

			public Boolean Add(String name, String rule, float price)
			{
				Int64 id = 0;
				return Add(name, rule, price, out id);
			}
			
			public Boolean Add(String name, String rule, float price, out Int64 id)
			{
				DbAdapter da = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["name"] = name;
				fields["rule"] = rule;
				fields["price"] = price.ToString();
				id = 0;

				if (!da.Insert(DbTable.ScheduleRules, fields, out id))
					return false;
					
				Items[id] = new ScheduleRule(id);
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.ScheduleRules, where);
			}

			public bool Remove(Int64 id)
			{
				if (!RemoveById(id))
					return false;
				return Items.Remove(id);
			}

			public bool Remove(ScheduleRule item)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", item.Id);
				da.Delete(DbTable.ScheduleRules, where);
				return Items.Remove(item.Id);
			}

			public ScheduleRule Search(Int64 id)
			{
				if(Items.ContainsKey(id))
					return Items[id];
				return null;
			}

			public List<ScheduleRule> Search(String name)
			{
				return Search(name, false);
			}

			public List<ScheduleRule> Search(String name, Boolean contains)
			{
				List<ScheduleRule> collection = new List<ScheduleRule>();
				foreach (KeyValuePair<Int64, ScheduleRule> priv in Items)
				{
					if ((contains && priv.Value.Name.Contains(name)) || priv.Value.Name.StartsWith(name))
					{
						collection.Add(priv.Value);
					}
				}
				return collection;
			}

			public int Count
			{
				get { return Items.Count; }
			}

			public IEnumerator<ScheduleRule> GetEnumerator()
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