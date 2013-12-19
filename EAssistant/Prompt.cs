using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AY.Log;

namespace EAssistant
{
	public partial class Prompt : Form
	{
		private const int m_minBarcodeLen = 13;

		private bool m_bAutoclose = true;

		public Prompt()
		{
			Logger.Enter();
			InitializeComponent();

			textBox.Focus();
			Logger.Leave();
		}

		public String Value
		{
			get
			{
				return textBox.Text;
			}
		}

		public bool AutoClose
		{
			get { return m_bAutoclose; }
			set
			{
				Logger.Enter();
				m_bAutoclose = value;
				Logger.Leave();
			}
		}

		public Button OK
		{
			get { return btnOk; }
		}

		public void Clear()
		{
			Logger.Enter();
			textBox.Text = String.Empty;
			Logger.Leave();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			if (m_bAutoclose)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			Logger.Leave();
		}
	}
}
