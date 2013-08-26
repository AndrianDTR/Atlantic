namespace AY.Utils
{
	partial class Step1
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnFinish = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnPrev = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panelMain = new System.Windows.Forms.Panel();
			this.labelMessage = new System.Windows.Forms.Label();
			this.radioByInternet = new System.Windows.Forms.RadioButton();
			this.radioByEmail = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panelMain, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 273);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(185, 9);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "Next >>";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btn2_Click);
			// 
			// btnFinish
			// 
			this.btnFinish.Location = new System.Drawing.Point(266, 9);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(75, 23);
			this.btnFinish.TabIndex = 2;
			this.btnFinish.Text = "Finish";
			this.btnFinish.UseVisualStyleBackColor = true;
			this.btnFinish.Click += new System.EventHandler(this.btn3_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnPrev);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnFinish);
			this.panel1.Controls.Add(this.btnNext);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(150, 233);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(434, 40);
			this.panel1.TabIndex = 3;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(347, 9);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btn4_Click);
			// 
			// btnPrev
			// 
			this.btnPrev.Location = new System.Drawing.Point(104, 9);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(75, 23);
			this.btnPrev.TabIndex = 0;
			this.btnPrev.Text = "<< Prev";
			this.btnPrev.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 2);
			this.pictureBox1.Size = new System.Drawing.Size(144, 267);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.radioByEmail);
			this.panelMain.Controls.Add(this.radioByInternet);
			this.panelMain.Controls.Add(this.labelMessage);
			this.panelMain.Location = new System.Drawing.Point(153, 3);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(428, 227);
			this.panelMain.TabIndex = 5;
			// 
			// labelMessage
			// 
			this.labelMessage.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMessage.Location = new System.Drawing.Point(10, 10);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(347, 59);
			this.labelMessage.TabIndex = 0;
			this.labelMessage.Text = "Registration method";
			// 
			// radioByInternet
			// 
			this.radioByInternet.AutoSize = true;
			this.radioByInternet.Location = new System.Drawing.Point(13, 94);
			this.radioByInternet.Name = "radioByInternet";
			this.radioByInternet.Size = new System.Drawing.Size(140, 17);
			this.radioByInternet.TabIndex = 0;
			this.radioByInternet.TabStop = true;
			this.radioByInternet.Text = "Resister through internet";
			this.radioByInternet.UseVisualStyleBackColor = true;
			// 
			// radioByEmail
			// 
			this.radioByEmail.AutoSize = true;
			this.radioByEmail.Location = new System.Drawing.Point(13, 133);
			this.radioByEmail.Name = "radioByEmail";
			this.radioByEmail.Size = new System.Drawing.Size(113, 17);
			this.radioByEmail.TabIndex = 1;
			this.radioByEmail.TabStop = true;
			this.radioByEmail.Text = "Register via E-Mail";
			this.radioByEmail.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 273);
			this.ControlBox = false;
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registration";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnFinish;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.RadioButton radioByEmail;
		private System.Windows.Forms.RadioButton radioByInternet;
	}
}