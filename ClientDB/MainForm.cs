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

namespace EAssistant
{
    public partial class MainForm : Form
    {
		public enum ClientTicketStus
		{
			None = -1,
			Present = 0,
			Overtime,
			Delayed,
			Missed,
		}
		
		class ClientStatus
		{
			public Int64 Id = 0;
			public ClientTicketStus state = ClientTicketStus.None;
			
			public ClientStatus(Int64 id, ClientTicketStus state)
			{
				this.Id = id;
				this.state = state;
			}
		}
		
		private Login m_login = new Login();
		private dbDataSet.settingsRow m_opt = null;
		
        public MainForm()
        {
			InitializeComponent();
#if !DEBUG
			//AutoUpdater.Start("http://pro100soft.eu/EAssistant/updates/latest.xml");
			AutoUpdater.Start("http://localhost/update.xml");
			CheckRegistration();
#endif
			m_opt = Db.Instance.dSet.settings.FindByid(1);
			
			UserLogin();
			Reinit();
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
		
		private void Reinit()
		{
			Session session = Session.Instance;
			
			m_calendar.RowHeight = (int)m_opt.calRowHeight;
			m_calendar.Reinit();
			session.PassLen = (int)m_opt.minPassLen;

			dbDataSet.userPrivilegesRow priv = Db.Instance.dSet.userPrivileges.FindByid(session.UserRoleId);
			
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

			m_calendar.StartDate = DateTime.Now;
			m_calendar.SelectedDate = m_calendar.StartDate;
			
			if (m_opt.StoreMainWindowState)
			{
				this.WindowState = m_opt.MainWindowState;
			}
			session.PassLen = (int)m_opt.minPassLen;
			
			GetOpenedTickets();
			
			session.TicketUpdate = new Session.UpdateTicketList(UpdateInfo);
		}

		private void OnClose(object sender, FormClosedEventArgs e)
		{
			m_opt.MainWindowState = this.WindowState;
			Db.Instance.Adapters.settingsTableAdapter.Update(m_opt);
		}
		
		private void GetOpenedTickets()
		{
			DateTime today = DateTime.Now;
#if !DEBUG
/*
select trainersSchedule.id as ID, trainersSchedule.trainerId, DT.dt from trainersSchedule left outer join 
(select date('2013-11-13') as dt) as DT on DT.[dt]=trainersSchedule.id
--(select count(R) as cc, dID from (select SUBSTR(scheduleDays, strftime('%w', date(ID)), 1) As R, date(ID) as dID from clients where R='X')) as CC on dID = ID where ID = date('2013-11-14')  
*/
			listClients.Items.Clear();
			ClientCollection clients = new ClientCollection();
			clients.Refresh("date(openTicket) = date('now', 'localtime')");
			foreach (DataRow dr in clients.Items)
			{
				Client client = new Client(dr);
				// Skip already closed tickets
				if(client.LastLeave.Date == today.Date)
					continue;
				
				ListViewItem lvi = listClients.Items.Add(client.Name);

				lvi.BackColor = m_opt.ColorPresent;
				ClientTicketStus status = ClientTicketStus.Present;
				
				DateTime clientTime = client.OpenTicket.AddHours(client.DecHours);
				if (today > clientTime)
				{
					status = ClientTicketStus.Overtime;
					lvi.BackColor = m_opt.ColorOvertime;
				}

				lvi.SubItems.Add(status.ToString());
				lvi.SubItems.Add(client.OpenTicket.ToString("HH:mm"));
				lvi.SubItems.Add("");
				lvi.SubItems.Add(client.TimesLeft.ToString());

				lvi.Tag = new ClientStatus(client.Id, status);
			}

			DayOfWeek ws = CultureInfoUtils.GetWeekStart();
			String where = String.Format("substr(scheduleDays, {0}, 1) = 'X' and strftime('%H:%M',scheduleTime) <= strftime('%H:%M','now','localtime')"
				, (int)today.DayOfWeek + (int)ws);

			clients.Refresh(where);
			foreach (DataRow dr in clients.Items)
			{
				Client client = new Client(dr);
				
				// Skip already closed tickets
				if (client.LastLeave.Date == today.Date)
					continue;
					
				TimeSpan clientTime = client.ScheduleTime.AddHours(client.DecHours).TimeOfDay;
				if (client.OpenTicket.Date != today.Date 
					&& client.TimesLeft > 0 
					&& today.TimeOfDay <= clientTime)
				{
					ListViewItem lvi = listClients.Items.Add(client.Name);
					ClientTicketStus status = ClientTicketStus.Delayed;

					lvi.BackColor = m_opt.ColorDelayed;
					lvi.SubItems.Add(status.ToString());
					lvi.SubItems.Add(client.ScheduleTime.ToString("HH:mm"));
					lvi.SubItems.Add(client.ScheduleTime.AddHours(client.DecHours).ToString("HH:mm"));
					lvi.SubItems.Add(client.TimesLeft.ToString());

					lvi.Tag = new ClientStatus(client.Id, status);
				}
			}

			where = String.Format("substr(scheduleDays, {0}, 1) = 'X' and strftime('%H:%M',scheduleTime) <= strftime('%H:%M','now','localtime')"
				, (int)today.DayOfWeek + (int)ws);
			
			clients.Refresh(where);
			foreach (DataRow dr in clients.Items)
			{
				Client client = new Client(dr);
				
				// Skip already closed tickets
				if (client.LastLeave.Date == today.Date)
					continue;
					
				TimeSpan clientTime = client.ScheduleTime.AddHours(client.DecHours).TimeOfDay;
				if (client.OpenTicket.Date != today.Date 
					&& client.TimesLeft > 0 
					&& today.TimeOfDay > clientTime)
				{
					ListViewItem lvi = listClients.Items.Add(client.Name);
					ClientTicketStus status = ClientTicketStus.Missed;
					
					lvi.BackColor = m_opt.ColorMissed;
					lvi.SubItems.Add(status.ToString());
					lvi.SubItems.Add(client.ScheduleTime.ToString("HH:mm"));
					lvi.SubItems.Add(client.ScheduleTime.AddHours(client.DecHours).ToString("HH:mm"));
					lvi.SubItems.Add(client.TimesLeft.ToString());

					lvi.Tag = new ClientStatus(client.Id, status);
				}
			}
#endif
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
						UpdateInfo();
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
			UpdateInfo();
		}

		private void AddClient()
		{
			ClientInfo ci = new ClientInfo(0);
			if (DialogResult.OK != ci.ShowDialog(this))
				return;
			UpdateInfo();
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

		private void btnClientManager_Click(object sender, EventArgs e)
		{
			ManageClients mc = new ManageClients();
			mc.ShowDialog(this);
			UpdateInfo();
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
			String prefix = DateTime.Now.ToString("yyyyMMdd");
			String ext = "dbu";
			String archName = String.Format("{0}\\{1}.{2}"
				, m_opt.pathBackUp
				, prefix
				, ext);
			if (!Directory.Exists(m_opt.pathBackUp))
			{
				Directory.CreateDirectory(m_opt.pathBackUp);
			}
			new DbAdapter().ExportData(archName);
		}
		
		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(DialogResult.Yes != UIMessages.Warning(
				"Data base will be reverted and all data stored after " +
				"BackUp will be lost. Do you really want to restore " +
				"database from BackUp file?", MessageBoxButtons.YesNo))
			{
				return;
			}
			
			OpenFileDialog opd = new OpenFileDialog();
			opd.InitialDirectory = m_opt.pathBackUp;
			opd.Filter = "Database BackUp files (*.dbu)|*.dbu";
			if(DialogResult.OK == opd.ShowDialog())
			{
				new DbAdapter().ImportData(opd.FileName);
				if(!dbDataSet.usersRow.UserExist(Session.Instance.UserId))
				{
					UserLogin();
				}
				Reinit();
			}
		}

		private void ShowClientInfo(object sender, EventArgs e)
		{
			if(listClients.SelectedItems.Count < 1)
				return;

			/*ClientStatus status = (ClientStatus)listClients.SelectedItems[0].Tag;
			ClientInfo ci = new ClientInfo(status.Id);
			ci.ShowDialog();
			*/
		}
		
		private void UpdateInfo()
		{
			GetOpenedTickets();
			m_calendar.Reinit();
		}

		private void btmMissLesson_Click(object sender, EventArgs e)
		{
			//DateTime now = DateTime.Now.Date;
			
			//foreach(ListViewItem lvi in listClients.Items)
			//{
			//    ClientStatus status = (ClientStatus)lvi.Tag;
			//    if(lvi.Selected && ClientTicketStus.Missed == status.state)
			//    {
			//        Client client = new Client(status.Id);
			//        DateTime st = client.scheduleTime;
			//        client.lastEnter = now.AddHours(st.Hour).AddMinutes(st.Minute);
			//        client.lastLeave = client.lastEnter.AddHours(client.DecHours);
			//        client.ProcessEnter();
			//    }
			//}
		}

		private void btnTrainersShedule_Click(object sender, EventArgs e)
		{
			ManageTrainerScheduleDlg dlg = new ManageTrainerScheduleDlg();
			if(DialogResult.OK == dlg.ShowDialog())
			{
				UpdateInfo();
			}
		}
		
		private Dictionary<DateTime, int> GetPrognosedData(DateTime date)
		{
			Dictionary<DateTime, int> res = new Dictionary<DateTime, int>();
			
			DateTime dt = m_opt.StartTime.AddHours(-1);
			while(dt < m_opt.EndTime.AddHours(1))
			{
				res[dt] = 3;
				
				dt = dt.AddMinutes(15);
			}
			
			return res;
		}

		private Dictionary<DateTime, int> GetPresentData(DateTime date)
		{
			Dictionary<DateTime, int> res = new Dictionary<DateTime, int>();

			Random rnd = new Random(Environment.TickCount);
			DateTime dt = m_opt.StartTime.AddHours(-1);
			while (dt < m_opt.EndTime.AddHours(1))
			{
				res[dt] = rnd.Next(5, 20);

				dt = dt.AddMinutes(15);
			}
			
			return res;
		}

		private void FillChart(object sender, ChartPaintEventArgs e)
		{
			DateTime date = m_calendar.SelectedDate;
			bool today = false;
			const int delta = 15;
					
			if(date.Date == DateTime.Now.Date)
				today = true;
						
			int nIters = m_opt.EndTime.Subtract(m_opt.StartTime).Minutes / delta;
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

		private void geterateBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BarcodePrinter bp = new BarcodePrinter();
			bp.ShowDialog();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'tmpDataSet.TodayClients' table. You can move, or remove it, as needed.
			this.todayClientsTableAdapter.Fill(this.tmpDataSet.TodayClients);

		}
    }
}
