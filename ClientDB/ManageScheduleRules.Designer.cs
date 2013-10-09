namespace EAssistant
{
	partial class ManageScheduleRules
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
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.gridRules = new System.Windows.Forms.DataGridView();
			this.scheduleRulesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gridRules)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scheduleRulesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(443, 343);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 23);
			this.ok.TabIndex = 6;
			this.ok.Text = "OK";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.save_Click);
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cancel.Location = new System.Drawing.Point(524, 343);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 7;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.gridRules.AllowUserToResizeRows = false;
			this.gridRules.AutoGenerateColumns = false;
			this.gridRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridRules.DataSource = this.scheduleRulesBindingSource;
			this.gridRules.Location = new System.Drawing.Point(12, 12);
			this.gridRules.MultiSelect = false;
			this.gridRules.Name = "dataGridView1";
			this.gridRules.RowHeadersVisible = false;
			this.gridRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridRules.Size = new System.Drawing.Size(587, 319);
			this.gridRules.TabIndex = 8;
			// 
			// scheduleRulesBindingSource
			// 
			this.scheduleRulesBindingSource.DataMember = "scheduleRules";
			// 
			// ManageScheduleRules
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(611, 378);
			this.Controls.Add(this.gridRules);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.cancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageScheduleRules";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage schedule rules";
			this.Load += new System.EventHandler(this.OnLoad);
			((System.ComponentModel.ISupportInitialize)(this.gridRules)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scheduleRulesBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.DataGridView gridRules;
		private System.Windows.Forms.BindingSource scheduleRulesBindingSource;
	}
}