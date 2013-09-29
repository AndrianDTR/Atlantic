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
			InitializeComponent();
			Init();
		}

		private void Init()
		{
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
			
			
		}
		
		private void OnLoad(object sender, EventArgs e)
		{
			Db.Instance.Adapters.trainersTableAdapter.Fill(Db.Instance.dSet.trainers);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			Db.Instance.AcceptChanges();
		}
	}
}
