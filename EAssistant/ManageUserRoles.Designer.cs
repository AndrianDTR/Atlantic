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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.gridRoles = new System.Windows.Forms.DataGridView();
			this.userPrivilegesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.panel3 = new System.Windows.Forms.Panel();
			this.privilegesGrid = new System.Windows.Forms.DataGridView();
			this.accType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.read = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.write = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.create = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remove = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRoles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.privilegesGrid)).BeginInit();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(676, 238);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tableLayoutPanel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(670, 202);
			this.panel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.05917F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.94083F));
			this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(670, 202);
			this.tableLayoutPanel2.TabIndex = 4;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.gridRoles);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(228, 196);
			this.panel2.TabIndex = 6;
			// 
			// gridRoles
			// 
			this.gridRoles.AllowUserToResizeRows = false;
			this.gridRoles.AutoGenerateColumns = false;
			this.gridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridRoles.DataSource = this.userPrivilegesBindingSource;
			this.gridRoles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridRoles.Location = new System.Drawing.Point(0, 0);
			this.gridRoles.MultiSelect = false;
			this.gridRoles.Name = "gridRoles";
			this.gridRoles.RowHeadersVisible = false;
			this.gridRoles.RowHeadersWidth = 4;
			this.gridRoles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.gridRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridRoles.Size = new System.Drawing.Size(228, 196);
			this.gridRoles.TabIndex = 3;
			this.gridRoles.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.OnChangeRole);
			// 
			// userPrivilegesBindingSource
			// 
			this.userPrivilegesBindingSource.DataMember = "userPrivileges";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.privilegesGrid);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(237, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(430, 196);
			this.panel3.TabIndex = 7;
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
			this.privilegesGrid.Size = new System.Drawing.Size(430, 196);
			this.privilegesGrid.TabIndex = 0;
			this.privilegesGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangePermission);
			// 
			// accType
			// 
			this.accType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.accType.DefaultCellStyle = dataGridViewCellStyle1;
			this.accType.HeaderText = "Access type";
			this.accType.Name = "accType";
			this.accType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.accType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// read
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.read.DefaultCellStyle = dataGridViewCellStyle2;
			this.read.HeaderText = "Read";
			this.read.Name = "read";
			this.read.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.read.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.read.Width = 40;
			// 
			// write
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.write.DefaultCellStyle = dataGridViewCellStyle3;
			this.write.HeaderText = "Write";
			this.write.Name = "write";
			this.write.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.write.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.write.Width = 40;
			// 
			// create
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.create.DefaultCellStyle = dataGridViewCellStyle4;
			this.create.HeaderText = "Create";
			this.create.Name = "create";
			this.create.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.create.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.create.Width = 45;
			// 
			// remove
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.remove.DefaultCellStyle = dataGridViewCellStyle5;
			this.remove.HeaderText = "Delete";
			this.remove.Name = "remove";
			this.remove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.remove.Width = 45;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnOK);
			this.panel4.Controls.Add(this.btnCancel);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 208);
			this.panel4.Margin = new System.Windows.Forms.Padding(0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(676, 30);
			this.panel4.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(517, 3);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(598, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// ManageUserRoles
			// 
			this.AcceptButton = this.btnCancel;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(676, 238);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageUserRoles";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage user groups";
			this.Load += new System.EventHandler(this.OnLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridRoles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.privilegesGrid)).EndInit();
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView gridRoles;
		private System.Windows.Forms.BindingSource userPrivilegesBindingSource;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView privilegesGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn accType;
		private System.Windows.Forms.DataGridViewTextBoxColumn read;
		private System.Windows.Forms.DataGridViewTextBoxColumn write;
		private System.Windows.Forms.DataGridViewTextBoxColumn create;
		private System.Windows.Forms.DataGridViewTextBoxColumn remove;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;

	}
}