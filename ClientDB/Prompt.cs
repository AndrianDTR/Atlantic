﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAssistant
{
	public partial class Prompt : Form
	{
		private const int m_minBarcodeLen = 13;
		
		private bool m_bAutoclose = true;
		private Int64 m_value = 0;
		
		public Prompt()
		{
			InitializeComponent();
			
			textBox.Focus();
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
			get{ return m_bAutoclose; }
			set { m_bAutoclose = value; }
		}

		public Button OK
		{
			get { return btnOk; }
		}
		
		public void Clear()
		{
			textBox.Text = String.Empty;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if(m_bAutoclose)
			{	
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
