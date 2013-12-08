﻿using System.Threading;

namespace AY.AutoUpdate
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
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.buttonSkip = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// webBrowser
			// 
			this.webBrowser.IsWebBrowserContextMenuEnabled = false;
			resources.ApplyResources(this.webBrowser, "webBrowser");
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			// 
			// labelUpdate
			// 
			resources.ApplyResources(this.labelUpdate, "labelUpdate");
			this.labelUpdate.MaximumSize = new System.Drawing.Size(480, 0);
			this.labelUpdate.Name = "labelUpdate";
			// 
			// labelDescription
			// 
			resources.ApplyResources(this.labelDescription, "labelDescription");
			this.labelDescription.MaximumSize = new System.Drawing.Size(471, 0);
			this.labelDescription.Name = "labelDescription";
			// 
			// labelReleaseNotes
			// 
			resources.ApplyResources(this.labelReleaseNotes, "labelReleaseNotes");
			this.labelReleaseNotes.Name = "labelReleaseNotes";
			this.labelReleaseNotes.Click += new System.EventHandler(this.labelReleaseNotes_Click);
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
			resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdateClick);
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::AY.AutoUpdate.Properties.Resources.update;
			resources.ApplyResources(this.pictureBoxIcon, "pictureBoxIcon");
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.TabStop = false;
			// 
			// buttonSkip
			// 
			this.buttonSkip.DialogResult = System.Windows.Forms.DialogResult.Abort;
			resources.ApplyResources(this.buttonSkip, "buttonSkip");
			this.buttonSkip.Name = "buttonSkip";
			this.buttonSkip.UseVisualStyleBackColor = true;
			this.buttonSkip.Click += new System.EventHandler(this.ButtonSkipClick);
			// 
			// UpdateForm
			// 
			this.AcceptButton = this.buttonUpdate;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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