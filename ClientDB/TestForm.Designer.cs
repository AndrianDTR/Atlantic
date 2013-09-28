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
			this.clientDataSet = new EAssistant.clientDataSet();
			this.userPrivilegesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.userPrivilegesTableAdapter = new EAssistant.clientDataSetTableAdapters.userPrivilegesTableAdapter();
			this.clientDataSet1 = new EAssistant.clientDataSet1();
			this.userPrivilegesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.userPrivilegesTableAdapter1 = new EAssistant.clientDataSet1TableAdapters.userPrivilegesTableAdapter();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clientsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scheduleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.trainersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.paymentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.backupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statisticsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.usersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.privilegesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn,
            this.clientsDataGridViewTextBoxColumn,
            this.scheduleDataGridViewTextBoxColumn,
            this.trainersDataGridViewTextBoxColumn,
            this.paymentsDataGridViewTextBoxColumn,
            this.backupDataGridViewTextBoxColumn,
            this.statisticsDataGridViewTextBoxColumn,
            this.usersDataGridViewTextBoxColumn,
            this.privilegesDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.userPrivilegesBindingSource1;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(676, 240);
			this.dataGridView1.TabIndex = 0;
			// 
			// clientDataSet
			// 
			this.clientDataSet.DataSetName = "clientDataSet";
			this.clientDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// userPrivilegesBindingSource
			// 
			this.userPrivilegesBindingSource.DataMember = "userPrivileges";
			this.userPrivilegesBindingSource.DataSource = this.clientDataSet;
			// 
			// userPrivilegesTableAdapter
			// 
			this.userPrivilegesTableAdapter.ClearBeforeFill = true;
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
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn1.HeaderText = "id";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// clientsDataGridViewTextBoxColumn
			// 
			this.clientsDataGridViewTextBoxColumn.DataPropertyName = "clients";
			this.clientsDataGridViewTextBoxColumn.HeaderText = "clients";
			this.clientsDataGridViewTextBoxColumn.Name = "clientsDataGridViewTextBoxColumn";
			this.clientsDataGridViewTextBoxColumn.Visible = false;
			// 
			// scheduleDataGridViewTextBoxColumn
			// 
			this.scheduleDataGridViewTextBoxColumn.DataPropertyName = "schedule";
			this.scheduleDataGridViewTextBoxColumn.HeaderText = "schedule";
			this.scheduleDataGridViewTextBoxColumn.Name = "scheduleDataGridViewTextBoxColumn";
			this.scheduleDataGridViewTextBoxColumn.Visible = false;
			// 
			// trainersDataGridViewTextBoxColumn
			// 
			this.trainersDataGridViewTextBoxColumn.DataPropertyName = "trainers";
			this.trainersDataGridViewTextBoxColumn.HeaderText = "trainers";
			this.trainersDataGridViewTextBoxColumn.Name = "trainersDataGridViewTextBoxColumn";
			this.trainersDataGridViewTextBoxColumn.Visible = false;
			// 
			// paymentsDataGridViewTextBoxColumn
			// 
			this.paymentsDataGridViewTextBoxColumn.DataPropertyName = "payments";
			this.paymentsDataGridViewTextBoxColumn.HeaderText = "payments";
			this.paymentsDataGridViewTextBoxColumn.Name = "paymentsDataGridViewTextBoxColumn";
			this.paymentsDataGridViewTextBoxColumn.Visible = false;
			// 
			// backupDataGridViewTextBoxColumn
			// 
			this.backupDataGridViewTextBoxColumn.DataPropertyName = "backup";
			this.backupDataGridViewTextBoxColumn.HeaderText = "backup";
			this.backupDataGridViewTextBoxColumn.Name = "backupDataGridViewTextBoxColumn";
			this.backupDataGridViewTextBoxColumn.Visible = false;
			// 
			// statisticsDataGridViewTextBoxColumn
			// 
			this.statisticsDataGridViewTextBoxColumn.DataPropertyName = "statistics";
			this.statisticsDataGridViewTextBoxColumn.HeaderText = "statistics";
			this.statisticsDataGridViewTextBoxColumn.Name = "statisticsDataGridViewTextBoxColumn";
			this.statisticsDataGridViewTextBoxColumn.Visible = false;
			// 
			// usersDataGridViewTextBoxColumn
			// 
			this.usersDataGridViewTextBoxColumn.DataPropertyName = "users";
			this.usersDataGridViewTextBoxColumn.HeaderText = "users";
			this.usersDataGridViewTextBoxColumn.Name = "usersDataGridViewTextBoxColumn";
			this.usersDataGridViewTextBoxColumn.Visible = false;
			// 
			// privilegesDataGridViewTextBoxColumn
			// 
			this.privilegesDataGridViewTextBoxColumn.DataPropertyName = "privileges";
			this.privilegesDataGridViewTextBoxColumn.HeaderText = "privileges";
			this.privilegesDataGridViewTextBoxColumn.Name = "privilegesDataGridViewTextBoxColumn";
			this.privilegesDataGridViewTextBoxColumn.Visible = false;
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
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientDataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource1)).EndInit();
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
		private clientDataSet clientDataSet;
		private System.Windows.Forms.BindingSource userPrivilegesBindingSource;
		private EAssistant.clientDataSetTableAdapters.userPrivilegesTableAdapter userPrivilegesTableAdapter;
		private clientDataSet1 clientDataSet1;
		private System.Windows.Forms.BindingSource userPrivilegesBindingSource1;
		private EAssistant.clientDataSet1TableAdapters.userPrivilegesTableAdapter userPrivilegesTableAdapter1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn clientsDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn scheduleDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn trainersDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn paymentsDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn backupDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn statisticsDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn usersDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn privilegesDataGridViewTextBoxColumn;
	}
}