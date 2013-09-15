using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class PaymentsHistory : Form
	{
		private PaymentsCollection m_payments = null;
		
		public PaymentsHistory(): this (0)
		{
		}

		public PaymentsHistory(Int64 clientId)
		{
			m_payments = new PaymentsCollection(clientId);
			InitializeComponent();
			Reinit();
		}

		private void Reinit()
		{
			listPayments.Items.Clear();

			foreach (Payment pay in m_payments)
			{
				ListViewItem lvi = listPayments.Items.Add(pay.Date.ToString());
				lvi.SubItems.Add(pay.Sum.ToString());
				lvi.SubItems.Add(new ScheduleRule(pay.ScheduleId).ToString());
				lvi.Tag = pay.Id;
			}
		}
		
		private void btnView_Click(object sender, EventArgs e)
		{
			PaymentInfo();
		}

		private void ShowDetails(object sender, EventArgs e)
		{
			PaymentInfo();
		}
		
		private void PaymentInfo()
		{
			if (listPayments.SelectedItems.Count < 1)
				return;

			Int64 id = (Int64)listPayments.SelectedItems[0].Tag;
			PaymentDetail pd = new PaymentDetail(id);
			pd.ShowDialog();
		}
	}
}
