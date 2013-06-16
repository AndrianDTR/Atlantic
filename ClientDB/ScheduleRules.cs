using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace ClientDB
{
	public class ScheduleRule
	{
		private Int64 m_id = 0;
		private String m_Name = String.Empty;
		private String m_Rule = String.Empty;
	
		public ScheduleRule()
		{
		
		}
		
		public ScheduleRule(Int64 id)
		{
			String where = String.Format("id = {0}", id);
			DataRow data = new DbAdapter().GetFirstRow(DbTable.Schedule, where, new List<String>());

			if (data != null)
			{
				m_id = id;
				m_Name = data["name"].ToString();
				m_Name = data["rule"].ToString();
			}
		}

		public ScheduleRule(String name)
		{
			String where = String.Format("name = '{0}'", name);
			DataRow data = new DbAdapter().GetFirstRow(DbTable.Schedule, where, new List<String>());

			if (data != null)
			{
				m_id = Int64.Parse(data["id"].ToString());
				m_Name = data["name"].ToString();
				m_Name = data["rule"].ToString();
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
		
		public void SetData(String name, String rule)
		{
			Debug.WriteLine(String.Format("Set data for SheduleRules '{0}': name='{0}', phone='{1}'", m_Name, name, rule));
			if (m_id <= 0)
			{
				return;
			}

			DbAdapter ad = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = name;
			fields["rule"] = rule;
			if (!ad.Update(DbTable.Schedule, fields, String.Format("id={0:d}", m_id)))
			{
				throw new Exception("Data could not been changed.");
			}
			m_Rule = rule;
			m_Name = name;
		}
	}

	class ScheduleRulesCollection : IEnumerable<ScheduleRule>
	{
		Dictionary<Int64, ScheduleRule> Items = new Dictionary<Int64, ScheduleRule>();

		public ScheduleRulesCollection()
		{
			DbAdapter da = new DbAdapter();
			DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.Schedule)));
			foreach (DataRow dr in dt.Rows)
			{
				ScheduleRule rule = new ScheduleRule(Int64.Parse(dr["id"].ToString()));
				Items[rule.Id] = rule;
			}
		}

		public Boolean Add(String name, String rule)
		{
			Int64 id = 0;
			return Add(name, rule, out id);
		}
		
		public Boolean Add(String name, String rule, out Int64 id)
		{
			DbAdapter da = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = name;
			fields["rule"] = rule;
			id = 0;

			if (!da.Insert(DbTable.Schedule, fields, out id))
				return false;
				
			Items[id] = new ScheduleRule(id);
			return true;
		}

		public static bool RemoveById(Int64 id)
		{
			DbAdapter da = new DbAdapter();
			String where = String.Format("id = {0}", id);
			return da.Delete(DbTable.Schedule, where);
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
			da.Delete(DbTable.Schedule, where);
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
