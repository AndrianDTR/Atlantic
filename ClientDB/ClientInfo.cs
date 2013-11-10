using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AY.db;
using AY.Log;
using AY.Utils;
using AY.db.dbDataSetTableAdapters;

namespace EAssistant
{
	public partial class ClientInfo : Form
	{	
		const String cancelText = "Cancel";
		const String enterText = "Enter";

		private Int32 m_client = 0;
		
		private Session session = Session.Instance;

		public ClientInfo(Int32 client)
		{
			InitializeComponent();
			Init();
			CheckPermissions();
			
			m_client = client;
			
			if (!ConfigUIForNewClient())
			{
				return;
			}
			
			dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(m_client);
			if(null == cr)
				return;
				
			textCode.Text = BarcodePrinter.GetCode(cr.id);
			textName.Text = cr.name;
			textPhone.Text = cr.phone;
			dateSchedTime.Text = cr.scheduleTime.ToShortTimeString();

			foreach (dbDataSet.trainersRow it in comboTrainer.Items)
			{
				if (it.id == cr.trainer)
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
		
		private bool ConfigUIForNewClient()
		{
			bool existingClient = !(m_client == 0);
			textName.ReadOnly = existingClient;
			btnPaymentAdd.Enabled = existingClient;
			btnPaymentHistory.Enabled = existingClient;
			btnEnter.Enabled = existingClient;
			btnChangeCode.Enabled = existingClient;

			return existingClient;
		}
				
		private void Init()
		{
			comboTrainer.Items.Clear();
			comboTrainer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			comboTrainer.AutoCompleteSource = AutoCompleteSource.CustomSource;

			foreach (dbDataSet.trainersRow tr in Db.Instance.dSet.trainers)
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

		private void UpdateLastPaymentInfo(dbDataSet.clientsRow cr)
		{
			String[] paymentInfo = cr.LastPayment;
			textLastPaySum.Text = paymentInfo[0];
			textLastPayDate.Text = paymentInfo[1];
		}

		private void UpdateTimesLeft(dbDataSet.clientsRow cr)
		{
			dbDataSet.userPrivilegesRow ur = Db.Instance.dSet.userPrivileges.FindByid(session.UserRoleId);
			if (dbDataSet.userPrivilegesRow.IsSet(ur.clients, UserRights.Write))
			{
				btnEnter.Enabled = true;
				btnChangeCode.Enabled = true;
			}

			textTimesLeft.Text = cr.hoursLeft.ToString();

			bool enabled = (cr.hoursLeft > 0);
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
		
		private void CheckPermissions()
		{
			dbDataSet.userPrivilegesRow priv = (Db.Instance.dSet.userPrivileges.FindByid(session.UserRoleId));
			
			if (dbDataSet.userPrivilegesRow.IsSet(priv.payments, UserRights.Read))
			{
				btnPaymentHistory.Enabled = true;
			}

			if (dbDataSet.userPrivilegesRow.IsSet(priv.payments, UserRights.Create))
			{
				btnPaymentAdd.Enabled = true;
			}

			if (dbDataSet.userPrivilegesRow.IsSet(priv.clients, UserRights.Create))
			{
				btnOk.Enabled = true;
			}
		}
		
		public Int64 Id
		{
			get { return m_client; }
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

		public dbDataSet.trainersRow Trainer
		{
			get { return (dbDataSet.trainersRow)comboTrainer.SelectedItem; }
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

				if (dbDataSet.clientsRow.Exists(id))
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
			if(m_client == 0)
			{
				if(!ChangeClientCode())
					return;
			}
			
			if(ValidateForm())
			{
				Int32 id = Session.CheckBarCode(textCode.Text);
				
				if(m_client == 0)
				{
					dbDataSet.clientsRow cr = Db.Instance.dSet.clients.NewclientsRow();
					cr.id = id;
					cr.name = textName.Text;
					cr.phone = textPhone.Text;
					cr.scheduleDays = GetScheduleDays();
					cr.scheduleTime = DateTime.Parse(dateSchedTime.Text);
					cr.trainer = Trainer.id;
					cr.comment = textComment.Text;
					cr.lastEnter = cr.lastLeave = cr.openTicket = DateTime.Now.AddYears(-1);
					cr.hoursLeft = 0;
					cr.plan = 0;
					m_client = cr.id;
					
					Db.Instance.dSet.clients.AddclientsRow(cr);
					Db.Instance.AcceptChanges();
					
					this.DialogResult = DialogResult.OK;
					this.Close();				
				}
				else
				{
					dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(m_client);
					if(null == cr)
						return;
						
					cr.id = id;
					cr.phone = textPhone.Text;
					cr.scheduleDays = GetScheduleDays();
					cr.scheduleTime = dateSchedTime.Value;
					cr.trainer = Trainer.id;
					cr.comment = textComment.Text;
					cr.AcceptChanges();

					Db.Instance.Adapters.clientsTableAdapter.Update(Db.Instance.dSet.clients);
					Db.Instance.AcceptChanges();
					
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				
				Session.Instance.UpdateTickets();
			}
		}

		private void btnPayment_Click(object sender, EventArgs e)
		{
			if (0 == m_client)
				return;
			
			AddPayment addPaymDlg = new AddPayment(m_client);
			if(DialogResult.Cancel == addPaymDlg.ShowDialog())
				return;

			dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(m_client);
			
			UpdateLastPaymentInfo(cr);
			UpdateTimesLeft(cr);
		}
		
		private void btnEnter_CheckedChanged(object sender, EventArgs e)
		{
			//if(0 == m_clienId)
			//    return;
			
			//Client clientInfo = new Client(m_clienId);
			
			//if(btnEnter.Checked)
			//{
			//    clientInfo.OpenTicket = DateTime.Now;
			//    btnLeave.Enabled = true;
			//    btnEnter.Text = cancelText;
			//}
			//else
			//{
			//    clientInfo.OpenTicket = clientInfo.OpenTicket.AddYears(-1);
			//    btnLeave.Enabled = false;
			//    btnEnter.Text = enterText;
			//}

			//Session.Instance.UpdateTickets();
		}

		private void btnLeave_Click(object sender, EventArgs e)
		{
			//Client clientInfo = new Client(m_clienId);
			//clientInfo.LastEnter = clientInfo.OpenTicket;
			//clientInfo.LastLeave = DateTime.Now;
			//clientInfo.ProcessEnter();
			
			//btnEnter.Checked = false;

			//clientDataSet.clientsRow cr = session.dSet.clients.FindByid(m_clienId);
			//UpdateTimesLeft(cr);

			//Session.Instance.UpdateTickets();
		}

		private void btnPaymentHistory_Click(object sender, EventArgs e)
		{
			if(0 == m_client)
				return;
				
			PaymentsHistory hist = new PaymentsHistory();
			hist.ClientId = m_client;
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
