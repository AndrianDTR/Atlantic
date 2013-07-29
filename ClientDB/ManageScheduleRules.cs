using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace GAssistant
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
		
		private bool ValidateForm()
		{
			try
			{
				float.Parse(price.Text.Trim());
			}
			catch
			{
				UIMessages.Error(String.Format("Please specify price in the 'XX{0}YY' format."
					, CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
				return false;
			}
			
			return true;
		}
		
		private float GetPrice()
		{
			String szPrice = price.Text.Trim();
			return float.Parse(szPrice);
		}
		
		private void add_Click(object sender, EventArgs e)
		{
			if(!ValidateForm())
				return;
				
			String szName = name.Text.Trim();
			String szPhone = rule.Text.Trim();
			float fPrice = GetPrice();
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
			
			if(!collection.Add(szName, szPhone, fPrice, out id))
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
				UIMessages.Error("Selected schedule rule could not been removed.");
				return;
			}
			
			rulesList.Items.Remove(trainer);
		}

		private void save_Click(object sender, EventArgs e)
		{
			if (!ValidateForm())
				return;
			
			if (rulesList.SelectedItem == null)
				return;
			
			String szName = name.Text.Trim();
			String szRule = rule.Text.Trim();
			float fPrice = GetPrice();

			if (szName.Length < 1)
				return;

			ScheduleRule selected = (ScheduleRule)rulesList.SelectedItem;
			selected.SetData(szName, szRule, fPrice);
			rulesList.Items[rulesList.SelectedIndex] = selected;
		}

		private void rulesList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rulesList.SelectedItem == null)
				return;

			ScheduleRule selected = (ScheduleRule)rulesList.SelectedItem;

			name.Text = selected.Name;
			rule.Text = selected.Rule;
			price.Text = selected.Price.ToString();
		}
	}
}
