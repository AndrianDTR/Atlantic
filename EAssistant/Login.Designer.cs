namespace EAssistant
{
    partial class Login
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.userName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.password = new System.Windows.Forms.MaskedTextBox();
			this.loginBtn = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.message = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.AccessibleDescription = null;
			this.pictureBox1.AccessibleName = null;
			resources.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.BackgroundImage = null;
			this.pictureBox1.Font = null;
			this.pictureBox1.Image = global::EAssistant.Properties.Resources._1367373274_lock_locked;
			this.pictureBox1.ImageLocation = null;
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// userName
			// 
			this.userName.AccessibleDescription = null;
			this.userName.AccessibleName = null;
			resources.ApplyResources(this.userName, "userName");
			this.userName.BackgroundImage = null;
			this.userName.Font = null;
			this.userName.Name = "userName";
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// password
			// 
			this.password.AccessibleDescription = null;
			this.password.AccessibleName = null;
			resources.ApplyResources(this.password, "password");
			this.password.BackgroundImage = null;
			this.password.Font = null;
			this.password.Name = "password";
			this.password.UseSystemPasswordChar = true;
			// 
			// loginBtn
			// 
			this.loginBtn.AccessibleDescription = null;
			this.loginBtn.AccessibleName = null;
			resources.ApplyResources(this.loginBtn, "loginBtn");
			this.loginBtn.BackgroundImage = null;
			this.loginBtn.Font = null;
			this.loginBtn.Name = "loginBtn";
			this.loginBtn.UseVisualStyleBackColor = true;
			this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
			// 
			// Cancel
			// 
			this.Cancel.AccessibleDescription = null;
			this.Cancel.AccessibleName = null;
			resources.ApplyResources(this.Cancel, "Cancel");
			this.Cancel.BackgroundImage = null;
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Font = null;
			this.Cancel.Name = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// message
			// 
			this.message.AccessibleDescription = null;
			this.message.AccessibleName = null;
			resources.ApplyResources(this.message, "message");
			this.message.ForeColor = System.Drawing.Color.DarkRed;
			this.message.Name = "message";
			// 
			// Login
			// 
			this.AcceptButton = this.loginBtn;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.Cancel;
			this.Controls.Add(this.message);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.loginBtn);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.userName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Login";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox password;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Label message;
    }
}