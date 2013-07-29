using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAssistant
{
	public partial class ClientInfo : Form
	{	
		private Int64 m_clienId = 0;
		
		private ClientInfo()
		{
		}
		
		public ClientInfo(Int64 id)
		{
			InitializeComponent();
			Init();
			CheckPermissions();
			
			m_clienId = id;
			
			if(id == 0)
			{
				return;
			}
			
			textName.ReadOnly = !(m_clienId == 0);

			Client client = new Client(m_clienId);
			
			textCode.Text = id.ToString().PadLeft(13, '0');
			textName.Text = client.Name;
			textPhone.Text = client.Phone;

			foreach (Trainer it in comboTrainer.Items)
			{
				if (it == client.Trainer)
				{
					comboTrainer.SelectedItem = it;
					break;
				}
			}

			foreach (ScheduleRule it in comboSchedule.Items)
			{
				if (it == client.Schedule)
				{
					comboSchedule.SelectedItem = it;
					break;
				}
			}

			textComment.Text = client.Comment;
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
			if (UserRole.IsSet(session.UserRole.Payments, UserRights.Read))
			{
				btnPaymentHistory.Enabled = true;
			}
			
			if (UserRole.IsSet(session.UserRole.Payments, UserRights.Create))
			{
				btnPaymentAdd.Enabled = true;
			}

			if (UserRole.IsSet(session.UserRole.Clients, UserRights.Write))
			{
				btnEnter.Enabled = true;
				btnLeave.Enabled = true;
				btnChangeCode.Enabled = true;
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
			if(val.Length < 13)
			{
				val = val.PadLeft(13, '0');
			}
			
			String grp1 = GetGroupValue(val.Substring(0, 1), "0123456789");
			String grp2 = GetGroupValue(val.Substring(1, 6), "ABCDEFGHIJ");
			String grp3 = GetGroupValue(val.Substring(7, 6), "abcdefghij");
								
			return String.Format("{0}{1}*{2}+", grp1, grp2, grp3);
		}

		public Int64 Id
		{
			get { return m_clienId; }
		}
		
		public String ClientName
		{
			get { return textName.Text; }
		}

		public String ClientPhone
		{
			get { return textPhone.Text; }
		}

		public String ClientCode
		{
			get { return textCode.Text; }
		}

		public Trainer Trainer
		{
			get { return (Trainer)comboTrainer.SelectedItem; }
		}

		public ScheduleRule Schedule
		{
			get { return (ScheduleRule)comboSchedule.SelectedItem; }
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
		
		private Int64 GetClientId(String val)
		{
			Int64 id = 0;
			try
			{
				Logger.Debug("000:" + val);
				if (val.Length > 13)
					throw new InvalidExpressionException();

				Logger.Debug("AAA");
				id = Int64.Parse(val);
				Logger.Debug("BBB" + id.ToString());
			}
			catch
			{
				UIMessages.Error("Invalid card number has been specified. Please use only digits and no more 13 characters.");
				id = 0;
			}
			return id;
		}
		
		private Boolean ChangeClientCode()
		{
			Boolean res = false;
			
			Prompt dlg = new Prompt();
			while (DialogResult.OK == dlg.ShowDialog())
			{
				if(Client.CodeExists(dlg.Value))
				{
					UIMessages.Error("This card already attached. Please use another one.");
					dlg.Clear();
					continue;
				}

				if (0 == GetClientId(dlg.Value))
				{
					dlg.Clear();
					continue;
				}
				
				textCode.Text = dlg.Value;
				res = true;
				break;
			}
			return res;
		}
		
		private void btnChangeCode_Click(object sender, EventArgs e)
		{
			ChangeClientCode();
		}
		
		private void btnOk_Click(object sender, EventArgs e)
		{
			if(m_clienId == 0)
			{
				if(!ChangeClientCode())
					return;
			}
			
			if(ValidateForm())
			{
				Int64 id = GetClientId(textCode.Text);
				
				if(m_clienId == 0)
				{
					ClientCollection cc = new ClientCollection();
					cc.Add(id, textName.Text, textPhone.Text, Schedule.Id, Trainer.Id, textComment.Text, out m_clienId);
				}
				else
				{
					Client client = new Client(m_clienId);
					client.SetData(id, textName.Text, textPhone.Text, Schedule.Id, Trainer.Id, textComment.Text);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}

		private void btnPayment_Click(object sender, EventArgs e)
		{
			if (0 == m_clienId)
				return;
			
			AddPayment addPaymDlg = new AddPayment(m_clienId);
			addPaymDlg.ShowDialog();
		}
	}
}
