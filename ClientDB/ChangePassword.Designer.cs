namespace ClientDB
{
	partial class ChangePassword
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
			System.Windows.Forms.Button change;
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.message = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.current = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.confirm = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cancel = new System.Windows.Forms.Button();
			change = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// change
			// 
			change.Location = new System.Drawing.Point(278, 196);
			change.Name = "change";
			change.Size = new System.Drawing.Size(89, 23);
			change.TabIndex = 3;
			change.Text = "Change";
			change.UseVisualStyleBackColor = true;
			change.Click += new System.EventHandler(this.change_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ClientDB.Properties.Resources._1367459833_lock1;
			this.pictureBox1.Location = new System.Drawing.Point(12, 42);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(136, 139);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// message
			// 
			this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.message.ForeColor = System.Drawing.Color.DarkRed;
			this.message.Location = new System.Drawing.Point(182, 9);
			this.message.Name = "message";
			this.message.Size = new System.Drawing.Size(303, 40);
			this.message.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(183, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Current password";
			// 
			// current
			// 
			this.current.Location = new System.Drawing.Point(278, 65);
			this.current.Name = "current";
			this.current.Size = new System.Drawing.Size(207, 20);
			this.current.TabIndex = 0;
			this.current.UseSystemPasswordChar = true;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(278, 103);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(207, 20);
			this.password.TabIndex = 1;
			this.password.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(183, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "New password";
			// 
			// confirm
			// 
			this.confirm.Location = new System.Drawing.Point(278, 141);
			this.confirm.Name = "confirm";
			this.confirm.Size = new System.Drawing.Size(207, 20);
			this.confirm.TabIndex = 2;
			this.confirm.UseSystemPasswordChar = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(182, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Confirm";
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(396, 196);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(89, 23);
			this.cancel.TabIndex = 4;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// ChangePassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(511, 241);
			this.Controls.Add(change);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.confirm);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.current);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.message);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangePassword";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Change user password";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label message;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox current;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox confirm;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cancel;
	}
}