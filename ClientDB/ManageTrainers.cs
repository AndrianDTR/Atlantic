using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAssistant
{
	public partial class ManageTrainers : Form
	{
		public ManageTrainers()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			TrainerCollection collection = new TrainerCollection();
			trainersList.Items.Clear();
			foreach (Trainer trainer in collection)
			{
				trainersList.Items.Add(trainer);
			}
		}

		private void add_Click(object sender, EventArgs e)
		{
			String szName = name.Text.Trim();
			String szPhone = phone.Text.Trim();
			Int64 id = 0;

			if(szName.Length < 1)
				return;

			TrainerCollection collection = new TrainerCollection();
			if(!collection.Add(szName, szPhone, out id))
			{
				UIMessages.Error("Trainer could not been added.");
				return;
			}
			
			trainersList.Items.Add(new Trainer(id));
		}

		private void remove_Click(object sender, EventArgs e)
		{
			if (trainersList.SelectedItem == null)
				return;
			
			Trainer trainer = (Trainer)trainersList.SelectedItem;
			if(!TrainerCollection.RemoveById(trainer.Id))
			{
				UIMessages.Error("Selected trainer could not been removed.");
				return;
			}
			
			trainersList.Items.Remove(trainer);
		}

		private void save_Click(object sender, EventArgs e)
		{
			if (trainersList.SelectedItem == null)
				return;
			
			String szName = name.Text.Trim();
			String szPhone = phone.Text.Trim();
			
			if (szName.Length < 1)
				return;

			Trainer selected = (Trainer)trainersList.SelectedItem;
			selected.SetData(szName, szPhone);
			trainersList.Items[trainersList.SelectedIndex] = selected;
		}

		private void trainerList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (trainersList.SelectedItem == null)
				return;

			Trainer selected = (Trainer)trainersList.SelectedItem;

			name.Text = selected.Name;
			phone.Text = selected.Phone;
		}
	}
}
