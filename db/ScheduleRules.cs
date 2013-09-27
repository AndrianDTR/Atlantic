using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public partial class dbDataSet
		{
			public partial class scheduleRulesRow
			{
				public static bool operator ==(scheduleRulesRow p1, scheduleRulesRow p2)
				{
					return p1.id == p2.id;
				}

				public static bool operator !=(scheduleRulesRow p1, scheduleRulesRow p2)
				{
					return !(p1.id == p2.id);
				}

				public override bool Equals(Object obj)
				{
					if (obj == null || GetType() != obj.GetType())
						return false;

					scheduleRulesRow Item = obj as scheduleRulesRow;
					return Item.id == this.id;
				}

				public override int GetHashCode()
				{
					return base.GetHashCode();
				}
				
				public override String ToString()
				{
					return name;
				}
			}
		}
	}
}