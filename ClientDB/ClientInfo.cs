using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AY.db;
using AY.Log;
using AY.Utils;
using EAssistant.clientDataSetTableAdapters;

namespace EAssistant
{
	public partial class ClientInfo : Form
	{	
		const String cancelText = "Cancel";
		const String enterText = "Enter";
		
		private Int64 m_clienId = 0;
		
		private Session session = Session.Instance;
	
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
			
			clientDataSet.clientsRow cr = session.dSet.clients.FindByid(m_clienId);
			if(null == cr)
			{
				// No such client
				return;
			}
			
			textCode.Text = cr.id.ToString();
			textName.Text = cr.name;
			textPhone.Text = cr.phone;
			dateSchedTime.Text = cr.scheduleTime.ToShortTimeString();

			foreach (Trainer it in comboTrainer.Items)
			{
				if (it.Id == cr.trainer)
				{
					comboTrainer.SelectedItem = it;
					break;
				}
			}
			SetScheduleDays(cr.scheduleDays);
			textComment.Text = cr.comment;
			
			UpdateLastPaymentInfo(cr);
			UpdateTimesLeft(cr);
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

		private void UpdateLastPaymentInfo(clientDataSet.clientsRow cr)
		{
			// TODO get from DB
			/*
			String[] paymentInfo = cr.lastPayment;
			textLastPaySum.Text = paymentInfo[0];
			textLastPayDate.Text = paymentInfo[1];
			*/
		}

		private void UpdateTimesLeft(clientDataSet.clientsRow cr)
		{
			if (UserRole.IsSet(session.UserRole.Clients, UserRights.Write))
			{
				btnEnter.Enabled = true;
				btnChangeCode.Enabled = true;
			}

			textTimesLeft.Text = cr.timesLeft.ToString();

			bool enabled = (cr.timesLeft > 0);
			btnEnter.Enabled = enabled && btnEnter.Enabled;
			btnLeave.Enabled = enabled && btnLeave.Enabled;

			textLastEnter.Text = cr.lastEnter.ToString();
			textLastLeave.Text = cr.lastLeave.ToString();
			
			if(cr.openTicket.Date == DateTime.Now.Date)
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
			if (UserRole.IsSet(session.UserRole.Payments, UserRights.Read))
			{
				btnPaymentHistory.Enabled = true;
			}
			
			if (UserRole.IsSet(session.UserRole.Payments, UserRights.Create))
			{
				btnPaymentAdd.Enabled = true;
			}

			if (UserRole.IsSet(session.UserRole.Clients, UserRights.Create))
			{
				btnOk.Enabled = true;
			}
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
				Int64 id = Session.CheckBarCode(dlg.Value);
				if (0 == id)
				{
					dlg.Clear();
					continue;
				}
				
				if(Client.CodeExists(id))
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
					clientDataSet.clientsRow cr = session.dSet.clients.NewclientsRow();
					cr.id = id;
					cr.name = textName.Text;
					cr.phone = textPhone.Text;
					cr.scheduleDays = GetScheduleDays();
					cr.scheduleTime = DateTime.Parse(dateSchedTime.Text);
					cr.trainer = Trainer.Id;
					cr.comment = textComment.Text;
					cr.lastEnter = cr.lastLeave = cr.openTicket = DateTime.Now.AddYears(-1);
					cr.timesLeft = 0;
					cr.extraInfo = "";
					m_clienId = id;

					session.dSet.clients.Rows.Add(cr);
					session.Adapters.clientsTableAdapter.Update(session.dSet.clients);
					ConfigUIForNewClient();					
				}
				else
				{
					clientDataSet.clientsRow cr = session.dSet.clients.FindByid(m_clienId);
					if(null == cr)
						return;
						
					cr.id = id;
					cr.phone = textPhone.Text;
					cr.scheduleDays = GetScheduleDays();
					cr.scheduleTime = dateSchedTime.Value;
					cr.trainer = Trainer.Id;
					cr.comment = textComment.Text;
					cr.AcceptChanges();

					m_clienId = id;

					session.Adapters.clientsTableAdapter.Update(session.dSet.clients);

					Session.SyncDB();
					
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				
				Session.Instance.UpdateTickets();
			}
		}

		private void btnPayment_Click(object sender, EventArgs e)
		{
			if (0 == m_clienId)
				return;
			
			AddPayment addPaymDlg = new AddPayment(m_clienId);
			if(DialogResult.Cancel == addPaymDlg.ShowDialog())
				return;

			clientDataSet.clientsRow cr = session.dSet.clients.FindByid(m_clienId);
			
			UpdateLastPaymentInfo(cr);
			UpdateTimesLeft(cr);
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

			clientDataSet.clientsRow cr = session.dSet.clients.FindByid(m_clienId);
			UpdateTimesLeft(cr);

			Session.Instance.UpdateTickets();
		}

		private void btnPaymentHistory_Click(object sender, EventArgs e)
		{
			if(0 == m_clienId)
				return;
				
			PaymentsHistory hist = new PaymentsHistory(m_clienId);
			hist.ShowDialog();
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					btnEnter.Checked = !btnEnter.Checked;
					btnEnter_CheckedChanged(sender, new EventArgs());
					break;
					
				case Keys.F6:
					btnLeave_Click(sender, new EventArgs());
					break;
				
				case Keys.F2:
					btnPayment_Click(sender, new EventArgs());
					break;
				
				case Keys.F3:
					btnPaymentHistory_Click(sender, new EventArgs());
					break;
			}
		}
	}
}
