using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class PaymentsHistory : Form
	{
		private DataGridViewTextBoxColumn colId;
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
			gridPayments.DataMember = "vPayments";
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
			Db.Instance.Adapters.vPaymentsTableAdapter.Fill(Db.Instance.dSet.vPayments);
		}
		
		private void Init()
		{
			colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			colService = new System.Windows.Forms.DataGridViewTextBoxColumn();

			colId.DataPropertyName = "id";
			colId.HeaderText = "ID";
			colId.Visible = false;
			colId.Name = "id";
			colId.ReadOnly = true;
			
			colDate.DataPropertyName = "date";
			colDate.DefaultCellStyle.Format = "G";
			colDate.HeaderText = "Date";
			colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			colDate.Name = "date";
			colDate.ReadOnly = true;

			colSum.DataPropertyName = "sum";
			colSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			colSum.DefaultCellStyle.Format = "C2";
			colSum.HeaderText = "Sum";
			colSum.Name = "sum";
			colSum.ReadOnly = true;

			colService.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			colService.DataPropertyName = "service";
			colService.HeaderText = "Service";
			colService.Name = "service";
			colService.ReadOnly = true;
			
			gridPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				colId, colDate, colSum, colService});
		}

		private void btnView_Click(object sender, EventArgs e)
		{
			PaymentInfo();
		}

		private void ViewDetail(object sender, DataGridViewCellEventArgs e)
		{
			PaymentInfo();
		}
		
		private void PaymentInfo()
		{
			if (gridPayments.SelectedRows.Count < 1)
				return;

			Int64 id = (Int64)gridPayments.SelectedRows[0].Cells["id"].Value;
			PaymentDetail pd = new PaymentDetail(id);
			pd.ShowDialog();
		}


	}
}
