using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class StatsEntry
		{
			private Int64 m_Id = 0;
			private Int64 m_clientId = 0;
			public DateTime m_enter;
			public DateTime m_leave;
			
			public StatsEntry(Int64 id)
			{	
				String where = String.Format("id = {0}", id);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Statistics, where, new List<string>());
				
				if(data == null)
				{
					throw new Exception("Error! No such statistics entry.");
				}

				m_Id = id;
				m_clientId = Int64.Parse(data["clientId"].ToString());
				m_enter = DateTime.Parse(data["enter"].ToString());
				m_leave = DateTime.Parse(data["leave"].ToString());
			}

			public Int64 Id
			{
				get
				{
					return m_Id;
				}
			}

			public Int64 ClientId
			{
				get
				{
					return m_clientId;
				}
			}
			
			public DateTime Enter
			{
				get
				{
					return m_enter;
				}
			}

			public DateTime Leave
			{
				get
				{
					return m_leave;
				}
			}
		}

		public class StatisticsCollection : IEnumerable<StatsEntry>
		{
			Dictionary<Int64, StatsEntry> Items = new Dictionary<Int64, StatsEntry>();
			
			public StatisticsCollection()
			{
				DbAdapter da = new DbAdapter();
				DataTable dt = da.ExecuteQuery(String.Format("select id from {0};"
					, DbUtils.GetTableName(DbTable.Statistics)));
				
				foreach(DataRow dr in dt.Rows)
				{
					StatsEntry user = new StatsEntry(Int64.Parse(dr["id"].ToString()));
					Items[user.Id] = user;
				}
			}
			
			public Boolean Add(Int64 clientId, DateTime enter, DateTime leave)
			{
				Int64 id = 0;
				return Add(clientId, enter, leave, out id);
			}

			public Boolean Add(Int64 clientId, DateTime enter, DateTime leave, out Int64 id)
			{
				DbAdapter da = new DbAdapter();
				Dictionary<string, Object> fields = new Dictionary<string, Object>();
				fields["clientId"] = clientId.ToString();
				fields["enter"] = enter.ToString();
				fields["leave"] = leave.ToString();
				id = 0;

				if (!da.Insert(DbTable.Statistics, fields, out id))
					return false;

				Items[id] = new StatsEntry(id);
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.Statistics, where);
			}
			
			public bool Remove(Int64 id)
			{
				if(!RemoveById(id))
					return false;
				return Items.Remove(id);
			}
			
			public bool Remove(User item)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", item.Id);
				da.Delete(DbTable.Statistics, where);
				return Items.Remove(item.Id);
			}

			public StatsEntry Search(Int64 id)
			{
				if(Items.ContainsKey(id))
					return Items[id];
				return null;
			}

			public int Count
			{
				get { return Items.Count; }
			}

			public IEnumerator<StatsEntry> GetEnumerator()
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