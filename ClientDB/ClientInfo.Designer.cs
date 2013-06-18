namespace ClientDB
{
	partial class ClientInfo
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
			this.textName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textPhone = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.comboSchedule = new System.Windows.Forms.ComboBox();
			this.comboTrainer = new System.Windows.Forms.ComboBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.textCode = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 17);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Code";
			// 
			// textName
			// 
			this.textName.Location = new System.Drawing.Point(143, 59);
			this.textName.Margin = new System.Windows.Forms.Padding(6);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(607, 29);
			this.textName.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 65);
			this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Name";
			// 
			// textPhone
			// 
			this.textPhone.Location = new System.Drawing.Point(143, 107);
			this.textPhone.Margin = new System.Windows.Forms.Padding(6);
			this.textPhone.Name = "textPhone";
			this.textPhone.Size = new System.Drawing.Size(607, 29);
			this.textPhone.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 113);
			this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "Phone";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 161);
			this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "Schedule";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(22, 209);
			this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 24);
			this.label5.TabIndex = 8;
			this.label5.Text = "Trainer";
			// 
			// comboSchedule
			// 
			this.comboSchedule.FormattingEnabled = true;
			this.comboSchedule.Location = new System.Drawing.Point(143, 155);
			this.comboSchedule.Margin = new System.Windows.Forms.Padding(6);
			this.comboSchedule.Name = "comboSchedule";
			this.comboSchedule.Size = new System.Drawing.Size(607, 32);
			this.comboSchedule.TabIndex = 2;
			// 
			// comboTrainer
			// 
			this.comboTrainer.FormattingEnabled = true;
			this.comboTrainer.Location = new System.Drawing.Point(143, 203);
			this.comboTrainer.Margin = new System.Windows.Forms.Padding(6);
			this.comboTrainer.Name = "comboTrainer";
			this.comboTrainer.Size = new System.Drawing.Size(607, 32);
			this.comboTrainer.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(612, 266);
			this.btnClose.Margin = new System.Windows.Forms.Padding(6);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(138, 42);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Cancel";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(462, 266);
			this.btnOk.Margin = new System.Windows.Forms.Padding(6);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(138, 42);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// textCode
			// 
			this.textCode.Location = new System.Drawing.Point(143, 14);
			this.textCode.Margin = new System.Windows.Forms.Padding(6);
			this.textCode.Name = "textCode";
			this.textCode.ReadOnly = true;
			this.textCode.Size = new System.Drawing.Size(607, 29);
			this.textCode.TabIndex = 9;
			this.textCode.TabStop = false;
			// 
			// ClientInfo
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(776, 330);
			this.Controls.Add(this.textCode);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.comboTrainer);
			this.Controls.Add(this.comboSchedule);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textPhone);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClientInfo";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Client info";
			this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textPhone;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboSchedule;
		private System.Windows.Forms.ComboBox comboTrainer;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox textCode;
	}
}