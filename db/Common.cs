using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;
using AY.Utils;
using AY.db.dbDataSetTableAdapters;

namespace AY.db
{
	namespace dbDataSetTableAdapters
	{
		public partial class TableAdapterManager
		{
			private vPaymentsTableAdapter _vPaymentsTableAdapter;
			private VClientsTableAdapter _vClientsTableAdapter;
			
			[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
			[global::System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" +
				"ft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
				"", "System.Drawing.Design.UITypeEditor")]
			public vPaymentsTableAdapter vPaymentsTableAdapter
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
		}
	}
	
	public class Db : Singleton<Db>
	{
		private dbDataSet m_clientDataSet;
		private TableAdapterManager tam;
		
		private Db()
		{
			m_clientDataSet = new dbDataSet();
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
			Adapters.vPaymentsTableAdapter = new vPaymentsTableAdapter();

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
			Adapters.vPaymentsTableAdapter.Fill(m_clientDataSet.vPayments);

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
	}
}

