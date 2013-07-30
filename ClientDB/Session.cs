using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GAssistant
{
	class Session
	{
		// Constructor
		public Session()
		{
			//Logger.Enter();

			//Logger.Leave();
		}

		//Singleton implementation
		private static Session instance;

		public static Session Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Session();
				}
				return instance;
			}
		}
		
		private int m_passLen = 8;
		private User m_user = new User();
		private UserRole m_userRole = new UserRole();
		
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
