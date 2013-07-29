namespace GAssistant
{
    partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientByBarcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trainersScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.manageClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.usersAndPasswordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.manageTrainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageScheduleRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sendLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.log = new System.Windows.Forms.TextBox();
			this.dayView1 = new CalendarTest.DayView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnBackUp = new System.Windows.Forms.Button();
			this.btnTrainersShedule = new System.Windows.Forms.Button();
			this.btnPaymentsHistory = new System.Windows.Forms.Button();
			this.btnClientManager = new System.Windows.Forms.Button();
			this.btnAddClient = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(921, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.importToolStripMenuItem.Text = "Import";
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientByBarcodeToolStripMenuItem,
            this.paymentToolStripMenuItem});
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.searchToolStripMenuItem.Text = "Search";
			// 
			// clientByBarcodeToolStripMenuItem
			// 
			this.clientByBarcodeToolStripMenuItem.Name = "clientByBarcodeToolStripMenuItem";
			this.clientByBarcodeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.clientByBarcodeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.clientByBarcodeToolStripMenuItem.Text = "Barcode";
			this.clientByBarcodeToolStripMenuItem.Click += new System.EventHandler(this.clientByBarcodeToolStripMenuItem_Click);
			// 
			// paymentToolStripMenuItem
			// 
			this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
			this.paymentToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.paymentToolStripMenuItem.Text = "Payment";
			this.paymentToolStripMenuItem.Visible = false;
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentsToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.trainersScheduleToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// paymentsToolStripMenuItem
			// 
			this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
			this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.paymentsToolStripMenuItem.Text = "Payments";
			this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
			// 
			// scheduleToolStripMenuItem
			// 
			this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
			this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.scheduleToolStripMenuItem.Text = "Schedule";
			this.scheduleToolStripMenuItem.Visible = false;
			// 
			// trainersScheduleToolStripMenuItem
			// 
			this.trainersScheduleToolStripMenuItem.Name = "trainersScheduleToolStripMenuItem";
			this.trainersScheduleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.trainersScheduleToolStripMenuItem.Text = "Trainers schedule";
			this.trainersScheduleToolStripMenuItem.Visible = false;
			// 
			// clientToolStripMenuItem
			// 
			this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripMenuItem5,
            this.manageClientsToolStripMenuItem});
			this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
			this.clientToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.clientToolStripMenuItem.Text = "Client";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.addToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.addToolStripMenuItem.Text = "Add";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(153, 6);
			// 
			// manageClientsToolStripMenuItem
			// 
			this.manageClientsToolStripMenuItem.Name = "manageClientsToolStripMenuItem";
			this.manageClientsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.manageClientsToolStripMenuItem.Text = "Manage clients";
			this.manageClientsToolStripMenuItem.Click += new System.EventHandler(this.manageClientsToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.toolStripMenuItem2,
            this.usersAndPasswordsToolStripMenuItem,
            this.userRolesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.manageTrainersToolStripMenuItem,
            this.manageScheduleRulesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.optionsToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// changePasswordToolStripMenuItem
			// 
			this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
			this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.changePasswordToolStripMenuItem.Text = "Change password";
			this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 6);
			// 
			// usersAndPasswordsToolStripMenuItem
			// 
			this.usersAndPasswordsToolStripMenuItem.Name = "usersAndPasswordsToolStripMenuItem";
			this.usersAndPasswordsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.usersAndPasswordsToolStripMenuItem.Text = "Users and passwords";
			this.usersAndPasswordsToolStripMenuItem.Click += new System.EventHandler(this.usersAndPasswordsToolStripMenuItem_Click);
			// 
			// userRolesToolStripMenuItem
			// 
			this.userRolesToolStripMenuItem.Name = "userRolesToolStripMenuItem";
			this.userRolesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.userRolesToolStripMenuItem.Text = "User roles";
			this.userRolesToolStripMenuItem.Click += new System.EventHandler(this.userRolesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(191, 6);
			// 
			// manageTrainersToolStripMenuItem
			// 
			this.manageTrainersToolStripMenuItem.Name = "manageTrainersToolStripMenuItem";
			this.manageTrainersToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.manageTrainersToolStripMenuItem.Text = "Manage trainers";
			this.manageTrainersToolStripMenuItem.Click += new System.EventHandler(this.manageTrainersToolStripMenuItem_Click);
			// 
			// manageScheduleRulesToolStripMenuItem
			// 
			this.manageScheduleRulesToolStripMenuItem.Name = "manageScheduleRulesToolStripMenuItem";
			this.manageScheduleRulesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.manageScheduleRulesToolStripMenuItem.Text = "Manage schedule rules";
			this.manageScheduleRulesToolStripMenuItem.Click += new System.EventHandler(this.manageScheduleRulesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(191, 6);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.sendLogToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// sendLogToolStripMenuItem
			// 
			this.sendLogToolStripMenuItem.Name = "sendLogToolStripMenuItem";
			this.sendLogToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.sendLogToolStripMenuItem.Text = "Send log ...";
			// 
			// panel2
			// 
			this.panel2.AutoSize = true;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(921, 0);
			this.panel2.TabIndex = 11;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.log, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.dayView1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(921, 511);
			this.tableLayoutPanel1.TabIndex = 12;
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(8, 359);
			this.log.Multiline = true;
			this.log.Name = "log";
			this.log.ReadOnly = true;
			this.log.Size = new System.Drawing.Size(905, 144);
			this.log.TabIndex = 8;
			// 
			// dayView1
			// 
			this.dayView1.ActiveTool = null;
			this.dayView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dayView1.Location = new System.Drawing.Point(8, 63);
			this.dayView1.Name = "dayView1";
			this.dayView1.NavButtonsHeight = 30;
			this.dayView1.RowHeight = 80;
			this.dayView1.SelectedDate = new System.DateTime(((long)(0)));
			this.dayView1.Size = new System.Drawing.Size(905, 290);
			this.dayView1.StartDate = new System.DateTime(2013, 7, 25, 0, 0, 0, 0);
			this.dayView1.TabIndex = 7;
			this.dayView1.Text = "dayView1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnBackUp);
			this.panel1.Controls.Add(this.btnTrainersShedule);
			this.panel1.Controls.Add(this.btnPaymentsHistory);
			this.panel1.Controls.Add(this.btnClientManager);
			this.panel1.Controls.Add(this.btnAddClient);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(905, 49);
			this.panel1.TabIndex = 5;
			// 
			// btnBackUp
			// 
			this.btnBackUp.Image = global::GAssistant.Properties.Resources._1367375035_filesave;
			this.btnBackUp.Location = new System.Drawing.Point(216, 0);
			this.btnBackUp.Name = "btnBackUp";
			this.btnBackUp.Size = new System.Drawing.Size(48, 48);
			this.btnBackUp.TabIndex = 6;
			this.btnBackUp.UseVisualStyleBackColor = true;
			// 
			// btnTrainersShedule
			// 
			this.btnTrainersShedule.Image = global::GAssistant.Properties.Resources._1367375242_schedule;
			this.btnTrainersShedule.Location = new System.Drawing.Point(162, 0);
			this.btnTrainersShedule.Name = "btnTrainersShedule";
			this.btnTrainersShedule.Size = new System.Drawing.Size(48, 48);
			this.btnTrainersShedule.TabIndex = 5;
			this.btnTrainersShedule.UseVisualStyleBackColor = true;
			// 
			// btnPaymentsHistory
			// 
			this.btnPaymentsHistory.Image = global::GAssistant.Properties.Resources._1367375158_coins;
			this.btnPaymentsHistory.Location = new System.Drawing.Point(108, 0);
			this.btnPaymentsHistory.Name = "btnPaymentsHistory";
			this.btnPaymentsHistory.Size = new System.Drawing.Size(48, 48);
			this.btnPaymentsHistory.TabIndex = 4;
			this.btnPaymentsHistory.UseVisualStyleBackColor = true;
			this.btnPaymentsHistory.Click += new System.EventHandler(this.btnPaymentsHistory_Click);
			// 
			// btnClientManager
			// 
			this.btnClientManager.Image = global::GAssistant.Properties.Resources._1367375688_27_Edit_Text;
			this.btnClientManager.Location = new System.Drawing.Point(54, 0);
			this.btnClientManager.Name = "btnClientManager";
			this.btnClientManager.Size = new System.Drawing.Size(48, 48);
			this.btnClientManager.TabIndex = 3;
			this.btnClientManager.UseVisualStyleBackColor = true;
			this.btnClientManager.Click += new System.EventHandler(this.btnClientManager_Click);
			// 
			// btnAddClient
			// 
			this.btnAddClient.Image = global::GAssistant.Properties.Resources._1367374740_edit_add;
			this.btnAddClient.Location = new System.Drawing.Point(0, 0);
			this.btnAddClient.Name = "btnAddClient";
			this.btnAddClient.Size = new System.Drawing.Size(48, 48);
			this.btnAddClient.TabIndex = 1;
			this.btnAddClient.UseVisualStyleBackColor = true;
			this.btnAddClient.Click += new System.EventHandler(this.add_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(921, 535);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "G-Assistant";
			this.Load += new System.EventHandler(this.OnLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clientByBarcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.Button btnTrainersShedule;
		private System.Windows.Forms.Button btnPaymentsHistory;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersAndPasswordsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem trainersScheduleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem userRolesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem manageTrainersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manageScheduleRulesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem manageClientsToolStripMenuItem;
		private System.Windows.Forms.Button btnClientManager;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private CalendarTest.DayView dayView1;
		private System.Windows.Forms.TextBox log;
		private System.Windows.Forms.ToolStripMenuItem sendLogToolStripMenuItem;
    }
}

