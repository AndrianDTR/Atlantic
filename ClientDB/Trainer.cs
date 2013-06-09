using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace ClientDB
{
	class Trainer
	{
		private Int64 m_id = 0;
		public String m_name = String.Empty;
		public String m_phone = String.Empty;

		public Trainer()
		{
		}

		public Trainer(Int64 id)
		{
			String where = String.Format("id = {0}", id);
			DataRow userData = new DbAdapter().GetFirstRow(DbTable.Trainers, where, new List<string> { "id", "name", "phone" });

			if (userData == null)
			{
				throw new Exception("Error! No such trainer.");
			}

			m_id = id;
			m_name = userData["name"].ToString();
			m_phone = userData["phone"].ToString();
		}

		public Trainer(String name)
		{
			String where = String.Format("name = '{0}'", name);
			DataRow userData = new DbAdapter().GetFirstRow(DbTable.Trainers, where, new List<string> { "id", "name", "phone" });

			if (userData == null)
			{
				throw new Exception("Error! No such trainer.");
			}

			m_id = Int64.Parse(userData["id"].ToString());
			m_name = userData["name"].ToString();
			m_phone = userData["phone"].ToString();
		}

		public Int64 Id
		{
			get
			{
				return m_id;
			}
		}

		public String Name
		{
			get
			{
				return m_name;
			}
		}

		public String Phone
		{
			get
			{
				return m_phone;
			}
		}

		public override string ToString()
		{
			return m_name;
		}
		
		public void SetData(String name, String phone)
		{
			Debug.WriteLine(String.Format("Set data for trainer '{0}': name='{0}', phone='{1}'", m_name, name, phone));
			if (m_id <= 0)
			{
				return;
			}

			DbAdapter ad = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = String.Format("'{0}'", name);
			fields["phone"] = String.Format("'{0}'", phone);
			if (!ad.Update(DbTable.Trainers, fields, String.Format("id={0:d}", m_id)))
			{
				throw new Exception("Data could not been changed.");
			}
			m_phone = phone;
			m_name = name;
		}
	}

	class TrainerCollection : IEnumerable<Trainer>
	{
		Dictionary<Int64, Trainer> Items = new Dictionary<Int64, Trainer>();

		public TrainerCollection()
		{
			DbAdapter da = new DbAdapter();
			DataTable dt = da.ExecuteQuery(String.Format("select id from {0};", DbUtils.GetTableName(DbTable.Trainers)));
			foreach (DataRow dr in dt.Rows)
			{
				Trainer trainer = new Trainer(Int64.Parse(dr["id"].ToString()));
				Items[trainer.Id] = trainer;
			}
		}

		public Boolean Add(String name, String phone)
		{
			Int64 id = 0;
			return Add(name, phone, out id);
		}
		
		public Boolean Add(String name, String phone, out Int64 id)
		{
			DbAdapter da = new DbAdapter();
			Dictionary<string, string> fields = new Dictionary<string, string>();
			fields["name"] = String.Format("'{0}'", name);
			fields["phone"] = String.Format("'{0}'", phone);
			id = 0;
			
			if (!da.Insert(DbTable.Trainers, fields, out id))
				return false;

			Items[id] = new Trainer(id);
			return true;
		}

		public static bool RemoveById(Int64 id)
		{
			DbAdapter da = new DbAdapter();
			String where = String.Format("id = {0}", id);
			return da.Delete(DbTable.Trainers, where);
		}

		public bool Remove(Int64 id)
		{
			if (!RemoveById(id))
				return false;
			return Items.Remove(id);
		}
		
		public bool Remove(Trainer item)
		{
			DbAdapter da = new DbAdapter();
			String where = String.Format("id = {0}", item.Id);
			da.Delete(DbTable.Trainers, where);
			return Items.Remove(item.Id);
		}

		public Trainer Search(Int64 id)
		{
			if (Items.ContainsKey(id))
				return Items[id];
			return null;
		}
		
		public List<Trainer> Search(String name)
		{
			return Search(name, false);
		}

		public List<Trainer> Search(String name, Boolean contains)
		{
			List<Trainer> collection = new List<Trainer>();
			foreach (KeyValuePair<Int64, Trainer> trainer in Items)
			{
				if ((contains && trainer.Value.Name.Contains(name)) || trainer.Value.Name.StartsWith(name))
				{
					collection.Add(trainer.Value);
				}
			}
			return collection;
		}

		public int Count
		{
			get { return Items.Count; }
		}

		public IEnumerator<Trainer> GetEnumerator()
		{
			return Items.Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Items.Values.GetEnumerator();
		}
	}
}
