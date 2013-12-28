using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

using AY.Log;
using AY.db;
using AY.db.dbDataSetTableAdapters;
using AY.Utils;
using System.Data.SqlClient;

namespace EAssistant
{
	class Session : Singleton<Session>
	{
		static ResourceManager rm = null;
		
		private static int m_minBarcodeLen = 13;

		private int m_passLen = 8;
		private Int64 m_user = 0;
		private Int64 m_userRole = 0;
		private Int32 m_customerID = 0;

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
				Logger.Enter();
				m_ticketsUpdDelegate = value;
				Logger.Leave();
			}
		}

		private Session()
		{
			Logger.Enter();
			
			m_customerID = RegUtils.Instance.CustomerId;
			
			Logger.Leave();
		}

		protected ResourceManager ResourceManager
		{
			get
			{
				if(null == rm)
				{
					rm = new ResourceManager("EAssistant.Resources.Res", typeof(MainForm).Assembly);
				}
				
				return rm;
			}
		}
		
		public void UpdateMain()
		{
			Logger.Enter();
			if (m_ticketsUpdDelegate != null)
				m_ticketsUpdDelegate();
			Logger.Leave();
		}

		public Int64 UserId
		{
			get { return m_user; }
		}

		public Int64 UserRoleId
		{
			get { return m_userRole; }
		}

		public int PassLen
		{
			get { return m_passLen; }
			set
			{
				Logger.Enter();
				m_passLen = value;
				Logger.Leave();
			}
		}

		public int MinBarcodeLen
		{
			get { return m_minBarcodeLen; }
		}

		public Int32 CheckBarCode(String code)
		{
			Int32 res = 0;
			Logger.Enter();
			try
			{
				if (code.Length > MinBarcodeLen)
					throw new InvalidExpressionException();

				Int32 prefix = 0;
				Int32 customer = 0;
				
				Int32.TryParse(code.Substring(0, 2), out prefix);
				Int32.TryParse(code.Substring(2, 5), out customer);
				Int32.TryParse(code.Substring(7, 5), out res);
			}
			catch
			{
				UIMessages.Error(
					String.Format(GetResStr("invalid_barcode")
						, MinBarcodeLen));
				res = 0;
			}
			Logger.Leave();
			return res;
		}

		public void SetUserInfo(Int64 userId, Int64 userPrivId)
		{
			Logger.Enter();
			m_user = userId;
			m_userRole = userPrivId;
			Logger.Leave();
		}

		public Int32 CustomerId
		{
			get { return m_customerID; }
		}

		public static String GetResStr(String name)
		{
			Logger.Enter();
			String res = "";
			try
			{
				res = Session.Instance.ResourceManager.GetString(
					name, CultureInfoUtils.CurrentCulture);
			}
			catch(Exception ex)
			{
				Logger.Error(String.Format(
						"Get resource string \"{0}\" error, Internal msg: {1}"
						, name
						, ex.Message)
					);
			}
			return res;
		}
	}
}
