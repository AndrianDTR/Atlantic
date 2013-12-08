using System;
using System.Text;
using System.Windows.Forms;
using AY.Utils;

namespace Registrator
{
	public partial class ActivatorForm : Form
	{
		public ActivatorForm()
		{
			InitializeComponent();
#if DEBUG			
			FillRegInfo();
#endif
		}
		
		private void FillRegInfo()
		{
			textSerial.Text = "BF279-1DE7C-EDB5A-D0207-488CF-452CA-FD24F-D06D1";
			textFName.Text = "Andrian";
			textLName.Text = "Yablonskyy";
			textPhone.Text = "+ 380 (67) 439 - 1881";
			textCustomer.Text = "1";
			textEmail.Text = "an-hak@mail.ru";
			textAddress.Text = "81105,\n8, N. Yaremchuka str.,\nNavaria,\nUkraine";
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			// Get registration data
			byte[] bytesId = BitConverter.GetBytes(Int32.Parse(textCustomer.Text));
			byte[] bytesSerial = Encoding.UTF8.GetBytes(textSerial.Text);
			byte[] bytesBuf = new byte[(int)RegUtils.ActKeyOffsets._end];
			
			// Create registration message
			String msg = "This application copy is registered to:\n\n";
			msg += String.Format("{0} {1}\n\n", textFName.Text.ToUpper(), textLName.Text.ToUpper());
			msg += String.Format("Address: {0}\n", textAddress.Text);
			msg += String.Format("Email: {0}\n", textEmail.Text); 
			msg += String.Format("Phone: {0}\n", textPhone.Text);
			msg += String.Format("\n");
			msg += String.Format("Customer ID: {0}\n\n", textCustomer.Text);
			msg += String.Format("Serial number: {0}\n\n", textSerial.Text);
			msg += RegUtils.Instance.MsgSplitter;
			
			// Generate suffix string
			int suffixLen = (int)(RegUtils.ActKeyOffsets._end 
					- RegUtils.ActKeyOffsets.Message) 
				- msg.Length;
				
			String suffixStr = RegUtils.Instance.GenerateRandomString(suffixLen);
			msg += suffixStr;
			
			// Get message bytes
			byte[] bytesMsg = Encoding.UTF8.GetBytes(msg);

			// Encrypt Message data
			for (int n = 0; n < bytesMsg.Length; n++)
			{
				RegUtils.ROL(ref bytesMsg[n], n % 8);
			}
			
			// Fill buffer
			int len = Math.Min(bytesId.Length
				, (int)(RegUtils.ActKeyOffsets.Serial - RegUtils.ActKeyOffsets.CustomerId));
			Array.Copy(bytesId, 0, bytesBuf, (int)RegUtils.ActKeyOffsets.CustomerId, len);

			len = Math.Min(bytesSerial.Length
				, (int)(RegUtils.ActKeyOffsets.Message - RegUtils.ActKeyOffsets.Serial));
			Array.Copy(bytesSerial, 0, bytesBuf, (int)RegUtils.ActKeyOffsets.Serial, len);

			len = Math.Min(bytesMsg.Length
				, (int)(RegUtils.ActKeyOffsets._end - RegUtils.ActKeyOffsets.Message));
			Array.Copy(bytesMsg, 0, bytesBuf, (int)RegUtils.ActKeyOffsets.Message, len);
			
			textActKey.Text = Convert.ToBase64String(bytesBuf);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
