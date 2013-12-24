namespace EAssistant
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trainersScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshOpenedTicketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.manageClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.geterateBarcodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trainersScheduleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.manageTrainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.usersAndPasswordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openUserManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.sendLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabManager = new System.Windows.Forms.TabControl();
			this.tabActiveClients = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tabCalendar = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.todayClientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnSearch = new System.Windows.Forms.Button();
			this.btmMissLesson = new System.Windows.Forms.Button();
			this.btnBackUp = new System.Windows.Forms.Button();
			this.btnTrainersShedule = new System.Windows.Forms.Button();
			this.btnPaymentsHistory = new System.Windows.Forms.Button();
			this.btnClientManager = new System.Windows.Forms.Button();
			this.btnAddClient = new System.Windows.Forms.Button();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabManager.SuspendLayout();
			this.tabActiveClients.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.todayClientsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.AccessibleDescription = null;
			this.menuStrip1.AccessibleName = null;
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.BackgroundImage = null;
			this.menuStrip1.Font = null;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.trainersToolStripMenuItem,
            this.servicesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Name = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.AccessibleDescription = null;
			this.fileToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			this.fileToolStripMenuItem.BackgroundImage = null;
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.AccessibleDescription = null;
			this.importToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
			this.importToolStripMenuItem.BackgroundImage = null;
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.AccessibleDescription = null;
			this.exportToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
			this.exportToolStripMenuItem.BackgroundImage = null;
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.AccessibleDescription = null;
			this.toolStripMenuItem1.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.AccessibleDescription = null;
			this.exitToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
			this.exitToolStripMenuItem.BackgroundImage = null;
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.AccessibleDescription = null;
			this.viewToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
			this.viewToolStripMenuItem.BackgroundImage = null;
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentsToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.trainersScheduleToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// paymentsToolStripMenuItem
			// 
			this.paymentsToolStripMenuItem.AccessibleDescription = null;
			this.paymentsToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.paymentsToolStripMenuItem, "paymentsToolStripMenuItem");
			this.paymentsToolStripMenuItem.BackgroundImage = null;
			this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
			this.paymentsToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
			// 
			// scheduleToolStripMenuItem
			// 
			this.scheduleToolStripMenuItem.AccessibleDescription = null;
			this.scheduleToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.scheduleToolStripMenuItem, "scheduleToolStripMenuItem");
			this.scheduleToolStripMenuItem.BackgroundImage = null;
			this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
			this.scheduleToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// trainersScheduleToolStripMenuItem
			// 
			this.trainersScheduleToolStripMenuItem.AccessibleDescription = null;
			this.trainersScheduleToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.trainersScheduleToolStripMenuItem, "trainersScheduleToolStripMenuItem");
			this.trainersScheduleToolStripMenuItem.BackgroundImage = null;
			this.trainersScheduleToolStripMenuItem.Name = "trainersScheduleToolStripMenuItem";
			this.trainersScheduleToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// clientToolStripMenuItem
			// 
			this.clientToolStripMenuItem.AccessibleDescription = null;
			this.clientToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.clientToolStripMenuItem, "clientToolStripMenuItem");
			this.clientToolStripMenuItem.BackgroundImage = null;
			this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshOpenedTicketsToolStripMenuItem,
            this.clientSearchToolStripMenuItem,
            this.addToolStripMenuItem,
            this.toolStripMenuItem5,
            this.manageClientsToolStripMenuItem,
            this.toolStripMenuItem6,
            this.geterateBarcodesToolStripMenuItem});
			this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
			this.clientToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// refreshOpenedTicketsToolStripMenuItem
			// 
			this.refreshOpenedTicketsToolStripMenuItem.AccessibleDescription = null;
			this.refreshOpenedTicketsToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.refreshOpenedTicketsToolStripMenuItem, "refreshOpenedTicketsToolStripMenuItem");
			this.refreshOpenedTicketsToolStripMenuItem.BackgroundImage = null;
			this.refreshOpenedTicketsToolStripMenuItem.Name = "refreshOpenedTicketsToolStripMenuItem";
			this.refreshOpenedTicketsToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.refreshOpenedTicketsToolStripMenuItem.Click += new System.EventHandler(this.refreshOpenedTicketsToolStripMenuItem_Click);
			// 
			// clientSearchToolStripMenuItem
			// 
			this.clientSearchToolStripMenuItem.AccessibleDescription = null;
			this.clientSearchToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.clientSearchToolStripMenuItem, "clientSearchToolStripMenuItem");
			this.clientSearchToolStripMenuItem.BackgroundImage = null;
			this.clientSearchToolStripMenuItem.Name = "clientSearchToolStripMenuItem";
			this.clientSearchToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.clientSearchToolStripMenuItem.Click += new System.EventHandler(this.clientSearchToolStripMenuItem_Click);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.AccessibleDescription = null;
			this.addToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
			this.addToolStripMenuItem.BackgroundImage = null;
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.AccessibleDescription = null;
			this.toolStripMenuItem5.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			// 
			// manageClientsToolStripMenuItem
			// 
			this.manageClientsToolStripMenuItem.AccessibleDescription = null;
			this.manageClientsToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.manageClientsToolStripMenuItem, "manageClientsToolStripMenuItem");
			this.manageClientsToolStripMenuItem.BackgroundImage = null;
			this.manageClientsToolStripMenuItem.Name = "manageClientsToolStripMenuItem";
			this.manageClientsToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.manageClientsToolStripMenuItem.Click += new System.EventHandler(this.manageClientsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.AccessibleDescription = null;
			this.toolStripMenuItem6.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			// 
			// geterateBarcodesToolStripMenuItem
			// 
			this.geterateBarcodesToolStripMenuItem.AccessibleDescription = null;
			this.geterateBarcodesToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.geterateBarcodesToolStripMenuItem, "geterateBarcodesToolStripMenuItem");
			this.geterateBarcodesToolStripMenuItem.BackgroundImage = null;
			this.geterateBarcodesToolStripMenuItem.Name = "geterateBarcodesToolStripMenuItem";
			this.geterateBarcodesToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.geterateBarcodesToolStripMenuItem.Click += new System.EventHandler(this.geterateBarcodesToolStripMenuItem_Click);
			// 
			// trainersToolStripMenuItem
			// 
			this.trainersToolStripMenuItem.AccessibleDescription = null;
			this.trainersToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.trainersToolStripMenuItem, "trainersToolStripMenuItem");
			this.trainersToolStripMenuItem.BackgroundImage = null;
			this.trainersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageTrainersToolStripMenuItem,
            this.toolStripMenuItem8,
            this.trainersScheduleToolStripMenuItem1});
			this.trainersToolStripMenuItem.Name = "trainersToolStripMenuItem";
			this.trainersToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// trainersScheduleToolStripMenuItem1
			// 
			this.trainersScheduleToolStripMenuItem1.AccessibleDescription = null;
			this.trainersScheduleToolStripMenuItem1.AccessibleName = null;
			resources.ApplyResources(this.trainersScheduleToolStripMenuItem1, "trainersScheduleToolStripMenuItem1");
			this.trainersScheduleToolStripMenuItem1.BackgroundImage = null;
			this.trainersScheduleToolStripMenuItem1.Name = "trainersScheduleToolStripMenuItem1";
			this.trainersScheduleToolStripMenuItem1.ShortcutKeyDisplayString = null;
			this.trainersScheduleToolStripMenuItem1.Click += new System.EventHandler(this.btnTrainersShedule_Click);
			// 
			// manageTrainersToolStripMenuItem
			// 
			this.manageTrainersToolStripMenuItem.AccessibleDescription = null;
			this.manageTrainersToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.manageTrainersToolStripMenuItem, "manageTrainersToolStripMenuItem");
			this.manageTrainersToolStripMenuItem.BackgroundImage = null;
			this.manageTrainersToolStripMenuItem.Name = "manageTrainersToolStripMenuItem";
			this.manageTrainersToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.manageTrainersToolStripMenuItem.Click += new System.EventHandler(this.manageTrainersToolStripMenuItem_Click);
			// 
			// servicesToolStripMenuItem
			// 
			this.servicesToolStripMenuItem.AccessibleDescription = null;
			this.servicesToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.servicesToolStripMenuItem, "servicesToolStripMenuItem");
			this.servicesToolStripMenuItem.BackgroundImage = null;
			this.servicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageServicesToolStripMenuItem});
			this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
			this.servicesToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// manageServicesToolStripMenuItem
			// 
			this.manageServicesToolStripMenuItem.AccessibleDescription = null;
			this.manageServicesToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.manageServicesToolStripMenuItem, "manageServicesToolStripMenuItem");
			this.manageServicesToolStripMenuItem.BackgroundImage = null;
			this.manageServicesToolStripMenuItem.Name = "manageServicesToolStripMenuItem";
			this.manageServicesToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.manageServicesToolStripMenuItem.Click += new System.EventHandler(this.manageServicesToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.AccessibleDescription = null;
			this.settingsToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
			this.settingsToolStripMenuItem.BackgroundImage = null;
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.toolStripMenuItem2,
            this.usersAndPasswordsToolStripMenuItem,
            this.userRolesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.optionsToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// changePasswordToolStripMenuItem
			// 
			this.changePasswordToolStripMenuItem.AccessibleDescription = null;
			this.changePasswordToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.changePasswordToolStripMenuItem, "changePasswordToolStripMenuItem");
			this.changePasswordToolStripMenuItem.BackgroundImage = null;
			this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
			this.changePasswordToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.AccessibleDescription = null;
			this.toolStripMenuItem2.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			// 
			// usersAndPasswordsToolStripMenuItem
			// 
			this.usersAndPasswordsToolStripMenuItem.AccessibleDescription = null;
			this.usersAndPasswordsToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.usersAndPasswordsToolStripMenuItem, "usersAndPasswordsToolStripMenuItem");
			this.usersAndPasswordsToolStripMenuItem.BackgroundImage = null;
			this.usersAndPasswordsToolStripMenuItem.Name = "usersAndPasswordsToolStripMenuItem";
			this.usersAndPasswordsToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.usersAndPasswordsToolStripMenuItem.Click += new System.EventHandler(this.usersAndPasswordsToolStripMenuItem_Click);
			// 
			// userRolesToolStripMenuItem
			// 
			this.userRolesToolStripMenuItem.AccessibleDescription = null;
			this.userRolesToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.userRolesToolStripMenuItem, "userRolesToolStripMenuItem");
			this.userRolesToolStripMenuItem.BackgroundImage = null;
			this.userRolesToolStripMenuItem.Name = "userRolesToolStripMenuItem";
			this.userRolesToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.userRolesToolStripMenuItem.Click += new System.EventHandler(this.userRolesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.AccessibleDescription = null;
			this.toolStripMenuItem3.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.AccessibleDescription = null;
			this.optionsToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
			this.optionsToolStripMenuItem.BackgroundImage = null;
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.AccessibleDescription = null;
			this.helpToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
			this.helpToolStripMenuItem.BackgroundImage = null;
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openUserManualToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem7,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.sendLogToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.ShortcutKeyDisplayString = null;
			// 
			// openUserManualToolStripMenuItem
			// 
			this.openUserManualToolStripMenuItem.AccessibleDescription = null;
			this.openUserManualToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.openUserManualToolStripMenuItem, "openUserManualToolStripMenuItem");
			this.openUserManualToolStripMenuItem.BackgroundImage = null;
			this.openUserManualToolStripMenuItem.Name = "openUserManualToolStripMenuItem";
			this.openUserManualToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.openUserManualToolStripMenuItem.Click += new System.EventHandler(this.openUserManualToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.AccessibleDescription = null;
			this.aboutToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
			this.aboutToolStripMenuItem.BackgroundImage = null;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.AccessibleDescription = null;
			this.toolStripMenuItem7.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			// 
			// checkForUpdatesToolStripMenuItem
			// 
			this.checkForUpdatesToolStripMenuItem.AccessibleDescription = null;
			this.checkForUpdatesToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.checkForUpdatesToolStripMenuItem, "checkForUpdatesToolStripMenuItem");
			this.checkForUpdatesToolStripMenuItem.BackgroundImage = null;
			this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			this.checkForUpdatesToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.AccessibleDescription = null;
			this.toolStripMenuItem4.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			// 
			// sendLogToolStripMenuItem
			// 
			this.sendLogToolStripMenuItem.AccessibleDescription = null;
			this.sendLogToolStripMenuItem.AccessibleName = null;
			resources.ApplyResources(this.sendLogToolStripMenuItem, "sendLogToolStripMenuItem");
			this.sendLogToolStripMenuItem.BackgroundImage = null;
			this.sendLogToolStripMenuItem.Name = "sendLogToolStripMenuItem";
			this.sendLogToolStripMenuItem.ShortcutKeyDisplayString = null;
			this.sendLogToolStripMenuItem.Click += new System.EventHandler(this.sendLogToolStripMenuItem_Click);
			// 
			// panel2
			// 
			this.panel2.AccessibleDescription = null;
			this.panel2.AccessibleName = null;
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.BackgroundImage = null;
			this.panel2.Font = null;
			this.panel2.Name = "panel2";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AccessibleDescription = null;
			this.tableLayoutPanel1.AccessibleName = null;
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.BackgroundImage = null;
			this.tableLayoutPanel1.Controls.Add(this.tabManager, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Font = null;
			this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// tabManager
			// 
			this.tabManager.AccessibleDescription = null;
			this.tabManager.AccessibleName = null;
			resources.ApplyResources(this.tabManager, "tabManager");
			this.tabManager.BackgroundImage = null;
			this.tabManager.Controls.Add(this.tabActiveClients);
			this.tabManager.Controls.Add(this.tabCalendar);
			this.tabManager.Font = null;
			this.tabManager.Name = "tabManager";
			this.tabManager.SelectedIndex = 0;
			// 
			// tabActiveClients
			// 
			this.tabActiveClients.AccessibleDescription = null;
			this.tabActiveClients.AccessibleName = null;
			resources.ApplyResources(this.tabActiveClients, "tabActiveClients");
			this.tabActiveClients.BackgroundImage = null;
			this.tabActiveClients.Controls.Add(this.dataGridView1);
			this.tabActiveClients.Font = null;
			this.tabActiveClients.Name = "tabActiveClients";
			this.tabActiveClients.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AccessibleDescription = null;
			this.dataGridView1.AccessibleName = null;
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			resources.ApplyResources(this.dataGridView1, "dataGridView1");
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.BackgroundImage = null;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.DataSource = this.todayClientsBindingSource;
			this.dataGridView1.Font = null;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.ShowCellErrors = false;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowClientInfo);
			// 
			// tabCalendar
			// 
			this.tabCalendar.AccessibleDescription = null;
			this.tabCalendar.AccessibleName = null;
			resources.ApplyResources(this.tabCalendar, "tabCalendar");
			this.tabCalendar.BackgroundImage = null;
			this.tabCalendar.Font = null;
			this.tabCalendar.Name = "tabCalendar";
			// 
			// panel1
			// 
			this.panel1.AccessibleDescription = null;
			this.panel1.AccessibleName = null;
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.BackgroundImage = null;
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Controls.Add(this.btmMissLesson);
			this.panel1.Controls.Add(this.btnBackUp);
			this.panel1.Controls.Add(this.btnTrainersShedule);
			this.panel1.Controls.Add(this.btnPaymentsHistory);
			this.panel1.Controls.Add(this.btnClientManager);
			this.panel1.Controls.Add(this.btnAddClient);
			this.panel1.Font = null;
			this.panel1.Name = "panel1";
			// 
			// todayClientsBindingSource
			// 
			this.todayClientsBindingSource.DataMember = "TodayClients";
			// 
			// btnSearch
			// 
			this.btnSearch.AccessibleDescription = null;
			this.btnSearch.AccessibleName = null;
			resources.ApplyResources(this.btnSearch, "btnSearch");
			this.btnSearch.BackgroundImage = null;
			this.btnSearch.Font = null;
			this.btnSearch.Image = global::EAssistant.Properties.Resources.search;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btmMissLesson
			// 
			this.btmMissLesson.AccessibleDescription = null;
			this.btmMissLesson.AccessibleName = null;
			resources.ApplyResources(this.btmMissLesson, "btmMissLesson");
			this.btmMissLesson.BackgroundImage = null;
			this.btmMissLesson.Font = null;
			this.btmMissLesson.Image = global::EAssistant.Properties.Resources.appointment_missed;
			this.btmMissLesson.Name = "btmMissLesson";
			this.btmMissLesson.UseVisualStyleBackColor = true;
			this.btmMissLesson.Click += new System.EventHandler(this.btmMissLesson_Click);
			// 
			// btnBackUp
			// 
			this.btnBackUp.AccessibleDescription = null;
			this.btnBackUp.AccessibleName = null;
			resources.ApplyResources(this.btnBackUp, "btnBackUp");
			this.btnBackUp.BackgroundImage = null;
			this.btnBackUp.Font = null;
			this.btnBackUp.Image = global::EAssistant.Properties.Resources._1367375035_filesave;
			this.btnBackUp.Name = "btnBackUp";
			this.btnBackUp.UseVisualStyleBackColor = true;
			this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
			// 
			// btnTrainersShedule
			// 
			this.btnTrainersShedule.AccessibleDescription = null;
			this.btnTrainersShedule.AccessibleName = null;
			resources.ApplyResources(this.btnTrainersShedule, "btnTrainersShedule");
			this.btnTrainersShedule.BackgroundImage = null;
			this.btnTrainersShedule.Font = null;
			this.btnTrainersShedule.Image = global::EAssistant.Properties.Resources._1367375242_schedule;
			this.btnTrainersShedule.Name = "btnTrainersShedule";
			this.btnTrainersShedule.UseVisualStyleBackColor = true;
			this.btnTrainersShedule.Click += new System.EventHandler(this.btnTrainersShedule_Click);
			// 
			// btnPaymentsHistory
			// 
			this.btnPaymentsHistory.AccessibleDescription = null;
			this.btnPaymentsHistory.AccessibleName = null;
			resources.ApplyResources(this.btnPaymentsHistory, "btnPaymentsHistory");
			this.btnPaymentsHistory.BackgroundImage = null;
			this.btnPaymentsHistory.Font = null;
			this.btnPaymentsHistory.Image = global::EAssistant.Properties.Resources._1367375158_coins;
			this.btnPaymentsHistory.Name = "btnPaymentsHistory";
			this.btnPaymentsHistory.UseVisualStyleBackColor = true;
			this.btnPaymentsHistory.Click += new System.EventHandler(this.btnPaymentsHistory_Click);
			// 
			// btnClientManager
			// 
			this.btnClientManager.AccessibleDescription = null;
			this.btnClientManager.AccessibleName = null;
			resources.ApplyResources(this.btnClientManager, "btnClientManager");
			this.btnClientManager.BackgroundImage = null;
			this.btnClientManager.Font = null;
			this.btnClientManager.Image = global::EAssistant.Properties.Resources._1367375688_27_Edit_Text;
			this.btnClientManager.Name = "btnClientManager";
			this.btnClientManager.UseVisualStyleBackColor = true;
			this.btnClientManager.Click += new System.EventHandler(this.btnClientManager_Click);
			// 
			// btnAddClient
			// 
			this.btnAddClient.AccessibleDescription = null;
			this.btnAddClient.AccessibleName = null;
			resources.ApplyResources(this.btnAddClient, "btnAddClient");
			this.btnAddClient.BackgroundImage = null;
			this.btnAddClient.Font = null;
			this.btnAddClient.Image = global::EAssistant.Properties.Resources._1367374740_edit_add;
			this.btnAddClient.Name = "btnAddClient";
			this.btnAddClient.UseVisualStyleBackColor = true;
			this.btnAddClient.Click += new System.EventHandler(this.add_Click);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.AccessibleDescription = null;
			this.toolStripMenuItem8.AccessibleName = null;
			resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			// 
			// MainForm
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.Font = null;
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tabManager.ResumeLayout(false);
			this.tabActiveClients.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.todayClientsBindingSource)).EndInit();
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
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem manageClientsToolStripMenuItem;
		private System.Windows.Forms.Button btnClientManager;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TabControl tabManager;
		private System.Windows.Forms.TabPage tabCalendar;
		private System.Windows.Forms.TabPage tabActiveClients;
		private System.Windows.Forms.Button btmMissLesson;
		private System.Windows.Forms.ToolStripMenuItem trainersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem trainersScheduleToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem manageTrainersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clientSearchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem geterateBarcodesToolStripMenuItem;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource todayClientsBindingSource;
		private System.Windows.Forms.ToolStripMenuItem refreshOpenedTicketsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openUserManualToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manageServicesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem sendLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
    }
}

