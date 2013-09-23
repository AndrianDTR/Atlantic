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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.checkStartWith = new System.Windows.Forms.CheckBox();
			this.checkCode = new System.Windows.Forms.CheckBox();
			this.checkNames = new System.Windows.Forms.CheckBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.textToSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.gridClients = new System.Windows.Forms.DataGridView();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.clientDataSet = new EAssistant.clientDataSet();
			this.clientsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.clientsListTableAdapter = new EAssistant.clientDataSetTableAdapters.clientsListTableAdapter();
			this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLastEnter = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTimesLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colScheduleTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridClients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientsListBindingSource)).BeginInit();
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
			// gridClients
			// 
			this.gridClients.AllowUserToAddRows = false;
			this.gridClients.AllowUserToDeleteRows = false;
			this.gridClients.AllowUserToResizeRows = false;
			this.gridClients.AutoGenerateColumns = false;
			this.gridClients.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.gridClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colLastEnter,
            this.colTimesLeft,
            this.colScheduleTime});
			this.gridClients.DataSource = this.clientsListBindingSource;
			this.gridClients.Location = new System.Drawing.Point(12, 74);
			this.gridClients.MultiSelect = false;
			this.gridClients.Name = "gridClients";
			this.gridClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridClients.Size = new System.Drawing.Size(784, 307);
			this.gridClients.TabIndex = 0;
			this.gridClients.DoubleClick += new System.EventHandler(this.OnEdit);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(12, 387);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(93, 387);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(174, 387);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 23);
			this.btnRemove.TabIndex = 3;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(721, 387);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// clientDataSet
			// 
			this.clientDataSet.DataSetName = "clientDataSet";
			this.clientDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// clientsListBindingSource
			// 
			this.clientsListBindingSource.DataMember = "clientsList";
			this.clientsListBindingSource.DataSource = this.clientDataSet;
			// 
			// clientsListTableAdapter
			// 
			this.clientsListTableAdapter.ClearBeforeFill = true;
			// 
			// colId
			// 
			this.colId.DataPropertyName = "id";
			this.colId.Frozen = true;
			this.colId.HeaderText = "Id";
			this.colId.Name = "colId";
			// 
			// colName
			// 
			this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colName.DataPropertyName = "name";
			this.colName.HeaderText = "Name";
			this.colName.Name = "colName";
			// 
			// colLastEnter
			// 
			this.colLastEnter.DataPropertyName = "lastEnter";
			this.colLastEnter.HeaderText = "Last Enter";
			this.colLastEnter.Name = "colLastEnter";
			// 
			// colTimesLeft
			// 
			this.colTimesLeft.DataPropertyName = "timesLeft";
			this.colTimesLeft.HeaderText = "Times Left";
			this.colTimesLeft.Name = "colTimesLeft";
			this.colTimesLeft.Width = 90;
			// 
			// colScheduleTime
			// 
			this.colScheduleTime.DataPropertyName = "scheduleTime";
			dataGridViewCellStyle1.Format = "t";
			dataGridViewCellStyle1.NullValue = null;
			this.colScheduleTime.DefaultCellStyle = dataGridViewCellStyle1;
			this.colScheduleTime.HeaderText = "Scheduled Time";
			this.colScheduleTime.Name = "colScheduleTime";
			this.colScheduleTime.Width = 110;
			// 
			// ManageClients
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(808, 422);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(groupBox1);
			this.Controls.Add(this.gridClients);
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
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientsListBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridClients;
		private System.Windows.Forms.CheckBox checkNames;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox textToSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkCode;
		private System.Windows.Forms.CheckBox checkStartWith;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnClose;
		private clientDataSet clientDataSet;
		private System.Windows.Forms.BindingSource clientsListBindingSource;
		private EAssistant.clientDataSetTableAdapters.clientsListTableAdapter clientsListTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn colId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLastEnter;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTimesLeft;
		private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleTime;
	}
}
