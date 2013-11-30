namespace Registrator
{
	partial class ActivatorForm
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
			this.textSerial = new System.Windows.Forms.TextBox();
			this.textActKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.textFName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textLName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textPhone = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textEmail = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textAddress = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textCustomer = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textCustomerId = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Serial";
			// 
			// textSerial
			// 
			this.textSerial.Location = new System.Drawing.Point(15, 30);
			this.textSerial.Name = "textSerial";
			this.textSerial.Size = new System.Drawing.Size(500, 20);
			this.textSerial.TabIndex = 1;
			// 
			// textActKey
			// 
			this.textActKey.Location = new System.Drawing.Point(15, 292);
			this.textActKey.Multiline = true;
			this.textActKey.Name = "textActKey";
			this.textActKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textActKey.Size = new System.Drawing.Size(500, 119);
			this.textActKey.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 271);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Activation key";
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(440, 425);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(359, 425);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 5;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// textFName
			// 
			this.textFName.Location = new System.Drawing.Point(69, 70);
			this.textFName.Name = "textFName";
			this.textFName.Size = new System.Drawing.Size(446, 20);
			this.textFName.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "First Name";
			// 
			// textLName
			// 
			this.textLName.Location = new System.Drawing.Point(69, 106);
			this.textLName.Name = "textLName";
			this.textLName.Size = new System.Drawing.Size(446, 20);
			this.textLName.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Last name";
			// 
			// textPhone
			// 
			this.textPhone.Location = new System.Drawing.Point(69, 142);
			this.textPhone.Name = "textPhone";
			this.textPhone.Size = new System.Drawing.Size(150, 20);
			this.textPhone.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 145);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Phone";
			// 
			// textEmail
			// 
			this.textEmail.Location = new System.Drawing.Point(69, 177);
			this.textEmail.Name = "textEmail";
			this.textEmail.Size = new System.Drawing.Size(223, 20);
			this.textEmail.TabIndex = 13;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 180);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Email";
			// 
			// textAddress
			// 
			this.textAddress.Location = new System.Drawing.Point(69, 211);
			this.textAddress.Multiline = true;
			this.textAddress.Name = "textAddress";
			this.textAddress.Size = new System.Drawing.Size(446, 49);
			this.textAddress.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 214);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 13);
			this.label7.TabIndex = 14;
			this.label7.Text = "Address";
			// 
			// textCustomer
			// 
			this.textCustomer.Location = new System.Drawing.Point(365, 142);
			this.textCustomer.Name = "textCustomer";
			this.textCustomer.Size = new System.Drawing.Size(150, 20);
			this.textCustomer.TabIndex = 17;
			this.textCustomer.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(298, 145);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "Customer #";
			// 
			// textCustomerId
			// 
			this.textCustomerId.Location = new System.Drawing.Point(365, 177);
			this.textCustomerId.Name = "textCustomerId";
			this.textCustomerId.Size = new System.Drawing.Size(150, 20);
			this.textCustomerId.TabIndex = 19;
			this.textCustomerId.Text = "0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(298, 180);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 13);
			this.label9.TabIndex = 18;
			this.label9.Text = "Customer ID";
			// 
			// ActivatorForm
			// 
			this.AcceptButton = this.btnGenerate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(527, 460);
			this.Controls.Add(this.textCustomerId);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textCustomer);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textAddress);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textEmail);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textPhone);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textLName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textFName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.textActKey);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textSerial);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ActivatorForm";
			this.Text = "Activator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textSerial;
		private System.Windows.Forms.TextBox textActKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.TextBox textFName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textLName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textPhone;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textEmail;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textAddress;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textCustomer;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textCustomerId;
		private System.Windows.Forms.Label label9;
	}
}

