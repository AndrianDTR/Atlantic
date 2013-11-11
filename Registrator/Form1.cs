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
			textAddress.Text = @"81105, N. Yaremchuka str., 8
Navaria, 
Ukraine";

		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			String randStr = RegUtils.RandomString((int)RegUtils.DataOffsets.ActKey / 4);

			String data = "This application copy is registered to:\n\n";
			data += String.Format("{0} {1}\n\n", textFName.Text.ToUpper(), textLName.Text.ToUpper());
			data += String.Format("Address: {0}\n", textAddress.Text);
			data += String.Format("Email: {0}\n", textEmail.Text); 
			data += String.Format("Phone: {0}\n", textPhone.Text);
			data += String.Format("\n");
			data += String.Format("Serial number: {0}\n", textSerial.Text);
			data += String.Format("Customer ID: {0}|{1}", textCustomer.Text, randStr);
			
			byte[] key = Encoding.UTF8.GetBytes(data);
			for(int n = 0; n < key.Length; n++)
			{
				RegUtils.ROL(ref key[n], n % 8);
			}
			
			String key64 = Convert.ToBase64String(key);
			textActKey.Text = key64;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
