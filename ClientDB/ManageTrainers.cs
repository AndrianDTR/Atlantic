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
	public partial class ManageTrainers : Form
	{
		public ManageTrainers()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			TrainerCollection collection = new TrainerCollection();
			trainerList.Items.Clear();
			foreach (Trainer trainer in collection)
			{
				trainerList.Items.Add(trainer);
			}
		}

		private void add_Click(object sender, EventArgs e)
		{
			String szName = name.Text.Trim();
			String szPhone = phone.Text.Trim();
			Int64 id = 0;

			TrainerCollection collection = new TrainerCollection();
			List<Trainer> trainers = collection.Search(szName);
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
			
			trainerList.Items.Add(new Trainer(id));
		}

		private void remove_Click(object sender, EventArgs e)
		{
			if (trainerList.SelectedItem == null)
				return;
			
			Trainer trainer = (Trainer)trainerList.SelectedItem;
			if(!TrainerCollection.RemoveById(trainer.Id))
			{
				UIMessages.Error("Selected ctariner could not been removed.");
				return;
			}
			
			trainerList.Items.Remove(trainer);
		}

		private void save_Click(object sender, EventArgs e)
		{
			if (trainerList.SelectedItem == null)
				return;
			
			String szName = name.Text.Trim();
			String szPhone = phone.Text.Trim();

			TrainerCollection collection = new TrainerCollection();
			List<Trainer> trainers = collection.Search(szName);
			if (trainers.Count > 0)
			{
				UIMessages.Error("Trainer with specified name already exists.");
				return;
			}
			
			if (szName.Length < 1)
				return;
				
			Trainer selected = (Trainer)trainerList.SelectedItem;
			selected.SetData(szName, szPhone);
			trainerList.Items[trainerList.SelectedIndex] = selected;
		}

		private void trainerList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (trainerList.SelectedItem == null)
				return;

			Trainer selected = (Trainer)trainerList.SelectedItem;

			name.Text = selected.Name;
			phone.Text = selected.Phone;
		}
	}
}
