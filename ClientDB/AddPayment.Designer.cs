namespace GAssistant
{
	partial class AddPayment
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
			this.label1 = new System.Windows.Forms.Label();
			this.textClientCode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textSum = new System.Windows.Forms.TextBox();
			this.Sum = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.comboTypeOfService = new System.Windows.Forms.ComboBox();
			this.textComment = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 23);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Client";
			// 
			// textClientCode
			// 
			this.textClientCode.Location = new System.Drawing.Point(139, 20);
			this.textClientCode.Margin = new System.Windows.Forms.Padding(6);
			this.textClientCode.Name = "textClientCode";
			this.textClientCode.ReadOnly = true;
			this.textClientCode.Size = new System.Drawing.Size(580, 29);
			this.textClientCode.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 69);
			this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Service type";
			// 
			// textSum
			// 
			this.textSum.Location = new System.Drawing.Point(139, 116);
			this.textSum.Margin = new System.Windows.Forms.Padding(6);
			this.textSum.Name = "textSum";
			this.textSum.Size = new System.Drawing.Size(168, 29);
			this.textSum.TabIndex = 1;
			// 
			// Sum
			// 
			this.Sum.AutoSize = true;
			this.Sum.Location = new System.Drawing.Point(7, 119);
			this.Sum.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.Sum.Name = "Sum";
			this.Sum.Size = new System.Drawing.Size(49, 24);
			this.Sum.TabIndex = 5;
			this.Sum.Text = "Sum";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(581, 253);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(138, 42);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(431, 253);
			this.btnOk.Margin = new System.Windows.Forms.Padding(6);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(138, 42);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// comboTypeOfService
			// 
			this.comboTypeOfService.FormattingEnabled = true;
			this.comboTypeOfService.Location = new System.Drawing.Point(139, 66);
			this.comboTypeOfService.Margin = new System.Windows.Forms.Padding(6);
			this.comboTypeOfService.Name = "comboTypeOfService";
			this.comboTypeOfService.Size = new System.Drawing.Size(580, 32);
			this.comboTypeOfService.TabIndex = 0;
			this.comboTypeOfService.SelectedIndexChanged += new System.EventHandler(this.ChangeService);
			// 
			// textComment
			// 
			this.textComment.Location = new System.Drawing.Point(139, 161);
			this.textComment.Margin = new System.Windows.Forms.Padding(6);
			this.textComment.Multiline = true;
			this.textComment.Name = "textComment";
			this.textComment.Size = new System.Drawing.Size(580, 73);
			this.textComment.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 164);
			this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 24);
			this.label3.TabIndex = 8;
			this.label3.Text = "Comment";
			// 
			// AddPayment
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(739, 313);
			this.Controls.Add(this.textComment);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboTypeOfService);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.textSum);
			this.Controls.Add(this.Sum);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textClientCode);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddPayment";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add client payment";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textClientCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textSum;
		private System.Windows.Forms.Label Sum;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ComboBox comboTypeOfService;
		private System.Windows.Forms.TextBox textComment;
		private System.Windows.Forms.Label label3;
	}
}