namespace EAssistant
{
	partial class ManageClients
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
			System.Windows.Forms.GroupBox groupBox1;
			this.checkStartWith = new System.Windows.Forms.CheckBox();
			this.checkCode = new System.Windows.Forms.CheckBox();
			this.checkNames = new System.Windows.Forms.CheckBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.textToSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.gridClients = new System.Windows.Forms.DataGridView();
			this.tmpDataSet = new EAssistant.tmpDataSet();
			this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.clientsTableAdapter = new EAssistant.tmpDataSetTableAdapters.clientsTableAdapter();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scheduleDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scheduleTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastEnterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastLeaveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.openTicketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.trainerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.planDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hoursLeftDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridClients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tmpDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(this.checkStartWith);
			groupBox1.Controls.Add(this.checkCode);
			groupBox1.Controls.Add(this.checkNames);
			groupBox1.Controls.Add(this.btnSearch);
			groupBox1.Controls.Add(this.textToSearch);
			groupBox1.Controls.Add(this.label1);
			groupBox1.Location = new System.Drawing.Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(784, 56);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Search";
			// 
			// checkStartWith
			// 
			this.checkStartWith.AutoSize = true;
			this.checkStartWith.Location = new System.Drawing.Point(659, 23);
			this.checkStartWith.Name = "checkStartWith";
			this.checkStartWith.Size = new System.Drawing.Size(75, 17);
			this.checkStartWith.TabIndex = 4;
			this.checkStartWith.Text = "Starts with";
			this.checkStartWith.UseVisualStyleBackColor = true;
			// 
			// checkCode
			// 
			this.checkCode.AutoSize = true;
			this.checkCode.Checked = true;
			this.checkCode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkCode.Location = new System.Drawing.Point(552, 23);
			this.checkCode.Name = "checkCode";
			this.checkCode.Size = new System.Drawing.Size(101, 17);
			this.checkCode.TabIndex = 3;
			this.checkCode.Text = "Search by code";
			this.checkCode.UseVisualStyleBackColor = true;
			// 
			// checkNames
			// 
			this.checkNames.AutoSize = true;
			this.checkNames.Checked = true;
			this.checkNames.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkNames.Location = new System.Drawing.Point(433, 23);
			this.checkNames.Name = "checkNames";
			this.checkNames.Size = new System.Drawing.Size(105, 17);
			this.checkNames.TabIndex = 2;
			this.checkNames.Text = "Search in names";
			this.checkNames.UseVisualStyleBackColor = true;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(352, 19);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// textToSearch
			// 
			this.textToSearch.Location = new System.Drawing.Point(47, 21);
			this.textToSearch.Name = "textToSearch";
			this.textToSearch.Size = new System.Drawing.Size(299, 20);
			this.textToSearch.TabIndex = 0;
			this.textToSearch.TextChanged += new System.EventHandler(this.OnSearch);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Text";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(721, 387);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(640, 387);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// gridClients
			// 
			this.gridClients.AutoGenerateColumns = false;
			this.gridClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.scheduleDaysDataGridViewTextBoxColumn,
            this.scheduleTimeDataGridViewTextBoxColumn,
            this.lastEnterDataGridViewTextBoxColumn,
            this.lastLeaveDataGridViewTextBoxColumn,
            this.openTicketDataGridViewTextBoxColumn,
            this.trainerDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.planDataGridViewTextBoxColumn,
            this.hoursLeftDataGridViewTextBoxColumn});
			this.gridClients.DataSource = this.clientsBindingSource;
			this.gridClients.Location = new System.Drawing.Point(12, 74);
			this.gridClients.Name = "gridClients";
			this.gridClients.Size = new System.Drawing.Size(784, 302);
			this.gridClients.TabIndex = 5;
			this.gridClients.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.OnRemoveRow);
			this.gridClients.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.OnAddRow);
			// 
			// tmpDataSet
			// 
			this.tmpDataSet.DataSetName = "tmpDataSet";
			this.tmpDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// clientsBindingSource
			// 
			this.clientsBindingSource.DataMember = "clients";
			this.clientsBindingSource.DataSource = this.tmpDataSet;
			// 
			// clientsTableAdapter
			// 
			this.clientsTableAdapter.ClearBeforeFill = true;
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
			this.idDataGridViewTextBoxColumn.HeaderText = "id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.Visible = false;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// phoneDataGridViewTextBoxColumn
			// 
			this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
			this.phoneDataGridViewTextBoxColumn.HeaderText = "phone";
			this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
			this.phoneDataGridViewTextBoxColumn.Visible = false;
			// 
			// scheduleDaysDataGridViewTextBoxColumn
			// 
			this.scheduleDaysDataGridViewTextBoxColumn.DataPropertyName = "scheduleDays";
			this.scheduleDaysDataGridViewTextBoxColumn.HeaderText = "Days";
			this.scheduleDaysDataGridViewTextBoxColumn.Name = "scheduleDaysDataGridViewTextBoxColumn";
			// 
			// scheduleTimeDataGridViewTextBoxColumn
			// 
			this.scheduleTimeDataGridViewTextBoxColumn.DataPropertyName = "scheduleTime";
			this.scheduleTimeDataGridViewTextBoxColumn.HeaderText = "Time";
			this.scheduleTimeDataGridViewTextBoxColumn.Name = "scheduleTimeDataGridViewTextBoxColumn";
			// 
			// lastEnterDataGridViewTextBoxColumn
			// 
			this.lastEnterDataGridViewTextBoxColumn.DataPropertyName = "lastEnter";
			this.lastEnterDataGridViewTextBoxColumn.HeaderText = "Last enter";
			this.lastEnterDataGridViewTextBoxColumn.Name = "lastEnterDataGridViewTextBoxColumn";
			// 
			// lastLeaveDataGridViewTextBoxColumn
			// 
			this.lastLeaveDataGridViewTextBoxColumn.DataPropertyName = "lastLeave";
			this.lastLeaveDataGridViewTextBoxColumn.HeaderText = "lastLeave";
			this.lastLeaveDataGridViewTextBoxColumn.Name = "lastLeaveDataGridViewTextBoxColumn";
			this.lastLeaveDataGridViewTextBoxColumn.Visible = false;
			// 
			// openTicketDataGridViewTextBoxColumn
			// 
			this.openTicketDataGridViewTextBoxColumn.DataPropertyName = "openTicket";
			this.openTicketDataGridViewTextBoxColumn.HeaderText = "openTicket";
			this.openTicketDataGridViewTextBoxColumn.Name = "openTicketDataGridViewTextBoxColumn";
			this.openTicketDataGridViewTextBoxColumn.Visible = false;
			// 
			// trainerDataGridViewTextBoxColumn
			// 
			this.trainerDataGridViewTextBoxColumn.DataPropertyName = "trainer";
			this.trainerDataGridViewTextBoxColumn.HeaderText = "trainer";
			this.trainerDataGridViewTextBoxColumn.Name = "trainerDataGridViewTextBoxColumn";
			this.trainerDataGridViewTextBoxColumn.Visible = false;
			// 
			// commentDataGridViewTextBoxColumn
			// 
			this.commentDataGridViewTextBoxColumn.DataPropertyName = "comment";
			this.commentDataGridViewTextBoxColumn.HeaderText = "comment";
			this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
			this.commentDataGridViewTextBoxColumn.Visible = false;
			// 
			// planDataGridViewTextBoxColumn
			// 
			this.planDataGridViewTextBoxColumn.DataPropertyName = "plan";
			this.planDataGridViewTextBoxColumn.HeaderText = "Plan";
			this.planDataGridViewTextBoxColumn.Name = "planDataGridViewTextBoxColumn";
			// 
			// hoursLeftDataGridViewTextBoxColumn
			// 
			this.hoursLeftDataGridViewTextBoxColumn.DataPropertyName = "hoursLeft";
			this.hoursLeftDataGridViewTextBoxColumn.HeaderText = "Hours left";
			this.hoursLeftDataGridViewTextBoxColumn.Name = "hoursLeftDataGridViewTextBoxColumn";
			// 
			// ManageClients
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(808, 422);
			this.Controls.Add(this.gridClients);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageClients";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clients manager";
			this.Load += new System.EventHandler(this.OnLoad);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridClients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tmpDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkNames;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox textToSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkCode;
		private System.Windows.Forms.CheckBox checkStartWith;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.DataGridView gridClients;
		private tmpDataSet tmpDataSet;
		private System.Windows.Forms.BindingSource clientsBindingSource;
		private EAssistant.tmpDataSetTableAdapters.clientsTableAdapter clientsTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn scheduleDaysDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn scheduleTimeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastEnterDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastLeaveDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn openTicketDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn trainerDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn planDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn hoursLeftDataGridViewTextBoxColumn;
	}
}
