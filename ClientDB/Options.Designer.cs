﻿namespace GAssistant
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
			this.btnOk = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnBackUpPath = new System.Windows.Forms.Button();
			this.textPathBackUp = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkSaveMainWindowState = new System.Windows.Forms.CheckBox();
			this.numericMinPassLen = new System.Windows.Forms.NumericUpDown();
			this.comboLang = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.numericCalRowHeight = new System.Windows.Forms.NumericUpDown();
			this.checkShowClientCount = new System.Windows.Forms.CheckBox();
			this.checkShowTrainer = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnColorMissed = new System.Windows.Forms.Button();
			this.btnColorDelayed = new System.Windows.Forms.Button();
			this.btnColorOvertime = new System.Windows.Forms.Button();
			this.btnColorPresent = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericMinPassLen)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericCalRowHeight)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(217, 226);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(298, 226);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Cancel";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Controls.Add(this.tabPage3);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(361, 208);
			this.tabControl.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnBackUpPath);
			this.tabPage1.Controls.Add(this.textPathBackUp);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.checkSaveMainWindowState);
			this.tabPage1.Controls.Add(this.numericMinPassLen);
			this.tabPage1.Controls.Add(this.comboLang);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(353, 182);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Global";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnBackUpPath
			// 
			this.btnBackUpPath.Location = new System.Drawing.Point(317, 66);
			this.btnBackUpPath.Name = "btnBackUpPath";
			this.btnBackUpPath.Size = new System.Drawing.Size(30, 20);
			this.btnBackUpPath.TabIndex = 37;
			this.btnBackUpPath.Text = "...";
			this.btnBackUpPath.UseVisualStyleBackColor = true;
			// 
			// textPathBackUp
			// 
			this.textPathBackUp.Location = new System.Drawing.Point(152, 66);
			this.textPathBackUp.Name = "textPathBackUp";
			this.textPathBackUp.Size = new System.Drawing.Size(159, 20);
			this.textPathBackUp.TabIndex = 36;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(109, 13);
			this.label4.TabIndex = 35;
			this.label4.Text = "Save DB BackUps to";
			// 
			// checkSaveMainWindowState
			// 
			this.checkSaveMainWindowState.AutoSize = true;
			this.checkSaveMainWindowState.Location = new System.Drawing.Point(6, 99);
			this.checkSaveMainWindowState.Name = "checkSaveMainWindowState";
			this.checkSaveMainWindowState.Size = new System.Drawing.Size(141, 17);
			this.checkSaveMainWindowState.TabIndex = 34;
			this.checkSaveMainWindowState.Text = "Save main window state";
			this.checkSaveMainWindowState.UseVisualStyleBackColor = true;
			// 
			// numericMinPassLen
			// 
			this.numericMinPassLen.Location = new System.Drawing.Point(152, 8);
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
			this.numericMinPassLen.TabIndex = 33;
			this.numericMinPassLen.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// comboLang
			// 
			this.comboLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboLang.FormattingEnabled = true;
			this.comboLang.Location = new System.Drawing.Point(152, 36);
			this.comboLang.Name = "comboLang";
			this.comboLang.Size = new System.Drawing.Size(195, 21);
			this.comboLang.TabIndex = 31;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 30;
			this.label2.Text = "Language";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 13);
			this.label1.TabIndex = 29;
			this.label1.Text = "Minimum password length";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.numericCalRowHeight);
			this.tabPage2.Controls.Add(this.checkShowClientCount);
			this.tabPage2.Controls.Add(this.checkShowTrainer);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(353, 182);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Calendar";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// numericCalRowHeight
			// 
			this.numericCalRowHeight.Location = new System.Drawing.Point(139, 8);
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
			this.numericCalRowHeight.TabIndex = 18;
			this.numericCalRowHeight.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			// 
			// checkShowClientCount
			// 
			this.checkShowClientCount.AutoSize = true;
			this.checkShowClientCount.Location = new System.Drawing.Point(9, 57);
			this.checkShowClientCount.Name = "checkShowClientCount";
			this.checkShowClientCount.Size = new System.Drawing.Size(111, 17);
			this.checkShowClientCount.TabIndex = 17;
			this.checkShowClientCount.Text = "Show client count";
			this.checkShowClientCount.UseVisualStyleBackColor = true;
			// 
			// checkShowTrainer
			// 
			this.checkShowTrainer.AutoSize = true;
			this.checkShowTrainer.Location = new System.Drawing.Point(9, 34);
			this.checkShowTrainer.Name = "checkShowTrainer";
			this.checkShowTrainer.Size = new System.Drawing.Size(189, 17);
			this.checkShowTrainer.TabIndex = 16;
			this.checkShowTrainer.Text = "Show tariner name in calendar day";
			this.checkShowTrainer.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Row height";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.btnColorMissed);
			this.tabPage3.Controls.Add(this.btnColorDelayed);
			this.tabPage3.Controls.Add(this.btnColorOvertime);
			this.tabPage3.Controls.Add(this.btnColorPresent);
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(353, 182);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Ticket colors";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// btnColorMissed
			// 
			this.btnColorMissed.Location = new System.Drawing.Point(260, 87);
			this.btnColorMissed.Name = "btnColorMissed";
			this.btnColorMissed.Size = new System.Drawing.Size(75, 23);
			this.btnColorMissed.TabIndex = 11;
			this.btnColorMissed.Text = "....";
			this.btnColorMissed.UseVisualStyleBackColor = true;
			this.btnColorMissed.Click += new System.EventHandler(this.btnColorMissed_Click);
			// 
			// btnColorDelayed
			// 
			this.btnColorDelayed.Location = new System.Drawing.Point(260, 61);
			this.btnColorDelayed.Name = "btnColorDelayed";
			this.btnColorDelayed.Size = new System.Drawing.Size(75, 23);
			this.btnColorDelayed.TabIndex = 10;
			this.btnColorDelayed.Text = "...";
			this.btnColorDelayed.UseVisualStyleBackColor = true;
			this.btnColorDelayed.Click += new System.EventHandler(this.btnColorDelayed_Click);
			// 
			// btnColorOvertime
			// 
			this.btnColorOvertime.Location = new System.Drawing.Point(260, 35);
			this.btnColorOvertime.Name = "btnColorOvertime";
			this.btnColorOvertime.Size = new System.Drawing.Size(75, 23);
			this.btnColorOvertime.TabIndex = 9;
			this.btnColorOvertime.Text = "...";
			this.btnColorOvertime.UseVisualStyleBackColor = true;
			this.btnColorOvertime.Click += new System.EventHandler(this.btnColorOvertime_Click);
			// 
			// btnColorPresent
			// 
			this.btnColorPresent.Location = new System.Drawing.Point(260, 9);
			this.btnColorPresent.Name = "btnColorPresent";
			this.btnColorPresent.Size = new System.Drawing.Size(75, 23);
			this.btnColorPresent.TabIndex = 8;
			this.btnColorPresent.Text = "...";
			this.btnColorPresent.UseVisualStyleBackColor = true;
			this.btnColorPresent.Click += new System.EventHandler(this.btnColorPresent_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 92);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Missed";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 66);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Delayed";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Overtime";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Present";
			// 
			// Options
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(385, 260);
			this.Controls.Add(this.tabControl);
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
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericMinPassLen)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericCalRowHeight)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnBackUpPath;
		private System.Windows.Forms.TextBox textPathBackUp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkSaveMainWindowState;
		private System.Windows.Forms.NumericUpDown numericMinPassLen;
		private System.Windows.Forms.ComboBox comboLang;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.NumericUpDown numericCalRowHeight;
		private System.Windows.Forms.CheckBox checkShowClientCount;
		private System.Windows.Forms.CheckBox checkShowTrainer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnColorDelayed;
		private System.Windows.Forms.Button btnColorOvertime;
		private System.Windows.Forms.Button btnColorPresent;
		private System.Windows.Forms.Button btnColorMissed;

	}
}