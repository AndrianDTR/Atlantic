namespace EAssistant
{
	partial class ManageUsers
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
			this.gridUsers = new System.Windows.Forms.DataGridView();
			this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.userPrivilegesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// gridUsers
			// 
			this.gridUsers.AllowUserToResizeColumns = false;
			this.gridUsers.AllowUserToResizeRows = false;
			this.gridUsers.AutoGenerateColumns = false;
			this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridUsers.DataSource = this.usersBindingSource;
			this.gridUsers.Location = new System.Drawing.Point(12, 7);
			this.gridUsers.MultiSelect = false;
			this.gridUsers.Name = "gridUsers";
			this.gridUsers.RowHeadersVisible = false;
			this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridUsers.Size = new System.Drawing.Size(693, 210);
			this.gridUsers.TabIndex = 9;
			this.gridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
			this.gridUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDataError);
			// 
			// usersBindingSource
			// 
			this.usersBindingSource.DataMember = "users";
			// 
			// userPrivilegesBindingSource
			// 
			this.userPrivilegesBindingSource.DataMember = "userPrivileges";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(630, 228);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(549, 228);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// ManageUsers
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(717, 260);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gridUsers);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageUsers";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Users";
			this.Load += new System.EventHandler(this.OnLoad);
			((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridUsers;
		private System.Windows.Forms.BindingSource usersBindingSource;
		private System.Windows.Forms.BindingSource userPrivilegesBindingSource;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}