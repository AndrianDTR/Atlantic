﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace ClientDB
{
	class Client
	{
		private Int64 m_id = 0;
		private UInt64 m_code = 0;
		public String m_name = String.Empty;
		public String m_phone = String.Empty;
		public String m_comment = String.Empty;
		private Int64 m_scheduleRule = 0;
		private Int64 m_trainer = 0;
		
		public Client()
		{
		}
		
		public Client(Int64 id)
		{	
			String where = String.Format("id = {0}", id);
			DataRow data = new DbAdapter().GetFirstRow(DbTable.Clients, where, new List<string>());

			if (data == null)
			{
				throw new Exception("Error! No such client.");
			}

			m_id = id;
			m_code = UInt64.Parse(data["code"].ToString());
			m_name = data["name"].ToString();
			m_phone = data["phone"].ToString();
			m_comment = data["comment"].ToString();
			m_scheduleRule = Int64.Parse(data["rule"].ToString());
			m_trainer = Int64.Parse(data["trainer"].ToString());
		}

		public Client(String name)
		{
			String where = String.Format("name = '{0}'", name);
			DataRow data = new DbAdapter().GetFirstRow(DbTable.Clients, where, new List<string>());
			
			if (data == null)
			{
				throw new Exception("Error! No such client.");
			}

			m_id = Int64.Parse(data["id"].ToString());
			m_code = UInt64.Parse(data["code"].ToString());
			m_name = data["name"].ToString();
			m_phone = data["phone"].ToString();
			m_comment = data["comment"].ToString();
			m_scheduleRule = Int64.Parse(data["rule"].ToString());
			m_trainer = Int64.Parse(data["trainer"].ToString());
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
				return m_name;
			}
		}

		public String Phone
		{
			get
			{
				return m_phone;
			}
		}

		public String Password
		{
			set
			{
				Debug.WriteLine(String.Format("Change '{0}' password  to: '{1}'", m_name, value));
				if (m_id <= 0)
				{
					return;
				}

				string newHash = DbUtils.md5(value);
				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["pass"] = String.Format("'{0}'", newHash);
				if (!ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Password could not been changed.");
				}
			}
		}
	}

	class ClientCollection : IEnumerable<Client>
	{
		Dictionary<Int64, Client> Items = new Dictionary<Int64, Client>();

		public ClientCollection()
		{
			DbAdapter da = new DbAdapter();
			DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.Clients)));
			foreach(DataRow dr in dt.Rows)
			{
				Client user = new Client(Int64.Parse(dr["id"].ToString()));
				Items[user.Id] = user;
			}
		}
		
		public Boolean Add(String name, Int64 priv)
		{
			Int64 id = 0;
			return Add(name, priv, out id);
		}
		
		public Boolean Add(String name, Int64 priv, out Int64 id)
		{
			DbAdapter da = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = String.Format("'{0}'", name);
			fields["privilege"] = priv.ToString();
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
			if(Items.ContainsKey(id))
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
			foreach (KeyValuePair<Int64, Client> user in Items)
			{
				if((contains && user.Value.Name.Contains(name)) || user.Value.Name.StartsWith(name))
				{
					collection.Add(user.Value);
				}
			}
			return collection;
		}
		
		public int Count
		{
			get { return Items.Count; }
		}

		public IEnumerator<Client> GetEnumerator()
		{
			return Items.Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Items.Values.GetEnumerator();
		}
	}
}
