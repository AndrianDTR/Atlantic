﻿using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class Client
		{
			private Int64 m_id = 0;
			private String m_name = String.Empty;
			private String m_phone = String.Empty;
			private String m_comment = String.Empty;
			private String m_extraInfo = String.Empty;
			private String m_scheduleDays = String.Empty;
			private DateTime m_scheduleTime;
			private Int64 m_trainer = 0;
			
			public static bool CodeExists(Int64 id)
			{
				return CodeExists(id.ToString());
			}

			public static bool CodeExists(String id)
			{
				String where = String.Format("id = '{0}'", id);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Clients, where, new List<string>());

				if (data == null)
				{
					return false;
				}
				return true;
			}
			
			private Client()
			{
			}
			
			public Client(Int64 id)
			{	
				String where = String.Format("id = {0}", id);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Clients, where, new List<string>());

				if (data == null)
				{
					throw new Exception("Error! No such client.");
				}

				m_id = id;
				m_name = data["name"].ToString();
				m_phone = data["phone"].ToString();
				m_comment = data["comment"].ToString();
				m_extraInfo = data["extraInfo"].ToString();
				m_scheduleDays = data["scheduleDays"].ToString();
				m_scheduleTime = DateTime.Parse(data["scheduleTime"].ToString());
				m_trainer = Int64.Parse(data["trainer"].ToString());
			}

			public Client(String name)
			{
				String where = String.Format("name = '{0}'", name);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Clients, where, new List<string>());
				
				if (data == null)
				{
					throw new Exception("Error! No such client.");
				}

				m_id = Int64.Parse(data["id"].ToString());
				m_name = data["name"].ToString();
				m_phone = data["phone"].ToString();
				m_comment = data["comment"].ToString();
				m_extraInfo = data["extraInfo"].ToString();
				m_scheduleDays = data["scheduleDays"].ToString();
				m_scheduleTime = DateTime.Parse(data["scheduleTime"].ToString());
				m_trainer = Int64.Parse(data["trainer"].ToString());
			}
			
			public Int64 Id
			{
				get
				{
					return m_id;
				}
			}

			public String Code
			{
				get
				{
					return m_id.ToString().PadLeft(13, '0');
				}
			}
			
			public String Name
			{
				get
				{
					return DbUtils.Dequote(m_name);
				}
			}

			public String Phone
			{
				get
				{
					return DbUtils.Dequote(m_phone);
				}
			}

			public String Comment
			{
				get
				{
					return DbUtils.Dequote(m_comment);
				}
			}

			public String ExtraInfo
			{
				get
				{
					return m_extraInfo;
				}
				set
				{
					String data = value;
					
					Logger.Debug(String.Format("Set extraInfo for client '{0}'", m_name));
					if (m_id > 0)
					{
						DbAdapter ad = new DbAdapter();
						Dictionary<string, string> fields = new Dictionary<string, string>();
						fields["extraInfo"] = data;

						if (ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
						{	
							m_extraInfo = data;
						}
					}
				}
			}

			public String ScheduleDays
			{
				get
				{
					return DbUtils.Dequote(m_scheduleDays);
				}
			}
			
			public Trainer Trainer
			{
				get
				{
					return new Trainer(m_trainer);
				}
			}

			public Int64 TrainerId
			{
				get
				{
					return m_trainer;
				}
			}

			public DateTime ScheduleTime
			{
				get
				{
					return m_scheduleTime;
				}
			}

			public bool SetData(Int64 code, String name, String phone, String scheduleDays, DateTime scheduleTime, Int64 trainerId, String comment)
			{
				Logger.Debug(String.Format("Set data for client '{0}'", m_name));
				if (m_id <= 0)
				{
					return false;
				}

				DbAdapter ad = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["id"] = code.ToString();
				fields["name"] = DbUtils.Quote(name);
				fields["phone"] = DbUtils.Quote(phone);
				fields["scheduleDays"] = DbUtils.Quote(scheduleDays);
				fields["scheduleTime"] = scheduleTime.ToString("HH:mm:ss");
				fields["trainer"] = trainerId.ToString();
				fields["comment"] = DbUtils.Quote(comment);

				if (!ad.Update(DbTable.Clients, fields, String.Format("id={0:d}", m_id)))
				{
					return false;
				}

				return true;
			}
		}

		public class ClientCollection : IEnumerable<Client>
		{
			Dictionary<Int64, Client> Items = new Dictionary<Int64, Client>();

			public ClientCollection()
			{
				DbAdapter da = new DbAdapter();
				DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.Clients)));
				foreach(DataRow dr in dt.Rows)
				{
					Client user = new Client(Int64.Parse(dr["id"].ToString()));
					Items[user.Id] = user;
				}
			}

			public Boolean Add(Int64 code, String name, String phone, String scheduleDays, DateTime scheduleTime, String comment, Int64 trainer)
			{
				Int64 id = 0;
				return Add(code, name, phone, scheduleDays, scheduleTime, trainer, comment, out id);
			}

			public Boolean Add(Int64 code, String name, String phone, String scheduleDays, DateTime scheduleTime, Int64 trainer, String comment, out Int64 id)
			{
				DbAdapter da = new DbAdapter();
				Dictionary<string, string> fields = new Dictionary<string, string>();
				fields["id"] = code.ToString();
				fields["name"] = DbUtils.Quote(name);
				fields["phone"] = DbUtils.Quote(phone);
				fields["scheduleDays"] = DbUtils.Quote(scheduleDays);
				fields["scheduleTime"] = scheduleTime.ToString("HH:mm:ss");
				fields["trainer"] = trainer.ToString();
				fields["comment"] = DbUtils.Quote(comment);
				id = 0;

				if (!da.Insert(DbTable.Clients, fields, out id))
					return false;

				Items[id] = new Client(id);
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.Clients, where);
			}
			
			public bool Remove(Int64 id)
			{
				if(!RemoveById(id))
					return false;
				return Items.Remove(id);
			}

			public bool Remove(Client item)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", item.Id);
				da.Delete(DbTable.Clients, where);
				return Items.Remove(item.Id);
			}

			public Client Search(Int64 id)
			{
				if(Items.ContainsKey(id))
					return Items[id];
				return null;
			}
			
			public List<Client> Search(String name)
			{
				return Search(name, false);
			}

			public List<Client> Search(String name, Boolean contains)
			{
				List<Client> collection = new List<Client>();
				foreach (KeyValuePair<Int64, Client> client in Items)
				{
					if((contains && client.Value.Name.Contains(name)) || client.Value.Name.StartsWith(name))
					{
						collection.Add(client.Value);
					}
				}
				return collection;
			}
			
			public int Count
			{
				get { return Items.Count; }
			}

			public IEnumerator<Client> GetEnumerator()
			{
				return Items.Values.GetEnumerator();
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return Items.Values.GetEnumerator();
			}
		}
	}
}
