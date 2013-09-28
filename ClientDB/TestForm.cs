using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EAssistant
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			InitializeComponent();
		}

		private void TestForm_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'clientDataSet2.users' table. You can move, or remove it, as needed.
			this.usersTableAdapter.Fill(this.clientDataSet2.users);
			// TODO: This line of code loads data into the 'clientDataSet1.userPrivileges' table. You can move, or remove it, as needed.
			this.userPrivilegesTableAdapter1.Fill(this.clientDataSet1.userPrivileges);
			// TODO: This line of code loads data into the 'clientDataSet.userPrivileges' table. You can move, or remove it, as needed.
			this.userPrivilegesTableAdapter.Fill(this.clientDataSet.userPrivileges);

		}
	}
}
