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
			public partial class trainersScheduleRow
			{
				public clientDataSet.trainersRow Trainer
				{
					get{ return Db.Instance.dSet.trainers.FindByid(trainerId); }
				}
			}

			public static clientDataSet.trainersRow GetTrainerForDate(DateTime dt)
			{
				String where = String.Format("workDate = '{0}'", dt);
				DataRow[] res = Db.Instance.dSet.trainersSchedule.Select(where);
				
				if(res.Length != 1)
					return null;
				return (clientDataSet.trainersRow)res[0];
			}	
		}	
	}
}