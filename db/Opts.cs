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
			private int m_storeMainWindowSatate = -1;
			private int m_mainWindowSatate = -1;
			private String m_pathBackUp = String.Empty;
			private String m_colors = String.Empty;
			
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
				m_storeMainWindowSatate = int.Parse(data["storeMainWindowState"].ToString());
				m_mainWindowSatate = int.Parse(data["mainWindowState"].ToString());

				m_language = data["language"].ToString();
				m_pathBackUp = data["pathBackUp"].ToString();
				m_colors = data["colors"].ToString();
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
					return (m_storeMainWindowSatate == 1);
				}
				set
				{
					m_storeMainWindowSatate = value ? 1 : 0;
				}
			}

			public FormWindowState MainWindowState
			{
				get
				{
					return (FormWindowState)m_mainWindowSatate;
				}
				set
				{
					m_mainWindowSatate = (int)value;
				}
			}
			
			public Color ColorPresent
			{
				get
				{
					Color clr = Color.FromArgb(0, 255, 0);
					
					Trigger tClr = new Trigger(m_colors);
					if(tClr.HasAttribute("ColorPresent"))
					{
						clr = tClr["ColorPresent"];
					}
					
					return clr;
				}
				set
				{
					Trigger tClr = new Trigger(m_colors);
					tClr["ColorPresent"] = value;
					m_colors = tClr.ToString();
				}
			}

			public Color ColorOvertime
			{
				get
				{
					Color clr = Color.FromArgb(255, 200, 50);

					Trigger tClr = new Trigger(m_colors);
					if (tClr.HasAttribute("ColorOvertime"))
					{
						clr = tClr["ColorOvertime"];
					}

					return clr;
				}
				set
				{
					Trigger tClr = new Trigger(m_colors);
					tClr["ColorOvertime"] = value;
					m_colors = tClr.ToString();
				}
			}

			public Color ColorDelayed
			{
				get
				{
					Color clr = Color.FromArgb(255, 255, 0);

					Trigger tClr = new Trigger(m_colors);
					if (tClr.HasAttribute("ColorDelayed"))
					{
						clr = tClr["ColorDelayed"];
					}

					return clr;
				}
				set
				{
					Trigger tClr = new Trigger(m_colors);
					tClr["ColorDelayed"] = value;
					m_colors = tClr.ToString();
				}
			}

			public Color ColorMissed
			{
				get
				{
					Color clr = Color.FromArgb(255, 50, 0);

					Trigger tClr = new Trigger(m_colors);
					if (tClr.HasAttribute("ColorMissed"))
					{
						clr = tClr["ColorMissed"];
					}

					return clr;
				}
				set
				{
					Trigger tClr = new Trigger(m_colors);
					tClr["ColorMissed"] = value;
					m_colors = tClr.ToString();
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
				fields["minPassLen"] = m_minPassLen.ToString();
				fields["calRowHeight"] = m_calRowHeight.ToString();
				fields["showTrainer"] = m_showTrainer.ToString();
				fields["showClientCount"] = m_showClientCount.ToString();
				fields["storeMainWindowState"] = m_storeMainWindowSatate.ToString();
				fields["mainWindowState"] = m_mainWindowSatate.ToString();
				
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