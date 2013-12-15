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
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnCancel.Location = new System.Drawing.Point(530, 242);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// gridTrainers
			// 
			this.gridTrainers.AllowUserToResizeRows = false;
			this.gridTrainers.AutoGenerateColumns = false;
			this.gridTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridTrainers.DataSource = this.trainersBindingSource;
			this.gridTrainers.Location = new System.Drawing.Point(12, 12);
			this.gridTrainers.Name = "gridTrainers";
			this.gridTrainers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.gridTrainers.RowHeadersVisible = false;
			this.gridTrainers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridTrainers.Size = new System.Drawing.Size(593, 220);
			this.gridTrainers.TabIndex = 7;
			this.gridTrainers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnError);
			// 
			// trainersBindingSource
			// 
			this.trainersBindingSource.DataMember = "trainers";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(449, 242);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// ManageTrainers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 277);
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
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage trainers";
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