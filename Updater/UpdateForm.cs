using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;
using System.Threading;
using AY.Log;
using AY.db;
using AY.db.dbDataSetTableAdapters;

namespace AY.Updater
{
	internal partial class UpdateForm : Form
	{
		public UpdateForm()
		{
			Logger.Enter();
			
			dbDataSet.settingsRow row = Db.Instance.dSet.settings.FindByid(1);
			CultureInfo cult = new CultureInfo(row.language);
			Thread.CurrentThread.CurrentUICulture = cult;
			
			InitializeComponent();

			labelUpdate.Text = String.Format(labelUpdate.Text, Updater.AppTitle);

			Logger.Leave();
		}

		private void UpdateFormLoad(object sender, EventArgs e)
		{
			Logger.Enter();
			webBrowser.Navigate(Updater.ChangeLogURL);
			Logger.Leave();
		}

		private void ButtonUpdateClick(object sender, EventArgs e)
		{
			Logger.Enter();
			DownloadUpdateDialog downloadDialog = new DownloadUpdateDialog(Updater.DownloadURL);

			try
			{
				downloadDialog.ShowDialog();
			}
			catch (System.Reflection.TargetInvocationException)
			{
				Logger.Error("Invocation exception.");
			}
			Logger.Leave();
		}

		private void labelReleaseNotes_Click(object sender, EventArgs e)
		{

		}
	}
}
