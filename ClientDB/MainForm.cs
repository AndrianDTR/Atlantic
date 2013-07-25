using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
    public partial class MainForm : Form
    {
		private Login m_login = new Login();
		private ClientCollection m_collection = new ClientCollection();
		
        public MainForm()
        {
            InitializeComponent();
        }

		private void clientByBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Prompt dlg = new Prompt();
			dlg.Text = "Search client by code";
			while(DialogResult.OK == dlg.ShowDialog())
			{
				if(dlg.Value.Length == 0)
					continue;
				
				Client client = m_collection.SearchCode(dlg.Value);
				ClientInfo ci = new ClientInfo();
				ci.ClientCode = client.Code;
				ci.ClientName = client.Name;
				ci.ClientPhone = client.Phone;
				ci.Schedule = client.Schedule;
				ci.Trainer = client.Trainer;
				if (DialogResult.OK != ci.ShowDialog(this))
					return;
				
				client.SetData(ci.ClientName, ci.ClientPhone, ci.ClientCode, ci.Schedule.Id, ci.Trainer.Id);
				dlg.Clear();
				Logger.Debug("Client data changed for: " + ci.ClientName + " " + ci.ClientCode);
			};
			
		}

        private void OnLoad(object sender, EventArgs e)
        {
			Session session = Session.Instance;
			
			DialogResult res = m_login.ShowDialog();
			if (res != DialogResult.OK)
			{
				this.Close();
			}
			
			UserRole priv = session.UserRole;

			// File menu
			exportToolStripMenuItem.Enabled = UserRole.IsSet(priv.Backup, UserRights.Create);
			importToolStripMenuItem.Enabled = UserRole.IsSet(priv.Backup, UserRights.Write);

			// Search menu
			clientByBarcodeToolStripMenuItem.Enabled = UserRole.IsSet(priv.Clients, UserRights.Read);

			// View menu

			// Clients menu
			manageClientsToolStripMenuItem.Enabled = UserRole.IsSet(priv.Clients, UserRights.Read);
			manageClientsToolStripMenuItem.Enabled = UserRole.IsSet(priv.Clients, UserRights.Read);
			
			// Settings menu
			userRolesToolStripMenuItem.Enabled = UserRole.IsSet(priv.Users, UserRights.Read);
			usersAndPasswordsToolStripMenuItem.Enabled = UserRole.IsSet(priv.Users, UserRights.Read);
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
			ClientInfo ci = new ClientInfo(true);
			if (DialogResult.OK != ci.ShowDialog(this))
				return;

			Int64 id = 0;
			
			if (!m_collection.Add(ci.ClientName, ci.ClientPhone, ci.ClientCode, ci.Schedule.Id, ci.Trainer.Id, out id))
			{
				UIMessages.Error("Client could not been added.");
				return;
			}
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
    }
}
