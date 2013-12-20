using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;
using AY.Log;

namespace AY.Updater
{
	internal partial class UpdateForm : Form
	{
		public UpdateForm()
		{
			Logger.Enter();
			InitializeComponent();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(UpdateForm));
			Text = Updater.DialogTitle;
			labelUpdate.Text = string.Format(resources.GetString("labelUpdate.Text", CultureInfo.CurrentCulture), Updater.AppTitle);
			labelDescription.Text =
				string.Format(resources.GetString("labelDescription.Text", CultureInfo.CurrentCulture),
					Updater.AppTitle, Updater.CurrentVersion, Updater.InstalledVersion);

			Logger.Leave();
		}

		public override sealed string Text
		{
			get { return base.Text; }
			set
			{
				Logger.Enter();
				base.Text = value;
				Logger.Leave();
			}
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
	}
}
