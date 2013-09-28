namespace EAssistant
{
	partial class ManageUserRoles
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.gridRoles = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.privilegesGrid = new System.Windows.Forms.DataGridView();
			this.accType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.read = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.write = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.create = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remove = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.userPrivilegesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colClients = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSchedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTrainers = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPayments = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colStatisrics = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPrivileges = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRoles)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.privilegesGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.05917F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.94083F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(676, 203);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.gridRoles);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(230, 197);
			this.panel1.TabIndex = 6;
			// 
			// gridRoles
			// 
			this.gridRoles.AllowUserToResizeRows = false;
			this.gridRoles.AutoGenerateColumns = false;
			this.gridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colClients,
            this.colSchedule,
            this.colTrainers,
            this.colPayments,
            this.colBackup,
            this.colStatisrics,
            this.colUsers,
            this.colPrivileges});
			this.gridRoles.DataSource = this.userPrivilegesBindingSource;
			this.gridRoles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridRoles.Location = new System.Drawing.Point(0, 0);
			this.gridRoles.MultiSelect = false;
			this.gridRoles.Name = "gridRoles";
			this.gridRoles.RowHeadersVisible = false;
			this.gridRoles.RowHeadersWidth = 4;
			this.gridRoles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.gridRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridRoles.Size = new System.Drawing.Size(230, 197);
			this.gridRoles.TabIndex = 3;
			this.gridRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnChangeCell);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.privilegesGrid);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(239, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(434, 197);
			this.panel2.TabIndex = 7;
			// 
			// privilegesGrid
			// 
			this.privilegesGrid.AllowUserToAddRows = false;
			this.privilegesGrid.AllowUserToDeleteRows = false;
			this.privilegesGrid.AllowUserToResizeColumns = false;
			this.privilegesGrid.AllowUserToResizeRows = false;
			this.privilegesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.privilegesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accType,
            this.read,
            this.write,
            this.create,
            this.remove});
			this.privilegesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.privilegesGrid.Location = new System.Drawing.Point(0, 0);
			this.privilegesGrid.MultiSelect = false;
			this.privilegesGrid.Name = "privilegesGrid";
			this.privilegesGrid.RowHeadersVisible = false;
			this.privilegesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.privilegesGrid.Size = new System.Drawing.Size(434, 197);
			this.privilegesGrid.TabIndex = 0;
			this.privilegesGrid.Click += new System.EventHandler(this.OnClick);
			// 
			// accType
			// 
			this.accType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.accType.DefaultCellStyle = dataGridViewCellStyle11;
			this.accType.HeaderText = "Access type";
			this.accType.Name = "accType";
			this.accType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.accType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// read
			// 
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.read.DefaultCellStyle = dataGridViewCellStyle12;
			this.read.HeaderText = "Read";
			this.read.Name = "read";
			this.read.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.read.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.read.Width = 40;
			// 
			// write
			// 
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.write.DefaultCellStyle = dataGridViewCellStyle13;
			this.write.HeaderText = "Write";
			this.write.Name = "write";
			this.write.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.write.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.write.Width = 40;
			// 
			// create
			// 
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.create.DefaultCellStyle = dataGridViewCellStyle14;
			this.create.HeaderText = "Create";
			this.create.Name = "create";
			this.create.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.create.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.create.Width = 45;
			// 
			// remove
			// 
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.remove.DefaultCellStyle = dataGridViewCellStyle15;
			this.remove.HeaderText = "Delete";
			this.remove.Name = "remove";
			this.remove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.remove.Width = 45;
			// 
			// userPrivilegesBindingSource
			// 
			this.userPrivilegesBindingSource.DataMember = "userPrivileges";
			// 
			// colId
			// 
			this.colId.DataPropertyName = "id";
			this.colId.HeaderText = "ID";
			this.colId.Name = "colId";
			this.colId.Visible = false;
			// 
			// colName
			// 
			this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colName.DataPropertyName = "name";
			this.colName.HeaderText = "name";
			this.colName.Name = "colName";
			// 
			// colClients
			// 
			this.colClients.DataPropertyName = "clients";
			this.colClients.HeaderText = "clients";
			this.colClients.Name = "colClients";
			this.colClients.Visible = false;
			// 
			// colSchedule
			// 
			this.colSchedule.DataPropertyName = "schedule";
			this.colSchedule.HeaderText = "schedule";
			this.colSchedule.Name = "colSchedule";
			this.colSchedule.Visible = false;
			// 
			// colTrainers
			// 
			this.colTrainers.DataPropertyName = "trainers";
			this.colTrainers.HeaderText = "trainers";
			this.colTrainers.Name = "colTrainers";
			this.colTrainers.Visible = false;
			// 
			// colPayments
			// 
			this.colPayments.DataPropertyName = "payments";
			this.colPayments.HeaderText = "payments";
			this.colPayments.Name = "colPayments";
			this.colPayments.Visible = false;
			// 
			// colBackup
			// 
			this.colBackup.DataPropertyName = "backup";
			this.colBackup.HeaderText = "backup";
			this.colBackup.Name = "colBackup";
			this.colBackup.Visible = false;
			// 
			// colStatisrics
			// 
			this.colStatisrics.DataPropertyName = "statistics";
			this.colStatisrics.HeaderText = "statistics";
			this.colStatisrics.Name = "colStatisrics";
			this.colStatisrics.Visible = false;
			// 
			// colUsers
			// 
			this.colUsers.DataPropertyName = "users";
			this.colUsers.HeaderText = "users";
			this.colUsers.Name = "colUsers";
			this.colUsers.Visible = false;
			// 
			// colPrivileges
			// 
			this.colPrivileges.DataPropertyName = "privileges";
			this.colPrivileges.HeaderText = "privileges";
			this.colPrivileges.Name = "colPrivileges";
			this.colPrivileges.Visible = false;
			// 
			// ManageUserRoles
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(676, 203);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageUserRoles";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "dbDataSet.usersRow roles";
			this.Load += new System.EventHandler(this.OnLoad);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridRoles)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.privilegesGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView privilegesGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn accType;
		private System.Windows.Forms.DataGridViewTextBoxColumn read;
		private System.Windows.Forms.DataGridViewTextBoxColumn write;
		private System.Windows.Forms.DataGridViewTextBoxColumn create;
		private System.Windows.Forms.DataGridViewTextBoxColumn remove;
		private System.Windows.Forms.DataGridView gridRoles;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
		private System.Windows.Forms.BindingSource userPrivilegesBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn colId;
		private System.Windows.Forms.DataGridViewTextBoxColumn colName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colClients;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSchedule;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTrainers;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPayments;
		private System.Windows.Forms.DataGridViewTextBoxColumn colBackup;
		private System.Windows.Forms.DataGridViewTextBoxColumn colStatisrics;
		private System.Windows.Forms.DataGridViewTextBoxColumn colUsers;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPrivileges;

	}
}