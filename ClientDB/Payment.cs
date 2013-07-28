using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace ClientDB
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
				return m_client;
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

	class PaymentsCollection : IEnumerable<Payment>
	{
		Dictionary<Int64, Payment> Items = new Dictionary<Int64, Payment>();

		public PaymentsCollection()
		{
			DbAdapter da = new DbAdapter();
			DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.Payments)));
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

		public Boolean Add(Int64 client, Int64 service, Int64 creator, float sum, String comment, out Int64 id)
		{
			DbAdapter da = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["clientId"] = client.ToString();
			fields["scheduleId"] = service.ToString();
			fields["creatorId"] = creator.ToString();
			fields["sum"] = sum.ToString();
			fields["comment"] = DbUtils.Quote(comment);
			
			id = 0;

			if (!da.Insert(DbTable.Payments, fields, out id))
				return false;

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
