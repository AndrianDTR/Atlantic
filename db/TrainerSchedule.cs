using System;
using System.Collections.Generic;
using System.Data;
using AY.Log;

namespace AY
{
	namespace db
	{
		public class TrainerSchedule
		{
			private Int64 m_Id = 0;
			private Int64 m_trainerId = 0;
			public DateTime m_date;

			public TrainerSchedule(Int64 id)
			{	
				String where = String.Format("id = {0}", id);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.TrainersSchedule, where, new List<string> { "trainerId", "date"});
				
				if(data == null)
				{
					throw new Exception("Error! No such trainer schedule entry.");
				}

				m_Id = id;
				m_trainerId = Int64.Parse(data["trainerId"].ToString());
				m_date = DateTime.Parse(data["date"].ToString());
			}

			public Int64 Id
			{
				get
				{
					return m_Id;
				}
			}

			public Int64 TrainerId
			{
				get
				{
					return m_trainerId;
				}
			}
			
			public DateTime Date
			{
				get
				{
					return m_date;
				}
			}
			
			public static Trainer GetTrainerForDate(DateTime date)
			{
				Trainer res = null;
				
				String where = String.Format("date = '{0}'", date);
				DataRow data = new DbAdapter().GetFirstRow(DbTable.Statistics, where, new List<string> { "trainerId"});

				if (data != null)
				{
					Int64 trainerId = Int64.Parse(data["trainerId"].ToString());
					res = new Trainer(trainerId);
				}
				return res;
			}
		}

		public class TrainerScheduleCollection : IEnumerable<TrainerSchedule>
		{
			Dictionary<Int64, TrainerSchedule> Items = new Dictionary<Int64, TrainerSchedule>();

			public TrainerScheduleCollection()
			{
				DbAdapter da = new DbAdapter();
				DataTable dt = da.ExecuteQuery(String.Format("select id from {0};"
					, DbUtils.GetTableName(DbTable.TrainersSchedule)));
				
				foreach(DataRow dr in dt.Rows)
				{
					TrainerSchedule data = new TrainerSchedule(Int64.Parse(dr["id"].ToString()));
					Items[data.Id] = data;
				}
			}
			
			public Boolean Add(Int64 trainerId, DateTime date)
			{
				Int64 id = 0;
				return Add(trainerId, date, out id);
			}

			public Boolean Add(Int64 trainerId, DateTime date, out Int64 id)
			{
				DbAdapter da = new DbAdapter();
				Dictionary<string, Object> fields = new Dictionary<string, Object>();
				fields["trainerId"] = trainerId.ToString();
				fields["date"] = date.ToString();
				id = 0;

				if (!da.Insert(DbTable.TrainersSchedule, fields, out id))
					return false;

				Items[id] = new TrainerSchedule(id);
				return true;
			}

			public static bool RemoveById(Int64 id)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", id);
				return da.Delete(DbTable.TrainersSchedule, where);
			}
			
			public bool Remove(Int64 id)
			{
				if(!RemoveById(id))
					return false;
				return Items.Remove(id);
			}

			public bool Remove(TrainerSchedule item)
			{
				DbAdapter da = new DbAdapter();
				String where = String.Format("id = {0}", item.Id);
				da.Delete(DbTable.TrainersSchedule, where);
				return Items.Remove(item.Id);
			}

			public TrainerSchedule Search(Int64 id)
			{
				if(Items.ContainsKey(id))
					return Items[id];
				return null;
			}

			public int Count
			{
				get { return Items.Count; }
			}

			public IEnumerator<TrainerSchedule> GetEnumerator()
			{
				return Items.Values.GetEnumerator();
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return Items.Values.GetEnumerator();
			}
		}	
	}
}