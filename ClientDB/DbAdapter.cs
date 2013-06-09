using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Data.Common;

namespace ClientDB
{
	public enum DbTable
	{
		_min = 0,
		UserPrivileges = 0,
		Clients,
		Users,
		Trainers,
		Payments,
		Schedule,
		Statistics,
		TrainersSchedule,
		_max,
	};
	
	class DbUtils
	{
		public static string md5(string input)
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

		public static String GetTableName(DbTable table)
		{
			switch (table)
			{
				case DbTable.UserPrivileges:
					return "userPrivileges";

				case DbTable.Users:
					return "users";

				case DbTable.Clients:
					return "clients";

				case DbTable.Payments:
					return "payments";

				case DbTable.Schedule:
					return "schedule";

				case DbTable.Statistics:
					return "statistics";

				case DbTable.Trainers:
					return "trainers";

				case DbTable.TrainersSchedule:
					return "trainersSchedule";

				default:
					return String.Empty;
			}
		}
	}
	
	class DbAdapter
    {
		// Constructor
		public DbAdapter()
		{
			Debug.WriteLine("Constructor enter");

			Debug.WriteLine("Constructor leave");
		}

		public DataTable GetTable(DbTable table)
		{
			String name = DbUtils.GetTableName(table);
			Debug.WriteLine("Get table '{0}'", name);
			String query = String.Format("select * from {0}", name);
			return new DbAdapter().ExecuteQuery(query);
		}
		
		private bool CheckTableExists(DbTable table)
		{
			bool res = false;
			
			String name = DbUtils.GetTableName(table);
			Debug.WriteLine(String.Format("Check table '{0}' exists.", name));
			
			try
			{
				String query = String.Format("select count(*) from {0}", name);
				ExecuteScalar(query);
				res = true;
			}
			catch(Exception fail)
			{
				Debug.WriteLine(String.Format("CheckTableExist exception: {0}.", fail.Message));
			}
			
			return res;
		}
		
		public bool CheckTables()
		{
			Debug.WriteLine("CheckTables Enter");
			bool res = true;
			
			for(DbTable tbl = DbTable._min; tbl < DbTable._max; tbl++ )
			{
				if(!CheckTableExists(tbl))
				{	
					res = false;
					break;
				}
			}
			Debug.WriteLine("CheckTables Leave");
			return res;
		}

		/// <summary>
		///     Allows the programmer to run a query against the Database.
		/// </summary>
		/// <param name="sql">The SQL to run</param>
		/// <returns>A DataTable containing the result set.</returns>
		public DataTable ExecuteQuery(string sql)
		{
			DataTable dt = new DataTable();
			SQLiteConnection cnn = new SQLiteConnection(ClientDB.Properties.Settings.Default.clientConnectionString);
			SQLiteDataReader reader = null;
			SQLiteCommand cmd = null;

			Debug.WriteLine(String.Format("Execute query: {0}.", sql));
			
			try
			{
				cnn.Open();
				cmd = new SQLiteCommand(sql, cnn);
				reader = cmd.ExecuteReader();
				dt.Load(reader);
			}
			catch (SQLiteException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				if(cmd.Transaction != null)
					cmd.Transaction.Commit();
				
				cnn.Close();
				
				if(reader != null)
					reader.Close();
			}
			
			return dt;
		}

		/// <summary>
		///     Allows the programmer to interact with the database for purposes other than a query.
		/// </summary>
		/// <param name="sql">The SQL to be run.</param>
		/// <returns>An Integer containing the number of rows updated.</returns>
		public int ExecuteNonQuery(string sql)
		{
			Int64 insertId = 0;
			return ExecuteNonQuery(sql, out insertId);
		}
		
		/// <summary>
		///     Allows the programmer to interact with the database for purposes other than a query.
		/// </summary>
		/// <param name="sql">The SQL to be run.</param>
		/// <returns>An Integer containing the number of rows updated.</returns>
		public int ExecuteNonQuery(string sql, out Int64 insertId)
		{
			SQLiteConnection cnn = new SQLiteConnection(ClientDB.Properties.Settings.Default.clientConnectionString);
			SQLiteCommand cmd = null;
			int rowsUpdated = -1;

			Debug.WriteLine(String.Format("Execute NON query: {0}.", sql));
			
			try
			{
				cnn.Open();
				cmd = new SQLiteCommand(sql, cnn);
				rowsUpdated = cmd.ExecuteNonQuery();
			}
			catch (SQLiteException e)
			{
				throw new Exception(e.Message);
			}
			finally
			{
				if (cmd.Transaction != null)
					cmd.Transaction.Commit();
				
				insertId = cnn.LastInsertRowId;
				cnn.Close();
			}
			
			return rowsUpdated;
		}
		
		/// <summary>
		///     Allows the programmer to retrieve single items from the DB.
		/// </summary>
		/// <param name="sql">The query to run.</param>
		/// <returns>A string.</returns>
		public string ExecuteScalar(string sql)
		{
			Int64 insertId = 0;
			return ExecuteScalar(sql, out insertId);
		}
		
		/// <summary>
		///     Allows the programmer to retrieve single items from the DB.
		/// </summary>
		/// <param name="sql">The query to run.</param>
		/// <param name="insertId">Last insert row id.</param>
		/// <returns>A string.</returns>
		public string ExecuteScalar(string sql, out Int64 insertId)
		{
			SQLiteConnection cnn = new SQLiteConnection(ClientDB.Properties.Settings.Default.clientConnectionString);
			SQLiteCommand cmd = null;
			object value = null;

			Debug.WriteLine(String.Format("Execute scalar: {0}.", sql));
			
			try
			{
				cnn.Open();
				cmd = new SQLiteCommand(sql, cnn);
				value = cmd.ExecuteScalar();
			}
			catch(SQLiteException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				if (cmd.Transaction != null)
					cmd.Transaction.Commit();

				insertId = cnn.LastInsertRowId;
				cnn.Close();
			}
			
			if (value != null)
			{
				return value.ToString();
			}
			return "";
		}

		/// <summary>
		///     Allows the programmer to easily select row fields from the table.
		/// </summary>
		/// <param name="table">The source table.</param>
		/// <param name="data">A list of Column to get.</param>
		/// <param name="where">The where clause for query.</param>
		/// <returns>Returns the first DataRow from querru results.</returns>
		public DataRow GetFirstRow(DbTable table, String where, List<String> fields)
		{
			SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.clientConnectionString);
			DataRow row = null;
			String query = String.Format("select * from {0} where {1};", DbUtils.GetTableName(table), where);
			
			if (fields.Count > 0)
			{
				String vals = "";
				foreach (String field in fields)
				{
					vals += String.Format(" {0},", field);
				}
				vals = vals.Substring(0, vals.Length - 1);
				query = String.Format("select {0} from {1} where {2} limit 1;", vals, DbUtils.GetTableName(table), where);
			}

			Debug.WriteLine(String.Format("GetFirstRow, query: {0}.", query));
			
			DataTable dt = ExecuteQuery(query);
			if (dt.Rows.Count > 0)
				row = dt.Rows[0];
			
			return row;
		}
		
		/// <summary>
		///     Allows the programmer to easily update rows in the DB.
		/// </summary>
		/// <param name="tableName">The table to update.</param>
		/// <param name="data">A dictionary containing Column names and their new values.</param>
		/// <param name="where">The where clause for the update statement.</param>
		/// <returns>A boolean true or false to signify success or failure.</returns>
		public bool Update(DbTable table, Dictionary<String, String> data, String where)
		{
			String vals = "";
			Boolean returnCode = true;
			if (data.Count >= 1)
			{
				foreach (KeyValuePair<String, String> val in data)
				{
					vals += String.Format(" {0} = {1},", val.Key.ToString(), val.Value.ToString());
				}
				vals = vals.Substring(0, vals.Length - 1);
			}
			try
			{
				String tableName = DbUtils.GetTableName(table);
				String query = String.Format("update {0} set {1} where {2};", tableName, vals, where);
				Debug.WriteLine(String.Format("Update {0}, query: {1}.", tableName, query));
				ExecuteNonQuery(query);
			}
			catch(Exception fail)
			{
				Debug.WriteLine(String.Format("Update exception: {0}.", fail.Message));
				returnCode = false;
			}
			return returnCode;
		}

		/// <summary>
		///     Allows the programmer to easily delete rows from the DB.
		/// </summary>
		/// <param name="tableName">The table from which to delete.</param>
		/// <param name="where">The where clause for the delete.</param>
		/// <returns>A boolean true or false to signify success or failure.</returns>
		public bool Delete(DbTable table, String where)
		{
			Boolean returnCode = true;
			try
			{
				String tableName = DbUtils.GetTableName(table);
				String query = String.Format("delete from {0} where {1};", tableName, where);
				Debug.WriteLine(String.Format("Delete from {0}, query: {1}.", tableName, query));
				ExecuteNonQuery(query);
			}
			catch (Exception fail)
			{
				Debug.WriteLine(String.Format("Delete exception: {0}.", fail.Message));
				returnCode = false;
			}
			return returnCode;
		}

		/// <summary>
		///     Allows the programmer to easily insert into the DB
		/// </summary>
		/// <param name="tableName">The table into which we insert the data.</param>
		/// <param name="data">A dictionary containing the column names and data for the insert.</param>
		/// <returns>A boolean true or false to signify success or failure.</returns>
		public bool Insert(DbTable table, Dictionary<String, String> data)
		{
			Int64 insertId = 0;
			return Insert(table, data, out insertId);
		}
		
		/// <summary>
		///     Allows the programmer to easily insert into the DB
		/// </summary>
		/// <param name="tableName">The table into which we insert the data.</param>
		/// <param name="data">A dictionary containing the column names and data for the insert.</param>
		/// <param name="inserId">Represent ID of the row that has been inserted.</param>
		/// <returns>A boolean true or false to signify success or failure.</returns>
		public bool Insert(DbTable table, Dictionary<String, String> data, out Int64 insertId)
		{
			String columns = "";
			String values = "";
			Boolean returnCode = true;
			insertId = 0;
			
			foreach (KeyValuePair<String, String> val in data)
			{
				columns += String.Format(" {0},", val.Key.ToString());
				values += String.Format(" {0},", val.Value);
			}
			columns = columns.Substring(0, columns.Length - 1);
			values = values.Substring(0, values.Length - 1);
			try
			{
				String tableName = DbUtils.GetTableName(table);
				String query = String.Format("insert into {0}({1}) values({2});", tableName, columns, values);
				Debug.WriteLine(String.Format("Insert to {0}, query: {1}.", tableName, query));
				ExecuteNonQuery(query, out insertId);
				Debug.WriteLine(String.Format("Insert ID is: {0}.", insertId));
			}
			catch (Exception fail)
			{
				Debug.WriteLine(String.Format("Insert exception: {0}.", fail.Message));
				returnCode = false;
			}
			return returnCode;
		}
		
		/// <summary>
		///     Allows the user to easily clear all data from a specific table.
		/// </summary>
		/// <param name="table">The name of the table to clear.</param>
		/// <returns>A boolean true or false to signify success or failure.</returns>
		public bool ClearTable(DbTable table)
		{
			try
			{
				this.ExecuteNonQuery(String.Format("delete from {0};", DbUtils.GetTableName(table)));
				return true;
			}
			catch (Exception fail)
			{
				Debug.WriteLine("ClearTable exception: {0}.", fail.Message);
				return false;
			}
		}
		
		public static bool ClearDB()
		{
			bool res = true;
			Debug.WriteLine("CreateTableStructure Enter");

			string tUserPrivileges = @"drop table if exists userPrivileges;
			CREATE TABLE userPrivileges
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
				, clients Integer NOT NULL Default(15)
				, schedule Integer NOT NULL Default(15)
				, trainers Integer NOT NULL Default(15)
				, payments Integer NOT NULL Default(15)
				, backup Integer NOT NULL Default(15)
				, statistics Integer NOT NULL Default(15)
				, users Integer NOT NULL Default(15)
				, privileges Integer NOT NULL Default(15)
			);
			INSERT INTO userPrivileges(name) VALUES('Administrator')";
			
			string tUsers = String.Format(@"drop table if exists users;
			CREATE TABLE users
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
				, pass VarChar
				, privilege Integer NOT NULL
			);
			INSERT INTO users(name, pass, privilege) VALUES('admin', '{0}', 1)", DbUtils.md5("administrator"));
			
			string tTrainers = @"drop table if exists trainers;
			CREATE TABLE trainers
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
				, phone VarChar NOT NULL
				, extraInfo VarChar DEFAULT('')
			)";
			
			string tTarinersSchedule = @"drop table if exists trainersSchedule;
			CREATE TABLE trainersSchedule
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, trainerId Integer NOT NULL
				, date Date NOT NULL
			)";
			
			string tClients = @"drop table if exists clients; 
			CREATE TABLE clients
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, code Integer NOT NULL
				, name VarChar NOT NULL
				, phone VarChar DEFAULT('')
				, schedule Integer NOT NULL
				, trainer Integer DEFAULT('')
				, comment Text DEFAULT('')
			)";
			
			string tPayments = @"drop table if exists payments;
			CREATE TABLE payments
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, clientId Integer NOT NULL
				, date TimeStamp Default(NOW())
				, sum money NOT NULL
				, comment Text Default('')
			)";
			
			string tScheduleRules = @"drop table if exists scheduleRules;
			CREATE TABLE scheduleRules
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, name VarChar NOT NULL
				, rule VarChar NOT NULL
			)";
			
			string tStatistics = @"drop table if exists statistics;
			CREATE TABLE statistics
			(
				id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
				, clientId Integer NOT NULL
				, date TimeStamp Default(NOW())
			)";

			SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.clientConnectionString);
			
			try
			{
				String[] conStr = Properties.Settings.Default.clientConnectionString.Split(';');
				foreach (String opt in conStr)
				{
					String[] keyVal = opt.Split('=');
					if(keyVal.Length == 2 && keyVal[0] == "data source")
					{
						if(!System.IO.File.Exists(keyVal[1]))
							SQLiteConnection.CreateFile(keyVal[1]);
					}
				}
				
				conn.Open();
				new SQLiteCommand(tUserPrivileges, conn).ExecuteNonQuery();
				new SQLiteCommand(tUsers, conn).ExecuteNonQuery();
				new SQLiteCommand(tTrainers, conn).ExecuteNonQuery();
				new SQLiteCommand(tClients, conn).ExecuteNonQuery();
				new SQLiteCommand(tPayments, conn).ExecuteNonQuery();
				new SQLiteCommand(tStatistics, conn).ExecuteNonQuery();
				new SQLiteCommand(tTarinersSchedule, conn).ExecuteNonQuery();
				new SQLiteCommand(tScheduleRules, conn).ExecuteNonQuery();
			}
			catch (SQLiteException ex)
			{
				Debug.WriteLine(String.Format("ClearDB exception: {0}.", ex.Message));
				throw new Exception("Error! DB clear failed.\r\n", ex);
			}
			finally
			{
				conn.Close();
			}
			
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
	}
}
