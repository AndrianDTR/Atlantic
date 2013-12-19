using System;
using System.Windows.Forms;
using AY.Log;

namespace EAssistant
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			Logger.Enter();
			InitializeComponent();
			Logger.Leave();
		}

		private void TestForm_Load(object sender, EventArgs e)
		{
			Logger.Enter();
			Logger.Leave();
		}
	}
}
