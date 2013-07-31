namespace GAssistant
{
	partial class Options
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
			this.btnClose = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboLang = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericCalRowHeight = new System.Windows.Forms.NumericUpDown();
			this.checkShowClientCount = new System.Windows.Forms.CheckBox();
			this.checkShowTrainer = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.numericMinPassLen = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericCalRowHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericMinPassLen)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(298, 159);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Cancel";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(217, 159);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Minimum password length";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Language";
			// 
			// comboLang
			// 
			this.comboLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboLang.FormattingEnabled = true;
			this.comboLang.Location = new System.Drawing.Point(161, 35);
			this.comboLang.Name = "comboLang";
			this.comboLang.Size = new System.Drawing.Size(212, 21);
			this.comboLang.TabIndex = 5;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericCalRowHeight);
			this.groupBox1.Controls.Add(this.checkShowClientCount);
			this.groupBox1.Controls.Add(this.checkShowTrainer);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(15, 62);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(358, 91);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Calendar options";
			// 
			// numericCalRowHeight
			// 
			this.numericCalRowHeight.Location = new System.Drawing.Point(143, 16);
			this.numericCalRowHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.numericCalRowHeight.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.numericCalRowHeight.Name = "numericCalRowHeight";
			this.numericCalRowHeight.Size = new System.Drawing.Size(59, 20);
			this.numericCalRowHeight.TabIndex = 14;
			this.numericCalRowHeight.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			// 
			// checkShowClientCount
			// 
			this.checkShowClientCount.AutoSize = true;
			this.checkShowClientCount.Location = new System.Drawing.Point(13, 65);
			this.checkShowClientCount.Name = "checkShowClientCount";
			this.checkShowClientCount.Size = new System.Drawing.Size(111, 17);
			this.checkShowClientCount.TabIndex = 13;
			this.checkShowClientCount.Text = "Show client count";
			this.checkShowClientCount.UseVisualStyleBackColor = true;
			// 
			// checkShowTrainer
			// 
			this.checkShowTrainer.AutoSize = true;
			this.checkShowTrainer.Location = new System.Drawing.Point(13, 42);
			this.checkShowTrainer.Name = "checkShowTrainer";
			this.checkShowTrainer.Size = new System.Drawing.Size(189, 17);
			this.checkShowTrainer.TabIndex = 12;
			this.checkShowTrainer.Text = "Show tariner name in calendar day";
			this.checkShowTrainer.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Row height";
			// 
			// numericMinPassLen
			// 
			this.numericMinPassLen.Location = new System.Drawing.Point(161, 7);
			this.numericMinPassLen.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericMinPassLen.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
			this.numericMinPassLen.Name = "numericMinPassLen";
			this.numericMinPassLen.Size = new System.Drawing.Size(59, 20);
			this.numericMinPassLen.TabIndex = 15;
			this.numericMinPassLen.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// Options
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(385, 193);
			this.Controls.Add(this.numericMinPassLen);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.comboLang);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Options";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Options";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericCalRowHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericMinPassLen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboLang;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericCalRowHeight;
		private System.Windows.Forms.CheckBox checkShowClientCount;
		private System.Windows.Forms.CheckBox checkShowTrainer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericMinPassLen;
	}
}