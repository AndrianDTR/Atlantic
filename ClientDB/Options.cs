using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;
using System.Drawing;

namespace EAssistant
{
	public partial class Options : Form
	{
		dbDataSet.settingsRow opts = null;
		
		public Options()
		{
			InitializeComponent();
			opts = Db.Instance.dSet.settings.FindByid(1);

			numericMinPassLen.Value = opts.minPassLen;
			numericCalRowHeight.Value = opts.calRowHeight;
			checkShowTrainer.Checked = opts.ShowTrainer;
			checkShowClientCount.Checked = opts.ShowClientCount;
			checkSaveMainWindowState.Checked = opts.StoreMainWindowState;
			textPathBackUp.Text = opts.pathBackUp;
			dateStart.Value = opts.StartTime;
			dateEnd.Value = opts.EndTime;
			
			comboLang.Items.Add("English");
			comboLang.SelectedIndex = 0;
			//comboLang.SelectedItem = opts.Language;

			InitPageColors();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			opts.minPassLen = (int)numericMinPassLen.Value;
			opts.calRowHeight = (int)numericCalRowHeight.Value;
			opts.ShowTrainer = checkShowTrainer.Checked;
			opts.ShowClientCount = checkShowClientCount.Checked;
			opts.StoreMainWindowState = checkSaveMainWindowState.Checked;
			opts.pathBackUp = textPathBackUp.Text;
			opts.StartTime = dateStart.Value;
			opts.EndTime = dateEnd.Value;
			
			//opts.Language = comboLang.SelectedItem;
			
			Db.Instance.AcceptChanges();
			
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnBackUpPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = opts.pathBackUp;
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				textPathBackUp.Text = fbd.SelectedPath;
			}
		}
		
		private void InitPageColors()
		{
			btnColorPresent.BackColor = opts.ColorPresent;
			btnColorOvertime.BackColor = opts.ColorOvertime;
			btnColorDelayed.BackColor = opts.ColorDelayed;
			btnColorMissed.BackColor = opts.ColorMissed;
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
			opts.ColorPresent = ChooseColor(opts.ColorPresent);
			InitPageColors();
		}

		private void btnColorOvertime_Click(object sender, EventArgs e)
		{
			opts.ColorOvertime = ChooseColor(opts.ColorOvertime);
			InitPageColors();
		}
		
		private void btnColorDelayed_Click(object sender, EventArgs e)
		{
			opts.ColorDelayed = ChooseColor(opts.ColorDelayed);
			InitPageColors();
		}
		
		private void btnColorMissed_Click(object sender, EventArgs e)
		{
			opts.ColorMissed = ChooseColor(opts.ColorMissed);
			InitPageColors();
		}
	}
}
