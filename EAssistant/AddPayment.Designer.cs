namespace EAssistant
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPayment));
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
			this.textCount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// textClientCode
			// 
			resources.ApplyResources(this.textClientCode, "textClientCode");
			this.textClientCode.Name = "textClientCode";
			this.textClientCode.ReadOnly = true;
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// textSum
			// 
			resources.ApplyResources(this.textSum, "textSum");
			this.textSum.Name = "textSum";
			// 
			// Sum
			// 
			resources.ApplyResources(this.Sum, "Sum");
			this.Sum.Name = "Sum";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// comboTypeOfService
			// 
			this.comboTypeOfService.FormattingEnabled = true;
			resources.ApplyResources(this.comboTypeOfService, "comboTypeOfService");
			this.comboTypeOfService.Name = "comboTypeOfService";
			this.comboTypeOfService.SelectedIndexChanged += new System.EventHandler(this.ChangeService);
			// 
			// textComment
			// 
			resources.ApplyResources(this.textComment, "textComment");
			this.textComment.Name = "textComment";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// textCount
			// 
			resources.ApplyResources(this.textCount, "textCount");
			this.textCount.Name = "textCount";
			this.textCount.TextChanged += new System.EventHandler(this.textCount_TextChanged);
			this.textCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumbers);
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// AddPayment
			// 
			this.AcceptButton = this.btnOk;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.textCount);
			this.Controls.Add(this.label4);
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddPayment";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
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
		private System.Windows.Forms.TextBox textCount;
		private System.Windows.Forms.Label label4;
	}
}