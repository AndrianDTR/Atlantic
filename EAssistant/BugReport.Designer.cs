namespace EAssistant
{
	partial class BugReport
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugReport));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textEmail = new System.Windows.Forms.TextBox();
			this.textIssue = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Font = null;
			this.label1.Name = "label1";
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Font = null;
			this.label2.Name = "label2";
			// 
			// textEmail
			// 
			this.textEmail.AccessibleDescription = null;
			this.textEmail.AccessibleName = null;
			resources.ApplyResources(this.textEmail, "textEmail");
			this.textEmail.BackgroundImage = null;
			this.textEmail.Font = null;
			this.textEmail.Name = "textEmail";
			// 
			// textIssue
			// 
			this.textIssue.AccessibleDescription = null;
			this.textIssue.AccessibleName = null;
			resources.ApplyResources(this.textIssue, "textIssue");
			this.textIssue.BackgroundImage = null;
			this.textIssue.Font = null;
			this.textIssue.Name = "textIssue";
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = null;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSend
			// 
			this.btnSend.AccessibleDescription = null;
			this.btnSend.AccessibleName = null;
			resources.ApplyResources(this.btnSend, "btnSend");
			this.btnSend.BackgroundImage = null;
			this.btnSend.Font = null;
			this.btnSend.Name = "btnSend";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// BugReport
			// 
			this.AcceptButton = this.btnSend;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.textIssue);
			this.Controls.Add(this.textEmail);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BugReport";
			this.ShowInTaskbar = false;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textEmail;
		private System.Windows.Forms.TextBox textIssue;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSend;
	}
}