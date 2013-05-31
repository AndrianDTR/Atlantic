using System;
using System.Collections;
using System.Text;

namespace ClientDB
{
	public class User
	{
		public uint id = 0;
		public String name = "";
		public byte[] pass = null;
		public uint privId = 0;
	};
	
	public class UserCollection : CollectionBase
	{
		DbAdapter m_adapter = DbAdapter.Instance;
				
		public UserCollection()
		{
			Refresh();
		}
		
		public void Refresh()
		{
			m_adapter.
		}
		
		public void Add(User item)
		{
			List.Add(item);
		}
		
		public void Remove(int index)
		{
			// Check to see if there is a widget at the supplied index.
			if (index > Count - 1 || index < 0)
			// If no widget exists, a messagebox is shown and the operation 
			// is cancelled.
			{
				System.Windows.Forms.MessageBox.Show("Index not valid!");
			}
			else
			{
				List.RemoveAt(index);
			}
		}

		public User Item(int Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Widget type, then returned to the 
			// caller.
			return (User)List[Index];
		}
	}
}
