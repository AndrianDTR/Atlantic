﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Data.Common;
using System.IO;
using System.Text;
using AY.Log;
using AY.Packer;

namespace AY
{
	namespace db
	{
		public enum DbTable
		{
			_min = 0,
			Settings = 0,
			UserPrivileges,
			Clients,
			Users,
			Trainers,
			Payments,
			ScheduleRules,
			Statistics,
			TrainersSchedule,
			Tickets,
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
					case DbTable.Settings:
						return "settings";
					
					case DbTable.UserPrivileges:
						return "userPrivileges";

					case DbTable.Users:
						return "users";

					case DbTable.Clients:
						return "clients";

					case DbTable.Payments:
						return "payments";

					case DbTable.ScheduleRules:
						return "scheduleRules";

					case DbTable.Statistics:
						return "statistics";

					case DbTable.Trainers:
						return "trainers";

					case DbTable.TrainersSchedule:
						return "trainersSchedule";
					
					case DbTable.Tickets:
						return "tickets";

					default:
						return String.Empty;
				}
			}

			public static String[] GetTableFieldList(DbTable table)
			{
				switch (table)
				{
					case DbTable.Settings:
						return new String[]{"id", "minPassLen", "language", "calRowHeight", "showTrainer"
							, "showClientCount", "storeMainWindowState", "mainWindowState", "pathBackUp"};

					case DbTable.UserPrivileges:
						return new String[]{"id", "name", "clients", "schedule", "trainers"
							, "payments", "backup", "statistics", "users", "privileges"};
						
					case DbTable.Users:
						return new String[]{"id", "name", "pass", "privilege"};

					case DbTable.Clients:
						return new String[]{"id", "name", "phone", "scheduleTime", "trainer"
							, "comment", "extraInfo"};

					case DbTable.Payments:
						return new String[]{"id", "clientId", "scheduleId", "creatorId", "date"
							, "sum", "comment"};

					case DbTable.ScheduleRules:
						return new String[] { "id", "name", "rule", "price" };

					case DbTable.Statistics:
						return new String[] { "id", "clientId", "enter", "leave" };

					case DbTable.Trainers:
						return new String[] { "id", "name", "phone", "extraInfo" };

					case DbTable.TrainersSchedule:
						return new String[] { "id", "trainerId", "date" };

					case DbTable.Tickets:
						return new String[] { "clientId", "enter", "leave" };

					default:
						return new String[]{};
				}
			}
			
			public static String Quote(String value)
			{
				return value;
			}
			
			public static String Dequote(String value)
			{
				return value;
			}
		}
		
		public class DbAdapter
		{
			private static object m_lock = new object();
			
			private static String ClientDbSrc
			{
				get
				{
					return AY.db.Properties.Settings.Default.szClientDataSrc 
						+ ClientDbFile;
				}
			}

			private static String ClientDbFile
			{
				get
				{
					String app = System.Reflection.Assembly.GetExecutingAssembly().Location;
					return System.IO.Path.GetDirectoryName(app)
						+ "\\"
						+ AY.db.Properties.Settings.Default.szDbSrcFile;
				}
			}
			
			// Constructor
			public DbAdapter()
			{
				Logger.Enter();

				Logger.Leave();
			}

			public DataTable GetTable(DbTable table)
			{
				Logger.Enter();
				String name = DbUtils.GetTableName(table);
				
				Logger.Debug(String.Format("Get table '{0}'", name));
				String query = String.Format("select * from {0}", name);
				
				DataTable res = new DbAdapter().ExecuteQuery(query);
				
				Logger.Leave();
				return res;
			}
			
			private bool CheckTableExists(DbTable table)
			{
				Logger.Enter();
				bool res = false;
				
				String name = DbUtils.GetTableName(table);
				Logger.Debug(String.Format("Check table '{0}' exists.", name));
				
				try
				{
					String query = String.Format("select count(*) from {0}", name);
					ExecuteScalar(query);
					
					res = true;
				}
				catch(Exception fail)
				{
					Logger.Debug(String.Format("CheckTableExist exception: {0}.", fail.Message));
				}

				Logger.Leave();
				return res;
			}
			
			public bool CheckTables()
			{
				Logger.Enter();
				bool res = true;
				
				for(DbTable tbl = DbTable._min; tbl < DbTable._max; tbl++ )
				{
					if(!CheckTableExists(tbl))
					{	
						res = false;
						break;
					}
					
					if (!CheckTableFields(tbl))
					{
						res = false;
						break;
					}
				}
				Logger.Leave();
				return res;
			}

			private bool CheckTableFields(DbTable table)
			{
				Logger.Enter();
				bool res = false;

				String name = DbUtils.GetTableName(table);
				Logger.Debug(String.Format("Check table '{0}' structure.", name));

				List<String> tblCols = new List<String>(DbUtils.GetTableFieldList(table));
				try
				{
					GetFirstRow(table, "1=1", tblCols);
					res = true;
				}
				catch(Exception ex)
				{
					Logger.Critical(String.Format("Table {0} is corrupt. Exception: {1}", name, ex.Message));
				}
				
				Logger.Leave();
				return res;
			}

			/// <summary>
			///     Allows the programmer to run a query against the Database.
			/// </summary>
			/// <param name="sql">The SQL to run</param>
			/// <returns>A DataTable containing the result set.</returns>
			public DataTable ExecuteQuery(string sql)
			{
				Logger.Enter();
				
				DataTable dt = new DataTable();
				SQLiteConnection cnn = new SQLiteConnection(ClientDbSrc);
				SQLiteDataReader reader = null;
				SQLiteCommand cmd = null;

				Logger.Debug(String.Format("Execute query: {0}.", sql));
				
				try
				{
					cnn.Open();
					cmd = new SQLiteCommand(sql, cnn);
					reader = cmd.ExecuteReader();
					dt.Load(reader);
					
					if (cmd.Transaction != null)
						cmd.Transaction.Commit();

					if (reader != null)
						reader.Close();

					cnn.Close();
				}
				catch (SQLiteException ex)
				{
					Logger.Error(ex.Message);
					throw new Exception(ex.Message);
				}
				
				Logger.Leave();
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
				Logger.Enter();
				int res = 0;
				Logger.Debug(String.Format("Execute NON query: {0}.", sql));
				
				SQLiteCommand cmd = new SQLiteCommand(sql);
				res = ExecuteNonQuery(cmd, out insertId);
				
				Logger.Enter();
				return res;
			}

			/// <summary>
			///     Allows the programmer to interact with the database for purposes other than a query.
			/// </summary>
			/// <param name="sql">The SQL to be run.</param>
			/// <returns>An Integer containing the number of rows updated.</returns>
			public int ExecuteNonQuery(SQLiteCommand cmd, out Int64 insertId)
			{
				Logger.Enter();
				SQLiteConnection cnn = new SQLiteConnection(ClientDbSrc);
				int rowsUpdated = -1;

				Logger.Debug(String.Format("Execute NON query: {0}.", cmd.CommandText));
				
				try
				{
					cnn.Open();
					cmd.Connection = cnn;
					rowsUpdated = cmd.ExecuteNonQuery();
				}
				catch (SQLiteException e)
				{
					Logger.Error(e.Message);
					throw new Exception(e.Message);
				}
				finally
				{
					if (cmd.Transaction != null)
						cmd.Transaction.Commit();

					insertId = cnn.LastInsertRowId;
					cnn.Close();
				}
				Logger.Leave();
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
				Logger.Enter();
				String res = "";
				SQLiteConnection cnn = new SQLiteConnection(ClientDbSrc);
				SQLiteCommand cmd = null;
				object value = null;

				Logger.Debug(String.Format("Execute scalar: {0}.", sql));
				
				try
				{
					cnn.Open();
					cmd = new SQLiteCommand(sql, cnn);
					value = cmd.ExecuteScalar();
				}
				catch(SQLiteException ex)
				{
					Logger.Error(ex.Message);
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
					res = value.ToString();
				}
				Logger.Leave();
				return res;
			}

			/// <summary>
			///     Allows the programmer to easily select row fields from the table.
			/// </summary>
			/// <param name="table">The source table.</param>
			/// <param name="data">A list of Column to get.</param>
			/// <param name="where">The where clause for query.</param>
			/// <returns>Returns the first DataRow from query results.</returns>
			public DataRow GetFirstRow(DbTable table, String where, List<String> fields)
			{
				Logger.Enter();
				SQLiteConnection conn = new SQLiteConnection(ClientDbSrc);
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

				Logger.Debug(String.Format("GetFirstRow, query: {0}.", query));
				
				DataTable dt = ExecuteQuery(query);
				if (dt.Rows.Count > 0)
					row = dt.Rows[0];

				Logger.Leave();
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
				Logger.Enter();
				Boolean returnCode = false;
				do
				{
					String vals = "";
					SQLiteCommand cmd = new SQLiteCommand();
					cmd.CommandType = CommandType.Text;
					
					if (data.Count < 1)
					{
						Logger.Debug("Nothing to update.");
						break;
					}
					
					foreach (KeyValuePair<String, String> val in data)
					{
						vals += String.Format(" `{0}` = @{0},", val.Key.ToString());
					}
					vals = vals.Substring(0, vals.Length - 1);
					
					try
					{
						String tableName = DbUtils.GetTableName(table);
						String query = String.Format("update `{0}` set {1} where {2};", tableName, vals, where);

						Logger.Debug(String.Format("Update {0}, query: {1}.", tableName, query));
						cmd.CommandText = query;
						foreach (KeyValuePair<String, String> val in data)
						{
							cmd.Parameters.AddWithValue(String.Format("@{0}", val.Key.ToString()), val.Value.ToString());
						}
						Int64 id = 0;			
						ExecuteNonQuery(cmd, out id);
						returnCode = true;
					}
					catch(Exception fail)
					{
						Logger.Debug(String.Format("Update exception: {0}.", fail.Message));
					}
				}while(false);
				Logger.Leave();
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
				Logger.Enter();
				Boolean returnCode = false;
				do
				{
					try
					{
						String tableName = DbUtils.GetTableName(table);
						String query = String.Format("delete from {0} where {1};", tableName, where);
						
						Logger.Debug(String.Format("Delete from {0}, query: {1}.", tableName, query));
						ExecuteNonQuery(query);
						returnCode = true;
					}
					catch (Exception fail)
					{
						Logger.Debug(String.Format("Delete exception: {0}.", fail.Message));
					}
				}while(false);
				
				Logger.Leave();
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
				Logger.Enter();
				
				String columns = "";
				String values = "";
				Boolean returnCode = false;
				insertId = 0;
				SQLiteCommand cmd = new SQLiteCommand();
				cmd.CommandType = CommandType.Text;
				
				do
				{
					if (data.Count < 1)
					{
						Logger.Debug("Nothing to insert.");
						break;
					}
					
					foreach (String val in data.Keys)
					{
						columns += String.Format(" {0},", val);
						values += String.Format(" @{0},", val);
					}
					
					columns = columns.Substring(0, columns.Length - 1);
					values = values.Substring(0, values.Length - 1);
					try
					{
						String tableName = DbUtils.GetTableName(table);
						String query = String.Format("insert into {0}({1}) values({2});", tableName, columns, values);
						
						Logger.Debug(String.Format("Insert to {0}, query: {1}.", tableName, query));
						cmd.CommandText = query;

						foreach (KeyValuePair<String, String> val in data)
						{
							cmd.Parameters.AddWithValue(val.Key, val.Value);
						}
					
						ExecuteNonQuery(cmd, out insertId);
						Logger.Debug(String.Format("Insert ID is: {0}.", insertId)); 
						returnCode = true;
					}
					catch (Exception fail)
					{
						Logger.Error(String.Format("Insert exception: {0}.", fail.Message));
					}
				} while (false);
				
				Logger.Leave();
				return returnCode;
			}
			
			/// <summary>
			///     Allows the user to easily clear all data from a specific table.
			/// </summary>
			/// <param name="table">The name of the table to clear.</param>
			/// <returns>A boolean true or false to signify success or failure.</returns>
			public bool ClearTable(DbTable table)
			{
				bool res = false;
				Logger.Enter();
				do 
				{
					try
					{
						this.ExecuteNonQuery(String.Format("delete from {0};", DbUtils.GetTableName(table)));
						res = true;
					}
					catch (Exception fail)
					{
						Logger.Error(String.Format("ClearTable exception: {0}.", fail.Message));
					}
				} while (false);
				
				Logger.Leave();
				return res;
			}
			
			public static bool ClearDB()
			{
				bool res = true;
				Logger.Enter();
				
				string tSettings = @"drop table if exists settings;
				CREATE TABLE settings
				(
					id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
					, minPassLen Integer NOT NULL Default(8)
					, language VarChar NOT NULL Default('English')
					, calRowHeight Integer NOT NULL Default(100)
					, showTrainer Integer NOT NULL Default(1)
					, showClientCount Integer NOT NULL Default(1)
					, storeMainWindowState Integer NOT NULL Default(1)
					, mainWindowState Integer NOT NULL Default(0)
					, pathBackUp VarChar NOT NULL Default('BackUp')
				);
				INSERT INTO settings(minPassLen) VALUES(8)";
				
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
					id Integer PRIMARY KEY NOT NULL
					, name VarChar NOT NULL
					, phone VarChar DEFAULT('')
					, scheduleDays VarChar DEFAULT('________')
					, scheduleTime Time NOT NULL
					, trainer Integer DEFAULT('')
					, comment Text DEFAULT('')
					, extraInfo Text DEFAULT('')
				)";
				
				string tPayments = @"drop table if exists payments;
				CREATE TABLE payments
				(
					id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
					, clientId Integer NOT NULL
					, scheduleId Integer NOT NULL
					, creatorId Integer NOT NULL
					, date TimeStamp Default(CURRENT_TIMESTAMP)
					, sum money NOT NULL
					, comment Text Default('')
				)";
				
				string tScheduleRules = @"drop table if exists scheduleRules;
				CREATE TABLE scheduleRules
				(
					id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
					, name VarChar NOT NULL
					, rule VarChar NOT NULL
					, price Float NOT NULL
				)";
				
				string tStatistics = @"drop table if exists statistics;
				CREATE TABLE statistics
				(
					id Integer PRIMARY KEY AUTOINCREMENT NOT NULL
					, clientId Integer NOT NULL
					, enter DateTime Default(CURRENT_TIMESTAMP)
					, leave DateTime Default(CURRENT_TIMESTAMP)
				)";

				string tTickets = @"drop table if exists tickets;
				CREATE TABLE tickets
				(
					  clientId PRIMARY KEY NOT NULL
					, enter DateTime Default(CURRENT_TIMESTAMP)
					, leave DateTime Default(CURRENT_TIMESTAMP)
				)";
				
				SQLiteConnection conn = new SQLiteConnection(ClientDbSrc);
				
				try
				{
					CheckDbFile(AY.db.Properties.Settings.Default.szDbSrcFile);
					
					conn.Open();
					new SQLiteCommand(tSettings, conn).ExecuteNonQuery();
					new SQLiteCommand(tUserPrivileges, conn).ExecuteNonQuery();
					new SQLiteCommand(tUsers, conn).ExecuteNonQuery();
					new SQLiteCommand(tTrainers, conn).ExecuteNonQuery();
					new SQLiteCommand(tClients, conn).ExecuteNonQuery();
					new SQLiteCommand(tPayments, conn).ExecuteNonQuery();
					new SQLiteCommand(tStatistics, conn).ExecuteNonQuery();
					new SQLiteCommand(tTarinersSchedule, conn).ExecuteNonQuery();
					new SQLiteCommand(tScheduleRules, conn).ExecuteNonQuery();
					new SQLiteCommand(tTickets, conn).ExecuteNonQuery();
				}
				catch (SQLiteException ex)
				{
					Logger.Error(String.Format("ClearDB exception: {0}.", ex.Message));
					throw new Exception("Error! DB clear failed.\r\n", ex);
				}
				finally
				{
					conn.Close();
				}
				
				Logger.Leave();
				return res;
			}

			private static void CheckDbFile(String dbFile)
			{
				if (!System.IO.File.Exists(dbFile))
				{
					SQLiteConnection.CreateFile(dbFile);
				}
			}

			public bool ImportData(String szImportFile)
			{
				bool res = false;
				Logger.Enter();
				
				do 
				{
					Opts op = new Opts();
					
					String szBackupFile;
					Archive.Decompress(new FileInfo(szImportFile), out szBackupFile);

					CheckDbFile(ClientDbFile);
					CheckDbFile(szBackupFile);
					
					String BackupSrc = AY.db.Properties.Settings.Default.szClientDataSrc + szBackupFile;
					
					lock (m_lock)
					{
						SQLiteConnection dbMain = new SQLiteConnection(ClientDbSrc);
						SQLiteConnection dbBackup = new SQLiteConnection(BackupSrc);

						try
						{
							dbBackup.Open();
							dbMain.Open();
							dbBackup.BackupDatabase(dbMain, "main", "main", -1, null, -1);
						}
						catch (SQLiteException ex)
						{
							Logger.Error(String.Format("Import DB exception: {0}.", ex.Message));
							throw new Exception("Error! Import DB failed.\r\n", ex);
						}
						finally
						{
							dbBackup.Close();
							dbMain.Close();
						}
					}	
					res = true;
				} while (false);
				
				Logger.Leave();
				return res;
			}

			public bool ExportData(String archName)
			{
				bool res = false;
				Logger.Enter();

				do
				{
					String tmpFile = DateTime.Now.ToString("yyyyMMddHHmmss") + ".tmp";
					String BackupSrc = AY.db.Properties.Settings.Default.szClientDataSrc + tmpFile;

					CheckDbFile(ClientDbFile);
					CheckDbFile(tmpFile);
					
					lock (m_lock)
					{
						SQLiteConnection dbMain = new SQLiteConnection(ClientDbSrc);
						SQLiteConnection dbBackup = new SQLiteConnection(BackupSrc);

						try
						{
							dbMain.Open();
							dbBackup.Open();
							dbMain.BackupDatabase(dbBackup, "main", "main", -1, null, -1);
						}
						catch (SQLiteException ex)
						{
							Logger.Error(String.Format("DB backup exception: {0}.", ex.Message));
							throw new Exception("Error! DB backup failed.\r\n", ex);
						}
						finally
						{
							dbMain.Close();
							dbBackup.Close();
						}


						FileInfo f = new FileInfo(tmpFile);
						Archive.Compress(f, archName);
						f.Delete();
					}
					
					res = true;
				} while (false);

				Logger.Leave();
				return res;
			}
		}
	}
}