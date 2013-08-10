using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Procurios.Public;
using System.Collections;

namespace GAssistant
{
	class PaymentTrigger
	{
		public PaymentTrigger(Int64 pid)
		{
			Logger.Enter();
			
			//Payment p = new Payment(pid);
			//ScheduleRule sr = new ScheduleRule(p.ScheduleId);
			
			String rule = "{\"add\":8,\"hour\":2,\"dec\":2}";
			Hashtable js = (Hashtable)JSON.JsonDecode(rule);
			Logger.Info(js.ToString());
			Logger.Leave();
		}
	}
}
