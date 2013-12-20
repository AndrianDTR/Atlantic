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
			Logger.Enter();
			do
			{
				InitializeComponent();
				Init();
				CheckPermissions();

				m_client = client;

				if (!ConfigUIForNewClient())
				{
					break;
				}

				dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(m_client);
				if (null == cr)
					break;

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
			} while (false);
			Logger.Leave();
		}

		private bool ConfigUIForNewClient()
		{
			Logger.Enter();
			bool existingClient = !(m_client == 0);
			textName.ReadOnly = existingClient;
			btnPaymentAdd.Enabled = existingClient;
			btnPaymentHistory.Enabled = existingClient;
			btnEnter.Enabled = existingClient;
			btnChangeCode.Enabled = existingClient;

			Logger.Leave();
			return existingClient;
		}

		private void Init()
		{
			Logger.Enter();
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
			Logger.Leave();
		}

		private void UpdateLastPaymentInfo(dbDataSet.clientsRow cr)
		{
			Logger.Enter();
			String[] paymentInfo = cr.LastPayment;
			textLastPaySum.Text = paymentInfo[0];
			textLastPayDate.Text = paymentInfo[1];
			Logger.Leave();
		}

		private void UpdateTimesLeft(dbDataSet.clientsRow cr)
		{
			Logger.Enter();
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

			if (cr.openTicket.Date == DateTime.Now.Date)
			{
				btnEnter.Checked = true;
				btnEnter.Text = cancelText;
			}
			Logger.Leave();
		}

		private void CheckPermissions()
		{
			Logger.Enter();
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
			Logger.Leave();
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
			get
			{
				Logger.Enter();
				dbDataSet.trainersRow row = (dbDataSet.trainersRow)comboTrainer.SelectedItem;
				Logger.Leave();
				return row;
			}
		}

		private bool ValidateForm()
		{
			Logger.Enter();
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
			} while (false);

			Logger.Leave();
			return res;
		}

		private Boolean ChangeClientCode()
		{
			Logger.Enter();
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
			Logger.Leave();
			return res;
		}

		private void btnChangeCode_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			ChangeClientCode();
			Logger.Leave();
		}

		private String GetScheduleDays()
		{
			Logger.Enter();
			String data = "";
			char[] entranceInfo = new char[7];

			entranceInfo[0] = checkDay1.Checked ? 'X' : '_';
			entranceInfo[1] = checkDay2.Checked ? 'X' : '_';
			entranceInfo[2] = checkDay3.Checked ? 'X' : '_';
			entranceInfo[3] = checkDay4.Checked ? 'X' : '_';
			entranceInfo[4] = checkDay5.Checked ? 'X' : '_';
			entranceInfo[5] = checkDay6.Checked ? 'X' : '_';
			entranceInfo[6] = checkDay7.Checked ? 'X' : '_';

			entranceInfo = CultureInfoUtils.RShift<char>(entranceInfo,
				(int)CultureInfoUtils.GetWeekStart());

			foreach (char x in entranceInfo)
			{
				data += x;
			}

			Logger.Leave();
			return data;
		}

		private void SetScheduleDays(String info)
		{
			Logger.Enter();
			do
			{
				char[] entranceInfo = CultureInfoUtils.Shift<char>(info.ToCharArray(),
							(int)CultureInfoUtils.GetWeekStart());

				if (entranceInfo.Length != 7)
					break;

				checkDay1.Checked = entranceInfo[0] == 'X';
				checkDay2.Checked = entranceInfo[1] == 'X';
				checkDay3.Checked = entranceInfo[2] == 'X';
				checkDay4.Checked = entranceInfo[3] == 'X';
				checkDay5.Checked = entranceInfo[4] == 'X';
				checkDay6.Checked = entranceInfo[5] == 'X';
				checkDay7.Checked = entranceInfo[6] == 'X';

			} while (false);
			Logger.Leave();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				if (m_client == 0)
				{
					if (!ChangeClientCode())
						break;
				}

				if (ValidateForm())
				{
					Int32 id = Session.CheckBarCode(textCode.Text);

					if (m_client == 0)
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
						if (null == cr)
							break;

						cr.id = id;
						cr.phone = textPhone.Text;
						cr.scheduleDays = GetScheduleDays();
						cr.scheduleTime = dateSchedTime.Value;
						cr.trainer = Trainer.id;
						cr.comment = textComment.Text;

						Db.Instance.Adapters.clientsTableAdapter.Update(Db.Instance.dSet.clients);
						Db.Instance.AcceptChanges();

						this.DialogResult = DialogResult.OK;
						this.Close();
					}
				}
			} while (false);
			Logger.Leave();
		}

		private void btnPayment_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				if (0 == m_client)
					break;

				AddPayment addPaymDlg = new AddPayment(m_client);
				if (DialogResult.Cancel == addPaymDlg.ShowDialog())
					break;

				dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(m_client);

				UpdateLastPaymentInfo(cr);
				UpdateTimesLeft(cr);
			} while (false);
			Logger.Leave();
		}

		private void btnEnter_CheckedChanged(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				if (0 == m_client)
					break;

				dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(m_client);

				if (btnEnter.Checked)
				{
					cr.openTicket = DateTime.Now;
					btnLeave.Enabled = true;
					btnEnter.Text = cancelText;
				}
				else
				{
					cr.openTicket = cr.openTicket.AddYears(-1);
					btnLeave.Enabled = false;
					btnEnter.Text = enterText;
				}
			} while (false);
			Logger.Leave();
		}

		private void btnLeave_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(m_client);
			cr.lastEnter = cr.openTicket;
			cr.lastLeave = DateTime.Now;
			cr.ProcessEnter();
			Db.Instance.AcceptChanges();

			btnEnter.Checked = false;

			UpdateTimesLeft(cr);
			Logger.Leave();
		}

		private void btnPaymentHistory_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				if (0 == m_client)
					break;

				PaymentsHistory hist = new PaymentsHistory();
				hist.ClientId = m_client;
				hist.ShowDialog();
			} while (false);
			Logger.Leave();
		}

		private void OnKeyUp(object sender, KeyEventArgs e)
		{
			Logger.Enter();
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
			Logger.Leave();
		}

		private void OnClose(object sender, FormClosedEventArgs e)
		{
			Logger.Enter();
			Session.Instance.UpdateMain();
			Logger.Leave();
		}
	}
}
