namespace GAssistant
{
	partial class PaymentsHistory
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
			this.listPayments = new System.Windows.Forms.ListView();
			this.colDate = new System.Windows.Forms.ColumnHeader();
			this.colSum = new System.Windows.Forms.ColumnHeader();
			this.colService = new System.Windows.Forms.ColumnHeader();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnView = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listPayments
			// 
			this.listPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colSum,
            this.colService});
			this.listPayments.Dock = System.Windows.Forms.DockStyle.Top;
			this.listPayments.FullRowSelect = true;
			this.listPayments.GridLines = true;
			this.listPayments.Location = new System.Drawing.Point(0, 0);
			this.listPayments.Name = "listPayments";
			this.listPayments.Size = new System.Drawing.Size(644, 349);
			this.listPayments.TabIndex = 0;
			this.listPayments.UseCompatibleStateImageBehavior = false;
			this.listPayments.View = System.Windows.Forms.View.Details;
			this.listPayments.DoubleClick += new System.EventHandler(this.ShowDetails);
			// 
			// colDate
			// 
			this.colDate.Text = "Date";
			this.colDate.Width = 143;
			// 
			// colSum
			// 
			this.colSum.Text = "Sum";
			this.colSum.Width = 80;
			// 
			// colService
			// 
			this.colService.Text = "Service";
			this.colService.Width = 400;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(556, 362);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnView
			// 
			this.btnView.Location = new System.Drawing.Point(476, 362);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(75, 23);
			this.btnView.TabIndex = 1;
			this.btnView.Text = "View details";
			this.btnView.UseVisualStyleBackColor = true;
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// PaymentsHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(644, 396);
			this.Controls.Add(this.btnView);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.listPayments);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PaymentsHistory";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Payments History";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listPayments;
		private System.Windows.Forms.ColumnHeader colDate;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnView;
		private System.Windows.Forms.ColumnHeader colSum;
		private System.Windows.Forms.ColumnHeader colService;
	}
}