using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GAssistant
{
    public partial class MainForm : Form
    {
		private Login m_login = new Login();
		private ClientCollection m_collection = new ClientCollection();
		private Opts m_opt = new Opts();
		
        public MainForm()
        {
			InitializeComponent();
			UserLogin();
			Reinit();
        }
		
		private void UserLogin()
		{
			DialogResult res = m_login.ShowDialog();

			if (res != DialogResult.OK)
			{
				Environment.Exit(1);
			}
		}
		
		private static Calendar.CellInfo GetCellInfo0(DateTime dt)
		{
			Calendar.CellInfo ci = new Calendar.CellInfo(dt);
			
			return ci;
		}
		
		private void Reinit()
		{
			Session session = Session.Instance;

			//m_calendar.RowHeight = m_opt.CalRowHeight;
			//m_calendar.CellInfoDeledate = GetCellInfo0;
			session.PassLen = m_opt.MinPassLen;
			
			UserRole priv = session.UserRole;
			
			// File menu
			exportToolStripMenuItem.Enabled = UserRole.IsSet(priv.Backup, UserRights.Create);
			importToolStripMenuItem.Enabled = UserRole.IsSet(priv.Backup, UserRights.Write);
			btnBackUp.Enabled = UserRole.IsSet(priv.Backup, UserRights.Write);

			// Search menu
			clientByBarcodeToolStripMenuItem.Enabled = UserRole.IsSet(priv.Clients, UserRights.Read);

			// View menu
			paymentsToolStripMenuItem.Enabled = UserRole.IsSet(priv.Payments, UserRights.Read);
			btnPaymentsHistory.Enabled = UserRole.IsSet(priv.Payments, UserRights.Read);

			// Clients menu
			addToolStripMenuItem.Enabled = UserRole.IsSet(priv.Clients, UserRights.Create);
			btnAddClient.Enabled = UserRole.IsSet(priv.Clients, UserRights.Read);
			manageClientsToolStripMenuItem.Enabled = UserRole.IsSet(priv.Clients, UserRights.Read);
			btnClientManager.Enabled = UserRole.IsSet(priv.Clients, UserRights.Read);

			// Settings menu
			userRolesToolStripMenuItem.Enabled = UserRole.IsSet(priv.Users, UserRights.Read);
			usersAndPasswordsToolStripMenuItem.Enabled = UserRole.IsSet(priv.Users, UserRights.Read);

			btnTrainersShedule.Enabled = UserRole.IsSet(priv.Trainers, UserRights.Read);
			manageTrainersToolStripMenuItem.Enabled = UserRole.IsSet(priv.Trainers, UserRights.Read);

			manageScheduleRulesToolStripMenuItem.Enabled = UserRole.IsSet(priv.Schedule, UserRights.Read);

			//m_calendar.StartDate = DateTime.Now;
			//m_calendar.SelectedDate = m_calendar.StartDate;
			
			if (m_opt.StoreMainWindowState)
			{
				this.WindowState = m_opt.MainWindowState;
			}
		}

		private void OnClose(object sender, FormClosedEventArgs e)
		{
			m_opt.MainWindowState = this.WindowState;
			m_opt.StoreData();
		}
		
		private void clientByBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Prompt dlg = new Prompt();
			dlg.Text = "Search client by code";
			while(DialogResult.OK == dlg.ShowDialog())
			{
				Int64 id = 0;
				if(dlg.Value.Length == 0)
					continue;
				
				if(!Int64.TryParse(dlg.Value, out id))
				{
					UIMessages.Error("Invalid card number has been specified. Please use only digits and input no more 13 characters.");
					dlg.Clear();
					continue;
				}
				
				if (Client.CodeExists(id))
				{
					ClientInfo ci = new ClientInfo(id);
					if (DialogResult.OK == ci.ShowDialog(this))
					{
						m_collection = new ClientCollection();
						Logger.Debug("Client data changed for: " + ci.ClientName + " " + ci.ClientCode);
					}
				}
				else
				{
					UIMessages.Warning("Specified card is unregistered.");
				}
				
				dlg.Clear();
			};
			
		}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
		}

		private void OnSearch(object sender, EventArgs e)
		{

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
		
		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
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
			m_collection = new ClientCollection();
		}

		private void AddClient()
		{
			ClientInfo ci = new ClientInfo(0);
			if (DialogResult.OK != ci.ShowDialog(this))
				return;

			m_collection = new ClientCollection();
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
			m_collection = new ClientCollection();
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
				Reinit();
		}

		private void btnBackUp_Click(object sender, EventArgs e)
		{
			String szBackUpFile;
			new DbAdapter().ExportData(out szBackUpFile);
		}
    }
}
