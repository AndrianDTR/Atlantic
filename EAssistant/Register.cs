using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using AY.Utils;
using System.Text;
using AY.Log;
using AY.Packer;
using System.IO.Compression;

namespace EAssistant
{
	public class RegisterForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textSerial;
		private System.Windows.Forms.Label label1;
		public Button btnProcess;
		private Label label3;
		private TextBox textActKey;
		public Button btnCancel;
		private PictureBox pictureBox1;

		public RegisterForm(String serial)
		{
			Logger.Enter();
			InitializeComponent();
			textSerial.Text = serial;
			Logger.Leave();
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
			this.textSerial = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnProcess = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textActKey = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// textSerial
			// 
			this.textSerial.AccessibleDescription = null;
			this.textSerial.AccessibleName = null;
			resources.ApplyResources(this.textSerial, "textSerial");
			this.textSerial.BackColor = System.Drawing.SystemColors.Window;
			this.textSerial.BackgroundImage = null;
			this.textSerial.Font = null;
			this.textSerial.Name = "textSerial";
			this.textSerial.ReadOnly = true;
			// 
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Name = "label1";
			// 
			// btnProcess
			// 
			this.btnProcess.AccessibleDescription = null;
			this.btnProcess.AccessibleName = null;
			resources.ApplyResources(this.btnProcess, "btnProcess");
			this.btnProcess.BackgroundImage = null;
			this.btnProcess.Font = null;
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = null;
			this.label3.AccessibleName = null;
			resources.ApplyResources(this.label3, "label3");
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Name = "label3";
			// 
			// textActKey
			// 
			this.textActKey.AccessibleDescription = null;
			this.textActKey.AccessibleName = null;
			resources.ApplyResources(this.textActKey, "textActKey");
			this.textActKey.BackColor = System.Drawing.SystemColors.Window;
			this.textActKey.BackgroundImage = null;
			this.textActKey.Font = null;
			this.textActKey.Name = "textActKey";
			// 
			// pictureBox1
			// 
			this.pictureBox1.AccessibleDescription = null;
			this.pictureBox1.AccessibleName = null;
			resources.ApplyResources(this.pictureBox1, "pictureBox1");
			this.pictureBox1.BackgroundImage = global::EAssistant.Properties.Resources.Game_diamond_icon;
			this.pictureBox1.Font = null;
			this.pictureBox1.ImageLocation = null;
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.TabStop = false;
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
			// 
			// RegisterForm
			// 
			this.AcceptButton = this.btnProcess;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textActKey);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textSerial);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RegisterForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void btnProcess_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			try
			{
				byte[] buf = RegUtils.Instance.SavedData;

				int regIdLen = (int)(RegUtils.ActKeyOffsets.Serial - RegUtils.ActKeyOffsets.CustomerId);
				int regSerialLen = (int)(RegUtils.ActKeyOffsets.Message - RegUtils.ActKeyOffsets.Serial);
				int regMsgLen = (int)(RegUtils.ActKeyOffsets._end - RegUtils.ActKeyOffsets.Message);

				if (null == buf)
				{
					//buf = RegUtils.Instance.FillRegInfo();
					Logger.Critical("No registration data.");
					throw new Exception();
				}

				byte[] data = Convert.FromBase64String(textActKey.Text);
				data = Archive.DecompressArray(data);

				Array.Copy(data
					, (int)RegUtils.ActKeyOffsets.CustomerId
					, buf
					, (int)RegUtils.DataOffsets.CustomerId
					, regIdLen);

				Array.Copy(data
					, (int)RegUtils.ActKeyOffsets.Serial
					, buf
					, (int)RegUtils.DataOffsets.Serial
					, regSerialLen);

				Array.Copy(data
					, (int)RegUtils.ActKeyOffsets.Message
					, buf
					, (int)RegUtils.DataOffsets.Message
					, regMsgLen);


				RegUtils.Instance.SavedData = buf;

				DialogResult = DialogResult.OK;
				this.Close();

			}
			catch (System.Exception ex)
			{
				Logger.Error(String.Format("Registration error, internal message: {0}", ex.Message));
				UIMessages.Info(
					Session.Instance.GetResStr("invalid_activation_key"));
			}
			Logger.Leave();

		}
	}
}
