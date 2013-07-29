namespace GAssistant
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
			this.save = new System.Windows.Forms.Button();
			this.close = new System.Windows.Forms.Button();
			this.rule = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.name = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.add = new System.Windows.Forms.Button();
			this.remove = new System.Windows.Forms.Button();
			this.rulesList = new System.Windows.Forms.ListBox();
			this.price = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(389, 195);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(75, 23);
			this.save.TabIndex = 6;
			this.save.Text = "Apply";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// close
			// 
			this.close.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.close.Location = new System.Drawing.Point(521, 195);
			this.close.Name = "close";
			this.close.Size = new System.Drawing.Size(75, 23);
			this.close.TabIndex = 7;
			this.close.Text = "Close";
			this.close.UseVisualStyleBackColor = true;
			// 
			// rule
			// 
			this.rule.Location = new System.Drawing.Point(282, 59);
			this.rule.Multiline = true;
			this.rule.Name = "rule";
			this.rule.Size = new System.Drawing.Size(314, 130);
			this.rule.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(224, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Rule";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(282, 7);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(314, 20);
			this.name.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(224, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Name";
			// 
			// add
			// 
			this.add.Location = new System.Drawing.Point(227, 195);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(75, 23);
			this.add.TabIndex = 4;
			this.add.Text = "Add new";
			this.add.UseVisualStyleBackColor = true;
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// remove
			// 
			this.remove.Location = new System.Drawing.Point(308, 195);
			this.remove.Name = "remove";
			this.remove.Size = new System.Drawing.Size(75, 23);
			this.remove.TabIndex = 5;
			this.remove.Text = "Remove";
			this.remove.UseVisualStyleBackColor = true;
			this.remove.Click += new System.EventHandler(this.remove_Click);
			// 
			// rulesList
			// 
			this.rulesList.Dock = System.Windows.Forms.DockStyle.Left;
			this.rulesList.FormattingEnabled = true;
			this.rulesList.Location = new System.Drawing.Point(0, 0);
			this.rulesList.Name = "rulesList";
			this.rulesList.Size = new System.Drawing.Size(218, 225);
			this.rulesList.TabIndex = 0;
			this.rulesList.SelectedIndexChanged += new System.EventHandler(this.rulesList_SelectedIndexChanged);
			// 
			// price
			// 
			this.price.Location = new System.Drawing.Point(282, 33);
			this.price.Name = "price";
			this.price.Size = new System.Drawing.Size(314, 20);
			this.price.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(224, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Price";
			// 
			// ManageScheduleRules
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(611, 225);
			this.Controls.Add(this.price);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rulesList);
			this.Controls.Add(this.remove);
			this.Controls.Add(this.add);
			this.Controls.Add(this.save);
			this.Controls.Add(this.close);
			this.Controls.Add(this.rule);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.name);
			this.Controls.Add(this.label1);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button close;
		private System.Windows.Forms.TextBox rule;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox name;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button add;
		private System.Windows.Forms.Button remove;
		private System.Windows.Forms.ListBox rulesList;
		private System.Windows.Forms.TextBox price;
		private System.Windows.Forms.Label label2;
	}
}