using System;
using System.IO;
using System.Collections.Generic;
using AY.Log;
using AY.db;

namespace AY
{
	namespace db
	{
		class TriggerProp: Object
		{
					
		}
		
		class Trigger
		{
			private Dictionary<String, Object> m_props;
			
			public Trigger(String data)
			{
				StringReader strReader = new StringReader(data);
				m_props = new Dictionary<String, Object>();
				
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
					m_props[key_val[0].Trim()] = key_val[1].Trim();
					
					prop = strReader.ReadLine();
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
			
			public Boolean HasAttribute(String key)
			{
				return m_props.ContainsKey(key);
			}
			
			public override String ToString()
			{
				String res = String.Empty;

				foreach (KeyValuePair<String, Object> kv in m_props)
				{
					res += String.Format("{0}:{1}\n", kv.Key, kv.Value.ToString());
				}

				return res;
			}
			
			public static bool PaymentTrigger(Int64 paymentId)
			{
				bool res = false;
				Logger.Enter();

				Payment payment = new Payment(paymentId);
				ScheduleRule rule = new ScheduleRule(payment.ScheduleId);
				Client client = new Client(payment.ClientId);

				Trigger ruleTrig = new Trigger(rule.Rule);
				Trigger clientTrig = new Trigger(client.ExtraInfo);

				// TODO: Process options here.
				
				client.ExtraInfo = clientTrig.ToString();

				Logger.Leave();
				return res;
			}
			
			public static bool EntranceTrigger(Int64 clientId)
			{
				bool res = false;
				Logger.Enter();

				Client client = new Client(clientId);

				Trigger clientTrig = new Trigger(client.ExtraInfo);

				// TODO: Process options here.
				
				client.ExtraInfo = clientTrig.ToString();

				Logger.Leave();
				return res;
			}
		}
	}
}
