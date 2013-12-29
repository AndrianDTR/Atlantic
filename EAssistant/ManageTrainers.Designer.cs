namespace EAssistant
{
	partial class ManageTrainers
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTrainers));
			this.btnCancel = new System.Windows.Forms.Button();
			this.gridTrainers = new System.Windows.Forms.DataGridView();
			this.trainersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridTrainers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trainersBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// gridTrainers
			// 
			this.gridTrainers.AllowUserToResizeRows = false;
			this.gridTrainers.AutoGenerateColumns = false;
			this.gridTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridTrainers.DataSource = this.trainersBindingSource;
			resources.ApplyResources(this.gridTrainers, "gridTrainers");
			this.gridTrainers.Name = "gridTrainers";
			this.gridTrainers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.gridTrainers.RowHeadersVisible = false;
			this.gridTrainers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridTrainers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnError);
			// 
			// trainersBindingSource
			// 
			this.trainersBindingSource.DataMember = "trainers";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			resources.ApplyResources(this.btnOK, "btnOK");
			this.btnOK.Name = "btnOK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// ManageTrainers
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gridTrainers);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageTrainers";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Load += new System.EventHandler(this.OnLoad);
			((System.ComponentModel.ISupportInitialize)(this.gridTrainers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trainersBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.DataGridView gridTrainers;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.BindingSource trainersBindingSource;
		
	}
}