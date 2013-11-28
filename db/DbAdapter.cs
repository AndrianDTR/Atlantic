using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;
using System.Text;
using AY.Log;
using AY.Packer;
using AY.Utils;

namespace AY
{
	namespace db
	{
		
		public class DbAdapter
		{
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
					String szBackupFile;
					Archive.Decompress(new FileInfo(szImportFile), out szBackupFile);

					//CheckDbFile(ClientDbFile);
					CheckDbFile(szBackupFile);
					
					String BackupSrc = AY.db.Properties.Settings.Default.szClientDataSrc + szBackupFile;
					
					//lock (m_lock)
					{
						//SQLiteConnection dbMain = new SQLiteConnection(ClientDbSrc);
						SQLiteConnection dbBackup = new SQLiteConnection(BackupSrc);

						try
						{
							dbBackup.Open();
							//dbMain.Open();
							//dbBackup.BackupDatabase(dbMain, "main", "main", -1, null, -1);
						}
						catch (SQLiteException ex)
						{
							Logger.Error(String.Format("Import DB exception: {0}.", ex.Message));
							throw new Exception("Error! Import DB failed.\r\n", ex);
						}
						finally
						{
							dbBackup.Close();
							//dbMain.Close();
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

					//CheckDbFile(ClientDbFile);
					CheckDbFile(tmpFile);
					
					//lock (m_lock)
					{
						//SQLiteConnection dbMain = new SQLiteConnection(ClientDbSrc);
						SQLiteConnection dbBackup = new SQLiteConnection(BackupSrc);

						try
						{
							//dbMain.Open();
							dbBackup.Open();
							//dbMain.BackupDatabase(dbBackup, "main", "main", -1, null, -1);
						}
						catch (SQLiteException ex)
						{
							Logger.Error(String.Format("DB backup exception: {0}.", ex.Message));
							throw new Exception("Error! DB backup failed.\r\n", ex);
						}
						finally
						{
							//dbMain.Close();
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
