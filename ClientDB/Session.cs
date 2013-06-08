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
		
		private User m_user = null;
		private UserPrivileges m_userPrivileges = null;
		
		public User User
		{
			get{ return m_user;}
			set{ m_user = value; m_userPrivileges = m_user.Privileges;}
		}

		public UserPrivileges UserPrivileges
		{
			get { return m_userPrivileges; }
		}
	}
}
