using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;
using AY.db.dbDataSetTableAdapters;

namespace AY
{
	namespace db
	{
		public enum UserRights
		{
			None = 0,
			Read = 1,
			Write = 2,
			Create = 4,
			Delete = 8
		};
		
		public partial class dbDataSet
		{
			public partial class userPrivilegesRow
			{
				public override String ToString()
				{
					return name;
				}

				public static bool IsSet(Int64 var, UserRights flag)
				{
					return (var & (Int64)flag) == (Int64)flag;
				}
			}
		}	
	}
}