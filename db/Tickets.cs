﻿using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class Ticket
		{
			private Int64 m_clientId = 0;
			public DateTime m_enter;
			public DateTime m_leave;

			public Ticket(Int64 id)
			{	
				String where = String.Format("clientId = {0}", id);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Tickets, where, new List<string> { "enter", "leave" });
				
				if(data == null)
				{
					AddTicket(id);
					return;
				}

				m_clientId = id;
				m_enter = DateTime.Parse(data["enter"].ToString());
				m_leave = DateTime.Parse(data["leave"].ToString());
			}

			private void AddTicket(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["clientId"] = id.ToString();

				if (!da.Insert(DbTable.Tickets, fields, out m_clientId))
				{
					Logger.Error("Error! Ticket creation failed.");
					throw new Exception("Error! Ticket creation failed.");
				}
			}
			
			public Int64 Id
			{
				get
				{
					return m_clientId;
				}
			}
			
			public DateTime Enter
			{
				get
				{
					return m_enter;
				}
			}

			public DateTime Leave
			{
				get
				{
					return m_leave;
				}
			}
		}
	}
}