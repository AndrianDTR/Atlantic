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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeList));
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
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Font = null;
			this.label1.Name = "label1";
			// 
			// textBarcodesList
			// 
			this.textBarcodesList.AcceptsReturn = true;
			this.textBarcodesList.AccessibleDescription = null;
			this.textBarcodesList.AccessibleName = null;
			resources.ApplyResources(this.textBarcodesList, "textBarcodesList");
			this.textBarcodesList.BackgroundImage = null;
			this.textBarcodesList.Font = null;
			this.textBarcodesList.Name = "textBarcodesList";
			this.textBarcodesList.ReadOnly = true;
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnCancel.Font = null;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnGenerate
			// 
			this.btnGenerate.AccessibleDescription = null;
			this.btnGenerate.AccessibleName = null;
			resources.ApplyResources(this.btnGenerate, "btnGenerate");
			this.btnGenerate.BackgroundImage = null;
			this.btnGenerate.Font = null;
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Font = null;
			this.label2.Name = "label2";
			// 
			// textFirstBCode
			// 
			this.textFirstBCode.AccessibleDescription = null;
			this.textFirstBCode.AccessibleName = null;
			resources.ApplyResources(this.textFirstBCode, "textFirstBCode");
			this.textFirstBCode.BackgroundImage = null;
			this.textFirstBCode.Font = null;
			this.textFirstBCode.Name = "textFirstBCode";
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Font = null;
			this.label3.Name = "label3";
			// 
			// textBox1
			// 
			this.textBox1.AccessibleDescription = null;
			this.textBox1.AccessibleName = null;
			resources.ApplyResources(this.textBox1, "textBox1");
			this.textBox1.BackgroundImage = null;
			this.textBox1.Font = null;
			this.textBox1.Name = "textBox1";
			// 
			// btnCopy
			// 
			this.btnCopy.AccessibleDescription = null;
			this.btnCopy.AccessibleName = null;
			resources.ApplyResources(this.btnCopy, "btnCopy");
			this.btnCopy.BackgroundImage = null;
			this.btnCopy.Font = null;
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// BarcodeList
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textFirstBCode);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.textBarcodesList);
			this.Controls.Add(this.label1);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BarcodeList";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
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