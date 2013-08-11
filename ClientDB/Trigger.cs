using System;
using System.Collections;
using System.IO;
using Procurios.Public;
using System.Collections.Generic;

namespace GAssistant
{
	class Trigger
	{
		private Dictionary<String, Object> m_props;
		
		private Trigger(String data)
		{
			StringReader strReader = new StringReader(data);
			m_props = new Dictionary<String, Object>();
			
			foreach(String prop in strReader.Read())
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
				
				m_props[key_val[0]] = key_val[1];
			}
		}
		
		public Object this[String index]
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
		
		public static bool PaymentTrigger(Int64 paymentId)
		{
			bool res = false;
			Logger.Enter();

			//Payment p = new Payment(pid);
			//ScheduleRule sr = new ScheduleRule(p.ScheduleId);

			String rule = "{\"add\":8,\"hour\":2,\"dec\":2}";
			Hashtable js = (Hashtable)JSON.JsonDecode(rule);
			Logger.Info(js.ToString());
			
			Logger.Leave();
			return res;
		}
	}
}
