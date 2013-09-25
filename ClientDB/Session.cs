using System;
using System.Data;
using System.Windows.Forms;

using AY.Log;
using AY.db;
using AY.db.dstAdapters;
using AY.Utils;
using System.Data.SqlClient;

namespace EAssistant
{
	class tAdapter
	{
		public clientsTableAdapter				taClients = new clientsTableAdapter();
		public paymentsTableAdapter				taPayments = new paymentsTableAdapter();
		public scheduleRulesTableAdapter		taRules = new scheduleRulesTableAdapter();
		public settingsTableAdapter				taSettings = new settingsTableAdapter();
		public statisticsTableAdapter			taStatistics = new statisticsTableAdapter();
		public trainersScheduleTableAdapter		taTrainersSchedule = new trainersScheduleTableAdapter();
		public trainersTableAdapter				taTrainers = new trainersTableAdapter();
		public userPrivilegesTableAdapter		taUserPrivileges = new userPrivilegesTableAdapter();
		public usersTableAdapter				taUsers = new usersTableAdapter();
		
		public clientsListTableAdapter			lvtaClientsList = new clientsListTableAdapter();
		
		public tAdapter()
		{
			lvtaClientsList.ClearBeforeFill = true;
		}
	}

	class Session : Singleton<Session>
	{
		private static int m_minBarcodeLen = 13;
		
		private int m_passLen = 8;
		private Int64 m_user = 0;
		private Int64 m_userRole = 0;
		
		public delegate void UpdateTicketList();
		
		private String RegInfo = String.Empty;
		
		//private dbDataSet m_clientDataSet;
		//private tAdapter m_tAdapter;
		//private TableAdapterManager tam;
		
		private UpdateTicketList m_ticketsUpdDelegate = null;
		public UpdateTicketList TicketUpdate
		{
			get
			{
				return m_ticketsUpdDelegate;
			}
			set
			{
				m_ticketsUpdDelegate = value;
			}
		}
		
		private Session()
		{
			/*
			m_clientDataSet = new clientDataSet();
			m_tAdapter = new tAdapter();
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

			m_tAdapter.lvtaClientsList.Fill(m_clientDataSet.clientsList);
			
			((System.ComponentModel.ISupportInitialize)(m_clientDataSet)).EndInit();
			*/
#if DEBUG
			test();
#endif			
		}

		public override void Dispose()
		{
			/*m_clientDataSet.AcceptChanges();
			int x = tam.UpdateAll(m_clientDataSet);
			m_clientDataSet.AcceptChanges();
			*/
			base.Dispose();
		}
		
		//public dbDataSet dSet
		//{
		//    get{ return m_clientDataSet; }
		//}

		//public TableAdapterManager Adapters
		//{
		//    get { return tam; }
		//}
		
		public void UpdateTickets()
		{
			if(m_ticketsUpdDelegate != null)
				m_ticketsUpdDelegate();
		}
		
		public Int64 UserId
		{
			get{ return m_user;}
		}

		public Int64 UserRoleId
		{
			get { return m_userRole; }
		}
		
		public int PassLen
		{
			get{ return m_passLen; }
			set{ m_passLen = value; }
		}
		
		public static int MinBarcodeLen
		{
			get { return m_minBarcodeLen; }
		}

		public static Int64 CheckBarCode(String code)
		{
			Int64 res = 0;
			try
			{
				if (code.Length > MinBarcodeLen)
					throw new InvalidExpressionException();

				res = Int64.Parse(code);
				
				if(0 == res)
				{
					UIMessages.Error("Client code should not be 'NULL'.");
				}
			}
			catch
			{
				UIMessages.Error(
					String.Format("Invalid card number has been specified.\n"
						+ "Please use only digits and no more {0} characters."
						, MinBarcodeLen));
				res = 0;
			}
			
			return res;
		}
		
		public void SetUserInfo(Int64 userId, Int64 userPrivId)
		{
			m_user = userId;
			m_userRole = userPrivId;
		}

		public static void SyncDB()
		{
			Db.Instance.Adapters.clientsTableAdapter.Update(Db.Instance.dSet);
		}
		
		private void test()
		{
			//Int64 newId = 1111000;
			//dbDataSet.clientsRow cr0 = Db.Instance.dSet.clients.FindByid(newId);
			//dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(2200000000006);
			
			//cr.BeginEdit();
			//cr.id = newId;
			//cr.EndEdit();
			
			//Db.Instance.dSet.clients.Rows.Add(cr);

			//dbDataSet.clientsRow ucr = Db.Instance.dSet.clients.FindByid(newId);
			
			//UIMessages.Info(ucr.name);
			//int x = Db.Instance.Adapters.UpdateAll(Db.Instance.dSet);
			//Db.Instance.dSet.AcceptChanges();
		}
	}
}
