using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
	public partial class ManageScheduleRules : Form
	{
		public ManageScheduleRules()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			ScheduleRulesCollection collection = new ScheduleRulesCollection();
			rulesList.Items.Clear();
			foreach (ScheduleRule trainer in collection)
			{
				rulesList.Items.Add(trainer);
			}
		}

		private void add_Click(object sender, EventArgs e)
		{
			String szName = name.Text.Trim();
			String szPhone = rule.Text.Trim();
			Int64 id = 0;

			ScheduleRulesCollection collection = new ScheduleRulesCollection();
			List<ScheduleRule> trainers = collection.Search(szName);
			if (trainers.Count > 0)
			{
				UIMessages.Error("Trainer with specified name already exists.");
				return;
			}
			
			if(szName.Length < 1)
				return;
			
			if(!collection.Add(szName, szPhone, out id))
			{
				UIMessages.Error("Trainer could not been added.");
				return;
			}

			rulesList.Items.Add(new ScheduleRule(id));
		}

		private void remove_Click(object sender, EventArgs e)
		{
			if (rulesList.SelectedItem == null)
				return;

			ScheduleRule trainer = (ScheduleRule)rulesList.SelectedItem;
			if (!ScheduleRulesCollection.RemoveById(trainer.Id))
			{
				UIMessages.Error("Selected ctariner could not been removed.");
				return;
			}
			
			rulesList.Items.Remove(trainer);
		}

		private void save_Click(object sender, EventArgs e)
		{
			if (rulesList.SelectedItem == null)
				return;
			
			String szName = name.Text.Trim();
			String szPhone = rule.Text.Trim();

			ScheduleRulesCollection collection = new ScheduleRulesCollection();
			List<ScheduleRule> trainers = collection.Search(szName);
			if (trainers.Count > 0)
			{
				UIMessages.Error("Rule with specified name already exists.");
				return;
			}
			
			if (szName.Length < 1)
				return;

			ScheduleRule selected = (ScheduleRule)rulesList.SelectedItem;
			selected.SetData(szName, szPhone);
			rulesList.Items[rulesList.SelectedIndex] = selected;
		}

		private void rulesList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rulesList.SelectedItem == null)
				return;

			ScheduleRule selected = (ScheduleRule)rulesList.SelectedItem;

			name.Text = selected.Name;
			rule.Text = selected.Rule;
		}
	}
}
