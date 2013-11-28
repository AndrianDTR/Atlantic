using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class ManageScheduleRules : Form
	{
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colHoursAdd;
		private DataGridViewTextBoxColumn colHoursPerLesson;
		private DataGridViewTextBoxColumn colPrice;
		
		public ManageScheduleRules()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{
			scheduleRulesBindingSource.DataSource = Db.Instance.dSet.scheduleRules;
			
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colHoursAdd = new DataGridViewTextBoxColumn();
			colHoursPerLesson = new DataGridViewTextBoxColumn();
			colPrice = new DataGridViewTextBoxColumn();

			gridRules.Columns.AddRange(new DataGridViewColumn[] {
				colId, colName, colHoursAdd, colHoursPerLesson, colPrice});
			
			// 
			// colId
			// 
			this.colId.DataPropertyName = "id";
			this.colId.HeaderText = "id";
			this.colId.Name = "colId";
			this.colId.Visible = false;
			// 
			// colName
			// 
			this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colName.DataPropertyName = "name";
			this.colName.HeaderText = "Name";
			this.colName.Name = "colName";
			// 
			// colHoursAdd
			// 
			this.colHoursAdd.DataPropertyName = "hoursAdd";
			this.colHoursAdd.HeaderText = "Plan hours";
			this.colHoursAdd.Name = "colHoursAdd";
			// 
			// colHoursPerLesson
			// 
			this.colHoursPerLesson.DataPropertyName = "hoursPerLesson";
			this.colHoursPerLesson.HeaderText = "Lesson";
			this.colHoursPerLesson.Name = "colHoursPerLesson";
			// 
			// colPrice
			// 
			this.colPrice.DataPropertyName = "price";
			this.colPrice.HeaderText = "Price";
			this.colPrice.Name = "colPrice";
		}
		
		private void OnLoad(object sender, EventArgs e)
		{
			Db.Instance.Adapters.scheduleRulesTableAdapter.Fill(Db.Instance.dSet.scheduleRules);
		}
		
		private void save_Click(object sender, EventArgs e)
		{
			Db.Instance.AcceptChanges();
			Session.Instance.UpdateMain();
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
