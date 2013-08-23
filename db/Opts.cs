using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AY.Log;
using System.Drawing;

namespace AY
{
	namespace db
	{
		public class Opts
		{
			private int m_minPassLen = -1;
			private String m_language = String.Empty;
			private int m_calRowHeight = -1;
			private int m_showTrainer = -1;
			private int m_showClientCount = -1;
			private int m_storeMainWindowState = -1;
			private int m_mainWindowState = -1;
			private String m_pathBackUp = String.Empty;
			private String m_colors = String.Empty;
			private DateTime m_startTime = DateTime.Now;
			private DateTime m_endTime = DateTime.Now;
			
			public Opts()
			{
				Update();
			}
			
			public void Update()
			{
				String where = String.Format("1 = 1");
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Settings, where, new List<string> { });

				if (data == null)
				{
					throw new Exception("Error! No such option.");
				}

				m_minPassLen = int.Parse(data["minPassLen"].ToString());
				m_calRowHeight = int.Parse(data["calRowHeight"].ToString());
				m_showTrainer = int.Parse(data["showTrainer"].ToString());
				m_showClientCount = int.Parse(data["showClientCount"].ToString());
				m_storeMainWindowState = int.Parse(data["storeMainWindowState"].ToString());
				m_mainWindowState = int.Parse(data["mainWindowState"].ToString());

				m_language = data["language"].ToString();
				m_pathBackUp = data["pathBackUp"].ToString();
				m_colors = data["colors"].ToString();
				
				m_startTime = DateTime.Parse(data["startTime"].ToString());
				m_endTime = DateTime.Parse(data["endTime"].ToString());
			}
			
			public String Language
			{
				get
				{
					return DbUtils.Dequote(m_language);
				}
				set
				{
					m_language = DbUtils.Quote(value);
				}
			}

			public String PathBackUp
			{
				get
				{
					return DbUtils.Dequote(m_pathBackUp);
				}
				set
				{
					m_pathBackUp = DbUtils.Quote(value);
				}
			}
			
			public int MinPassLen
			{
				get
				{
					return m_minPassLen;
				}
				set
				{
					m_minPassLen = value;
				}
			}

			public int CalRowHeight
			{
				get
				{
					return m_calRowHeight;
				}
				set
				{
					m_calRowHeight = value;
				}
			}

			public Boolean ShowTrainer
			{
				get
				{
					return (m_showTrainer == 1);
				}
				set
				{
					m_showTrainer = value ? 1 : 0;
				}
			}

			public Boolean ShowClientCount
			{
				get
				{
					return (m_showClientCount == 1);
				}
				set
				{
					m_showClientCount = value ? 1 : 0;
				}
			}

			public Boolean StoreMainWindowState
			{
				get
				{
					return (m_storeMainWindowState == 1);
				}
				set
				{
					m_storeMainWindowState = value ? 1 : 0;
				}
			}

			public FormWindowState MainWindowState
			{
				get
				{
					return (FormWindowState)m_mainWindowState;
				}
				set
				{
					m_mainWindowState = (int)value;
				}
			}
			
			public Color ColorPresent
			{
				get
				{
					Color clr = Color.FromArgb(0, 255, 0);
					
					Trigger tClr = new Trigger(m_colors);
					if (tClr.HasAttribute(TriggerFields.ColorPresent))
					{
						clr = tClr[TriggerFields.ColorPresent];
					}
					
					return clr;
				}
				set
				{
					Trigger tClr = new Trigger(m_colors);
					tClr[TriggerFields.ColorPresent] = value;
					m_colors = tClr.ToString();
				}
			}

			public Color ColorOvertime
			{
				get
				{
					Color clr = Color.FromArgb(255, 200, 50);

					Trigger tClr = new Trigger(m_colors);
					if (tClr.HasAttribute(TriggerFields.ColorOvertime))
					{
						clr = tClr[TriggerFields.ColorOvertime];
					}

					return clr;
				}
				set
				{
					Trigger tClr = new Trigger(m_colors);
					tClr[TriggerFields.ColorOvertime] = value;
					m_colors = tClr.ToString();
				}
			}

			public Color ColorDelayed
			{
				get
				{
					Color clr = Color.FromArgb(255, 255, 0);

					Trigger tClr = new Trigger(m_colors);
					if (tClr.HasAttribute(TriggerFields.ColorDelayed))
					{
						clr = tClr[TriggerFields.ColorDelayed];
					}

					return clr;
				}
				set
				{
					Trigger tClr = new Trigger(m_colors);
					tClr[TriggerFields.ColorDelayed] = value;
					m_colors = tClr.ToString();
				}
			}

			public Color ColorMissed
			{
				get
				{
					Color clr = Color.FromArgb(255, 50, 0);

					Trigger tClr = new Trigger(m_colors);
					if (tClr.HasAttribute(TriggerFields.ColorMissed))
					{
						clr = tClr[TriggerFields.ColorMissed];
					}

					return clr;
				}
				set
				{
					Trigger tClr = new Trigger(m_colors);
					tClr[TriggerFields.ColorMissed] = value;
					m_colors = tClr.ToString();
				}
			}

			public DateTime StartTime
			{
				get
				{
					return m_startTime;
				}
				set
				{
					m_startTime = value;
				}
			}

			public DateTime EndTime
			{
				get
				{
					return m_endTime;
				}
				set
				{
					m_endTime = value;
				}
			}
			
			public void StoreData()
			{
				Logger.Enter();
				
				DbAdapter ad = new DbAdapter();
				Dictionary<string, Object> fields = new Dictionary<string, Object>();
				fields["language"] = m_language;
				fields["pathBackUp"] = m_pathBackUp;
				fields["colors"] = m_colors;
				fields["minPassLen"] = m_minPassLen;
				fields["calRowHeight"] = m_calRowHeight;
				fields["showTrainer"] = m_showTrainer;
				fields["showClientCount"] = m_showClientCount;
				fields["storeMainWindowState"] = m_storeMainWindowState;
				fields["mainWindowState"] = m_mainWindowState;
				fields["startTime"] = m_startTime;
				fields["endTime"] = m_endTime;
				
				if (!ad.Update(DbTable.Settings, fields, String.Format("id=1")))
				{
					Logger.Error("Store option error.");
					throw new Exception("Data could not been stored.");
				}
				
				Logger.Leave();
			}
		}
	}
}