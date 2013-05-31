using System;
using System.Data;

namespace ClientDB
{

	public interface ITable : DataTable
	{
		DbAdapter m_adapter = DbAdapter.Instance;
		
		public void Refresh();
		public uint AddRow(DataRow row);
		public DataRow GetRow(uint index);
		
	}
}
