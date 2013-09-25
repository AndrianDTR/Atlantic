using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;
using AY.Utils;
using AY.db.dstAdapters;

namespace AY.db
{
	public class Db : Singleton<Db>
	{
		private dbDataSet m_clientDataSet;
		//private tAdapter m_tAdapter;
		private TableAdapterManager tam;
		
		private Db()
		{
			m_clientDataSet = new dbDataSet();
			//m_tAdapter = new tAdapter();
			tam = new TableAdapterManager();

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

			Adapters.clientsTableAdapter.Fill(m_clientDataSet.clients);
			Adapters.paymentsTableAdapter.Fill(m_clientDataSet.payments);
			Adapters.scheduleRulesTableAdapter.Fill(m_clientDataSet.scheduleRules);
			Adapters.settingsTableAdapter.Fill(m_clientDataSet.settings);
			Adapters.statisticsTableAdapter.Fill(m_clientDataSet.statistics);
			Adapters.trainersTableAdapter.Fill(m_clientDataSet.trainers);
			Adapters.trainersScheduleTableAdapter.Fill(m_clientDataSet.trainersSchedule);
			Adapters.userPrivilegesTableAdapter.Fill(m_clientDataSet.userPrivileges);
			Adapters.usersTableAdapter.Fill(m_clientDataSet.users);

			//m_tAdapter.lvtaClientsList.Fill(m_clientDataSet.clientsList);

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
	}
}

