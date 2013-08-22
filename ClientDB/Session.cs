using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;
using AY.Utils;
using System.Data;

namespace GAssistant
{
	class Session : Singleton<Session>
	{
		private static int m_minBarcodeLen = 13;
		
		private int m_passLen = 8;
		private User m_user = new User();
		private UserRole m_userRole = new UserRole();
		
		public delegate void UpdateTicketList();
		
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
		
		public void UpdateTickets()
		{
			if(m_ticketsUpdDelegate != null)
				m_ticketsUpdDelegate();
		}
		
		public User User
		{
			get{ return m_user;}
			set{ m_user = value; m_userRole = m_user.Role;}
		}

		public UserRole UserRole
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
	}
}
