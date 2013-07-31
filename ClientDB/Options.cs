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
	public partial class Options : Form
	{
		private Opts m_opts = null;
		
		public Options()
		{
			InitializeComponent();
			m_opts = new Opts();

			numericMinPassLen.Value = m_opts.MinPassLen;
			numericCalRowHeight.Value = m_opts.CalRowHeight;
			checkShowTrainer.Checked = m_opts.ShowTrainer;
			checkShowClientCount.Checked = m_opts.ShowClientCount;
			
			comboLang.Items.Add("English");
			comboLang.SelectedIndex = 0;
			//comboLang.SelectedItem = m_opts.Language;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			m_opts.MinPassLen = (int)numericMinPassLen.Value;
			m_opts.CalRowHeight = (int)numericCalRowHeight.Value;
			m_opts.ShowTrainer = checkShowTrainer.Checked;
			m_opts.ShowClientCount = checkShowClientCount.Checked;

			//opts.Language = comboLang.SelectedItem;
			
			m_opts.StoreData();
			
			this.DialogResult = DialogResult.OK;
			Close();
		}
	}
}
