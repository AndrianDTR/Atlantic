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
			this.pictureBox1.Image = global::EAssistant.Properties.Resources._1367373274_lock_locked;
			this.pictureBox1.Location = new System.Drawing.Point(31, 26);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(146, 137);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(191, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "User";
			// 
			// userName
			// 
			this.userName.Location = new System.Drawing.Point(267, 67);
			this.userName.Name = "userName";
			this.userName.Size = new System.Drawing.Size(222, 20);
			this.userName.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(191, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password";
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(267, 103);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(222, 20);
			this.password.TabIndex = 1;
			this.password.UseSystemPasswordChar = true;
			// 
			// loginBtn
			// 
			this.loginBtn.Location = new System.Drawing.Point(267, 156);
			this.loginBtn.Name = "loginBtn";
			this.loginBtn.Size = new System.Drawing.Size(98, 23);
			this.loginBtn.TabIndex = 2;
			this.loginBtn.Text = "Login";
			this.loginBtn.UseVisualStyleBackColor = true;
			this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(391, 156);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(98, 23);
			this.Cancel.TabIndex = 3;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			// 
			// message
			// 
			this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.message.ForeColor = System.Drawing.Color.DarkRed;
			this.message.Location = new System.Drawing.Point(191, 12);
			this.message.Name = "message";
			this.message.Size = new System.Drawing.Size(298, 40);
			this.message.TabIndex = 7;
			this.message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Login
			// 
			this.AcceptButton = this.loginBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(514, 191);
			this.Controls.Add(this.message);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.loginBtn);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.userName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Login";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
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