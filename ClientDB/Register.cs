using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Runtime.Serialization;

namespace GAssistant
{

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// <exception cref="DataStoreAppConfigException">
	/// If the datastore has not been initialized before the form was created this exception will be thrown.
	/// </exception>
	public class RegisterForm : System.Windows.Forms.Form
	{

		#region private form variables
		private System.Windows.Forms.TextBox firstname;
		private System.Windows.Forms.TextBox lastname;
		private System.Windows.Forms.TextBox phone;
		private System.Windows.Forms.TextBox email;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button submit;
		private System.Windows.Forms.ErrorProvider errNotifier;
	
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Label label3;
		private TextBox textSerial;
		private PictureBox pictureBox1;
		string _status;
		#endregion

		#region constructor
		/// <summary>
		/// The constructor for the Register Form
		/// </summary>
		/// <exception cref="DataStoreAppConfigException">
		/// If the datastore has not been initialized before the form was created this exception will be thrown.
		/// </exception>
		public RegisterForm()
		{
			InitializeComponent();
			
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.firstname = new System.Windows.Forms.TextBox();
			this.lastname = new System.Windows.Forms.TextBox();
			this.phone = new System.Windows.Forms.TextBox();
			this.email = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.submit = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textSerial = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// firstname
			// 
			this.firstname.BackColor = System.Drawing.SystemColors.Window;
			this.firstname.Location = new System.Drawing.Point(171, 32);
			this.firstname.MaxLength = 32;
			this.firstname.Name = "firstname";
			this.firstname.Size = new System.Drawing.Size(175, 20);
			this.firstname.TabIndex = 0;
			// 
			// lastname
			// 
			this.lastname.BackColor = System.Drawing.SystemColors.Window;
			this.lastname.Location = new System.Drawing.Point(362, 32);
			this.lastname.MaxLength = 32;
			this.lastname.Name = "lastname";
			this.lastname.Size = new System.Drawing.Size(175, 20);
			this.lastname.TabIndex = 1;
			// 
			// phone
			// 
			this.phone.BackColor = System.Drawing.SystemColors.Window;
			this.phone.Location = new System.Drawing.Point(171, 87);
			this.phone.MaxLength = 32;
			this.phone.Name = "phone";
			this.phone.Size = new System.Drawing.Size(175, 20);
			this.phone.TabIndex = 6;
			// 
			// email
			// 
			this.email.BackColor = System.Drawing.SystemColors.Window;
			this.email.Location = new System.Drawing.Point(362, 87);
			this.email.MaxLength = 32;
			this.email.Name = "email";
			this.email.Size = new System.Drawing.Size(175, 20);
			this.email.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(171, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "First Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(362, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Last Name:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(171, 66);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Phone:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(361, 67);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "E-mail:";
			// 
			// submit
			// 
			this.submit.AutoSize = true;
			this.submit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.submit.Location = new System.Drawing.Point(423, 189);
			this.submit.Name = "submit";
			this.submit.Size = new System.Drawing.Size(114, 23);
			this.submit.TabIndex = 19;
			this.submit.Text = "Submit";
			this.submit.Click += new System.EventHandler(this.submit_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(171, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Serial Number:";
			// 
			// textSerial
			// 
			this.textSerial.BackColor = System.Drawing.SystemColors.Window;
			this.textSerial.Location = new System.Drawing.Point(171, 143);
			this.textSerial.MaxLength = 32;
			this.textSerial.Name = "textSerial";
			this.textSerial.Size = new System.Drawing.Size(366, 20);
			this.textSerial.TabIndex = 20;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::GAssistant.Properties.Resources.Game_diamond_icon;
			this.pictureBox1.Location = new System.Drawing.Point(22, 23);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(130, 130);
			this.pictureBox1.TabIndex = 22;
			this.pictureBox1.TabStop = false;
			// 
			// RegisterForm
			// 
			this.AcceptButton = this.submit;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(569, 235);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textSerial);
			this.Controls.Add(this.submit);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.email);
			this.Controls.Add(this.phone);
			this.Controls.Add(this.lastname);
			this.Controls.Add(this.firstname);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RegisterForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Register";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		#region form event handling


		/// <summary>
		/// used to validate the input on the form
		/// </summary>
		/// <param name="control"></param>
		/// <returns></returns>
		private bool ValidateField(Control control)
		{
			/*
			 FormValidator.ControlValidator validator;

			if (control.Name == "email")
			{
				validator = new FormValidator.ControlValidator(FormValidator.Isemailvalidator);
			}
			else
			{
				validator = new FormValidator.ControlValidator(FormValidator.Hastextvalidator);
			}

			return FormValidator.Fieldisvalid(this.errNotifier, control, "Required Field", validator);
			*/
			return false;
		}

		/// <summary>
		/// If the button is clicked and the status is submitted or Error then the form is closed.
		/// Otherwise, the UI is initialized to a processing status and the web service is contacted
		/// via the serverProcessing class
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void submit_Click(object sender, System.EventArgs e)
		{


			if (_status == "submitted" || _status == "Error")
			{
				this.Close();
			}
			else
			{

				//first validate name and email fields to see if they are populated.  We do this because the IF statement
				//below will only run the first validation if it fails right there, and we want to validate all three fields
				//no matter what
				ValidateField(this.firstname);
				ValidateField(this.lastname);
				ValidateField(this.email);

				if (ValidateField(this.firstname) && ValidateField(this.lastname) && ValidateField(this.email))
				{
					this.firstname.Visible = false;
					this.lastname.Visible = false;
					this.phone.Visible = false;
					this.email.Visible = false;
					this.label1.Visible = false;
					this.label2.Visible = false;
					this.label3.Visible = false;
					this.label7.Visible = false;
					this.label8.Visible = false;
					/*
					_status = "submitted";
					TextBox statusText = new TextBox();
					statusText.Multiline = true;
					statusText.BorderStyle = BorderStyle.None;
					statusText.ReadOnly = true;
					statusText.TabStop = false;
					statusText.BackColor = Color.White;
					statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					statusText.Name = "statusText";
					statusText.Text = "Your registration is being processed.  This may take a few moments.";
					Graphics grfx = this.CreateGraphics();
					SizeF sizef = grfx.MeasureString(statusText.Text, statusText.Font, 300);
					statusText.Width = 350;
					statusText.Height = Convert.ToInt32(sizef.Height) + 50;
					statusText.Location = new Point(170, (this.Height - statusText.Height) / 2);
					this.submit.Enabled = false;
					this.Controls.Add(statusText);

					DataStore dataStore = new DataStore(this);
					RegisterInfo registerInfo = new RegisterInfo(dataStore.ProductName,
																dataStore.GetLicenseLevel.LicenseLevel, this.email.Text,
																this.firstname.Text, this.lastname.Text,
																dataStore.Devtoken,
																this.address.Text, this.city.Text,
																this.state.Text, this.zipcode.Text,
																this.phone.Text, dataStore.UniqueMachineID,
																this);

					//Create the new web service processing class and pass in the information to be transmitted
					sp = new Serverprocessing(registerInfo);

					//set up the event handlers for the serverProcessing Class
					sp.Processingcomplete += new EventHandler<ProcessingCompletedEvent>(this.RegisterForm_ProccessingComplete);
					sp.Processingfailed += new EventHandler<ProcessingFailedEvent>(this.RegisterForm_ProccessingFailed);

					//start the web service on a seperate thread
					ThreadStart handleProcessingThreadStarter = new ThreadStart(sp.HandleRegistration);
					Thread handleProcessingThread = new Thread(handleProcessingThreadStarter);
					handleProcessingThread.Start();
					*/
				}
			}
		}



		#endregion


	}
}
