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
			this.userPrivilegesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
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
			this.gridUsers.Size = new System.Drawing.Size(693, 241);
			this.gridUsers.TabIndex = 9;
			this.gridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
			// 
			// userPrivilegesBindingSource
			// 
			this.userPrivilegesBindingSource.DataMember = "userPrivileges";
			// 
			// usersBindingSource
			// 
			this.usersBindingSource.DataMember = "users";
			// 
			// ManageUsers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(717, 260);
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
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
			((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userPrivilegesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gridUsers;
		private System.Windows.Forms.BindingSource usersBindingSource;
		private System.Windows.Forms.BindingSource userPrivilegesBindingSource;
	}
}