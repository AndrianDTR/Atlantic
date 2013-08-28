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
			byte[] key = Encoding.UTF8.GetBytes("Valid ACT key for: " + textSerial.Text + randStr);
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
