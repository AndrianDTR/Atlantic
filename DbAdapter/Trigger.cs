using System;
using System.IO;
using System.Collections.Generic;
using AY.Log;
using AY.db;
using System.Drawing;

namespace AY
{
	namespace db
	{
		enum TriggerFields
		{
			_min,
			None,
			
			//Payment trigger fields
			RuleId,
			CPUTimesLeft,
			CPUHoursLeft,
			UCIDecHours,
			// Client trigger fields
			HoursLeft,
			DecHours,
			// Options trigger fields
			ColorPresent,
			ColorOvertime,
			ColorDelayed,
			ColorMissed,
			
			_max
		};
		
		class ObjType
		{
			#pragma warning disable 0168
			
			private Object m_value = null;
			
			public ObjType(int val)
			{
				m_value = val;
			}

			public ObjType(Int64 val)
			{
				m_value = val;
			}

			public ObjType(String val)
			{
				m_value = val;
			}

			public ObjType(Color val)
			{
				m_value = val.ToArgb();
			}

			public ObjType(DateTime val)
			{
				m_value = val;
			}

			public static implicit operator ObjType(int val)
			{
				return new ObjType(val);
			}

			public static implicit operator ObjType(Int64 val)
			{
				return new ObjType(val);
			}
			
			public static implicit operator ObjType(DateTime val)
			{
				return new ObjType(val);
			}

			public static implicit operator ObjType(Color val)
			{
				return new ObjType(val);
			}
			
			public static implicit operator ObjType(String val)
			{
				return new ObjType(val);
			}
			
			public static implicit operator int(ObjType obj)
			{
				int res = 0;
				
				try
				{
					res = int.Parse(obj.m_value.ToString());
				}
				catch (System.Exception ex)
				{
					Logger.Error("Parse int failed. Value: " + obj.m_value.ToString());
				}
				
				return res;
			}

			public static implicit operator Int64(ObjType obj)
			{
				Int64 res = 0;

				try
				{
					res = Int64.Parse(obj.m_value.ToString());
				}
				catch (System.Exception ex)
				{
					Logger.Error("Parse Int64 failed. Value: " + obj.m_value.ToString());
				}

				return res;
			}

			public static implicit operator Color(ObjType obj)
			{
				Color res = new Color();

				try
				{
					Int32 iClr = Int32.Parse(obj.m_value.ToString());
					res = Color.FromArgb(iClr);
				}
				catch (System.Exception ex)
				{
					Logger.Error("Parse DateTime failed. Value: " + obj.m_value.ToString());
				}

				return res;
			}
			
			public static implicit operator DateTime(ObjType obj)
			{
				DateTime res = new DateTime();
				
				try
				{
					res = DateTime.Parse(obj.m_value.ToString());
				}
				catch (System.Exception ex)
				{
					Logger.Error("Parse DateTime failed. Value: " + obj.m_value.ToString());
				}

				return res;
			}

			public static implicit operator string(ObjType obj)
			{
				return obj.m_value.ToString();
			}

			public override String ToString()
			{
				return m_value.ToString();
			}
			
			#pragma warning restore 0168
		}
		
		class Trigger
		{
			private Dictionary<TriggerFields, ObjType> m_props;
			
			public Trigger(String data)
			{
				StringReader strReader = new StringReader(data);
				m_props = new Dictionary<TriggerFields, ObjType>();
				
				String prop = strReader.ReadLine();
				while(prop != null)
				{
					// Ignore comments
					String dataLine = prop.Split('#')[0];
					
					// Parse string as key:value pair
					String[] key_val = dataLine.Split(':');
					if(key_val.Length != 2)
					{
						Logger.Warning(String.Format("Invalid property line. Src: '{0}'.", prop));
						continue;
					}
					TriggerFields key = Trigger.GetFieldByName(key_val[0].Trim());
					m_props[key] = key_val[1].Trim();
					
					prop = strReader.ReadLine();
				}
			}

			public ObjType this[TriggerFields index]
			{
				get
				{
					if (!m_props.ContainsKey(index))
						return null;
					return m_props[index];
				}
				set
				{
					m_props[index] = value;
				}
			}
			
			public Boolean HasAttribute(TriggerFields key)
			{
				return m_props.ContainsKey(key);
			}
			
			public override String ToString()
			{
				String res = String.Empty;

				foreach (KeyValuePair<TriggerFields, ObjType> kv in m_props)
				{
					res += String.Format("{0}:{1}\n", kv.Key, kv.Value.ToString());
				}

				return res;
			}
			
			public bool Remove(TriggerFields key)
			{
				if(m_props.ContainsKey(key))
				{
					return m_props.Remove(key);
				}
				return false;
			}
			
			public static TriggerFields GetFieldByName(String key)
			{
				TriggerFields res = TriggerFields.None;
				
				for (TriggerFields tf = TriggerFields._min;
					tf < TriggerFields._max;
					tf++)
				{
					if(key == tf.ToString())
					{
						res = tf;
						break;
					}
				}
				
				return res;
			}
		}
	}
}
