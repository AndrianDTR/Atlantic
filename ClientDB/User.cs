using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace ClientDB
{
	class User
	{
		private UInt64 m_userId = 0;
		public String m_userName = String.Empty;
		public UInt64 m_userPrivilegesId = 0;
		
		public User()
		{
		}
		
		public User(UInt64 id)
		{	
			String where = String.Format("id = {0}", id);
			DataRow userData = new DbAdapter().GetFirstRow(DbTable.Users, where, new List<string>{"id","name","privilege"});
			
			if(userData == null)
			{
				throw new Exception("Error! No such user.");
			}

			m_userId = (UInt64)long.Parse(userData["id"].ToString());
			m_userName = (String)userData["name"];
			m_userPrivilegesId = (UInt64)long.Parse(userData["privilege"].ToString());
		}

		public User(String name)
		{
			String where = String.Format("name = '{0}'", name);
			DataRow userData = new DbAdapter().GetFirstRow(DbTable.Users, where, new List<string> { "id", "name", "privilege" });
			
			if (userData == null)
			{
				throw new Exception("Error! No such user.");
			}

			m_userId = (UInt64)long.Parse(userData["id"].ToString());
			m_userName = (String)userData["name"];
			m_userPrivilegesId = (UInt64)long.Parse(userData["privilege"].ToString());
		}
		
		public void SetUserPrivileges(UInt64 privId)
		{
			m_userPrivilegesId = privId;
		}
		
		public UInt64 Id
		{
			get
			{
				return m_userId;
			}
		}

		public String Name
		{
			get
			{
				return m_userName;
			}
		}

		public UserRole Role
		{
			get
			{
				return new UserRole(m_userPrivilegesId);
			}
		}

		public String Password
		{
			set
			{
				Debug.WriteLine(String.Format("Change '{0}' password  to: '{1}'", m_userName, value));
				if (m_userId <= 0)
				{
					return;
				}

				string newHash = DbUtils.md5(value);
				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["pass"] = String.Format("'{0}'", newHash);
				if(!ad.Update(DbTable.Users, fields, String.Format("id={0:d}", m_userId)))
				{
					throw new Exception("Password could not been changed.");
				}
			}
		}
		
		public Boolean ChangePassword(String oldPass, String newPass)
		{
			if(m_userId <= 0)
			{	
				return false;
			}
						
			string oldHash = DbUtils.md5(oldPass);
			string newHash = DbUtils.md5(newPass);
			DbAdapter ad = new DbAdapter();
			Dictionary<string,string> fields = new Dictionary<string,string>();
			fields["pass"] = String.Format("'{0}'", newHash);
			ad.Update(DbTable.Users, fields, String.Format("id={0:d} and pass = '{1}'", m_userId, oldHash));
			
			return true;
		}
		
		public static User Authenticate(String name, String pass)
		{
			User user = null;
			String where = String.Format("name = '{0}' and pass = '{1}'", name, DbUtils.md5(pass));
			DataRow userData = new DbAdapter().GetFirstRow(DbTable.Users, where, new List<string> { "id", "name", "privilege" });
			if(userData != null)
			{
				user = new User();
				user.m_userId = (UInt64)long.Parse(userData["id"].ToString());
				user.m_userName = (String)userData["name"];
				user.m_userPrivilegesId = (UInt64)long.Parse(userData["privilege"].ToString());
			}
			return user;
		}
	}

	class UserCollection : IEnumerable<User>
	{
		List<User> Items = new List<User>();
		
		public UserCollection()
		{
			DbAdapter da = new DbAdapter();
			DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.Users)));
			foreach(DataRow dr in dt.Rows)
			{
				User user = new User(UInt64.Parse(dr["id"].ToString()));
				Items.Add(user);
			}
		}
		
		public Boolean Add(String name, UInt64 priv)
		{
			DbAdapter da = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = String.Format("'{0}'", name);
			fields["privilege"] = priv.ToString();
			
			if(!da.Insert(DbTable.Users, fields))
				return false;
				
			User user = new User(name);
			Items.Add(user);
			return true;
		}

		public bool Remove(User item)
		{
			DbAdapter da = new DbAdapter();
			String where = String.Format("id = {0}", item.Id);
			da.Delete(DbTable.Users, where);
			return Items.Remove(item);
		}
		
		public List<User> Search(String name)
		{
			return Search(name, false);
		}
		
		public List<User> Search(String name, Boolean contains)
		{
			List<User> collection = new List<User>();
			foreach (User user in Items)
			{
				if((contains && user.Name.Contains(name)) || user.Name.StartsWith(name))
				{
					collection.Add(user);
				}
			}
			return collection;
		}
		
		public int Count
		{
			get { return Items.Count; }
		}

		public IEnumerator<User> GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Items.GetEnumerator();
		}
	}	
}
