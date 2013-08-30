﻿namespace GAssistant
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
			this.clientSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.manageClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trainersScheduleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.manageTrainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.usersAndPasswordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.manageScheduleRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sendLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabManager = new System.Windows.Forms.TabControl();
			this.tabActiveClients = new System.Windows.Forms.TabPage();
			this.listClients = new System.Windows.Forms.ListView();
			this.columnClient = new System.Windows.Forms.ColumnHeader();
			this.columnStatus = new System.Windows.Forms.ColumnHeader();
			this.columnEnter = new System.Windows.Forms.ColumnHeader();
			this.columnLeave = new System.Windows.Forms.ColumnHeader();
			this.columnEntarncesLeft = new System.Windows.Forms.ColumnHeader();
			this.tabCalendar = new System.Windows.Forms.TabPage();
			this.m_calendar = new GAssistant.DayView();
			this.tabStatistics = new System.Windows.Forms.TabPage();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btmMissLesson = new System.Windows.Forms.Button();
			this.btnBackUp = new System.Windows.Forms.Button();
			this.btnTrainersShedule = new System.Windows.Forms.Button();
			this.btnPaymentsHistory = new System.Windows.Forms.Button();
			this.btnClientManager = new System.Windows.Forms.Button();
			this.btnAddClient = new System.Windows.Forms.Button();
			this.geterateBarcodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabManager.SuspendLayout();
			this.tabActiveClients.SuspendLayout();
			this.tabCalendar.SuspendLayout();
			this.tabStatistics.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.trainersToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
			this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentsToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.trainersScheduleToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
			// 
			// paymentsToolStripMenuItem
			// 
			this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
			resources.ApplyResources(this.paymentsToolStripMenuItem, "paymentsToolStripMenuItem");
			this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
			// 
			// scheduleToolStripMenuItem
			// 
			this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
			resources.ApplyResources(this.scheduleToolStripMenuItem, "scheduleToolStripMenuItem");
			// 
			// trainersScheduleToolStripMenuItem
			// 
			this.trainersScheduleToolStripMenuItem.Name = "trainersScheduleToolStripMenuItem";
			resources.ApplyResources(this.trainersScheduleToolStripMenuItem, "trainersScheduleToolStripMenuItem");
			// 
			// clientToolStripMenuItem
			// 
			this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientSearchToolStripMenuItem,
            this.addToolStripMenuItem,
            this.toolStripMenuItem5,
            this.manageClientsToolStripMenuItem,
            this.toolStripMenuItem6,
            this.geterateBarcodesToolStripMenuItem});
			this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
			resources.ApplyResources(this.clientToolStripMenuItem, "clientToolStripMenuItem");
			// 
			// clientSearchToolStripMenuItem
			// 
			this.clientSearchToolStripMenuItem.Name = "clientSearchToolStripMenuItem";
			resources.ApplyResources(this.clientSearchToolStripMenuItem, "clientSearchToolStripMenuItem");
			this.clientSearchToolStripMenuItem.Click += new System.EventHandler(this.clientSearchToolStripMenuItem_Click);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
			this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
			// 
			// manageClientsToolStripMenuItem
			// 
			this.manageClientsToolStripMenuItem.Name = "manageClientsToolStripMenuItem";
			resources.ApplyResources(this.manageClientsToolStripMenuItem, "manageClientsToolStripMenuItem");
			this.manageClientsToolStripMenuItem.Click += new System.EventHandler(this.manageClientsToolStripMenuItem_Click);
			// 
			// trainersToolStripMenuItem
			// 
			this.trainersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainersScheduleToolStripMenuItem1,
            this.manageTrainersToolStripMenuItem});
			this.trainersToolStripMenuItem.Name = "trainersToolStripMenuItem";
			resources.ApplyResources(this.trainersToolStripMenuItem, "trainersToolStripMenuItem");
			// 
			// trainersScheduleToolStripMenuItem1
			// 
			this.trainersScheduleToolStripMenuItem1.Name = "trainersScheduleToolStripMenuItem1";
			resources.ApplyResources(this.trainersScheduleToolStripMenuItem1, "trainersScheduleToolStripMenuItem1");
			this.trainersScheduleToolStripMenuItem1.Click += new System.EventHandler(this.btnTrainersShedule_Click);
			// 
			// manageTrainersToolStripMenuItem
			// 
			this.manageTrainersToolStripMenuItem.Name = "manageTrainersToolStripMenuItem";
			resources.ApplyResources(this.manageTrainersToolStripMenuItem, "manageTrainersToolStripMenuItem");
			this.manageTrainersToolStripMenuItem.Click += new System.EventHandler(this.manageTrainersToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.toolStripMenuItem2,
            this.usersAndPasswordsToolStripMenuItem,
            this.userRolesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.manageScheduleRulesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.optionsToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
			// 
			// changePasswordToolStripMenuItem
			// 
			this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
			resources.ApplyResources(this.changePasswordToolStripMenuItem, "changePasswordToolStripMenuItem");
			this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
			// 
			// usersAndPasswordsToolStripMenuItem
			// 
			this.usersAndPasswordsToolStripMenuItem.Name = "usersAndPasswordsToolStripMenuItem";
			resources.ApplyResources(this.usersAndPasswordsToolStripMenuItem, "usersAndPasswordsToolStripMenuItem");
			this.usersAndPasswordsToolStripMenuItem.Click += new System.EventHandler(this.usersAndPasswordsToolStripMenuItem_Click);
			// 
			// userRolesToolStripMenuItem
			// 
			this.userRolesToolStripMenuItem.Name = "userRolesToolStripMenuItem";
			resources.ApplyResources(this.userRolesToolStripMenuItem, "userRolesToolStripMenuItem");
			this.userRolesToolStripMenuItem.Click += new System.EventHandler(this.userRolesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
			// 
			// manageScheduleRulesToolStripMenuItem
			// 
			this.manageScheduleRulesToolStripMenuItem.Name = "manageScheduleRulesToolStripMenuItem";
			resources.ApplyResources(this.manageScheduleRulesToolStripMenuItem, "manageScheduleRulesToolStripMenuItem");
			this.manageScheduleRulesToolStripMenuItem.Click += new System.EventHandler(this.manageScheduleRulesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.sendLogToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// sendLogToolStripMenuItem
			// 
			this.sendLogToolStripMenuItem.Name = "sendLogToolStripMenuItem";
			resources.ApplyResources(this.sendLogToolStripMenuItem, "sendLogToolStripMenuItem");
			// 
			// panel2
			// 
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.tabManager, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// tabManager
			// 
			resources.ApplyResources(this.tabManager, "tabManager");
			this.tabManager.Controls.Add(this.tabActiveClients);
			this.tabManager.Controls.Add(this.tabCalendar);
			this.tabManager.Controls.Add(this.tabStatistics);
			this.tabManager.Name = "tabManager";
			this.tabManager.SelectedIndex = 0;
			// 
			// tabActiveClients
			// 
			this.tabActiveClients.Controls.Add(this.listClients);
			resources.ApplyResources(this.tabActiveClients, "tabActiveClients");
			this.tabActiveClients.Name = "tabActiveClients";
			this.tabActiveClients.UseVisualStyleBackColor = true;
			// 
			// listClients
			// 
			this.listClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnClient,
            this.columnStatus,
            this.columnEnter,
            this.columnLeave,
            this.columnEntarncesLeft});
			resources.ApplyResources(this.listClients, "listClients");
			this.listClients.FullRowSelect = true;
			this.listClients.GridLines = true;
			this.listClients.HideSelection = false;
			this.listClients.MultiSelect = false;
			this.listClients.Name = "listClients";
			this.listClients.UseCompatibleStateImageBehavior = false;
			this.listClients.View = System.Windows.Forms.View.Details;
			this.listClients.DoubleClick += new System.EventHandler(this.ShowClientInfo);
			// 
			// columnClient
			// 
			resources.ApplyResources(this.columnClient, "columnClient");
			// 
			// columnStatus
			// 
			resources.ApplyResources(this.columnStatus, "columnStatus");
			// 
			// columnEnter
			// 
			resources.ApplyResources(this.columnEnter, "columnEnter");
			// 
			// columnLeave
			// 
			resources.ApplyResources(this.columnLeave, "columnLeave");
			// 
			// columnEntarncesLeft
			// 
			resources.ApplyResources(this.columnEntarncesLeft, "columnEntarncesLeft");
			// 
			// tabCalendar
			// 
			this.tabCalendar.Controls.Add(this.m_calendar);
			resources.ApplyResources(this.tabCalendar, "tabCalendar");
			this.tabCalendar.Name = "tabCalendar";
			this.tabCalendar.UseVisualStyleBackColor = true;
			// 
			// m_calendar
			// 
			this.m_calendar.ActiveTool = null;
			this.m_calendar.BgColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(246)))));
			this.m_calendar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(this.m_calendar, "m_calendar");
			this.m_calendar.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(246)))));
			this.m_calendar.HeaderBgColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(186)))), ((int)(((byte)(201)))));
			this.m_calendar.HorisontalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.m_calendar.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.m_calendar.Name = "m_calendar";
			this.m_calendar.SelectedDate = new System.DateTime(((long)(0)));
			this.m_calendar.SelectionBorderColor = System.Drawing.SystemColors.ActiveBorder;
			this.m_calendar.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
			this.m_calendar.StartDate = new System.DateTime(2013, 8, 13, 0, 0, 0, 0);
			this.m_calendar.VerticalLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
			// 
			// tabStatistics
			// 
			this.tabStatistics.Controls.Add(this.chart1);
			resources.ApplyResources(this.tabStatistics, "tabStatistics");
			this.tabStatistics.Name = "tabStatistics";
			this.tabStatistics.UseVisualStyleBackColor = true;
			// 
			// chart1
			// 
			chartArea1.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
			chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			resources.ApplyResources(this.chart1, "chart1");
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series1.Color = System.Drawing.Color.Blue;
			series1.IsXValueIndexed = true;
			series1.Legend = "Legend1";
			series1.LegendText = "Present";
			series1.Name = "seriesPresent";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series2.Color = System.Drawing.Color.Red;
			series2.IsXValueIndexed = true;
			series2.Legend = "Legend1";
			series2.LegendText = "Prognose";
			series2.Name = "seriesPrognosed";
			series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
			series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
			this.chart1.Series.Add(series1);
			this.chart1.Series.Add(series2);
			this.chart1.PrePaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.FillChart);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btmMissLesson);
			this.panel1.Controls.Add(this.btnBackUp);
			this.panel1.Controls.Add(this.btnTrainersShedule);
			this.panel1.Controls.Add(this.btnPaymentsHistory);
			this.panel1.Controls.Add(this.btnClientManager);
			this.panel1.Controls.Add(this.btnAddClient);
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			// 
			// btmMissLesson
			// 
			this.btmMissLesson.Image = global::GAssistant.Properties.Resources.appointment_missed;
			resources.ApplyResources(this.btmMissLesson, "btmMissLesson");
			this.btmMissLesson.Name = "btmMissLesson";
			this.btmMissLesson.UseVisualStyleBackColor = true;
			this.btmMissLesson.Click += new System.EventHandler(this.btmMissLesson_Click);
			// 
			// btnBackUp
			// 
			this.btnBackUp.Image = global::GAssistant.Properties.Resources._1367375035_filesave;
			resources.ApplyResources(this.btnBackUp, "btnBackUp");
			this.btnBackUp.Name = "btnBackUp";
			this.btnBackUp.UseVisualStyleBackColor = true;
			this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
			// 
			// btnTrainersShedule
			// 
			this.btnTrainersShedule.Image = global::GAssistant.Properties.Resources._1367375242_schedule;
			resources.ApplyResources(this.btnTrainersShedule, "btnTrainersShedule");
			this.btnTrainersShedule.Name = "btnTrainersShedule";
			this.btnTrainersShedule.UseVisualStyleBackColor = true;
			this.btnTrainersShedule.Click += new System.EventHandler(this.btnTrainersShedule_Click);
			// 
			// btnPaymentsHistory
			// 
			this.btnPaymentsHistory.Image = global::GAssistant.Properties.Resources._1367375158_coins;
			resources.ApplyResources(this.btnPaymentsHistory, "btnPaymentsHistory");
			this.btnPaymentsHistory.Name = "btnPaymentsHistory";
			this.btnPaymentsHistory.UseVisualStyleBackColor = true;
			this.btnPaymentsHistory.Click += new System.EventHandler(this.btnPaymentsHistory_Click);
			// 
			// btnClientManager
			// 
			this.btnClientManager.Image = global::GAssistant.Properties.Resources._1367375688_27_Edit_Text;
			resources.ApplyResources(this.btnClientManager, "btnClientManager");
			this.btnClientManager.Name = "btnClientManager";
			this.btnClientManager.UseVisualStyleBackColor = true;
			this.btnClientManager.Click += new System.EventHandler(this.btnClientManager_Click);
			// 
			// btnAddClient
			// 
			this.btnAddClient.Image = global::GAssistant.Properties.Resources._1367374740_edit_add;
			resources.ApplyResources(this.btnAddClient, "btnAddClient");
			this.btnAddClient.Name = "btnAddClient";
			this.btnAddClient.UseVisualStyleBackColor = true;
			this.btnAddClient.Click += new System.EventHandler(this.add_Click);
			// 
			// geterateBarcodesToolStripMenuItem
			// 
			this.geterateBarcodesToolStripMenuItem.Name = "geterateBarcodesToolStripMenuItem";
			resources.ApplyResources(this.geterateBarcodesToolStripMenuItem, "geterateBarcodesToolStripMenuItem");
			this.geterateBarcodesToolStripMenuItem.Click += new System.EventHandler(this.geterateBarcodesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tabManager.ResumeLayout(false);
			this.tabActiveClients.ResumeLayout(false);
			this.tabCalendar.ResumeLayout(false);
			this.tabStatistics.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
		private System.Windows.Forms.ToolStripMenuItem manageScheduleRulesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem manageClientsToolStripMenuItem;
		private System.Windows.Forms.Button btnClientManager;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStripMenuItem sendLogToolStripMenuItem;
		private System.Windows.Forms.TabControl tabManager;
		private System.Windows.Forms.ListView listClients;
		private System.Windows.Forms.ColumnHeader columnClient;
		private System.Windows.Forms.ColumnHeader columnStatus;
		private System.Windows.Forms.ColumnHeader columnEnter;
		private System.Windows.Forms.ColumnHeader columnLeave;
		private System.Windows.Forms.ColumnHeader columnEntarncesLeft;
		private DayView m_calendar;
		private System.Windows.Forms.TabPage tabCalendar;
		private System.Windows.Forms.TabPage tabStatistics;
		private System.Windows.Forms.TabPage tabActiveClients;
		private System.Windows.Forms.Button btmMissLesson;
		private System.Windows.Forms.ToolStripMenuItem trainersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem trainersScheduleToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem manageTrainersToolStripMenuItem;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.ToolStripMenuItem clientSearchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem geterateBarcodesToolStripMenuItem;
    }
}

