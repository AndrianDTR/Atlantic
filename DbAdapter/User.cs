using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;
using AY.Utils;

namespace AY
{
	namespace db
	{
		public partial class dbDataSet{
			public partial class usersRow
			{
				public void SetUserPrivileges(Int64 privId)
				{
					privilege = privId;
				}
				
				public userPrivilegesRow Role
				{
					get
					{
						return Db.Instance.dSet.userPrivileges.FindByid(privilege);
					}
				}

				public String Password
				{
					set
					{
						pass = SecUtils.md5(value);
					}
				}

				public Boolean ChangePassword(String oldPass, String newPass)
				{
					if (id <= 0)
					{
						return false;
					}
					
					string oldHash = SecUtils.md5(oldPass);
					string newHash = SecUtils.md5(newPass);
					String filter = String.Format("id={0:d} and pass = '{1}'", id, oldHash);
					DataRow[] dr = Db.Instance.dSet.users.Select(filter);
					if (dr == null || dr.Length != 1)
					{
						return false;
					}
					pass = newPass;
					return true;
				}

				public static dbDataSet.usersRow Authenticate(String name, String pass)
				{
					String filter = String.Format("name='{0}' and pass='{1}'", name, SecUtils.md5(pass));
					DataRow[] dr = Db.Instance.dSet.users.Select(filter);
					if (dr == null || dr.Length != 1)
					{
						return null;
					}
					return (dbDataSet.usersRow)dr[0];
				}

				public static bool UserExist(Int64 id)
				{
					String where = String.Format("id = {0}", id);
					DataRow userData = Db.Instance.dSet.users.FindByid(id);
					if (userData != null)
					{
						return true;
					}
					return false;
				}
			}
		}
	}
}