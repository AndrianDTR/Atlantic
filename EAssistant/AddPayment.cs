using System;
using System.Windows.Forms;
using System.Globalization;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class AddPayment : Form
	{
		private Int32 m_ClientId;

		public AddPayment(Int32 clientId)
		{
			Logger.Enter();

			InitializeComponent();
			m_ClientId = clientId;

			textClientCode.Text = BarcodePrinter.GetCode(m_ClientId);

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
			Logger.Leave();
		}

		private void ChangeService(object sender, EventArgs e)
		{
			Logger.Enter();

			do
			{
				if (comboTypeOfService.SelectedIndex < 0)
					break;

				dbDataSet.scheduleRulesRow sr = (dbDataSet.scheduleRulesRow)comboTypeOfService.SelectedItem;
				textSum.Text = sr.price.ToString();
			} while (false);
			Logger.Leave();
		}

		private Boolean ValidateForm()
		{
			Logger.Enter();
			Boolean res = false;
			do
			{
				if (null == comboTypeOfService.SelectedItem)
				{
					UIMessages.Error(Session.GetResStr("AP_SERVICE_NOT_SPECIFIED"));
					break;
				}

				try
				{
					float.Parse(textSum.Text.Trim());
				}
				catch
				{
					UIMessages.Error(
						String.Format(
							Session.GetResStr("AP_INVALID_SUM_FORMAT")
							, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
					break;
				}

				res = true;
			} while (false);
			Logger.Leave();
			return res;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				if (!ValidateForm())
					break;

				dbDataSet.scheduleRulesRow sc = (dbDataSet.scheduleRulesRow)comboTypeOfService.SelectedItem;

				int id = Db.Instance.Adapters.paymentsTableAdapter.Insert(m_ClientId
					, sc.id
					, Session.Instance.UserId
					, DateTime.Now
					, decimal.Parse(textSum.Text.Trim())
					, textComment.Text);

				dbDataSet.clientsRow cr = Db.Instance.dSet.clients.FindByid(m_ClientId);
				if (null != cr)
				{
					cr.hoursLeft += sc.hoursAdd;
					cr.plan = sc.id;
				}

				if (id != 1 | null == cr)
				{
					UIMessages.Error(Session.GetResStr("AP_ADD_ERROR"));
					break;
				}

				Db.Instance.AcceptChanges();

				Session.Instance.UpdateMain();

				this.DialogResult = DialogResult.OK;
				this.Close();
			} while (false);
			Logger.Leave();
		}
	}
}
