using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
    public partial class MainForm : Form
    {
		private DbAdapter m_db = null;
		private Login m_login = new Login();
		
        public MainForm()
        {
			m_db = DbAdapter.Instance;
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
			DialogResult res = m_login.ShowDialog();
			if (res != DialogResult.OK)
			{
				this.Close();
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
			cp.UserId = m_login.m_userId;
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
    }
}
