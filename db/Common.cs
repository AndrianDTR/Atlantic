using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY.db
{
	public class DbTableRow
	{
		protected Int64 m_id = 0;
		protected DataRow m_DataRow = null;
		
		public DbTableRow()
		{
		}

		public DbTableRow(DbTable table, Int64 id)
		{
			String where = String.Format("id = {0}", id);
			DataRow data = new DbAdapter().GetFirstRow(table, where, new List<string>());

			if (data == null)
			{
				Logger.Warning(String.Format("No such entry, Table: {0}, id: {1}.", table, id));
				return;
			}

			m_id = id;
			m_DataRow = data;
		}

		public DataRow Row
		{
			get{ return m_DataRow; }
			set
			{ 
				DataRow dr = value;
				if(!dr.Table.Columns.Contains("id"))
					return;
				m_id = Int64.Parse(dr["id"].ToString());
				m_DataRow = dr; 
			}
		}
		
		public Int64 Id
		{
			get
			{
				return m_id;
			}
		}
	}

	public class DbTableRowCollection<EnType> : IEnumerable<EnType>
	{
		public delegate void CountChangedEventHandler(Int64 newCount);
		public delegate void CollectionChangedEventHandler();
		
		protected Dictionary<Int64, EnType> Items = new Dictionary<Int64, EnType>();

		public event CollectionChangedEventHandler CollectionChanged;
		public event CountChangedEventHandler CountChanged;
		
		public IEnumerator<EnType> GetEnumerator()
		{
			return Items.Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return Items.Values.GetEnumerator();
		}
		
		public int Count
		{
			get { return Items.Count; }
		}

		public virtual void OnCountChanged(Int64 newCount)
		{
			if (CountChanged != null)
				CountChanged(newCount);
		}

		public virtual void OnCollectionChanged()
		{
			if (CollectionChanged != null)
				CollectionChanged();
		}
	}
}

