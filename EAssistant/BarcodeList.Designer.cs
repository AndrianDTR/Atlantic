namespace EAssistant
{
	partial class BarcodeList
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
			this.textBarcodesList = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textFirstBCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnCopy = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "List of barcodes";
			// 
			// textBarcodesList
			// 
			this.textBarcodesList.AcceptsReturn = true;
			this.textBarcodesList.Location = new System.Drawing.Point(15, 25);
			this.textBarcodesList.Multiline = true;
			this.textBarcodesList.Name = "textBarcodesList";
			this.textBarcodesList.Size = new System.Drawing.Size(483, 207);
			this.textBarcodesList.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnCancel.Location = new System.Drawing.Point(423, 238);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Close";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(259, 238);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 3;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 243);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Start";
			// 
			// textFirstBCode
			// 
			this.textFirstBCode.Location = new System.Drawing.Point(47, 240);
			this.textFirstBCode.Name = "textFirstBCode";
			this.textFirstBCode.Size = new System.Drawing.Size(100, 20);
			this.textFirstBCode.TabIndex = 1;
			this.textFirstBCode.Text = "1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(153, 243);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Count";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(194, 240);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(50, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "100";
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(340, 238);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(75, 23);
			this.btnCopy.TabIndex = 8;
			this.btnCopy.Text = "Copy";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// BarcodeList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(510, 273);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textFirstBCode);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.textBarcodesList);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BarcodeList";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Barcode List";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBarcodesList;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textFirstBCode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnCopy;
	}
}