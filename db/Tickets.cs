using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class Ticket
		{
			private Int64 m_clientId = 0;
			public DateTime m_enter;
			public DateTime m_leave;

			public Ticket(Int64 id)
			{	
				String where = String.Format("clientId = {0}", id);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Tickets, where, new List<string> { "id", "name", "privilege" });
				
				if(data == null)
				{
					throw new Exception("Error! No such statistics entry.");
				}

				m_clientId = id;
				m_enter = DateTime.Parse(data["enter"].ToString());
				m_leave = DateTime.Parse(data["leave"].ToString());
			}

			public Int64 Id
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

		public class TicketsCollection : IEnumerable<Ticket>
		{
			Dictionary<Int64, Ticket> Items = new Dictionary<Int64, Ticket>();

			public TicketsCollection()
			{
				DbAdapter da = new DbAdapter();
				DataTable dt = da.ExecuteQuery(String.Format("select id from {0};"
					, DbUtils.GetTableName(DbTable.Tickets)));
				
				foreach(DataRow dr in dt.Rows)
				{
					Ticket data = new Ticket(Int64.Parse(dr["clientId"].ToString()));
					Items[data.Id] = data;
				}
			}
			
			public Boolean Add(DateTime enter, DateTime leave)
			{
				Int64 id = 0;
				return Add(enter, leave, out id);
			}

			public Boolean Add(DateTime enter, DateTime leave, out Int64 id)
			{
				DbAdapter da = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["enter"] = enter.ToString();
				fields["leave"] = leave.ToString();
				id = 0;

				if (!da.Insert(DbTable.Tickets, fields, out id))
					return false;

				Items[id] = new Ticket(id);
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.Tickets, where);
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
				da.Delete(DbTable.Tickets, where);
				return Items.Remove(item.Id);
			}

			public Ticket Search(Int64 id)
			{
				if(Items.ContainsKey(id))
					return Items[id];
				return null;
			}

			public int Count
			{
				get { return Items.Count; }
			}

			public IEnumerator<Ticket> GetEnumerator()
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