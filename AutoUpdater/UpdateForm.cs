using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;

namespace AY.AutoUpdate
{
    internal partial class UpdateForm : Form
    {
		public UpdateForm()
        {
            InitializeComponent();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(UpdateForm));
            Text = AutoUpdater.DialogTitle;
            labelUpdate.Text = string.Format(resources.GetString("labelUpdate.Text", CultureInfo.CurrentCulture), AutoUpdater.AppTitle);
            labelDescription.Text =
                string.Format(resources.GetString("labelDescription.Text", CultureInfo.CurrentCulture),
                    AutoUpdater.AppTitle, AutoUpdater.CurrentVersion, AutoUpdater.InstalledVersion);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void UpdateFormLoad(object sender, EventArgs e)
        {
            webBrowser.Navigate(AutoUpdater.ChangeLogURL);
        }

        private void ButtonUpdateClick(object sender, EventArgs e)
        {
			DownloadUpdateDialog downloadDialog = new DownloadUpdateDialog(AutoUpdater.DownloadURL);

            try
            {
                downloadDialog.ShowDialog();
            }
            catch (System.Reflection.TargetInvocationException)
            {
            }
        }
    }
}
