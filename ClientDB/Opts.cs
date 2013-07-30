using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace GAssistant
{
	public class Opts
	{
		private String m_name = String.Empty;
		private String m_phone = String.Empty;
		
		public Opts()
		{
			String where = String.Format("1 = 1");
			DataRow userData = new DbAdapter().GetFirstRow(DbTable.Trainers, where, new List<string> { "id", "name", "phone" });

			if (userData == null)
			{
				throw new Exception("Error! No such trainer.");
			}

			m_name = userData["name"].ToString();
			m_phone = userData["phone"].ToString();
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
				return m_phone;
			}
		}

		public void SetData(String name, String phone)
		{
			Debug.WriteLine(String.Format("Set data for trainer '{0}': name='{0}', phone='{1}'", m_name, name, phone));
			
			DbAdapter ad = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = name;
			fields["phone"] = phone;
			if (!ad.Update(DbTable.Trainers, fields, String.Format("id=1")))
			{
				throw new Exception("Data could not been changed.");
			}
			m_phone = phone;
			m_name = name;
		}
	}
}
