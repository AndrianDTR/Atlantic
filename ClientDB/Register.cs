using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using AY.Utils;
using System.Text;

namespace GAssistant
{
	public class RegisterForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textSerial;
		private System.Windows.Forms.Label label1;
		public Button btnProcess;
		private Label label3;
		private TextBox textActKey;
		private PictureBox pictureBox1;

		public RegisterForm(String serial)
		{
			InitializeComponent();
			textSerial.Text = serial;
		}
		
		private void InitializeComponent()
		{
			this.textSerial = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnProcess = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textActKey = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// textSerial
			// 
			this.textSerial.BackColor = System.Drawing.SystemColors.Window;
			this.textSerial.Location = new System.Drawing.Point(171, 32);
			this.textSerial.MaxLength = 32;
			this.textSerial.Name = "textSerial";
			this.textSerial.ReadOnly = true;
			this.textSerial.Size = new System.Drawing.Size(366, 20);
			this.textSerial.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(171, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Serial:";
			// 
			// btnProcess
			// 
			this.btnProcess.AutoSize = true;
			this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnProcess.Location = new System.Drawing.Point(423, 179);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(114, 23);
			this.btnProcess.TabIndex = 1;
			this.btnProcess.Text = "Process";
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(171, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Activation key:";
			// 
			// textActKey
			// 
			this.textActKey.BackColor = System.Drawing.SystemColors.Window;
			this.textActKey.Location = new System.Drawing.Point(171, 85);
			this.textActKey.MaxLength = 2048;
			this.textActKey.Multiline = true;
			this.textActKey.Name = "textActKey";
			this.textActKey.Size = new System.Drawing.Size(366, 80);
			this.textActKey.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::GAssistant.Properties.Resources.Game_diamond_icon;
			this.pictureBox1.Location = new System.Drawing.Point(12, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(130, 133);
			this.pictureBox1.TabIndex = 22;
			this.pictureBox1.TabStop = false;
			// 
			// RegisterForm
			// 
			this.AcceptButton = this.btnProcess;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(548, 216);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textActKey);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textSerial);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RegisterForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Register";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void btnProcess_Click(object sender, EventArgs e)
		{
			FileInfo fi = new FileInfo("reporter.exe");
			byte[] buf = new byte[ExeUtils.BufSize];
			Int64 orgSize = 0;
			
			if (ExeUtils.GetExeData(fi, ref buf, ref orgSize))
			{
				byte[] srcDate = BitConverter.GetBytes((Int64)DateTime.Now.Ticks);
				byte[] serial = Encoding.ASCII.GetBytes(ExeUtils.GetSerialNumber());
				byte[] act = Convert.FromBase64String(textActKey.Text);
				
				int pos = 0;
				Array.Copy(srcDate, 0, buf, pos, srcDate.Length);

				pos += (int)ExeUtils.DataOffsets.Data;
				Array.Copy(serial, 0, buf, pos, serial.Length);
				
				pos += (int)ExeUtils.DataOffsets.Serial;
				pos += (int)ExeUtils.DataOffsets.PubKey;
				pos += (int)ExeUtils.DataOffsets.PrivKey;
				Array.Copy(act, 0, buf, pos, act.Length);

				ExeUtils.SetExeData(fi, buf, orgSize);
			}
		}
	}
}
