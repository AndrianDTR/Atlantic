using System;
using System.Data;
using System.Windows.Forms;

using AY.Log;
using AY.db;
using AY.db.dbDataSetTableAdapters;
using AY.Utils;
using System.Data.SqlClient;

namespace EAssistant
{
	class Session : Singleton<Session>
	{
		private static int m_minBarcodeLen = 13;
		
		private int m_passLen = 8;
		private Int64 m_user = 0;
		private Int64 m_userRole = 0;
		
		public delegate void UpdateTicketList();
		
		private String RegInfo = String.Empty;
		
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
		}

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
	}
}
