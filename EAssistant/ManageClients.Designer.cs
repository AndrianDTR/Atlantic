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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageClients));
			this.radioId = new System.Windows.Forms.RadioButton();
			this.radioName = new System.Windows.Forms.RadioButton();
			this.checkStartWith = new System.Windows.Forms.CheckBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.textToSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.gridClients = new System.Windows.Forms.DataGridView();
			this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnPayments = new System.Windows.Forms.Button();
			this.BtnEntrance = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridClients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.AccessibleDescription = null;
			groupBox1.AccessibleName = null;
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.BackgroundImage = null;
			groupBox1.Controls.Add(this.radioId);
			groupBox1.Controls.Add(this.radioName);
			groupBox1.Controls.Add(this.checkStartWith);
			groupBox1.Controls.Add(this.btnSearch);
			groupBox1.Controls.Add(this.textToSearch);
			groupBox1.Controls.Add(this.label1);
			groupBox1.Font = null;
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			// 
			// radioId
			// 
			this.radioId.AccessibleDescription = null;
			this.radioId.AccessibleName = null;
			resources.ApplyResources(this.radioId, "radioId");
			this.radioId.BackgroundImage = null;
			this.radioId.Font = null;
			this.radioId.Name = "radioId";
			this.radioId.UseVisualStyleBackColor = true;
			// 
			// radioName
			// 
			this.radioName.AccessibleDescription = null;
			this.radioName.AccessibleName = null;
			resources.ApplyResources(this.radioName, "radioName");
			this.radioName.BackgroundImage = null;
			this.radioName.Checked = true;
			this.radioName.Font = null;
			this.radioName.Name = "radioName";
			this.radioName.TabStop = true;
			this.radioName.UseVisualStyleBackColor = true;
			// 
			// checkStartWith
			// 
			this.checkStartWith.AccessibleDescription = null;
			this.checkStartWith.AccessibleName = null;
			resources.ApplyResources(this.checkStartWith, "checkStartWith");
			this.checkStartWith.BackgroundImage = null;
			this.checkStartWith.Font = null;
			this.checkStartWith.Name = "checkStartWith";
			this.checkStartWith.UseVisualStyleBackColor = true;
			// 
			// btnSearch
			// 
			this.btnSearch.AccessibleDescription = null;
			this.btnSearch.AccessibleName = null;
			resources.ApplyResources(this.btnSearch, "btnSearch");
			this.btnSearch.BackgroundImage = null;
			this.btnSearch.Font = null;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// textToSearch
			// 
			this.textToSearch.AccessibleDescription = null;
			this.textToSearch.AccessibleName = null;
			resources.ApplyResources(this.textToSearch, "textToSearch");
			this.textToSearch.BackgroundImage = null;
			this.textToSearch.Font = null;
			this.textToSearch.Name = "textToSearch";
			this.textToSearch.TextChanged += new System.EventHandler(this.OnSearch);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Font = null;
			this.label1.Name = "label1";
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = null;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.AccessibleDescription = null;
			this.btnOk.AccessibleName = null;
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.BackgroundImage = null;
			this.btnOk.Font = null;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// gridClients
			// 
			this.gridClients.AccessibleDescription = null;
			this.gridClients.AccessibleName = null;
			this.gridClients.AllowUserToAddRows = false;
			this.gridClients.AllowUserToDeleteRows = false;
			this.gridClients.AllowUserToResizeRows = false;
			resources.ApplyResources(this.gridClients, "gridClients");
			this.gridClients.AutoGenerateColumns = false;
			this.gridClients.BackgroundImage = null;
			this.gridClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridClients.DataSource = this.clientsBindingSource;
			this.gridClients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gridClients.Font = null;
			this.gridClients.MultiSelect = false;
			this.gridClients.Name = "gridClients";
			this.gridClients.RowHeadersVisible = false;
			this.gridClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridClients.DoubleClick += new System.EventHandler(this.OnEditClient);
			// 
			// clientsBindingSource
			// 
			this.clientsBindingSource.DataMember = "vClients";
			// 
			// btnAdd
			// 
			this.btnAdd.AccessibleDescription = null;
			this.btnAdd.AccessibleName = null;
			resources.ApplyResources(this.btnAdd, "btnAdd");
			this.btnAdd.BackgroundImage = null;
			this.btnAdd.Font = null;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.AccessibleDescription = null;
			this.btnEdit.AccessibleName = null;
			resources.ApplyResources(this.btnEdit, "btnEdit");
			this.btnEdit.BackgroundImage = null;
			this.btnEdit.Font = null;
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.AccessibleDescription = null;
			this.btnRemove.AccessibleName = null;
			resources.ApplyResources(this.btnRemove, "btnRemove");
			this.btnRemove.BackgroundImage = null;
			this.btnRemove.Font = null;
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnPayments
			// 
			this.btnPayments.AccessibleDescription = null;
			this.btnPayments.AccessibleName = null;
			resources.ApplyResources(this.btnPayments, "btnPayments");
			this.btnPayments.BackgroundImage = null;
			this.btnPayments.Font = null;
			this.btnPayments.Name = "btnPayments";
			this.btnPayments.UseVisualStyleBackColor = true;
			this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
			// 
			// BtnEntrance
			// 
			this.BtnEntrance.AccessibleDescription = null;
			this.BtnEntrance.AccessibleName = null;
			resources.ApplyResources(this.BtnEntrance, "BtnEntrance");
			this.BtnEntrance.BackgroundImage = null;
			this.BtnEntrance.Font = null;
			this.BtnEntrance.Name = "BtnEntrance";
			this.BtnEntrance.UseVisualStyleBackColor = true;
			this.BtnEntrance.Click += new System.EventHandler(this.BtnEntrance_Click);
			// 
			// ManageClients
			// 
			this.AcceptButton = this.btnSearch;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.BtnEntrance);
			this.Controls.Add(this.btnPayments);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.gridClients);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(groupBox1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageClients";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Load += new System.EventHandler(this.OnLoad);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridClients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox textToSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkStartWith;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.DataGridView gridClients;
		private System.Windows.Forms.BindingSource clientsBindingSource;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnPayments;
		private System.Windows.Forms.Button BtnEntrance;
		private System.Windows.Forms.RadioButton radioId;
		private System.Windows.Forms.RadioButton radioName;
	}
}
