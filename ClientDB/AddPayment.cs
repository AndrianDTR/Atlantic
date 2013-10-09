using System;
using System.Windows.Forms;
using System.Globalization;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class AddPayment : Form
	{
		private Int64 m_ClientId;
		
		public AddPayment(Int64 clientId)
		{
			InitializeComponent();
			m_ClientId = clientId;
			
			textClientCode.Text = m_ClientId.ToString().PadLeft(Session.MinBarcodeLen, '0');
			
			comboTypeOfService.Items.Clear();
			comboTypeOfService.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			comboTypeOfService.AutoCompleteSource = AutoCompleteSource.CustomSource;

			Db.Instance.Adapters.scheduleRulesTableAdapter.Fill(Db.Instance.dSet.scheduleRules);

			foreach (dbDataSet.scheduleRulesRow srr in Db.Instance.dSet.scheduleRules.Rows)
			{
				comboTypeOfService.Items.Add(srr);
				comboTypeOfService.AutoCompleteCustomSource.Add(srr.ToString());
			}
			
			textSum.Text = "0";
		}

		private void ChangeService(object sender, EventArgs e)
		{
			if(comboTypeOfService.SelectedIndex < 0)
				return;

			dbDataSet.scheduleRulesRow sr = (dbDataSet.scheduleRulesRow)comboTypeOfService.SelectedItem;
			textSum.Text = sr.price.ToString();
		}

		private Boolean ValidateForm()
		{
			Boolean res = false;
			do
			{
				if (null == comboTypeOfService.SelectedItem)
				{
					UIMessages.Error("Please select one of service first.");
					break;
				}

				try
				{
					float.Parse(textSum.Text.Trim());
				}
				catch
				{
					UIMessages.Error(String.Format("Please specify sum value in the 'XX{0}YY' format."
						, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
					break;
				}
			
				res = true;
			}while(false);
			
			return res;
		}
		
		private void btnOk_Click(object sender, EventArgs e)
		{
			if(!ValidateForm())
				return;

			dbDataSet.scheduleRulesRow sc = (dbDataSet.scheduleRulesRow)comboTypeOfService.SelectedItem;
			
			int id = Db.Instance.Adapters.paymentsTableAdapter.Insert(m_ClientId
				, sc.id
				, Session.Instance.UserId
				, DateTime.Now
				, decimal.Parse(textSum.Text.Trim())
				, textComment.Text);
			if(id != 1)
			{
				UIMessages.Error("Payment could not been added.");
				return;
			}
			
			Db.Instance.AcceptChanges();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
