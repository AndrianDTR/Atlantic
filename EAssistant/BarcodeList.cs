using System;
using System.Windows.Forms;
using AY;
using AY.Utils;
using AY.db;
using AY.Log;

namespace EAssistant
{
	public partial class BarcodeList : Form
	{
		public BarcodeList()
		{
			InitializeComponent();
		}

		public static String GetCode(Int32 id)
		{
			Logger.Enter();
			String code = String.Format("22{0}{1}"
				, Session.Instance.CustomerId.ToString().PadLeft(5, '0')
				, id.ToString().PadLeft(5, '0'));

			Logger.Leave();
			return code;
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				Int32 nClientId = 0;
				int nCodes = 0;
				
				int.TryParse(textFirstBCode.Text, out nClientId);
				int.TryParse(textBox1.Text, out nCodes);
			
				String[] szCodes = new String[nCodes];
				for (int nRow = 0; nRow < nCodes; nRow++)
				{
					szCodes[nRow] = Barcode.EAN13(GetCode(++nClientId)).ToString();
				}
				
				textBarcodesList.Lines = szCodes;

			} while (false);
			Logger.Leave();
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			textBarcodesList.SelectAll();
			textBarcodesList.Copy();
			textBarcodesList.DeselectAll();
		}
	}
}
