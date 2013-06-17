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
			
			row[0] = client.Id;
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
			if(DialogResult.OK == ci.ShowDialog(this))
			{
				Int64 id = 0;
				if(!m_collection.Add(ci.ClientName, ci.ClientPhone, ci.ClientCode, ci.Schedule, ci.Trainer, out id))
				{
					UIMessages.Error("Client could not been added.");
					return;
				}
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if(gridClients.SelectedRows.Count < 1)
				return;

			Client client = new Client((Int64)gridClients.SelectedRows[0].Tag);

			ClientInfo ci = new ClientInfo();
			ci.ClientCode = client.Code;
			ci.ClientName = client.Name;
			ci.ClientPhone = client.Phone;
			ci.Trainer = client.TrainerId;
			ci.Schedule = client.ScheduleId;
			
			if (DialogResult.OK == ci.ShowDialog(this))
			{
				Int64 id = 0;
				if (!m_collection.Add(ci.ClientName, ci.ClientPhone, ci.ClientCode, ci.Schedule, ci.Trainer, out id))
				{
					UIMessages.Error("Client could not been added.");
					return;
				}
			}
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{

		}
	}
}
