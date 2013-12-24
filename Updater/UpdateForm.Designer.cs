using System.Threading;

namespace AY.Updater
{
    partial class UpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.labelUpdate = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelReleaseNotes = new System.Windows.Forms.Label();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.buttonSkip = new System.Windows.Forms.Button();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// webBrowser
			// 
			this.webBrowser.AccessibleDescription = null;
			this.webBrowser.AccessibleName = null;
			resources.ApplyResources(this.webBrowser, "webBrowser");
			this.webBrowser.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			// 
			// labelUpdate
			// 
			this.labelUpdate.AccessibleDescription = null;
			this.labelUpdate.AccessibleName = null;
			resources.ApplyResources(this.labelUpdate, "labelUpdate");
			this.labelUpdate.MaximumSize = new System.Drawing.Size(480, 0);
			this.labelUpdate.Name = "labelUpdate";
			// 
			// labelDescription
			// 
			this.labelDescription.AccessibleDescription = null;
			this.labelDescription.AccessibleName = null;
			resources.ApplyResources(this.labelDescription, "labelDescription");
			this.labelDescription.MaximumSize = new System.Drawing.Size(471, 0);
			this.labelDescription.Name = "labelDescription";
			// 
			// labelReleaseNotes
			// 
			this.labelReleaseNotes.AccessibleDescription = null;
			this.labelReleaseNotes.AccessibleName = null;
			resources.ApplyResources(this.labelReleaseNotes, "labelReleaseNotes");
			this.labelReleaseNotes.Name = "labelReleaseNotes";
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.AccessibleDescription = null;
			this.buttonUpdate.AccessibleName = null;
			resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
			this.buttonUpdate.BackgroundImage = null;
			this.buttonUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonUpdate.Font = null;
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdateClick);
			// 
			// buttonSkip
			// 
			this.buttonSkip.AccessibleDescription = null;
			this.buttonSkip.AccessibleName = null;
			resources.ApplyResources(this.buttonSkip, "buttonSkip");
			this.buttonSkip.BackgroundImage = null;
			this.buttonSkip.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.buttonSkip.Font = null;
			this.buttonSkip.Name = "buttonSkip";
			this.buttonSkip.UseVisualStyleBackColor = true;
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.AccessibleDescription = null;
			this.pictureBoxIcon.AccessibleName = null;
			resources.ApplyResources(this.pictureBoxIcon, "pictureBoxIcon");
			this.pictureBoxIcon.BackgroundImage = null;
			this.pictureBoxIcon.Font = null;
			this.pictureBoxIcon.Image = global::AY.Updater.Properties.Resources.update;
			this.pictureBoxIcon.ImageLocation = null;
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.TabStop = false;
			// 
			// UpdateForm
			// 
			this.AcceptButton = this.buttonUpdate;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.pictureBoxIcon);
			this.Controls.Add(this.labelReleaseNotes);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.labelUpdate);
			this.Controls.Add(this.webBrowser);
			this.Controls.Add(this.buttonUpdate);
			this.Controls.Add(this.buttonSkip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateForm";
			this.ShowIcon = false;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.UpdateFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSkip;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label labelUpdate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelReleaseNotes;
        private System.Windows.Forms.PictureBox pictureBoxIcon;

    }
}