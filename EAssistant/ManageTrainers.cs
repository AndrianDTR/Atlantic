using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class ManageTrainers : Form
	{
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colPhone;
		private DataGridViewTextBoxColumn colComment;

		public ManageTrainers()
		{
			Logger.Enter();
			InitializeComponent();
			Init();
			Logger.Leave();
		}

		private void Init()
		{
			Logger.Enter();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colPhone = new DataGridViewTextBoxColumn();
			colComment = new DataGridViewTextBoxColumn();

			trainersBindingSource.DataSource = Db.Instance.dSet.trainers;

			gridTrainers.Columns.AddRange(new DataGridViewColumn[] {
				colId,
				colName,
				colPhone,
				colComment});

			// 
			// colId
			// 
			colId.DataPropertyName = "id";
			colId.HeaderText = "id";
			colId.Name = "idDataGridViewTextBoxColumn";
			colId.Visible = false;
			// 
			// colName
			// 
			colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			colName.DataPropertyName = "name";
			colName.HeaderText = "Name";
			colName.Name = "colName";
			// 
			// colPhone
			// 
			colPhone.DataPropertyName = "phone";
			colPhone.HeaderText = "Phone";
			colPhone.Name = "colPhone";
			// 
			// colComment
			// 
			colComment.DataPropertyName = "extraInfo";
			colComment.HeaderText = "Comment";
			colComment.Name = "colComment";
			Logger.Leave();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			Logger.Enter();
			Db.Instance.Adapters.trainersTableAdapter.Fill(Db.Instance.dSet.trainers);
			Logger.Leave();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			Db.Instance.AcceptChanges();
			Session.Instance.UpdateMain();
			Logger.Leave();
		}

		private void OnError(object sender, DataGridViewDataErrorEventArgs e)
		{
			Logger.Enter();
			UIMessages.Error(e.Exception.Message);
			Logger.Leave();
		}
	}
}
