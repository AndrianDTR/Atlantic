using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace GAssistant
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
		
		public Opts()
		{
			String where = String.Format("1 = 1");
			DataRow data = new DbAdapter().GetFirstRow(DbTable.Settings, where, new List<string> {});

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
		
		public void StoreData()
		{
			Logger.Enter();
			
			DbAdapter ad = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["language"] = m_language;
			fields["pathBackUp"] = m_pathBackUp;
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
