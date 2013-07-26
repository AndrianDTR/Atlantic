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
			Init();
			CheckPermissions();
			textName.ReadOnly = true;
		}
		
		public ClientInfo(Boolean newClient)
		{
			InitializeComponent();
			Init();
			CheckPermissions();
		}
		
		private void Init()
		{
			comboSchedule.Items.Clear();
			comboSchedule.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			comboSchedule.AutoCompleteSource = AutoCompleteSource.CustomSource;

			comboTrainer.Items.Clear();
			comboTrainer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			comboTrainer.AutoCompleteSource = AutoCompleteSource.CustomSource;

			foreach (ScheduleRule sr in new ScheduleRulesCollection())
			{
				comboSchedule.Items.Add(sr);
				comboSchedule.AutoCompleteCustomSource.Add(sr.ToString());
			}

			foreach (Trainer tr in new TrainerCollection())
			{
				comboTrainer.Items.Add(tr);
				comboTrainer.AutoCompleteCustomSource.Add(tr.ToString());
			}
		}
		
		private void CheckPermissions()
		{
			Session session = Session.Instance;
			if (UserRole.IsSet(session.UserRole.Payments, UserRights.Create))
			{
				btnPayment.Enabled = true;
			}

			if (UserRole.IsSet(session.UserRole.Clients, UserRights.Create))
			{
				btnOk.Enabled = true;
			}
		}
		
		private static String GetGroupValue(String str2parse, String grp)
		{
			String res = "";
			foreach (Char s in str2parse)
			{
				int ndx = int.Parse(s.ToString());
				res += grp[ndx];
			}
			return res;
		}
		
		public static String GenerateEan13Code(String val)
		{
			String grp1 = GetGroupValue(val.Substring(0, 1), "0123456789");
			String grp2 = GetGroupValue(val.Substring(1, 6), "ABCDEFGHIJ");
			String grp3 = GetGroupValue(val.Substring(7, 6), "abcdefghij");
								
			return String.Format("{0}{1}*{2}+",grp1,grp2,grp3);
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
			set
			{
				foreach (Trainer it in comboTrainer.Items)
				{
					if (it == value)
					{
						comboTrainer.SelectedItem = it;
						break;
					}
				}
			}
		}

		public ScheduleRule Schedule
		{
			get { return (ScheduleRule)comboSchedule.SelectedItem; }
			set 
			{
				foreach (ScheduleRule it in comboSchedule.Items)
				{
					if(it == value)
					{
						comboSchedule.SelectedItem = it;
						break;
					}
						
				}
			}
		}
		
		private bool ValidateForm()
		{
			bool res = false;
			
			do
			{
				if (0 == textCode.Text.Length)
				{
					UIMessages.Error("Card is not attached. Please attach card first.");
					break;
				}

				if (0 == textName.Text.Length)
				{
					UIMessages.Error("Field 'Name' should not be an empty. Please fill it first.");
					break;
				}

				if (0 == textPhone.Text.Length)
				{
					UIMessages.Error("Field 'Phone' should not be an empty. Please fill it first.");
					break;
				}

				if (null == comboSchedule.SelectedItem)
				{
					UIMessages.Error("Schedule must be selected from the list.");
					break;
				}

				if (null == comboTrainer.SelectedItem)
				{
					UIMessages.Error("Trainer must be selected from the list.");
					break;
				}
				
				res = true;
			}while (false);
			
			return res;			
		}
		
		private void btnOk_Click(object sender, EventArgs e)
		{
			if(ValidateForm())
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnScan_Click(object sender, EventArgs e)
		{
			Prompt dlg = new Prompt();
			if(DialogResult.OK == dlg.ShowDialog())
			{
				textCode.Text = dlg.Value + " | " + GenerateEan13Code(dlg.Value);
			}
		}

		private void btnPayment_Click(object sender, EventArgs e)
		{

		}
	}
}
