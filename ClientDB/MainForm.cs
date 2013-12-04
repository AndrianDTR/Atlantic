using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using AY.Log;
using AY.db;
using AY.Utils;
using System.Data;
using System.Data.SQLite;
using AY.AutoUpdate;
using AY.db.dbDataSetTableAdapters;

namespace EAssistant
{
    public partial class MainForm : Form
    {
		private DataGridViewTextBoxColumn colOTId;
		private DataGridViewTextBoxColumn colOTName;
		private DataGridViewTextBoxColumn colOTStatus;
		private DataGridViewTextBoxColumn colOTSchedTime;
		private DataGridViewTextBoxColumn colOTOpenTicket;
		private DataGridViewTextBoxColumn colOTLastLeave;
		private DataGridViewTextBoxColumn colOTHoursLeft;
		private DataGridViewTextBoxColumn colOTHoursDec;
		
		public enum ClientTicketStus
		{
			None = -1,
			Closed = 0,
			Present,
			Overtime,
			Delayed,
			Missed,
		}
		
		private Login m_login = new Login();
		
        public MainForm()
        {
			InitializeComponent();
#if !DEBUG
			//AutoUpdater.Start("http://pro100soft.eu/EAssistant/updates/latest.xml");
			AutoUpdater.Start("http://localhost/update.xml");
#endif
			try
			{
				CheckRegistration();
			}
			catch(Exception ex)
			{
				UIMessages.Error(ex.Message);
				throw ex;
			}

			UserLogin();
			InitOnce();
			Reinit();
        }

		private void MainForm_Load(object sender, EventArgs e)
		{
			GetOpenedTickets();
		}
		
		private void InitOnce()
		{
			DataGridViewCellStyle csTime = new DataGridViewCellStyle();
			csTime.Format = "t";
			
			colOTId = new DataGridViewTextBoxColumn();
			colOTName = new DataGridViewTextBoxColumn();
			colOTStatus = new DataGridViewTextBoxColumn();
			colOTSchedTime = new DataGridViewTextBoxColumn();
			colOTOpenTicket = new DataGridViewTextBoxColumn();
			colOTLastLeave = new DataGridViewTextBoxColumn();
			colOTHoursLeft = new DataGridViewTextBoxColumn();
			colOTHoursDec = new DataGridViewTextBoxColumn();
			
			// 
			// colOTId
			// 
			colOTId.DataPropertyName = "id";
			colOTId.Name = "colOTId";
			colOTId.ReadOnly = true;
			colOTId.Visible = false;
			// 
			// colOTName
			// 
			colOTName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			colOTName.DataPropertyName = "name";
			colOTName.Name = "colOTName";
			colOTName.HeaderText = "Client Name";
			colOTName.ReadOnly = true;
			// 
			// colOTStatus
			// 
			colOTStatus.DataPropertyName = "status";
			colOTStatus.Name = "colOTStatus";
			colOTStatus.HeaderText = "Status";
			colOTStatus.ReadOnly = true;
			// 
			// colOTSchedTime
			// 
			colOTSchedTime.DataPropertyName = "scheduleTime";
			colOTSchedTime.Name = "colOTSchedTime";
			colOTSchedTime.HeaderText = "Time";
			colOTSchedTime.ReadOnly = true;
			colOTSchedTime.DefaultCellStyle = csTime;
			// 
			// colOTOpenTicket
			// 
			colOTOpenTicket.DataPropertyName = "openTicket";
			colOTOpenTicket.Name = "colOTOpenTicket";
			colOTOpenTicket.HeaderText = "Enter";
			colOTOpenTicket.ReadOnly = true;
			colOTOpenTicket.DefaultCellStyle = csTime;
			// 
			// colOTLastLeave
			// 
			colOTLastLeave.DataPropertyName = "lastLeave";
			colOTLastLeave.Name = "colOTLastLeave";
			colOTLastLeave.HeaderText = "Leave";
			colOTLastLeave.ReadOnly = true;
			colOTLastLeave.DefaultCellStyle = csTime;
			// 
			// colOTHoursLeft
			// 
			colOTHoursLeft.DataPropertyName = "hoursLeft";
			colOTHoursLeft.Name = "colOTHoursLeft";
			colOTHoursLeft.HeaderText = "Available Hours";
			colOTHoursLeft.Width = 110;
			colOTHoursLeft.ReadOnly = true;

			// 
			// colOTHoursDec
			// 
			colOTHoursDec.DataPropertyName = "hoursDec";
			colOTHoursDec.Name = "colOTHoursDec";
			colOTHoursDec.HeaderText = "Lesson";
			colOTHoursDec.Visible = false;

			dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
				colOTId,
				colOTName,
				colOTStatus,
				colOTSchedTime,
				colOTOpenTicket,
				colOTLastLeave,
				colOTHoursLeft,
				colOTHoursDec});
		}
		
		private void CheckRegistration()
		{
			byte[] buf = RegUtils.RegData;
			if (null == buf)
			{
				buf = new byte[ExeUtils.BufSize];
				byte[] srcDate = BitConverter.GetBytes((Int64)DateTime.Now.Ticks);
				byte[] serial = Encoding.ASCII.GetBytes(RegUtils.GetSerialNumber());
				byte[] pub = new byte[(int)RegUtils.DataOffsets.PubKey];
				byte[] prv = new byte[(int)RegUtils.DataOffsets.PrivKey];
				SecUtils.RSA(ref pub
					, ref prv
					, new System.Security.Cryptography.RSACryptoServiceProvider(512));

				int pos = 0;
				Array.Copy(srcDate, 0, buf, pos, srcDate.Length);

				pos += (int)RegUtils.DataOffsets.Data;
				Array.Copy(serial, 0, buf, pos, serial.Length);

				pos += (int)RegUtils.DataOffsets.Serial;
				Array.Copy(pub, 0, buf, pos, pub.Length);

				pos += (int)RegUtils.DataOffsets.PubKey;
				Array.Copy(prv, 0, buf, pos, prv.Length);

				RegUtils.RegData = buf;
			}

			if (!RegUtils.CheckRegInfo(buf))
			{
				RegisterForm rdlg = new RegisterForm(RegUtils.GetSerialNumberCrypted());
				Int64 ticks = BitConverter.ToInt64(buf, 0);
				DateTime regDate = new DateTime(ticks);
				TimeSpan daysLeft = regDate.AddDays(30).Subtract(DateTime.Now);
				if (daysLeft.Days > 0)
				{
					DialogResult res = UIMessages.Warning(
						String.Format(
							  "You using unregistered copy of the application.\n"
							+ "Evaluation period will expire after {0} days.\n"
							+ "Please contact support and register it.\n\n"
							+ "If you want register your copy of the application now press \"Yes\"."
							, daysLeft.Days)
						, MessageBoxButtons.YesNo);
					if (DialogResult.Yes == res)
					{
						rdlg.ShowDialog();
					}
				}
				else
				{
					DialogResult res = UIMessages.Error(
						  "Evaluation period has been expired!\n"
						+ "Do you wish register your copy of application?"
						, MessageBoxButtons.YesNo
						);
					if (DialogResult.Yes != res)
					{
						Environment.Exit(1);
					}
					
					if(DialogResult.OK != rdlg.ShowDialog())
					{
						Environment.Exit(1);
					}
				}
			}
		}
		
		private void UserLogin()
		{
			DialogResult res = m_login.ShowDialog();

			if (res != DialogResult.OK)
			{
				Environment.Exit(1);
			}
		}
		
		private void ConfigureUserRights()
		{
			dbDataSet.userPrivilegesRow priv = Db.Instance.dSet.userPrivileges.FindByid(Session.Instance.UserRoleId);

			// File menu
			exportToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.backup, UserRights.Create);
			importToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.backup, UserRights.Write);
			btnBackUp.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.backup, UserRights.Write);

			// View menu
			paymentsToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.payments, UserRights.Read);
			btnPaymentsHistory.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.payments, UserRights.Read);

			// Clients menu
			addToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.clients, UserRights.Create);
			btnAddClient.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.clients, UserRights.Read);

			clientSearchToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.clients, UserRights.Read);
			manageClientsToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.clients, UserRights.Read);
			btnClientManager.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.clients, UserRights.Read);

			// Settings menu
			userRolesToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.users, UserRights.Read);
			usersAndPasswordsToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.users, UserRights.Read);

			btnTrainersShedule.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.trainers, UserRights.Read);
			manageTrainersToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.trainers, UserRights.Read);

			manageScheduleRulesToolStripMenuItem.Enabled = dbDataSet.userPrivilegesRow.IsSet(priv.schedule, UserRights.Read);
		}
		
		private void Reinit()
		{
			dbDataSet.settingsRow opt = Db.Instance.dSet.settings.FindByid(1);
			Session session = Session.Instance;
			
			m_calendar.RowHeight = (int)opt.calRowHeight;
			m_calendar.Reinit();
			session.PassLen = (int)opt.minPassLen;

			ConfigureUserRights();
			
			m_calendar.StartDate = DateTime.Now;
			m_calendar.SelectedDate = m_calendar.StartDate;
			
			if (opt.StoreMainWindowState)
			{
				this.WindowState = opt.MainWindowState;
			}
			session.PassLen = (int)opt.minPassLen;
			
			GetOpenedTickets();
			
			session.TicketUpdate = new Session.UpdateTicketList(UpdateInfo);
		}

		private void OnClose(object sender, FormClosedEventArgs e)
		{
			dbDataSet.settingsRow opt = Db.Instance.dSet.settings.FindByid(1);
			opt.MainWindowState = this.WindowState;
			Db.Instance.Adapters.settingsTableAdapter.Update(opt);
		}
		
		private void GetOpenedTickets()
		{
			todayClientsBindingSource.DataSource = Db.Instance.dSet.VTodayClients;
			dbDataSet.settingsRow opt = Db.Instance.dSet.settings.FindByid(1);
			Db.Instance.Adapters.VTodayClientsTableAdapter.Fill(Db.Instance.dSet.VTodayClients);
			
			DateTime today = DateTime.Now;
			DateTime td = today.Date;
			TimeSpan ct = today.TimeOfDay;
			
			foreach( DataGridViewRow row in dataGridView1.Rows)
			{
				DateTime ll = (DateTime)row.Cells["colOTLastLeave"].Value;
				DateTime ot = (DateTime)row.Cells["colOTOpenTicket"].Value;
				DateTime st = (DateTime)row.Cells["colOTSchedTime"].Value;
				Int64 hd = (Int64)row.Cells["colOTHoursDec"].Value;
				
				// Closed tickets
				if(ll.Date == td && ot < ll)
				{
					row.Cells["colOTStatus"].Value = ClientTicketStus.Closed;
				}
				// Overtime
				else if (ot.Date == td && ot.TimeOfDay.TotalMinutes + hd * 60 < ct.TotalMinutes)
				{
					row.DefaultCellStyle.BackColor = opt.ColorOvertime;
					row.Cells["colOTLastLeave"].Value = "";
					row.Cells["colOTStatus"].Value = ClientTicketStus.Overtime;
				}
				// Currently present
				else if (ot.Date == td && ot.TimeOfDay.Hours >= ct.Hours - hd)
				{
					row.DefaultCellStyle.BackColor = opt.ColorPresent;
					row.Cells["colOTLastLeave"].Value = "";
					row.Cells["colOTStatus"].Value = ClientTicketStus.Present;
				}
				// Late
				else if (st.TimeOfDay < ct && st.TimeOfDay.TotalMinutes + hd * 60 > ct.TotalMinutes)
				{
					row.DefaultCellStyle.BackColor = opt.ColorDelayed;
					row.Cells["colOTLastLeave"].Value = "";
					row.Cells["colOTOpenTicket"].Value = "";
					row.Cells["colOTStatus"].Value = ClientTicketStus.Delayed;
				}
				// Miss
				else if (ot.Date != td && st.TimeOfDay < ct && st.TimeOfDay.TotalMinutes + hd * 60 < ct.TotalMinutes)
				{
					row.DefaultCellStyle.BackColor = opt.ColorMissed;
					row.Cells["colOTLastLeave"].Value = "";
					row.Cells["colOTOpenTicket"].Value = "";
					row.Cells["colOTStatus"].Value = ClientTicketStus.Missed;
				}
				else
				{
					row.Cells["colOTLastLeave"].Value = "";
					row.Cells["colOTOpenTicket"].Value = "";
				}
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchClient();
		}
		
		private void clientSearchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SearchClient();
		}
		
		private void SearchClient()
		{
			Prompt dlg = new Prompt();
			dlg.Text = "Search client by code";
			while (DialogResult.OK == dlg.ShowDialog())
			{
				Int32 id = Session.CheckBarCode(dlg.Value);
				if (0 == id)
				{
					dlg.Clear();
					continue;
				}
				
				dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(id);
				if (null != cr)
				{
					ClientInfo ci = new ClientInfo(cr.id);
					if (DialogResult.OK == ci.ShowDialog(this))
					{
						Logger.Debug("Client data changed for: " + ci.ClientName + " " + ci.ClientCode);
					}
				}
				else
				{
					UIMessages.Warning("Specified card is unregistered.");
				}

				dlg.Clear();
			}
		}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
		}

		private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangePassword cp = new ChangePassword();
			cp.ShowDialog(this);
		}

		private void usersAndPasswordsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ManageUsers users = new ManageUsers();
			users.ShowDialog(this);
		}
		
		private void userRolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ManageUserRoles pm = new ManageUserRoles();
			pm.ShowDialog(this);
		}

		private void manageTrainersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ManageTrainers mt = new ManageTrainers();
			mt.ShowDialog(this);
		}

		private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ManageClients mc = new ManageClients();
			mc.ShowDialog(this);
		}

		private void AddClient()
		{
			ClientInfo ci = new ClientInfo(0);
			if (DialogResult.OK != ci.ShowDialog(this))
				return;
		}
		
		private void add_Click(object sender, EventArgs e)
		{
			AddClient();
		}
		
		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddClient();
		}

		private void manageScheduleRulesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ManageScheduleRules sc = new ManageScheduleRules();
			sc.ShowDialog(this);
		}

		private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PaymentsHistory his = new PaymentsHistory();
			his.ShowDialog();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About ab = new About();
			ab.ShowDialog();
		}

		private void geterateBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BarcodePrinter bp = new BarcodePrinter();
			bp.ShowDialog();
		}

		private void refreshOpenedTicketsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateInfo();
		}

		private void btnClientManager_Click(object sender, EventArgs e)
		{
			ManageClients mc = new ManageClients();
			mc.ShowDialog(this);
		}

		private void btnPaymentsHistory_Click(object sender, EventArgs e)
		{
			PaymentsHistory his = new PaymentsHistory();
			his.ShowDialog();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Options opt = new Options();
			if(DialogResult.OK == opt.ShowDialog())
			{
				Reinit();
			}
		}

		private void btnBackUp_Click(object sender, EventArgs e)
		{
			BackUpDB();
		}
		
		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BackUpDB();
		}

		private void BackUpDB()
		{
			dbDataSet.settingsRow opt = Db.Instance.dSet.settings.FindByid(1);
			String prefix = DateTime.Now.ToString("yyyyMMdd");
			String ext = "dbu";
			String archName = String.Format("{0}\\{1}.{2}"
				, opt.pathBackUp
				, prefix
				, ext);
			if (!Directory.Exists(opt.pathBackUp))
			{
				Directory.CreateDirectory(opt.pathBackUp);
			}
			Db.Instance.ExportData(archName);
			UpdateInfo();
		}
		
		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UIMessages.DisabledFeature();
			return;
			
			dbDataSet.settingsRow opt = Db.Instance.dSet.settings.FindByid(1);
			if(DialogResult.Yes != UIMessages.Warning(
				"Data base will be reverted and all data stored after " +
				"BackUp will be lost. Do you really want to restore " +
				"database from BackUp file?", MessageBoxButtons.YesNo))
			{
				return;
			}
			
			OpenFileDialog opd = new OpenFileDialog();
			opd.InitialDirectory = opt.pathBackUp;
			opd.Filter = "Database BackUp files (*.dbu)|*.dbu";
			if(DialogResult.OK == opd.ShowDialog())
			{
				Db.Instance.ImportData(opd.FileName);
				if(!dbDataSet.usersRow.UserExist(Session.Instance.UserId))
				{
					UserLogin();
				}
				Reinit();
			}
		}

		private void UpdateInfo()
		{
			GetOpenedTickets();
			m_calendar.Reinit();
		}
		
		private void ShowClientInfo(object sender, DataGridViewCellEventArgs e)
		{
			Int32 clientId = (Int32)dataGridView1.Rows[e.RowIndex].Cells["colOTId"].Value;
			ClientInfo ci = new ClientInfo(clientId);
			ci.ShowDialog();
		}
		
		private void btmMissLesson_Click(object sender, EventArgs e)
		{
			DateTime td = DateTime.Now;
			DateTime cd = td.Date;
			TimeSpan ct = td.TimeOfDay;
			
			Db.Instance.Adapters.clientsTableAdapter.Fill(Db.Instance.dSet.clients);
			
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				DateTime ll = (DateTime)row.Cells["colOTLastLeave"].Value;
				DateTime ot = (DateTime)row.Cells["colOTOpenTicket"].Value;
				DateTime st = (DateTime)row.Cells["colOTSchedTime"].Value;
				Int64 hd = (Int64)row.Cells["colOTHoursDec"].Value;

				// Miss
				if (ll.Date != cd 
					&& ot.Date != td 
					&& st.TimeOfDay < ct 
					&& st.TimeOfDay.TotalMinutes + hd * 60 < ct.TotalMinutes)
				{
					int id = (int)row.Cells["colOTId"].Value;
					dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(id);
					if(null == cr)
					{
						continue;
					}
					cr.lastEnter = cd.Add(st.TimeOfDay);
					cr.lastLeave = cd.Add(st.TimeOfDay.Add(new TimeSpan((int)hd, 0, 0)));
					cr.ProcessEnter();
				}
			}
			
			dbDataSet.clientsDataTable cdt = 
				(dbDataSet.clientsDataTable)Db.Instance.dSet.clients.GetChanges(DataRowState.Modified);
			
			if(null == cdt)
				return;
			
			Db.Instance.Adapters.clientsTableAdapter.Update(cdt);
			Db.Instance.dSet.AcceptChanges();
			
			UpdateInfo();
		}

		private void btnTrainersShedule_Click(object sender, EventArgs e)
		{
			ManageTrainerScheduleDlg dlg = new ManageTrainerScheduleDlg();
			dlg.ShowDialog();
		}
		
		private Dictionary<DateTime, int> GetPrognosedData(DateTime date)
		{
			dbDataSet.settingsRow opt = Db.Instance.dSet.settings.FindByid(1);
			Dictionary<DateTime, int> res = new Dictionary<DateTime, int>();
			
			DateTime dt = opt.StartTime.AddHours(-1);
			while(dt < opt.EndTime.AddHours(1))
			{
				res[dt] = 3;
				
				dt = dt.AddMinutes(15);
			}
			
			return res;
		}

		private Dictionary<DateTime, int> GetPresentData(DateTime date)
		{
			dbDataSet.settingsRow opt = Db.Instance.dSet.settings.FindByid(1);
			Dictionary<DateTime, int> res = new Dictionary<DateTime, int>();

			Random rnd = new Random(Environment.TickCount);
			DateTime dt = opt.StartTime.AddHours(-1);
			while (dt < opt.EndTime.AddHours(1))
			{
				res[dt] = rnd.Next(5, 20);

				dt = dt.AddMinutes(15);
			}
			
			return res;
		}

		private void FillChart(object sender, ChartPaintEventArgs e)
		{
			dbDataSet.settingsRow opt = Db.Instance.dSet.settings.FindByid(1);
			DateTime date = m_calendar.SelectedDate;
			bool today = false;
			const int delta = 15;
					
			if(date.Date == DateTime.Now.Date)
				today = true;
						
			int nIters = opt.EndTime.Subtract(opt.StartTime).Minutes / delta;
			WaitDialog wd = new WaitDialog(0, today ? nIters * 2 : nIters, 1);
			wd.Show();
			wd.Refresh();			
			
			//chart1.SuspendLayout();

			chart1.ChartAreas[0].AxisX.Interval = 60;
			chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
			chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
			
			chart1.Series["seriesPresent"].Points.Clear();
			chart1.Series["seriesPrognosed"].Points.Clear();
			
			Dictionary<DateTime, int> present = GetPresentData(date);
			Dictionary<DateTime, int> prognosed = GetPrognosedData(date);

			if(date.Date == DateTime.Now.Date)
			{
				foreach (KeyValuePair<DateTime, int> kv in present)
				{
					wd.StepIt();
					chart1.Series["seriesPresent"].Points.AddXY(kv.Key, kv.Value);
				}
			}
			
			foreach (KeyValuePair<DateTime, int> kv in prognosed)
			{
				wd.StepIt();
				chart1.Series["seriesPrognosed"].Points.AddXY(kv.Key, kv.Value);
			}

			//chart1.ResumeLayout();
			chart1.Invalidate(true);
			wd.Close();
		}
    }
}
