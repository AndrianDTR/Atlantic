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
			// textClientCode
			// 
			this.textClientCode.AccessibleDescription = null;
			this.textClientCode.AccessibleName = null;
			resources.ApplyResources(this.textClientCode, "textClientCode");
			this.textClientCode.BackgroundImage = null;
			this.textClientCode.Font = null;
			this.textClientCode.Name = "textClientCode";
			this.textClientCode.ReadOnly = true;
			// 
			// label2
			// 
			this.label2.AccessibleDescription = null;
			this.label2.AccessibleName = null;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Font = null;
			this.label2.Name = "label2";
			// 
			// textSum
			// 
			this.textSum.AccessibleDescription = null;
			this.textSum.AccessibleName = null;
			resources.ApplyResources(this.textSum, "textSum");
			this.textSum.BackgroundImage = null;
			this.textSum.Font = null;
			this.textSum.Name = "textSum";
			// 
			// Sum
			// 
			this.Sum.AccessibleDescription = null;
			this.Sum.AccessibleName = null;
			resources.ApplyResources(this.Sum, "Sum");
			this.Sum.Font = null;
			this.Sum.Name = "Sum";
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = null;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.AccessibleDescription = null;
			this.btnOk.AccessibleName = null;
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.BackgroundImage = null;
			this.btnOk.Font = null;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// comboTypeOfService
			// 
			this.comboTypeOfService.AccessibleDescription = null;
			this.comboTypeOfService.AccessibleName = null;
			resources.ApplyResources(this.comboTypeOfService, "comboTypeOfService");
			this.comboTypeOfService.BackgroundImage = null;
			this.comboTypeOfService.Font = null;
			this.comboTypeOfService.FormattingEnabled = true;
			this.comboTypeOfService.Name = "comboTypeOfService";
			this.comboTypeOfService.SelectedIndexChanged += new System.EventHandler(this.ChangeService);
			// 
			// textComment
			// 
			this.textComment.AccessibleDescription = null;
			this.textComment.AccessibleName = null;
			resources.ApplyResources(this.textComment, "textComment");
			this.textComment.BackgroundImage = null;
			this.textComment.Font = null;
			this.textComment.Name = "textComment";
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Font = null;
			this.label3.Name = "label3";
			// 
			// AddPayment
			// 
			this.AcceptButton = this.btnOk;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
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
			this.Icon = null;
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
	}
}