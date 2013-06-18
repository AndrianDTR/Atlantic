﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientDB
{
	public partial class ManageClients : Form
	{
		ClientCollection m_collection = new ClientCollection();
		
		public ManageClients()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private object[] parseClient(Client client)
		{
			object[] row = new object[4];
			
			row[0] = client.Code;
			row[1] = client.Name;
			row[2] = client.Phone;
			row[3] = client.Schedule.ToString();
			
			return row;
		}
	
		private void FillGrid()
		{
			gridClients.Rows.Clear();

			foreach (Client client in m_collection)
			{
				bool addCode = false;
				bool addName = false;
				
				if(checkNames.Checked)
					if(checkStartWith.Checked)
						addCode = client.Name.ToUpper().StartsWith(textToSearch.Text.ToUpper());
					else
						addCode = client.Name.ToUpper().Contains(textToSearch.Text.ToUpper());

				if(checkCode.Checked)
					if (checkStartWith.Checked)
						addName = client.Code.ToUpper().StartsWith(textToSearch.Text.ToUpper());
					else
						addName = client.Code.ToUpper().Contains(textToSearch.Text.ToUpper());
				
				if(addCode || addName)
				{
					int nRow = gridClients.Rows.Add(parseClient(client));
					gridClients.Rows[nRow].Tag = client.Id;
				}
			}
		}
		
		private void OnLoad(object sender, EventArgs e)
		{
			FillGrid();
		}
		
		private void btnSearch_Click(object sender, EventArgs e)
		{
			FillGrid();
		}

		private void OnSearch(object sender, EventArgs e)
		{
			FillGrid();
		}
		
		private void btnAdd_Click(object sender, EventArgs e)
		{
			ClientInfo ci = new ClientInfo(true);
			if(DialogResult.OK != ci.ShowDialog(this))
				return;
			
			Int64 id = 0;
			if(!m_collection.Add(ci.ClientName, ci.ClientPhone, ci.ClientCode, ci.Schedule.Id, ci.Trainer.Id, out id))
			{
				UIMessages.Error("Client could not been added.");
				return;
			}

			int nRow = gridClients.Rows.Add(parseClient(new Client(id)));
			gridClients.Rows[nRow].Tag = id;
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if(gridClients.SelectedRows.Count < 1)
				return;

			Int64 clientId = (Int64)gridClients.SelectedRows[0].Tag;
			if (!UserCollection.RemoveById(clientId))
			{
				UIMessages.Error("Client could not been removed.");
				return;
			}
			int ndx = gridClients.SelectedRows[0].Index - 1;
			gridClients.Rows.Remove(gridClients.SelectedRows[0]);
			if(ndx >= 0)
				gridClients.Rows[ndx].Selected = true;
		}

		private void btnHistory_Click(object sender, EventArgs e)
		{
			if(gridClients.SelectedRows.Count < 1)
				return;

			Int64 clientId = (Int64)gridClients.SelectedRows[0].Tag;
		}

		private void btnPayments_Click(object sender, EventArgs e)
		{
			if(gridClients.SelectedRows.Count < 1)
				return;

			Int64 clientId = (Int64)gridClients.SelectedRows[0].Tag;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			EditClient();
		}
		
		private void OnEdit(object sender, EventArgs e)
		{
			EditClient();
		}
		
		private void EditClient()
		{
			if (gridClients.SelectedRows.Count < 1)
				return;

			Client client = new Client((Int64)gridClients.SelectedRows[0].Tag);

			ClientInfo ci = new ClientInfo();
			ci.ClientCode = client.Code;
			ci.ClientName = client.Name;
			ci.ClientPhone = client.Phone;
			ci.Trainer = client.Trainer;
			ci.Schedule = client.Schedule;

			if (DialogResult.OK != ci.ShowDialog(this))
				return;

			if (!client.SetData(ci.ClientName, ci.ClientPhone, ci.ClientCode, ci.Schedule.Id, ci.Trainer.Id))
			{
				UIMessages.Error("Client data could not been changed.");
				return;
			}
			gridClients.SelectedRows[0].SetValues(parseClient(client));
		}
	}
}
