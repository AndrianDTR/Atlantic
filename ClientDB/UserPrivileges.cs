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
	
	public class UserRole
	{
		private UInt64 m_id = 0;
		private String m_Name = String.Empty;
		private UserRights m_clients = 0;
		private UserRights m_schedule = 0;
		private UserRights m_trainers = 0;
		private UserRights m_payments = 0;
		private UserRights m_backup = 0;
		private UserRights m_statistics = 0;
		private UserRights m_users = 0;
		private UserRights m_privileges = 0;
	
		public UserRole()
		{
		
		}
		
		public UserRole(UInt64 id)
		{
			String where = String.Format("id = {0}", id);
			DataRow privs = new DbAdapter().GetFirstRow(DbTable.UserPrivileges, where, new List<String>());

			if (privs != null)
			{
				m_id = UInt64.Parse(privs["id"].ToString());
				m_Name = privs["name"].ToString();
				m_clients = (UserRights)int.Parse(privs["clients"].ToString());
				m_schedule = (UserRights)int.Parse(privs["schedule"].ToString());
				m_trainers = (UserRights)int.Parse(privs["trainers"].ToString());
				m_payments = (UserRights)int.Parse(privs["payments"].ToString());
				m_backup = (UserRights)int.Parse(privs["backup"].ToString());
				m_statistics = (UserRights)int.Parse(privs["statistics"].ToString());
				m_users = (UserRights)int.Parse(privs["users"].ToString());
				m_privileges = (UserRights)int.Parse(privs["privileges"].ToString());
			}
		}

		public UserRole(String name)
		{
			String where = String.Format("name = '{0}'", name);
			DataRow privs = new DbAdapter().GetFirstRow(DbTable.UserPrivileges, where, new List<String>());

			if (privs != null)
			{
				m_id = UInt64.Parse(privs["id"].ToString());
				m_Name = privs["name"].ToString();
				m_clients = (UserRights)int.Parse(privs["clients"].ToString());
				m_schedule = (UserRights)int.Parse(privs["schedule"].ToString());
				m_trainers = (UserRights)int.Parse(privs["trainers"].ToString());
				m_payments = (UserRights)int.Parse(privs["payments"].ToString());
				m_backup = (UserRights)int.Parse(privs["backup"].ToString());
				m_statistics = (UserRights)int.Parse(privs["statistics"].ToString());
				m_users = (UserRights)int.Parse(privs["users"].ToString());
				m_privileges = (UserRights)int.Parse(privs["privileges"].ToString());
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

		public UInt64 Id
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
			set
			{
				Debug.WriteLine(String.Format("Change role name from '{0}' to '{1}'", m_Name, value));
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["name"] = String.Format("'{0}'", value);
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Name could not been changed.");
				}
			}
		}

		public UserRights Statistics
		{
			get
			{
				return m_statistics;
			}
			set
			{
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["statistics"] = ((int)value).ToString();
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Manage statistics rights could not been changed.");
				}
				m_statistics = value;
			}
		}

		public UserRights Users
		{
			get
			{
				return m_users;
			}
			set
			{
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["users"] = ((int)value).ToString();
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Manage user rights could not been changed.");
				}
				m_users = value;
			}
		}

		public UserRights Clients
		{
			get
			{
				return m_clients;
			}
			set
			{
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["clients"] = ((int)value).ToString();
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Manage user rights could not been changed.");
				}
				m_clients = value;
			}
		}

		public UserRights Payments
		{
			get
			{
				return m_payments;
			}
			set
			{
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["payments"] = ((int)value).ToString();
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Manage user rights could not been changed.");
				}
				m_payments = value;
			}
		}

		public UserRights Trainers
		{
			get
			{
				return m_trainers;
			}
			set
			{
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["trainers"] = ((int)value).ToString();
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Manage user rights could not been changed.");
				}
				m_trainers = value;
			}
		}

		public UserRights Schedule
		{
			get
			{
				return m_schedule;
			}
			set
			{
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["schedule"] = ((int)value).ToString();
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Manage user rights could not been changed.");
				}
				m_schedule = value;
			}
		}

		public UserRights Backup
		{
			get
			{
				return m_backup;
			}
			set
			{
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["backup"] = ((int)value).ToString();
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Manage user rights could not been changed.");
				}
				m_backup = value;
			}
		}
		
		public UserRights Privileges
		{
			get
			{
				return m_privileges;
			}
			set
			{
				if (m_id <= 0)
				{
					return;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["privileges"] = ((int)value).ToString();
				if (!ad.Update(DbTable.UserPrivileges, fields, String.Format("id={0:d}", m_id)))
				{
					throw new Exception("Manage user rights could not been changed.");
				}
				m_privileges = value;
			}
		}
	}

	class UserRolesCollection : IEnumerable<UserRole>
	{
		List<UserRole> Items = new List<UserRole>();

		public UserRolesCollection()
		{
			DbAdapter da = new DbAdapter();
			DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.UserPrivileges)));
			foreach (DataRow dr in dt.Rows)
			{
				UserRole priv = new UserRole(UInt64.Parse(dr["id"].ToString()));
				Items.Add(priv);
			}
		}

		public Boolean Add(String name)
		{
			DbAdapter da = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = String.Format("'{0}'", name);
			if(!da.Insert(DbTable.UserPrivileges, fields))
				return false;
				
			UserRole priv = new UserRole(name);
			Items.Add(priv);
			return true;
		}

		public bool Remove(UserRole item)
		{
			DbAdapter da = new DbAdapter();
			String where = String.Format("id = {0}", item.Id);
			da.Delete(DbTable.UserPrivileges, where);
			return Items.Remove(item);
		}

		public List<UserRole> Search(String name)
		{
			return Search(name, false);
		}

		public List<UserRole> Search(String name, Boolean contains)
		{
			List<UserRole> collection = new List<UserRole>();
			foreach (UserRole priv in Items)
			{
				if ((contains && priv.Name.Contains(name)) || priv.Name.StartsWith(name))
				{
					collection.Add(priv);
				}
			}
			return collection;
		}

		public int Count
		{
			get { return Items.Count; }
		}

		public IEnumerator<UserRole> GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Items.GetEnumerator();
		}
	}	
}
