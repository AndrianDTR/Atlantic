namespace EAssistant
{
	partial class TestForm
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.clientDataSet1 = new EAssistant.clientDataSet1();
			this.userPrivilegesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.userPrivilegesTableAdapter1 = new EAssistant.clientDataSet1TableAdapters.userPrivilegesTableAdapter();
			this.clientDataSet2 = new EAssistant.clientDataSet2();
			this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.usersTableAdapter = new EAssistant.clientDataSet2TableAdapters.usersTableAdapter();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.passDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.privilegeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn,
            this.passDataGridViewTextBoxColumn,
            this.privilegeDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.usersBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(676, 240);
			this.dataGridView1.TabIndex = 0;
			// 
			// clientDataSet1
			// 
			this.clientDataSet1.DataSetName = "clientDataSet1";
			this.clientDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// userPrivilegesBindingSource1
			// 
			this.userPrivilegesBindingSource1.DataMember = "userPrivileges";
			this.userPrivilegesBindingSource1.DataSource = this.clientDataSet1;
			// 
			// userPrivilegesTableAdapter1
			// 
			this.userPrivilegesTableAdapter1.ClearBeforeFill = true;
			// 
			// clientDataSet2
			// 
			this.clientDataSet2.DataSetName = "clientDataSet2";
			this.clientDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// usersBindingSource
			// 
			this.usersBindingSource.DataMember = "users";
			this.usersBindingSource.DataSource = this.clientDataSet2;
			// 
			// usersTableAdapter
			// 
			this.usersTableAdapter.ClearBeforeFill = true;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn1.HeaderText = "id";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Visible = false;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// passDataGridViewTextBoxColumn
			// 
			this.passDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.passDataGridViewTextBoxColumn.DataPropertyName = "pass";
			this.passDataGridViewTextBoxColumn.HeaderText = "pass";
			this.passDataGridViewTextBoxColumn.Name = "passDataGridViewTextBoxColumn";
			this.passDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.passDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.passDataGridViewTextBoxColumn.Text = "Change";
			this.passDataGridViewTextBoxColumn.UseColumnTextForButtonValue = true;
			this.passDataGridViewTextBoxColumn.Width = 54;
			// 
			// privilegeDataGridViewTextBoxColumn
			// 
			this.privilegeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.privilegeDataGridViewTextBoxColumn.DataPropertyName = "privilege";
			this.privilegeDataGridViewTextBoxColumn.DataSource = this.userPrivilegesBindingSource1;
			this.privilegeDataGridViewTextBoxColumn.DisplayMember = "name";
			this.privilegeDataGridViewTextBoxColumn.HeaderText = "privilege";
			this.privilegeDataGridViewTextBoxColumn.Name = "privilegeDataGridViewTextBoxColumn";
			this.privilegeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.privilegeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.privilegeDataGridViewTextBoxColumn.ValueMember = "id";
			this.privilegeDataGridViewTextBoxColumn.Width = 71;
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 273);
			this.Controls.Add(this.dataGridView1);
			this.Name = "TestForm";
			this.Text = "TestForm";
			this.Load += new System.EventHandler(this.TestForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn scheduleIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn creatorIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
		private clientDataSet1 clientDataSet1;
		private System.Windows.Forms.BindingSource userPrivilegesBindingSource1;
		private EAssistant.clientDataSet1TableAdapters.userPrivilegesTableAdapter userPrivilegesTableAdapter1;
		private clientDataSet2 clientDataSet2;
		private System.Windows.Forms.BindingSource usersBindingSource;
		private EAssistant.clientDataSet2TableAdapters.usersTableAdapter usersTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewButtonColumn passDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn privilegeDataGridViewTextBoxColumn;
	}
}