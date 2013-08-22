using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AY.db;
using AY.Log;
using AY.Utils;

namespace GAssistant
{
	public partial class ClientInfo : Form
	{	
		const String cancelText = "Cancel";
		const String enterText = "Enter";
		
		private Int64 m_clienId = 0;
		
		public ClientInfo(Int64 id)
		{
			InitializeComponent();
			Init();
			CheckPermissions();
			
			m_clienId = id;
			
			if (!ConfigUIForNewClient())
			{
				return;
			}
			
			Client client = new Client(m_clienId);
			
			textCode.Text = id.ToString().PadLeft(Session.MinBarcodeLen, '0');
			textName.Text = client.Name;
			textPhone.Text = client.Phone;
			dateSchedTime.Text = client.ScheduleTime.ToLongTimeString();

			foreach (Trainer it in comboTrainer.Items)
			{
				if (it == client.Trainer)
				{
					comboTrainer.SelectedItem = it;
					break;
				}
			}
			SetScheduleDays(client.ScheduleDays);
			textComment.Text = client.Comment;
			
			UpdateLastPaymentInfo(client);
			UpdateTimesLeft(client);
		}

		private void Init()
		{
			comboTrainer.Items.Clear();
			comboTrainer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			comboTrainer.AutoCompleteSource = AutoCompleteSource.CustomSource;

			foreach (Trainer tr in new TrainerCollection())
			{
				comboTrainer.Items.Add(tr);
				comboTrainer.AutoCompleteCustomSource.Add(tr.ToString());
			}

			string[] names = CultureInfoUtils.GetWeekDayNames();
			checkDay1.Text = names[0];
			checkDay2.Text = names[1];
			checkDay3.Text = names[2];
			checkDay4.Text = names[3];
			checkDay5.Text = names[4];
			checkDay6.Text = names[5];
			checkDay7.Text = names[6];
		}

		private void UpdateLastPaymentInfo(Client client)
		{
			String[] paymentInfo = client.LastPayment;
			textLastPaySum.Text = paymentInfo[0];
			textLastPayDate.Text = paymentInfo[1];
		}
		
		private void UpdateTimesLeft(Client client)
		{
			textTimesLeft.Text = client.TimesLeft.ToString();

			bool enabled = (client.TimesLeft > 0);
			btnEnter.Enabled = enabled && btnEnter.Enabled;
			btnLeave.Enabled = enabled && btnLeave.Enabled;

			textLastEnter.Text = client.LastEnter.ToString();
			textLastLeave.Text = client.LastLeave.ToString();
			
			if(client.OpenTicket.Date == DateTime.Now.Date)
			{
				btnEnter.Checked = true;
				btnEnter.Text = cancelText;
			}
		}
		
		private bool ConfigUIForNewClient()
		{
			bool existingClient = !(m_clienId == 0);
			textName.ReadOnly = existingClient;
			btnPaymentAdd.Enabled = existingClient;
			btnPaymentHistory.Enabled = existingClient;
			btnEnter.Enabled = existingClient;
			
			return existingClient;
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
			if(val.Length < Session.MinBarcodeLen)
			{
				val = val.PadLeft(Session.MinBarcodeLen, '0');
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

				if (null == comboTrainer.SelectedItem)
				{
					UIMessages.Error("Trainer must be selected from the list.");
					break;
				}
				
				res = true;
			}while (false);
			
			return res;			
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
		
		private String GetScheduleDays()
		{
			String data = "";
			
			data += checkDay1.Checked ? "X" : "_";
			data += checkDay2.Checked ? "X" : "_";
			data += checkDay3.Checked ? "X" : "_";
			data += checkDay4.Checked ? "X" : "_";
			data += checkDay5.Checked ? "X" : "_";
			data += checkDay6.Checked ? "X" : "_";
			data += checkDay7.Checked ? "X" : "_";
			
			return data;
		}

		private bool IsDaySet(int nDay, String data)
		{
			bool res = false;
			
			if (data.Length > nDay && data[nDay - 1] != '_')
				res = true;
			
			return res;
		}
		
		private void SetScheduleDays(String data)
		{
			checkDay1.Checked = IsDaySet(1, data);
			checkDay2.Checked = IsDaySet(2, data);
			checkDay3.Checked = IsDaySet(3, data);
			checkDay4.Checked = IsDaySet(4, data);
			checkDay5.Checked = IsDaySet(5, data);
			checkDay6.Checked = IsDaySet(6, data);
			checkDay7.Checked = IsDaySet(7, data);
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
				Int64 id = Session.CheckBarCode(textCode.Text);
				
				if(m_clienId == 0)
				{
					ClientCollection cc = new ClientCollection();
					cc.Add(id
						, textName.Text
						, textPhone.Text
						, GetScheduleDays()
						, DateTime.Parse(dateSchedTime.Text)
						, Trainer.Id
						, textComment.Text
						, out m_clienId);
						
					ConfigUIForNewClient();					
				}
				else
				{
					Client client = new Client(m_clienId);
					client.SetData(id
						, textName.Text
						, textPhone.Text
						, GetScheduleDays()
						, DateTime.Parse(dateSchedTime.Text)
						, Trainer.Id
						, textComment.Text);
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
			
			Client client = new Client(m_clienId);
			UpdateTimesLeft(client);
			UpdateLastPaymentInfo(client);
		}
		
		private void btnEnter_CheckedChanged(object sender, EventArgs e)
		{
			if(0 == m_clienId)
				return;
			
			Client clientInfo = new Client(m_clienId);
			
			if(btnEnter.Checked)
			{
				clientInfo.OpenTicket = DateTime.Now;
				btnLeave.Enabled = true;
				btnEnter.Text = cancelText;
			}
			else
			{
				clientInfo.OpenTicket = clientInfo.OpenTicket.AddYears(-1);
				btnLeave.Enabled = false;
				btnEnter.Text = enterText;
			}

			Session.Instance.UpdateTickets();
		}

		private void btnLeave_Click(object sender, EventArgs e)
		{
			Client clientInfo = new Client(m_clienId);
			clientInfo.LastEnter = clientInfo.OpenTicket;
			clientInfo.LastLeave = DateTime.Now;
			clientInfo.ProcessEnter();
			
			btnEnter.Checked = false;
			
			UpdateTimesLeft(new Client(m_clienId));

			Session.Instance.UpdateTickets();
		}

		private void btnPaymentHistory_Click(object sender, EventArgs e)
		{
			if(0 == m_clienId)
				return;
				
			PaymentsHistory hist = new PaymentsHistory(m_clienId);
			hist.ShowDialog();
		}
	}
}
