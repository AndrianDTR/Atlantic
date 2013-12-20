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

		private Int32 m_clientId = 0;

		public PaymentsHistory()
		{
			Logger.Enter();

			InitializeComponent();

			bindingSource.DataSource = Db.Instance.dSet.VPayments;
			bindingSource.Position = 0;
			gridPayments.DataSource = bindingSource;
			Logger.Leave();
		}

		public Int32 ClientId
		{
			get { return m_clientId; }
			set
			{
				Logger.Enter();
				m_clientId = value;
				Db.Instance.Adapters.VPaymentsTableAdapter.FillBy(Db.Instance.dSet.VPayments, m_clientId);
				Logger.Leave();
			}
		}

		private void PaymentsHistory_Load(object sender, EventArgs e)
		{
			Logger.Enter();
			Init();

			if (0 != m_clientId)
				Db.Instance.Adapters.VPaymentsTableAdapter.FillBy(Db.Instance.dSet.VPayments, m_clientId);
			else
				Db.Instance.Adapters.VPaymentsTableAdapter.Fill(Db.Instance.dSet.VPayments);

			Logger.Leave();
		}

		private void Init()
		{
			Logger.Enter();
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
			colService.DataPropertyName = "name";
			colService.HeaderText = "Service";
			colService.Name = "service";
			colService.ReadOnly = true;

			gridPayments.Columns.Clear();
			gridPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				colId, colDate, colSum, colService});

			Logger.Leave();
		}

		private void btnView_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			PaymentInfo();
			Logger.Leave();
		}

		private void ViewDetail(object sender, DataGridViewCellEventArgs e)
		{
			Logger.Enter();
			PaymentInfo();
			Logger.Leave();
		}

		private void PaymentInfo()
		{

			Logger.Enter();
			do
			{
				if (gridPayments.SelectedRows.Count < 1)
					break;

				Int64 id = (Int64)gridPayments.SelectedRows[0].Cells["id"].Value;
				PaymentDetail pd = new PaymentDetail(id);
				pd.ShowDialog();
			} while (false);
			Logger.Leave();
		}
	}
}
