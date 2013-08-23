using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;
using System.Drawing;

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
			checkSaveMainWindowState.Checked = m_opts.StoreMainWindowState;
			textPathBackUp.Text = m_opts.PathBackUp;
			dateStart.Value = m_opts.StartTime;
			dateEnd.Value = m_opts.EndTime;
			
			comboLang.Items.Add("English");
			comboLang.SelectedIndex = 0;
			//comboLang.SelectedItem = m_opts.Language;

			InitPageColors();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			m_opts.MinPassLen = (int)numericMinPassLen.Value;
			m_opts.CalRowHeight = (int)numericCalRowHeight.Value;
			m_opts.ShowTrainer = checkShowTrainer.Checked;
			m_opts.ShowClientCount = checkShowClientCount.Checked;
			m_opts.StoreMainWindowState = checkSaveMainWindowState.Checked;
			m_opts.PathBackUp = textPathBackUp.Text;
			m_opts.StartTime = dateStart.Value;
			m_opts.EndTime = dateEnd.Value;
			
			//opts.Language = comboLang.SelectedItem;
			
			m_opts.StoreData();
			
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnBackUpPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = m_opts.PathBackUp;
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				textPathBackUp.Text = fbd.SelectedPath;
			}
		}
		
		private void InitPageColors()
		{
			btnColorPresent.BackColor = m_opts.ColorPresent;
			btnColorOvertime.BackColor = m_opts.ColorOvertime;
			btnColorDelayed.BackColor = m_opts.ColorDelayed;
			btnColorMissed.BackColor = m_opts.ColorMissed;
		}
		
		private Color ChooseColor(Color old)
		{
			Color clr = old;
			
			ColorDialog dlg = new ColorDialog();
			dlg.Color = old;
			if(DialogResult.OK == dlg.ShowDialog())
			{
				clr = dlg.Color;
			}
			
			return clr;
		}
		
		private void btnColorPresent_Click(object sender, EventArgs e)
		{
			m_opts.ColorPresent = ChooseColor(m_opts.ColorPresent);
			InitPageColors();
		}

		private void btnColorOvertime_Click(object sender, EventArgs e)
		{
			m_opts.ColorOvertime = ChooseColor(m_opts.ColorOvertime);
			InitPageColors();
		}
		
		private void btnColorDelayed_Click(object sender, EventArgs e)
		{
			m_opts.ColorDelayed = ChooseColor(m_opts.ColorDelayed);
			InitPageColors();
		}
		
		private void btnColorMissed_Click(object sender, EventArgs e)
		{
			m_opts.ColorMissed = ChooseColor(m_opts.ColorMissed);
			InitPageColors();
		}
	}
}
