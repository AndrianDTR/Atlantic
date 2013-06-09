using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
    public partial class MainForm : Form
    {
		private Login m_login = new Login();
		
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

		private void add23_Click(object sender, EventArgs e)
		{
			Schedule sc = new Schedule();
			sc.ShowDialog(this);
			
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
			;
		}


		private void OnKeyPress(object sender, KeyPressEventArgs e)
		{
			if (!m_Search.Focused && e.KeyChar >= '0' && e.KeyChar <= '9')
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

		private void manageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ManageTrainers mt = new ManageTrainers();
			mt.ShowDialog(this);
		}

		
    }
}
