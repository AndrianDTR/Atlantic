using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ClientDB
{
	public class UserPrivilege
	{
		public int clients = 0;
		public int schedule = 0;
		public int trainers = 0;
		public int payments = 0;
		public int backup = 0;
		public int statistics = 0;
		public int users = 0;
		public int privileges = 0;
		
	};
	
	class DbAdapter
    {
		// Constructor
		private DbAdapter()
		{
			Debug.WriteLine("Constructor");
			
			if (!SetConnection())
			{
				throw new System.Exception("Connection cannot be initialized.");
			}

			if (!CheckTables())
			{
				CreateTableStructure();
			}
		}

		//Singleton implementation
        private static DbAdapter instance;

		public static DbAdapter Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new DbAdapter();
				}
				return instance;
			}
		}
		
		// DB data
		private SQLiteConnection m_SqlCon;
		private SQLiteCommand m_SqlCmd;
		string m_tableNames = "clients, payments, schedule, statistics, trainers, trainersShedule, users, userPrivileges";

		private bool SetConnection()
		{
			Debug.WriteLine("SetConnection Enter");
			bool res = true;
			try
			{
				m_SqlCon = new SQLiteConnection("Data Source=client.db;Version=3;New=True;Compress=True;");
				m_SqlCon.Open();
			}
			catch (System.Exception)
			{
				res = false;
			}

			Debug.WriteLine("SetConnection Leave");
			return res;
		}
		
		private void CloseConnection()
		{
			m_SqlCon.Close();
		}

		public string md5(string input)
		{
			// step 1, calculate MD5 hash from input
			MD5 md5 = MD5.Create();
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);

			// step 2, convert byte array to hex string
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}
			
			return sb.ToString();
		}

		private int ExecuteNonQuery(string query)
		{
			Debug.WriteLine("ExecuteNonQuery Enter");
			Debug.WriteLine("Query: "+ query);
			m_SqlCmd = m_SqlCon.CreateCommand();
			m_SqlCmd.CommandText = query;
			int res = m_SqlCmd.ExecuteNonQuery();

			Debug.WriteLine("ExecuteNonQuery Leave");
			return res;
		}

		public SQLiteDataReader ExecuteQuery(string query)
		{
			SQLiteCommand command = new SQLiteCommand(m_SqlCon);
			command.CommandText = query;
			command.CommandType = CommandType.Text;
			SQLiteDataReader reader = command.ExecuteReader();
			return reader;
		}
		
		private bool CheckTableExists(string name)
		{
			bool res = true;
			Debug.WriteLine("CheckTable Enter");
			Debug.WriteLine("Table: " + name);
			try
			{
				string query = String.Format("SELECT count(id) from {0}", name);
				ExecuteNonQuery(query);
			}
			catch (SQLiteException)
			{
				res = false;
			}
			
			Debug.WriteLine("CheckTable Leave");
			return res;
		}
		
		private bool CheckTables()
		{
			Debug.WriteLine("CheckTables Enter");
			bool res = true;
			
			string[] tables = m_tableNames.Split(',');
			foreach (string table in tables)
			{
				if(table.Trim().Length > 0 && !CheckTableExists(table.Trim()))
					res = false;
			}
			Debug.WriteLine("CheckTables Leave");
			return res;
		}
		
		private bool CreateTableStructure()
		{
			bool res = true;
			Debug.WriteLine("CreateTableStructure Enter");

			string tUserPrivileges = @"drop table if exists userPrivileges;
			CREATE TABLE userPrivileges
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
				, clients Integer NOT NULL Default(7)
				, schedule Integer NOT NULL Default(7)
				, trainers Integer NOT NULL Default(7)
				, payments Integer NOT NULL Default(7)
				, backup Integer NOT NULL Default(7)
				, statistics Integer NOT NULL Default(7)
				, users Integer NOT NULL Default(7)
				, privileges Integer NOT NULL Default(7)
			);
			INSERT INTO userPrivileges(name) VALUES('root')";
			ExecuteNonQuery(tUserPrivileges);
			
			string tUsers = @"drop table if exists users;
			CREATE TABLE users
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
				, pass VarChar NOT NULL
				, privilege Integer NOT NULL
			);";
			string addRoot = String.Format("INSERT INTO users(name, pass, privilege) VALUES('admin', '{0}', 1)", md5("root"));
			ExecuteNonQuery(tUsers);
			ExecuteNonQuery(addRoot);
			
			string tTrainers = @"drop table if exists trainers;
			CREATE TABLE trainers
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
			)";
			ExecuteNonQuery(tTrainers);

			string tTarinersShedule = @"drop table if exists trainersShedule;
			CREATE TABLE trainersShedule
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, trainerId Integer NOT NULL
				, date Date NOT NULL
			)";
			ExecuteNonQuery(tTarinersShedule);
			
			string tClients = @"drop table if exists clients; 
			CREATE TABLE clients
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
				, code Integer NOT NULL
				, plan Integer NOT NULL
				, phone VarChar NULL
				, comment Text NULL
				, trainer Integer NULL
			)";
			ExecuteNonQuery(tClients);

			string tPayments = @"drop table if exists payments;
			CREATE TABLE payments
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, clientId Integer NOT NULL
				, date TimeStamp NULL
				, sum VarChar NULL
				, comment Text NULL
			)";
			ExecuteNonQuery(tPayments);

			string tSchedule = @"drop table if exists schedule;
			CREATE TABLE schedule
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
			)";
			ExecuteNonQuery(tSchedule);

			string tStatistics = @"drop table if exists statistics;
			CREATE TABLE statistics
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, clientId Integer NOT NULL
				, date TimeStamp NULL
			)";
			ExecuteNonQuery(tStatistics);

			Debug.WriteLine("CreateTableStructure Leave");
			return res;
		}
		
		public bool ImportData()
		{
			return true;
		}
		
		public bool ExportData()
		{
			return true;
		}
		
		public KeyValuePair<long, int>  CheckUser(String user, String passwd)
		{
			KeyValuePair<long, int> result = new KeyValuePair<long, int>(-1, -1);
			
			SQLiteDataReader dataReader = ExecuteQuery(String.Format("select id, privilege from users where name='{0}' and pass='{1}'", user, md5(passwd)));
			if(dataReader.HasRows)
			{
				dataReader.Read();
				result = new KeyValuePair<long, int>(dataReader.GetInt64(0),dataReader.GetInt32(1));
			}
			return result;
		}
		
		public UserPrivilege GetUserPrivilegeById(long uid)
		{
			UserPrivilege result = new UserPrivilege();

			SQLiteDataReader dataReader = ExecuteQuery(String.Format("select * from userPrivileges where id={0}", uid));
			if (dataReader.HasRows)
			{
				dataReader.Read();
				result.clients = dataReader.GetInt32(2);
				result.schedule = dataReader.GetInt32(3);
				result.trainers = dataReader.GetInt32(4);
				result.payments = dataReader.GetInt32(5);
				result.backup = dataReader.GetInt32(6);
				result.statistics = dataReader.GetInt32(7);
				result.users = dataReader.GetInt32(8);
				result.privileges = dataReader.GetInt32(9);
			}
			return result;
		}

		public bool SetUserPassword(long uid, string oldPasswd, string passwd)
		{
			bool result = false;

			Debug.WriteLine(ExecuteNonQuery(String.Format("update users set pass='{0}' where id={1} and pass='{2}'", md5(passwd), uid, md5(oldPasswd))));
			
			return result;
		}
	}
}
