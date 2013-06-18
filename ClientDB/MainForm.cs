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
		
		private void OnShown(object sender, EventArgs e)
		{
			m_Search.Focus();
		}

		private void clientByBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_Search.Focus();
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

			userRolesToolStripMenuItem.Enabled = priv.IsSet(priv.Users, UserRights.Read);
			usersAndPasswordsToolStripMenuItem.Enabled = priv.IsSet(priv.Users, UserRights.Read);
			
			exportToolStripMenuItem.Enabled = priv.IsSet(priv.Backup, UserRights.Create);
			importToolStripMenuItem.Enabled = priv.IsSet(priv.Backup, UserRights.Write);
			
			foreach (Client ci in m_collection)
			{
				ListViewItem it = clientList.Items.Add(ci.Name);
				it.SubItems.Add("");
				it.SubItems.Add(ci.Schedule.Name);
				it.SubItems.Add(ci.Trainer.Name);
				it.Tag = ci.Code;
			}				
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

		private void OnSearchKeyUp(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
			{
				SearchById(m_Search.Text);
				m_Search.Clear();
			}
		}
		
		private void SearchById(String id)
		{
			foreach (ListViewItem lvi in clientList.Items)
			{
				lvi.Selected = false;
				if (lvi.Text.ToUpper().Contains(id.ToUpper())
				|| ((String)lvi.Tag).ToUpper().Contains(id.ToUpper()))
				{
					lvi.Selected = true;
				}
			}
		}

		private void OnKeyPress(object sender, KeyPressEventArgs e)
		{
			if (!m_Search.Focused 
			&& (
				(e.KeyChar >= '0' && e.KeyChar <= '9')
				|| (e.KeyChar >= 'a' && e.KeyChar <= 'z')
				|| (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
			))
			{
				m_Search.Focus();
				m_Search.Text = e.KeyChar.ToString();
				m_Search.Select(1, 1);
			}
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
			ListViewItem it = clientList.Items.Add(ci.ClientName);
			it.SubItems.Add("");
			it.SubItems.Add(ci.Schedule.Name);
			it.SubItems.Add(ci.Trainer.Name);
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
