namespace ClientDB
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
			this.editPersonalDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paymentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.clientList = new System.Windows.Forms.ListView();
			this.client = new System.Windows.Forms.ColumnHeader();
			this.lastPayment = new System.Windows.Forms.ColumnHeader();
			this.plan = new System.Windows.Forms.ColumnHeader();
			this.trainer = new System.Windows.Forms.ColumnHeader();
			this.comment = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_Search = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.export = new System.Windows.Forms.Button();
			this.shedule = new System.Windows.Forms.Button();
			this.payments = new System.Windows.Forms.Button();
			this.edit = new System.Windows.Forms.Button();
			this.remove = new System.Windows.Forms.Button();
			this.add = new System.Windows.Forms.Button();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.manageClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel4.SuspendLayout();
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
			// 
			// scheduleToolStripMenuItem
			// 
			this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
			this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.scheduleToolStripMenuItem.Text = "Schedule";
			// 
			// trainersScheduleToolStripMenuItem
			// 
			this.trainersScheduleToolStripMenuItem.Name = "trainersScheduleToolStripMenuItem";
			this.trainersScheduleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.trainersScheduleToolStripMenuItem.Text = "Trainers schedule";
			// 
			// clientToolStripMenuItem
			// 
			this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editPersonalDataToolStripMenuItem,
            this.paymentToolStripMenuItem1,
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
			this.addToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.addToolStripMenuItem.Text = "Add";
			// 
			// editPersonalDataToolStripMenuItem
			// 
			this.editPersonalDataToolStripMenuItem.Name = "editPersonalDataToolStripMenuItem";
			this.editPersonalDataToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.editPersonalDataToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.editPersonalDataToolStripMenuItem.Text = "Edit personal data";
			// 
			// paymentToolStripMenuItem1
			// 
			this.paymentToolStripMenuItem1.Name = "paymentToolStripMenuItem1";
			this.paymentToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.paymentToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
			this.paymentToolStripMenuItem1.Text = "Payment";
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
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.aboutToolStripMenuItem.Text = "About";
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
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(921, 437);
			this.tableLayoutPanel1.TabIndex = 12;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.clientList);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(8, 63);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(905, 366);
			this.panel4.TabIndex = 2;
			// 
			// clientList
			// 
			this.clientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.client,
            this.lastPayment,
            this.plan,
            this.trainer,
            this.comment});
			this.clientList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clientList.FullRowSelect = true;
			this.clientList.Location = new System.Drawing.Point(0, 0);
			this.clientList.MultiSelect = false;
			this.clientList.Name = "clientList";
			this.clientList.Size = new System.Drawing.Size(905, 366);
			this.clientList.TabIndex = 0;
			this.clientList.UseCompatibleStateImageBehavior = false;
			this.clientList.View = System.Windows.Forms.View.Details;
			// 
			// client
			// 
			this.client.Text = "Client";
			this.client.Width = 250;
			// 
			// lastPayment
			// 
			this.lastPayment.Text = "Last payment";
			this.lastPayment.Width = 160;
			// 
			// plan
			// 
			this.plan.Text = "Plan";
			this.plan.Width = 100;
			// 
			// trainer
			// 
			this.trainer.Text = "Trainer";
			this.trainer.Width = 140;
			// 
			// comment
			// 
			this.comment.Text = "Comment";
			this.comment.Width = 220;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_Search);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.export);
			this.panel1.Controls.Add(this.shedule);
			this.panel1.Controls.Add(this.payments);
			this.panel1.Controls.Add(this.edit);
			this.panel1.Controls.Add(this.remove);
			this.panel1.Controls.Add(this.add);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(905, 49);
			this.panel1.TabIndex = 5;
			// 
			// m_Search
			// 
			this.m_Search.AcceptsReturn = true;
			this.m_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.m_Search.Location = new System.Drawing.Point(447, 2);
			this.m_Search.Name = "m_Search";
			this.m_Search.Size = new System.Drawing.Size(454, 44);
			this.m_Search.TabIndex = 0;
			this.m_Search.TextChanged += new System.EventHandler(this.OnSearch);
			this.m_Search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnSearchKeyUp);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(324, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 37);
			this.label2.TabIndex = 6;
			this.label2.Text = "Search";
			// 
			// export
			// 
			this.export.Image = global::ClientDB.Properties.Resources._1367375035_filesave;
			this.export.Location = new System.Drawing.Point(270, 0);
			this.export.Name = "export";
			this.export.Size = new System.Drawing.Size(48, 48);
			this.export.TabIndex = 6;
			this.export.UseVisualStyleBackColor = true;
			// 
			// shedule
			// 
			this.shedule.Image = global::ClientDB.Properties.Resources._1367375242_schedule;
			this.shedule.Location = new System.Drawing.Point(216, 0);
			this.shedule.Name = "shedule";
			this.shedule.Size = new System.Drawing.Size(48, 48);
			this.shedule.TabIndex = 5;
			this.shedule.UseVisualStyleBackColor = true;
			// 
			// payments
			// 
			this.payments.Image = global::ClientDB.Properties.Resources._1367375158_coins;
			this.payments.Location = new System.Drawing.Point(162, 0);
			this.payments.Name = "payments";
			this.payments.Size = new System.Drawing.Size(48, 48);
			this.payments.TabIndex = 4;
			this.payments.UseVisualStyleBackColor = true;
			// 
			// edit
			// 
			this.edit.Image = global::ClientDB.Properties.Resources._1367375688_27_Edit_Text;
			this.edit.Location = new System.Drawing.Point(108, 0);
			this.edit.Name = "edit";
			this.edit.Size = new System.Drawing.Size(48, 48);
			this.edit.TabIndex = 3;
			this.edit.UseVisualStyleBackColor = true;
			// 
			// remove
			// 
			this.remove.Image = global::ClientDB.Properties.Resources._1367374751_edit_remove;
			this.remove.Location = new System.Drawing.Point(54, 0);
			this.remove.Name = "remove";
			this.remove.Size = new System.Drawing.Size(48, 48);
			this.remove.TabIndex = 2;
			this.remove.UseVisualStyleBackColor = true;
			// 
			// add
			// 
			this.add.Image = global::ClientDB.Properties.Resources._1367374740_edit_add;
			this.add.Location = new System.Drawing.Point(0, 0);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(48, 48);
			this.add.TabIndex = 1;
			this.add.UseVisualStyleBackColor = true;
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(188, 6);
			// 
			// manageClientsToolStripMenuItem
			// 
			this.manageClientsToolStripMenuItem.Name = "manageClientsToolStripMenuItem";
			this.manageClientsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.manageClientsToolStripMenuItem.Text = "Manage clients";
			this.manageClientsToolStripMenuItem.Click += new System.EventHandler(this.manageClientsToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(921, 461);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clients";
			this.Load += new System.EventHandler(this.OnLoad);
			this.Shown += new System.EventHandler(this.OnShown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem editPersonalDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView clientList;
        private System.Windows.Forms.ColumnHeader client;
        private System.Windows.Forms.ColumnHeader lastPayment;
        private System.Windows.Forms.ColumnHeader plan;
        private System.Windows.Forms.ColumnHeader trainer;
        private System.Windows.Forms.ColumnHeader comment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button shedule;
        private System.Windows.Forms.Button payments;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.TextBox m_Search;
        private System.Windows.Forms.Label label2;
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
    }
}

