using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class PaymentsHistory : Form
	{
		private DataGridViewTextBoxColumn colDate;
		private DataGridViewTextBoxColumn colSum;
		private DataGridViewTextBoxColumn colService;

		
		private Int64 m_clientId = 0;
		
		public PaymentsHistory()
		{
			InitializeComponent();
			Init();
			
			bindingSource.DataSource = Db.Instance.dSet;
			bindingSource.Position = 0;
			gridPayments.DataSource = bindingSource;
			gridPayments.DataMember = "payments";
		}

		public Int64 ClientId
		{
			get{ return m_clientId;}
			set
			{
				m_clientId = value;
				bindingSource.Filter = String.Format("clientId = {0}", m_clientId);
			}
		}

		private void PaymentsHistory_Load(object sender, EventArgs e)
		{
			Db.Instance.Adapters.paymentsTableAdapter.FillService(Db.Instance.dSet.payments);
		}
		
		private void Init()
		{
			colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colService = new System.Windows.Forms.DataGridViewTextBoxColumn();
			
			colDate.DataPropertyName = "payments.date";
			colDate.DefaultCellStyle.Format = "G";
			colDate.HeaderText = "Date";
			colDate.Name = "dataGridViewTextBoxColumn1";
			colDate.ReadOnly = true;

			colSum.DataPropertyName = "payments.sum";
			colSum.DefaultCellStyle.Format = "C2";
			colSum.HeaderText = "Sum";
			colSum.Name = "dataGridViewTextBoxColumn2";
			colSum.ReadOnly = true;

			colService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			colService.DataPropertyName = "scheduleRules.name";
			colService.HeaderText = "Service";
			colService.Name = "dataGridViewTextBoxColumn3";
			colService.ReadOnly = true;
			
			gridPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				colDate, colSum, colService});
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
			if (gridPayments.SelectedRows.Count < 1)
				return;
			
			/*
			Int64 id = (Int64)gridPayments.SelectedItems[0];
			PaymentDetail pd = new PaymentDetail(id);
			pd.ShowDialog();
			 * */
		}
	}
}
