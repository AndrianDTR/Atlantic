namespace ClientDB
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
			System.Windows.Forms.ColumnHeader userName;
			System.Windows.Forms.ColumnHeader Role;
			this.label1 = new System.Windows.Forms.Label();
			this.m_userName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.m_userRole = new System.Windows.Forms.ComboBox();
			this.m_showPass = new System.Windows.Forms.CheckBox();
			this.close = new System.Windows.Forms.Button();
			this.save = new System.Windows.Forms.Button();
			this.remove = new System.Windows.Forms.Button();
			this.add = new System.Windows.Forms.Button();
			this.userList = new System.Windows.Forms.ListView();
			userName = new System.Windows.Forms.ColumnHeader();
			Role = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(336, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name";
			// 
			// m_userName
			// 
			this.m_userName.Location = new System.Drawing.Point(394, 60);
			this.m_userName.Name = "m_userName";
			this.m_userName.Size = new System.Drawing.Size(314, 20);
			this.m_userName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(336, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Role";
			// 
			// m_password
			// 
			this.m_password.Location = new System.Drawing.Point(394, 137);
			this.m_password.Name = "m_password";
			this.m_password.Size = new System.Drawing.Size(314, 20);
			this.m_password.TabIndex = 3;
			this.m_password.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(336, 140);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Password";
			// 
			// m_userRole
			// 
			this.m_userRole.FormattingEnabled = true;
			this.m_userRole.Location = new System.Drawing.Point(394, 98);
			this.m_userRole.Name = "m_userRole";
			this.m_userRole.Size = new System.Drawing.Size(314, 21);
			this.m_userRole.TabIndex = 2;
			// 
			// m_showPass
			// 
			this.m_showPass.AutoSize = true;
			this.m_showPass.Location = new System.Drawing.Point(394, 175);
			this.m_showPass.Name = "m_showPass";
			this.m_showPass.Size = new System.Drawing.Size(96, 17);
			this.m_showPass.TabIndex = 10;
			this.m_showPass.Text = "Show pasword";
			this.m_showPass.UseVisualStyleBackColor = true;
			this.m_showPass.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// close
			// 
			this.close.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.close.Location = new System.Drawing.Point(633, 229);
			this.close.Name = "close";
			this.close.Size = new System.Drawing.Size(75, 23);
			this.close.TabIndex = 5;
			this.close.Text = "Close";
			this.close.UseVisualStyleBackColor = true;
			this.close.Click += new System.EventHandler(this.close_Click);
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(552, 229);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(75, 23);
			this.save.TabIndex = 4;
			this.save.Text = "Save";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// remove
			// 
			this.remove.Location = new System.Drawing.Point(420, 229);
			this.remove.Name = "remove";
			this.remove.Size = new System.Drawing.Size(75, 23);
			this.remove.TabIndex = 7;
			this.remove.Text = "Remove";
			this.remove.UseVisualStyleBackColor = true;
			// 
			// add
			// 
			this.add.Location = new System.Drawing.Point(339, 229);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(75, 23);
			this.add.TabIndex = 6;
			this.add.Text = "Add new";
			this.add.UseVisualStyleBackColor = true;
			// 
			// userList
			// 
			this.userList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            userName,
            Role});
			this.userList.Dock = System.Windows.Forms.DockStyle.Left;
			this.userList.FullRowSelect = true;
			this.userList.HideSelection = false;
			this.userList.Location = new System.Drawing.Point(0, 0);
			this.userList.MultiSelect = false;
			this.userList.Name = "userList";
			this.userList.Size = new System.Drawing.Size(330, 260);
			this.userList.TabIndex = 11;
			this.userList.UseCompatibleStateImageBehavior = false;
			this.userList.View = System.Windows.Forms.View.Details;
			this.userList.SelectedIndexChanged += new System.EventHandler(this.ChangeUser);
			// 
			// userName
			// 
			userName.Text = "Name";
			userName.Width = 200;
			// 
			// Role
			// 
			Role.Text = "Role";
			Role.Width = 100;
			// 
			// ManageUsers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(717, 260);
			this.Controls.Add(this.userList);
			this.Controls.Add(this.remove);
			this.Controls.Add(this.add);
			this.Controls.Add(this.save);
			this.Controls.Add(this.close);
			this.Controls.Add(this.m_showPass);
			this.Controls.Add(this.m_userRole);
			this.Controls.Add(this.m_password);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_userName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageUsers";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Users";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_userName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox m_userRole;
		private System.Windows.Forms.CheckBox m_showPass;
		private System.Windows.Forms.Button close;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button remove;
		private System.Windows.Forms.Button add;
		private System.Windows.Forms.ListView userList;

	}
}