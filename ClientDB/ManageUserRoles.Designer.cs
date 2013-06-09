﻿namespace ClientDB
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
			System.Windows.Forms.ColumnHeader roleName;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.delButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.listRoles = new System.Windows.Forms.ListView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.privilegesGrid = new System.Windows.Forms.DataGridView();
			this.accType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.read = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.write = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.create = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.remove = new System.Windows.Forms.DataGridViewTextBoxColumn();
			roleName = new System.Windows.Forms.ColumnHeader();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.privilegesGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// roleName
			// 
			roleName.Text = "Role";
			roleName.Width = 200;
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
			this.panel1.Controls.Add(this.delButton);
			this.panel1.Controls.Add(this.addButton);
			this.panel1.Controls.Add(this.listRoles);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(230, 197);
			this.panel1.TabIndex = 6;
			// 
			// delButton
			// 
			this.delButton.Location = new System.Drawing.Point(118, 168);
			this.delButton.Name = "delButton";
			this.delButton.Size = new System.Drawing.Size(105, 23);
			this.delButton.TabIndex = 2;
			this.delButton.Text = "Remove selected";
			this.delButton.UseVisualStyleBackColor = true;
			this.delButton.Click += new System.EventHandler(this.delButton_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(7, 168);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(105, 23);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "Add new role";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// listRoles
			// 
			this.listRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            roleName});
			this.listRoles.Dock = System.Windows.Forms.DockStyle.Top;
			this.listRoles.FullRowSelect = true;
			this.listRoles.LabelEdit = true;
			this.listRoles.Location = new System.Drawing.Point(0, 0);
			this.listRoles.MultiSelect = false;
			this.listRoles.Name = "listRoles";
			this.listRoles.Size = new System.Drawing.Size(230, 162);
			this.listRoles.TabIndex = 0;
			this.listRoles.UseCompatibleStateImageBehavior = false;
			this.listRoles.View = System.Windows.Forms.View.Details;
			this.listRoles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.AfterEdit);
			this.listRoles.SelectedIndexChanged += new System.EventHandler(this.listRoles_SelectedIndexChanged);
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
			this.privilegesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.privilegesGrid.Size = new System.Drawing.Size(434, 197);
			this.privilegesGrid.TabIndex = 0;
			this.privilegesGrid.Click += new System.EventHandler(this.OnClick);
			// 
			// accType
			// 
			this.accType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.accType.DefaultCellStyle = dataGridViewCellStyle6;
			this.accType.HeaderText = "Access type";
			this.accType.Name = "accType";
			this.accType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.accType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// read
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.read.DefaultCellStyle = dataGridViewCellStyle7;
			this.read.HeaderText = "Read";
			this.read.Name = "read";
			this.read.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.read.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.read.Width = 40;
			// 
			// write
			// 
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.write.DefaultCellStyle = dataGridViewCellStyle8;
			this.write.HeaderText = "Write";
			this.write.Name = "write";
			this.write.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.write.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.write.Width = 40;
			// 
			// create
			// 
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.create.DefaultCellStyle = dataGridViewCellStyle9;
			this.create.HeaderText = "Create";
			this.create.Name = "create";
			this.create.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.create.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.create.Width = 45;
			// 
			// remove
			// 
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.remove.DefaultCellStyle = dataGridViewCellStyle10;
			this.remove.HeaderText = "Delete";
			this.remove.Name = "remove";
			this.remove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.remove.Width = 45;
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
			this.Text = "User roles";
			this.Load += new System.EventHandler(this.OnLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.privilegesGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button delButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.ListView listRoles;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView privilegesGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn accType;
		private System.Windows.Forms.DataGridViewTextBoxColumn read;
		private System.Windows.Forms.DataGridViewTextBoxColumn write;
		private System.Windows.Forms.DataGridViewTextBoxColumn create;
		private System.Windows.Forms.DataGridViewTextBoxColumn remove;

	}
}