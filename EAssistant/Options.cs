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
			Logger.Enter();
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

			comboUpdatesFrequency.SelectedIndex = opts.updates;

			InitPageColors();
			Logger.Leave();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			opts.minPassLen = (int)numericMinPassLen.Value;
			opts.calRowHeight = (int)numericCalRowHeight.Value;
			opts.ShowTrainer = checkShowTrainer.Checked;
			opts.ShowClientCount = checkShowClientCount.Checked;
			opts.StoreMainWindowState = checkSaveMainWindowState.Checked;
			opts.pathBackUp = textPathBackUp.Text;
			opts.StartTime = dateStart.Value;
			opts.EndTime = dateEnd.Value;

			//opts.Language = comboLang.SelectedItem;

			opts.updates = comboUpdatesFrequency.SelectedIndex;

			Db.Instance.AcceptChanges();
			Session.Instance.UpdateMain();
			this.DialogResult = DialogResult.OK;
			Close();
			Logger.Leave();
		}

		private void btnBackUpPath_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = opts.pathBackUp;
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				textPathBackUp.Text = fbd.SelectedPath;
			}
			Logger.Leave();
		}

		private void InitPageColors()
		{
			Logger.Enter();
			btnColorPresent.BackColor = opts.ColorPresent;
			btnColorOvertime.BackColor = opts.ColorOvertime;
			btnColorDelayed.BackColor = opts.ColorDelayed;
			btnColorMissed.BackColor = opts.ColorMissed;
			Logger.Leave();
		}

		private Color ChooseColor(Color old)
		{
			Logger.Enter();
			Color clr = old;

			ColorDialog dlg = new ColorDialog();
			dlg.Color = old;
			if (DialogResult.OK == dlg.ShowDialog())
			{
				clr = dlg.Color;
			}

			Logger.Leave();
			return clr;
		}

		private void btnColorPresent_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			opts.ColorPresent = ChooseColor(opts.ColorPresent);
			InitPageColors();
			Logger.Leave();
		}

		private void btnColorOvertime_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			opts.ColorOvertime = ChooseColor(opts.ColorOvertime);
			InitPageColors();
			Logger.Leave();
		}

		private void btnColorDelayed_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			opts.ColorDelayed = ChooseColor(opts.ColorDelayed);
			InitPageColors();
			Logger.Leave();
		}

		private void btnColorMissed_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			opts.ColorMissed = ChooseColor(opts.ColorMissed);
			InitPageColors();
			Logger.Leave();
		}
	}
}
