using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AY;
using AY.Utils;
using AY.db;

namespace EAssistant
{
	public partial class BarcodePrinter : Form
	{
		private int m_nMinCodeLen = Session.MinBarcodeLen;
		Random m_random = new Random(Environment.TickCount);
		String m_Style = "";
		public BarcodePrinter()
		{
			InitializeComponent();
					
			m_Style = @"table 
{
    border-collapse: collapse;
    border-spacing: 0;
    border: 0;
    table-layout: fixed;
    width:17cm;
    max-width: 17cm;
}

table td, table th {
    border: 1px solid black;
}
";

			Init();
		}
		
		private void Init()
		{
			int nRows = (int)numericRows.Value;
			int nCols = (int)numericCols.Value;
			Int32 nMaxClientId = GetMaxClientCode();
			
			WaitDialog wd = new WaitDialog(0, nRows * nCols, 1);
			wd.Show();
			wd.Refresh();
						
			String html = String.Format("<html><head><style type=\"text/css\">{0}</style></head><body>"
				+ "<table style=\"font: {1}pt, code EAN13;\">"
				, m_Style
				, (int)numericFontSize.Value);
			
			for (int nRow = 0; nRow < nRows; nRow++)
			{
				html += "<tr>";
				for (int nCol = 0; nCol < nCols; nCol++)
				{
					html += "<td style=\"padding:4px;\">";
					html += String.Format("{0}", Barcode.EAN13(GetCode(++nMaxClientId)).ToString());
					wd.StepIt();
					html += "</td>";
				}
				html += "</tr>";
			}
			
			html += "</table></body></html>";

			webBrowser.DocumentText = html;
			wd.Close();
		}
		
		private Int32 GetMaxClientCode()
		{
			Object res = Db.Instance.dSet.clients.Compute("max(id)", "");
			Int32 code = Int32.Parse(res.ToString());
			
			return code;
		}
		
		public static String GetCode(Int32 id)
		{
			return String.Format("22{0}{1}"
				, Session.Instance.CustomerId.ToString().PadLeft(5, '0')
				, id.ToString().PadLeft(5, '0'));
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			webBrowser.Print();
		}

		private void btnRegenerate_Click(object sender, EventArgs e)
		{
			Init();
		}
	}
}
