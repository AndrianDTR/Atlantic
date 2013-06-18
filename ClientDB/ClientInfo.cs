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

		public Trainer Trainer
		{
			get { return (Trainer)comboTrainer.SelectedItem; }
			set { comboTrainer.SelectedItem = value; }
		}

		public ScheduleRule Schedule
		{
			get { return (ScheduleRule)comboSchedule.SelectedItem; }
			set { comboSchedule.SelectedItem = value; }
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			comboSchedule.Items.Clear();
			comboTrainer.Items.Clear();
			
			foreach (ScheduleRule sr in new ScheduleRulesCollection())
			{
				comboSchedule.Items.Add(sr);
			}

			foreach (Trainer tr in new TrainerCollection())
			{
				comboTrainer.Items.Add(tr);
			}
		}
	}
}
