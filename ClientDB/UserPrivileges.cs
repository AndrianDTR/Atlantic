using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SQLite;
using System.Diagnostics;

namespace ClientDB
{
	public enum UserRights
	{
		None = 0,
		Read = 1,
		Write = 2,
		Create = 4,
		Delete = 8
	};
	
	public class UserPrivileges
	{
		public UInt64 m_id = 0;
		public String m_Name = String.Empty;
		public UserRights clients = 0;
		public UserRights schedule = 0;
		public UserRights trainers = 0;
		public UserRights payments = 0;
		public UserRights backup = 0;
		public UserRights statistics = 0;
		public UserRights users = 0;
		public UserRights privileges = 0;
	
		public UserPrivileges()
		{
		
		}
		
		public UserPrivileges(UInt64 id)
		{
			String where = String.Format("id = {0}", id);
			DataRow privs = new DbAdapter().GetFirstRow(DbTable.UserPrivileges, where, new List<String>());

			if (privs != null)
			{
				m_id = UInt64.Parse(privs["id"].ToString());
				m_Name = privs["name"].ToString();
				clients = (UserRights)int.Parse(privs["clients"].ToString());
				schedule = (UserRights)int.Parse(privs["schedule"].ToString());
				trainers = (UserRights)int.Parse(privs["trainers"].ToString());
				payments = (UserRights)int.Parse(privs["payments"].ToString());
				backup = (UserRights)int.Parse(privs["backup"].ToString());
				statistics = (UserRights)int.Parse(privs["statistics"].ToString());
				users = (UserRights)int.Parse(privs["users"].ToString());
				privileges = (UserRights)int.Parse(privs["privileges"].ToString());
			}
		}

		public UserPrivileges(String name)
		{
			String where = String.Format("name = '{0}'", name);
			DataRow privs = new DbAdapter().GetFirstRow(DbTable.UserPrivileges, where, new List<String>());

			if (privs != null)
			{
				m_id = UInt64.Parse(privs["id"].ToString());
				m_Name = privs["name"].ToString();
				clients = (UserRights)int.Parse(privs["clients"].ToString());
				schedule = (UserRights)int.Parse(privs["schedule"].ToString());
				trainers = (UserRights)int.Parse(privs["trainers"].ToString());
				payments = (UserRights)int.Parse(privs["payments"].ToString());
				backup = (UserRights)int.Parse(privs["backup"].ToString());
				statistics = (UserRights)int.Parse(privs["statistics"].ToString());
				users = (UserRights)int.Parse(privs["users"].ToString());
				privileges = (UserRights)int.Parse(privs["privileges"].ToString());
			}
		}
		
		public override String ToString()
		{
			return m_Name;
		}

		public bool IsSet(UserRights var, UserRights flag)
		{
			return flag == (var & flag);
		}
	}

	class UserPrivilegesCollection : IEnumerable<UserPrivileges>
	{
		List<UserPrivileges> Items = new List<UserPrivileges>();

		public UserPrivilegesCollection()
		{
			DbAdapter da = new DbAdapter();
			DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.UserPrivileges)));
			foreach (DataRow dr in dt.Rows)
			{
				UserPrivileges priv = new UserPrivileges(UInt64.Parse(dr["id"].ToString()));
				Items.Add(priv);
			}
		}

		public UInt64 Add(String name)
		{
			DbAdapter da = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = name;
			da.Insert(DbTable.UserPrivileges, fields);
			UserPrivileges priv = new UserPrivileges(name);
			Items.Add(priv);
			return priv.m_id;
		}

		public bool Remove(UserPrivileges item)
		{
			DbAdapter da = new DbAdapter();
			String where = String.Format("id = {0}", item.m_id);
			da.Delete(DbTable.UserPrivileges, where);
			return Items.Remove(item);
		}

		public List<UserPrivileges> Search(String name)
		{
			return Search(name, false);
		}

		public List<UserPrivileges> Search(String name, Boolean contains)
		{
			List<UserPrivileges> collection = Items;
			foreach (UserPrivileges priv in collection)
			{
				if ((contains && !priv.m_Name.Contains(name)) || !priv.m_Name.StartsWith(name))
				{
					collection.Remove(priv);
				}
			}
			return collection;
		}

		public int Count
		{
			get { return Items.Count; }
		}

		public IEnumerator<UserPrivileges> GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Items.GetEnumerator();
		}
	}	
}
