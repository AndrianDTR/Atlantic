using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public partial class clientDataSet
		{
			public partial class trainersRow
			{

				public static bool operator ==(trainersRow p1, trainersRow p2)
				{
					return p1.id == p2.id;
				}

				public static bool operator !=(trainersRow p1, trainersRow p2)
				{
					if (null == p1 || null == p2)
						return true;
						
					return !(p1.id == p2.id);
				}

				public override bool Equals(Object obj)
				{
					if (obj == null || GetType() != obj.GetType())
						return false;

					trainersRow Item = obj as trainersRow;
					return Item.id == this.id;
				}

				public override int GetHashCode()
				{
					return base.GetHashCode();
				}
				
				public override string ToString()
				{
					return name;
				}
			}
		}
	}
}