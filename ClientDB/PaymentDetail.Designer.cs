namespace GAssistant
{
	partial class PaymentDetail
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
			this.label1 = new System.Windows.Forms.Label();
			this.textDate = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textSum = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textClient = new System.Windows.Forms.TextBox();
			this.textUser = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textService = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textComment = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Date";
			// 
			// textDate
			// 
			this.textDate.Location = new System.Drawing.Point(69, 6);
			this.textDate.Name = "textDate";
			this.textDate.ReadOnly = true;
			this.textDate.Size = new System.Drawing.Size(176, 20);
			this.textDate.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(290, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Sum";
			// 
			// textSum
			// 
			this.textSum.Location = new System.Drawing.Point(336, 6);
			this.textSum.Name = "textSum";
			this.textSum.ReadOnly = true;
			this.textSum.Size = new System.Drawing.Size(126, 20);
			this.textSum.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Client";
			// 
			// textClient
			// 
			this.textClient.Location = new System.Drawing.Point(69, 32);
			this.textClient.Name = "textClient";
			this.textClient.ReadOnly = true;
			this.textClient.Size = new System.Drawing.Size(176, 20);
			this.textClient.TabIndex = 2;
			// 
			// textUser
			// 
			this.textUser.Location = new System.Drawing.Point(336, 35);
			this.textUser.Name = "textUser";
			this.textUser.ReadOnly = true;
			this.textUser.Size = new System.Drawing.Size(126, 20);
			this.textUser.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(290, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Add by";
			// 
			// textService
			// 
			this.textService.Location = new System.Drawing.Point(69, 58);
			this.textService.Name = "textService";
			this.textService.ReadOnly = true;
			this.textService.Size = new System.Drawing.Size(393, 20);
			this.textService.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 61);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Service";
			// 
			// textComment
			// 
			this.textComment.Location = new System.Drawing.Point(69, 84);
			this.textComment.Multiline = true;
			this.textComment.Name = "textComment";
			this.textComment.ReadOnly = true;
			this.textComment.Size = new System.Drawing.Size(393, 64);
			this.textComment.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 87);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Comment";
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(387, 163);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// PaymentDetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(474, 199);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.textComment);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textService);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textUser);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textClient);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textSum);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textDate);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PaymentDetail";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Payment Detail";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textSum;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textClient;
		private System.Windows.Forms.TextBox textUser;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textService;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textComment;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnClose;
	}
}