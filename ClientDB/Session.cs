using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;
using AY.Utils;

namespace GAssistant
{
	class Session : Singleton<Session>
	{
		private int m_passLen = 8;
		private User m_user = new User();
		private UserRole m_userRole = new UserRole();
		private ListView m_ticketsList = null;
		
		public ListView Tickets
		{
			get
			{
				return m_ticketsList;
			}
			set
			{
				m_ticketsList = value;
			}
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
	}
}
