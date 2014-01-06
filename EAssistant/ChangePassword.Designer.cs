namespace EAssistant
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
			this.message = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.current = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.confirm = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cancel = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			change = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// change
			// 
			resources.ApplyResources(change, "change");
			change.Name = "change";
			change.UseVisualStyleBackColor = true;
			change.Click += new System.EventHandler(this.change_Click);
			// 
			// message
			// 
			resources.ApplyResources(this.message, "message");
			this.message.ForeColor = System.Drawing.Color.DarkRed;
			this.message.Name = "message";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// current
			// 
			resources.ApplyResources(this.current, "current");
			this.current.Name = "current";
			this.current.UseSystemPasswordChar = true;
			// 
			// password
			// 
			resources.ApplyResources(this.password, "password");
			this.password.Name = "password";
			this.password.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// confirm
			// 
			resources.ApplyResources(this.confirm, "confirm");
			this.confirm.Name = "confirm";
			this.confirm.UseSystemPasswordChar = true;
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.cancel, "cancel");
			this.cancel.Name = "cancel";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::EAssistant.Properties.Resources._1367459833_lock1;
			resources.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
			// 
			// ChangePassword
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(change);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.confirm);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.current);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.message);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangePassword";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label message;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox current;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox confirm;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}