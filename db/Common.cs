using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;
using AY.Utils;
using AY.db.dbDataSetTableAdapters;
using AY.Packer;
using System.IO;

namespace AY.db
{
	namespace dbDataSetTableAdapters
	{
		public partial class TableAdapterManager
		{
			private VPaymentsTableAdapter _vPaymentsTableAdapter;
			private VClientsTableAdapter _vClientsTableAdapter;
			private VCalendarInfoTableAdapter _vCalendarInfoTableAdapter;
			private VTodayClientsTableAdapter _vTodayClientsTableAdapter;
			
			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" +
				"ft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
				"", "System.Drawing.Design.UITypeEditor")]
			public VPaymentsTableAdapter VPaymentsTableAdapter
			{
				get
				{
					return this._vPaymentsTableAdapter;
				}
				set
				{
					this._vPaymentsTableAdapter = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" +
				"ft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
				"", "System.Drawing.Design.UITypeEditor")]
			public VClientsTableAdapter VClientsTableAdapter
			{
				get
				{
					return this._vClientsTableAdapter;
				}
				set
				{
					this._vClientsTableAdapter = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" +
				"ft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
				"", "System.Drawing.Design.UITypeEditor")]
			public VCalendarInfoTableAdapter VCalendarInfoTableAdapter
			{
				get
				{
					return this._vCalendarInfoTableAdapter;
				}
				set
				{
					this._vCalendarInfoTableAdapter = value;
				}
			}

			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" +
				"ft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
				"", "System.Drawing.Design.UITypeEditor")]
			public VTodayClientsTableAdapter VTodayClientsTableAdapter
			{
				get
				{
					return this._vTodayClientsTableAdapter;
				}
				set
				{
					this._vTodayClientsTableAdapter = value;
				}
			}
		}
	}
	
	public class Db : Singleton<Db>
	{
		private object m_lock = new object();
		private dbDataSet m_clientDataSet;
		private TableAdapterManager tam;
		
		private Db()
		{
			m_clientDataSet = new dbDataSet();
			Refill();	
		}

		private void Refill()
		{
			tam = new TableAdapterManager();
			tam.UpdateAll(m_clientDataSet);

			((System.ComponentModel.ISupportInitialize)(m_clientDataSet)).BeginInit();
			m_clientDataSet.DataSetName = "clientDataSet";
			m_clientDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

			Adapters.clientsTableAdapter = new clientsTableAdapter();
			Adapters.paymentsTableAdapter = new paymentsTableAdapter();
			Adapters.scheduleRulesTableAdapter = new scheduleRulesTableAdapter();
			Adapters.settingsTableAdapter = new settingsTableAdapter();
			Adapters.statisticsTableAdapter = new statisticsTableAdapter();
			Adapters.trainersTableAdapter = new trainersTableAdapter();
			Adapters.trainersScheduleTableAdapter = new trainersScheduleTableAdapter();
			Adapters.userPrivilegesTableAdapter = new userPrivilegesTableAdapter();
			Adapters.usersTableAdapter = new usersTableAdapter();
			Adapters.VClientsTableAdapter = new VClientsTableAdapter();
			Adapters.VPaymentsTableAdapter = new VPaymentsTableAdapter();
			Adapters.VCalendarInfoTableAdapter = new VCalendarInfoTableAdapter();
			Adapters.VTodayClientsTableAdapter = new VTodayClientsTableAdapter();

			Adapters.clientsTableAdapter.Fill(m_clientDataSet.clients);
			Adapters.paymentsTableAdapter.Fill(m_clientDataSet.payments);
			Adapters.scheduleRulesTableAdapter.Fill(m_clientDataSet.scheduleRules);
			Adapters.settingsTableAdapter.Fill(m_clientDataSet.settings);
			Adapters.statisticsTableAdapter.Fill(m_clientDataSet.statistics);
			Adapters.trainersTableAdapter.Fill(m_clientDataSet.trainers);
			Adapters.trainersScheduleTableAdapter.Fill(m_clientDataSet.trainersSchedule);
			Adapters.userPrivilegesTableAdapter.Fill(m_clientDataSet.userPrivileges);
			Adapters.usersTableAdapter.Fill(m_clientDataSet.users);
			Adapters.VClientsTableAdapter.Fill(m_clientDataSet.VClients);
			Adapters.VPaymentsTableAdapter.Fill(m_clientDataSet.VPayments);
			Adapters.VCalendarInfoTableAdapter.Fill(m_clientDataSet.VCalendarInfo);
			Adapters.VTodayClientsTableAdapter.Fill(m_clientDataSet.VTodayClients);

			((System.ComponentModel.ISupportInitialize)(m_clientDataSet)).EndInit();
		}
		
		public dbDataSet dSet
		{
			get { return m_clientDataSet; }
		}

		public TableAdapterManager Adapters
		{
			get { return tam; }
		}
		
		public void AcceptChanges()
		{
			Adapters.UpdateAll(dSet);
			dSet.AcceptChanges();
		}

		public bool ImportData(String szImportFile)
		{
			bool res = false;
			Logger.Enter();

			do
			{
				String szBackupFile;
				Archive.Decompress(new FileInfo(szImportFile), out szBackupFile);

				lock (m_lock)
				{
					dbDataSet ds = (dbDataSet)dSet.Clone();
					
					try
					{
						m_clientDataSet.Clear();

						foreach (DataTable dataTable in dSet.Tables)
						{
							dataTable.BeginLoadData();
						}

						dSet.ReadXml(szBackupFile, XmlReadMode.ReadSchema);

						foreach (DataTable dataTable in dSet.Tables)
						{
							dataTable.EndLoadData();
						}
					}
					catch(Exception ex)
					{
						Logger.Error("RestoreDatabase error. Changes could not be applied.");
						m_clientDataSet = ds;
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
				
				lock (m_lock)
				{
					m_clientDataSet.AcceptChanges();
					m_clientDataSet.WriteXml(tmpFile, XmlWriteMode.WriteSchema);

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

