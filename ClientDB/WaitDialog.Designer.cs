namespace GAssistant
{
	partial class WaitDialog
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
			this.labelMsg = new System.Windows.Forms.Label();
			this.progressComplete = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// labelMsg
			// 
			this.labelMsg.Location = new System.Drawing.Point(12, 9);
			this.labelMsg.Name = "labelMsg";
			this.labelMsg.Size = new System.Drawing.Size(394, 23);
			this.labelMsg.TabIndex = 0;
			this.labelMsg.Text = "Please wait";
			this.labelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressComplete
			// 
			this.progressComplete.Location = new System.Drawing.Point(15, 44);
			this.progressComplete.Name = "progressComplete";
			this.progressComplete.Size = new System.Drawing.Size(394, 14);
			this.progressComplete.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressComplete.TabIndex = 1;
			// 
			// WaitDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 78);
			this.ControlBox = false;
			this.Controls.Add(this.progressComplete);
			this.Controls.Add(this.labelMsg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WaitDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Wait";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelMsg;
		private System.Windows.Forms.ProgressBar progressComplete;
	}
}