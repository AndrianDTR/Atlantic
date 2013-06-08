using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ClientDB
{
	class Session
	{
		// Constructor
		public Session()
		{
			Debug.WriteLine("Constructor enter");

			Debug.WriteLine("Constructor leave");
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
		private UserPrivileges m_userPrivileges = new UserPrivileges();
		
		public User User
		{
			get{ return m_user;}
			set{ m_user = value; m_userPrivileges = m_user.Privileges;}
		}

		public UserPrivileges UserPrivileges
		{
			get { return m_userPrivileges; }
		}
		
		public int PassLen
		{
			get{ return m_passLen; }
			set{ m_passLen = value; }
		}
	}
}
