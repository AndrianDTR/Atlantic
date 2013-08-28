using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;
using AY.Utils;

namespace AY
{
	namespace db
	{
		public class User
		{
			private Int64 m_userId = 0;
			public String m_userName = String.Empty;
			public Int64 m_userPrivilegesId = 0;
			
			public User()
			{
			}
			
			public User(Int64 id)
			{	
				String where = String.Format("id = {0}", id);
				DataRow userData = new DbAdapter().GetFirstRow(DbTable.Users, where, new List<string>{"id","name","privilege"});
				
				if(userData == null)
				{
					throw new Exception("Error! No such user.");
				}

				m_userId = id;
				m_userName = userData["name"].ToString();
				m_userPrivilegesId = Int64.Parse(userData["privilege"].ToString());
			}

			public User(String name)
			{
				String where = String.Format("name = '{0}'", name);
				DataRow userData = new DbAdapter().GetFirstRow(DbTable.Users, where, new List<string> { "id", "name", "privilege" });
				
				if (userData == null)
				{
					throw new Exception("Error! No such user.");
				}

				m_userId = Int64.Parse(userData["id"].ToString());
				m_userName = userData["name"].ToString();
				m_userPrivilegesId = Int64.Parse(userData["privilege"].ToString());
			}
			
			public void SetUserPrivileges(Int64 privId)
			{
				m_userPrivilegesId = privId;
			}
			
			public Int64 Id
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
					return DbUtils.Dequote(m_userName);
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
					Logger.Debug(String.Format("Change '{0}' password  to: '{1}'", m_userName, value));
					if (m_userId <= 0)
					{
						return;
					}

					string newHash = SecUtils.md5(value);
					DbAdapter ad = new DbAdapter();
					Dictionary<string, Object> fields = new Dictionary<string, Object>();
					fields["pass"] = newHash;
					if(!ad.Update(DbTable.Users, fields, String.Format("id={0:d}", m_userId)))
					{
						Logger.Error("Password could not been changed.");
						throw new Exception("Password could not been changed.");
					}
				}
			}

			public Boolean ChangePassword(String oldPass, String newPass)
			{
				if (m_userId <= 0)
				{
					return false;
				}

				string oldHash = SecUtils.md5(oldPass);
				string newHash = SecUtils.md5(newPass);
				DbAdapter ad = new DbAdapter();
				Dictionary<string, Object> fields = new Dictionary<string, Object>();
				fields["pass"] = newHash;
				ad.Update(DbTable.Users, fields, String.Format("id={0:d} and pass = '{1}'", m_userId, oldHash));

				return true;
			}
			
			public static User Authenticate(String name, String pass)
			{
				User user = null;
				String where = String.Format("name = '{0}' and pass = '{1}'", DbUtils.Quote(name), SecUtils.md5(pass));
				DataRow userData = new DbAdapter().GetFirstRow(DbTable.Users, where, new List<string> { "id", "name", "privilege" });
				if(userData != null)
				{
					user = new User();
					user.m_userId = Int64.Parse(userData["id"].ToString());
					user.m_userName = (String)userData["name"];
					user.m_userPrivilegesId = Int64.Parse(userData["privilege"].ToString());
				}
				return user;
			}

			public static bool UserExist(Int64 id)
			{
				String where = String.Format("id = {0}", id);
				DataRow userData = new DbAdapter().GetFirstRow(DbTable.Users, where, new List<string> { "id" });
				if (userData != null)
				{
					return true;
				}
				return false;
			}
		}

		public class UserCollection : IEnumerable<User>
		{
			Dictionary<Int64, User> Items = new Dictionary<Int64, User>();
			
			public UserCollection()
			{
				DbAdapter da = new DbAdapter();
				DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.Users)));
				foreach(DataRow dr in dt.Rows)
				{
					User user = new User(Int64.Parse(dr["id"].ToString()));
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
				Dictionary<string, Object> fields = new Dictionary<string, Object>();
				fields["name"] = DbUtils.Quote(name);
				fields["privilege"] = priv.ToString();
				id = 0;
				
				if(!da.Insert(DbTable.Users, fields, out id))
					return false;
					
				Items[id] = new User(id);
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.Users, where);
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
				da.Delete(DbTable.Users, where);
				return Items.Remove(item.Id);
			}
			
			public User Search(Int64 id)
			{
				if(Items.ContainsKey(id))
					return Items[id];
				return null;
			}
			
			public List<User> Search(String name)
			{
				return Search(name, false);
			}
			
			public List<User> Search(String name, Boolean contains)
			{
				List<User> collection = new List<User>();
				foreach (KeyValuePair<Int64, User> user in Items)
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

			public IEnumerator<User> GetEnumerator()
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