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
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			String randStr = ExeUtils.RandomString((int)ExeUtils.DataOffsets.ActKey / 4);
			
			String data = String.Empty;
			data += String.Format("Registered to {0} {1}\n", textFName.Text, textLName.Text);
			data += String.Format("{0}\n", textAddress.Text);
			data += String.Format("Phone: {0}\n", textPhone.Text);
			data += String.Format("Email: {0}\n", textEmail.Text);
			data += String.Format("\n");
			data += String.Format("Serial number: {0}|{1}", textSerial.Text, randStr);
			
			byte[] key = Encoding.UTF8.GetBytes(data);
			for(int n = 0; n < key.Length; n++)
			{
				ExeUtils.ROL(ref key[n], n % 8);
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
