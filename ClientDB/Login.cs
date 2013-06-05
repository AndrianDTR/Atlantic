using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.SQLite;
using System.Data.SqlClient;	
using System.Windows.Forms;
using System.Diagnostics;

namespace ClientDB
{
    public partial class Login : Form
    {
		public long m_userId = -1;
		public UserPrivilege m_userPriv = new UserPrivilege();
		private int m_loginAttempt = 0;
		
		public Login()
        {
			//m_db = DbAdapter.Instance.ClientDataSet;
            InitializeComponent();
            init();
        }
		
		private void init()
		{
			
		}

		public UserPrivilege GetUserPrivilegeById(long uid)
		{
			UserPrivilege result = new UserPrivilege();
			DataTable privs = DbHelper.GetTable("select * from userPrivileges");
			
			var q = from priv in privs.AsEnumerable() select new {
				  Clients = priv["clients"]
				, Schedule = priv["schedule"]
				, Trainers = priv["trainers"]
				, Payments = priv["payments"]
				, Backup = priv["backup"]
				, Statistics = priv["statistics"]
				, Users = priv["users"]
				, Privileges = priv["privileges"]
				};

			if (1 == q.Count())
			{
				var r = q.First();
				result.clients = (UserRights)long.Parse(r.Clients.ToString());
				result.schedule = (UserRights)long.Parse(r.Schedule.ToString());
				result.trainers = (UserRights)long.Parse(r.Trainers.ToString());
				result.payments = (UserRights)long.Parse(r.Payments.ToString());
				result.backup = (UserRights)long.Parse(r.Backup.ToString());
				result.statistics = (UserRights)long.Parse(r.Statistics.ToString());
				result.users = (UserRights)long.Parse(r.Users.ToString());
				result.privileges = (UserRights)long.Parse(r.Privileges.ToString());
			}
			
			return result;
		}
		
		private void loginBtn_Click(object sender, EventArgs e)
		{
			if (m_loginAttempt == 0)
				m_loginAttempt = 3;

			DataTable users = DbHelper.GetTable("select * from users");
			
			var q = from user in users.AsEnumerable() select new {Id = user["id"], Priv = user["privilege"]};
			
			if(1 == q.Count())
			{
				var r = q.First(); 
				m_userId = (long)r.Id;
				m_userPriv = GetUserPrivilegeById((long)r.Priv);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				message.Text = "Login failed.\nPlease check username and password.";
				password.Text = "";
			}

			m_loginAttempt--;

			if (m_loginAttempt == 0)
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}
    }
}
