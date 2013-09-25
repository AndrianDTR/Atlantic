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
			
			textClientCode.Text = m_ClientId.ToString().PadLeft(13,'0');
			
			comboTypeOfService.Items.Clear();
			comboTypeOfService.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			comboTypeOfService.AutoCompleteSource = AutoCompleteSource.CustomSource;

			foreach (ScheduleRule sr in new ScheduleRulesCollection())
			{
				comboTypeOfService.Items.Add(sr);
				comboTypeOfService.AutoCompleteCustomSource.Add(sr.ToString());
			}
			
			textSum.Text = "0";
		}

		private void ChangeService(object sender, EventArgs e)
		{
			if(comboTypeOfService.SelectedIndex < 0)
				return;

			ScheduleRule sr = (ScheduleRule)comboTypeOfService.SelectedItem;
			textSum.Text = sr.Price.ToString();
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
			
			ScheduleRule sc = (ScheduleRule)comboTypeOfService.SelectedItem;
			
			if(!new PaymentsCollection().Add(m_ClientId
				, sc.Id
				, Session.Instance.UserId
				, float.Parse(textSum.Text.Trim())
				, textComment.Text))
			{
				UIMessages.Error("Payment could not been added.");
				return;
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
