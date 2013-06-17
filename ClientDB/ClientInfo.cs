using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
	public partial class ClientInfo : Form
	{
		private Int64 m_trainer = 0;
		private Int64 m_schedule = 0;

		public ClientInfo()
		{
			InitializeComponent();
		}
		
		public ClientInfo(Boolean newClient)
		{
			InitializeComponent();
			
			if (newClient)
				GenerateCode();
		}
		private void GenerateCode()
		{
			var chars = "ABCDEFGHJKLMNPQRSTUVWXYZ0123456789";
			var random = new Random();
			var result = new String(
				Enumerable.Repeat(chars, 14)
					.Select(s => s[random.Next(s.Length)])
					.ToArray());
			textCode.Text = result;
		}
		
		public String ClientName
		{
			get { return textName.Text; }
			set { textName.Text = value; }
		}

		public String ClientPhone
		{
			get { return textPhone.Text; }
			set { textPhone.Text = value; }
		}

		public String ClientCode
		{
			get { return textCode.Text; }
			set { textCode.Text = value; }
		}

		public Int64 Trainer
		{
			get { return m_trainer; }
			set { m_trainer = value; }
		}

		public Int64 Schedule
		{
			get { return m_schedule; }
			set { m_schedule = value; }
		}
	}
}
