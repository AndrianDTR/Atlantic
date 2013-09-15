namespace EAssistant
{
	partial class BarcodePrinter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodePrinter));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.panel1 = new System.Windows.Forms.Panel();
			this.numericRows = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numericCols = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numericFontSize = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnRegenerate = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericCols)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
			this.tableLayoutPanel1.Controls.Add(this.webBrowser, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(647, 441);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point(3, 3);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(501, 435);
			this.webBrowser.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnRegenerate);
			this.panel1.Controls.Add(this.numericRows);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.numericCols);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.numericFontSize);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(510, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(134, 435);
			this.panel1.TabIndex = 1;
			// 
			// numericRows
			// 
			this.numericRows.Location = new System.Drawing.Point(12, 217);
			this.numericRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericRows.Name = "numericRows";
			this.numericRows.Size = new System.Drawing.Size(55, 20);
			this.numericRows.TabIndex = 7;
			this.numericRows.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 198);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Rows per page";
			// 
			// numericCols
			// 
			this.numericCols.Location = new System.Drawing.Point(12, 164);
			this.numericCols.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericCols.Name = "numericCols";
			this.numericCols.Size = new System.Drawing.Size(55, 20);
			this.numericCols.TabIndex = 5;
			this.numericCols.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 145);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Cols per page";
			// 
			// numericFontSize
			// 
			this.numericFontSize.AllowDrop = true;
			this.numericFontSize.Location = new System.Drawing.Point(12, 107);
			this.numericFontSize.Maximum = new decimal(new int[] {
            54,
            0,
            0,
            0});
			this.numericFontSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numericFontSize.Name = "numericFontSize";
			this.numericFontSize.Size = new System.Drawing.Size(55, 20);
			this.numericFontSize.TabIndex = 3;
			this.numericFontSize.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Font size";
			// 
			// btnPrint
			// 
			this.btnPrint.Location = new System.Drawing.Point(12, 9);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(111, 23);
			this.btnPrint.TabIndex = 0;
			this.btnPrint.Text = "Print";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(12, 38);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(111, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnRegenerate
			// 
			this.btnRegenerate.Location = new System.Drawing.Point(13, 254);
			this.btnRegenerate.Name = "btnRegenerate";
			this.btnRegenerate.Size = new System.Drawing.Size(110, 23);
			this.btnRegenerate.TabIndex = 8;
			this.btnRegenerate.Text = "Regenerate";
			this.btnRegenerate.UseVisualStyleBackColor = true;
			this.btnRegenerate.Click += new System.EventHandler(this.btnRegenerate_Click);
			// 
			// BarcodePrinter
			// 
			this.AcceptButton = this.btnRegenerate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(647, 441);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BarcodePrinter";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Barcode printer";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericCols)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.NumericUpDown numericFontSize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericRows;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericCols;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnRegenerate;
	}
}