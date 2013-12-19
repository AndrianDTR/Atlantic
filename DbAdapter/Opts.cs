using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AY.Log;
using System.Drawing;

namespace AY
{
	namespace db
	{
		public partial class dbDataSet
		{
			public partial class settingsRow
			{
				public Boolean ShowTrainer
				{
					get
					{
						return (showTrainer == 1);
					}
					set
					{
						Logger.Enter();
						showTrainer = value ? 1 : 0;
						Logger.Leave();
					}
				}

				public Boolean ShowClientCount
				{
					get
					{
						return (showClientCount == 1);
					}
					set
					{
						Logger.Enter();
						showClientCount = value ? 1 : 0;
						Logger.Leave();
					}
				}

				public Boolean StoreMainWindowState
				{
					get
					{
						return (storeMainWindowState == 1);
					}
					set
					{
						Logger.Enter();
						storeMainWindowState = value ? 1 : 0;
						Logger.Leave();
					}
				}

				public FormWindowState MainWindowState
				{
					get
					{
						return (FormWindowState)mainWindowState;
					}
					set
					{
						Logger.Enter();
						mainWindowState = (int)value;
						Logger.Leave();
					}
				}
				
				public Color ColorPresent
				{
					get
					{
						Logger.Enter();
						Color clr = Color.FromArgb(0, 255, 0);
						
						Trigger tClr = new Trigger(colors);
						if (tClr.HasAttribute(TriggerFields.ColorPresent))
						{
							clr = tClr[TriggerFields.ColorPresent];
						}
						Logger.Leave();
						return clr;
					}
					set
					{
						Logger.Enter();
						Trigger tClr = new Trigger(colors);
						tClr[TriggerFields.ColorPresent] = value;
						colors = tClr.ToString();
						Logger.Leave();
					}
				}

				public Color ColorOvertime
				{
					get
					{
						Logger.Enter();
						Color clr = Color.FromArgb(255, 200, 50);

						Trigger tClr = new Trigger(colors);
						if (tClr.HasAttribute(TriggerFields.ColorOvertime))
						{
							clr = tClr[TriggerFields.ColorOvertime];
						}
						Logger.Leave();
						return clr;
					}
					set
					{
						Logger.Enter();
						Trigger tClr = new Trigger(colors);
						tClr[TriggerFields.ColorOvertime] = value;
						colors = tClr.ToString();
						Logger.Leave();
					}
				}

				public Color ColorDelayed
				{
					get
					{
						Logger.Enter();
						Color clr = Color.FromArgb(255, 255, 0);

						Trigger tClr = new Trigger(colors);
						if (tClr.HasAttribute(TriggerFields.ColorDelayed))
						{
							clr = tClr[TriggerFields.ColorDelayed];
						}
						Logger.Leave();
						return clr;
					}
					set
					{
						Logger.Enter();
						Trigger tClr = new Trigger(colors);
						tClr[TriggerFields.ColorDelayed] = value;
						colors = tClr.ToString();
						Logger.Leave();
					}
				}

				public Color ColorMissed
				{
					get
					{
						Logger.Enter();
						Color clr = Color.FromArgb(255, 50, 0);

						Trigger tClr = new Trigger(colors);
						if (tClr.HasAttribute(TriggerFields.ColorMissed))
						{
							clr = tClr[TriggerFields.ColorMissed];
						}
						Logger.Leave();
						return clr;
					}
					set
					{
						Logger.Enter();
						Trigger tClr = new Trigger(colors);
						tClr[TriggerFields.ColorMissed] = value;
						colors = tClr.ToString();
						Logger.Leave();
					}
				}

				public DateTime StartTime
				{
					get
					{
						Logger.Enter();
						startTime = DateTime.Now.Date.Add(startTime.TimeOfDay);
						Logger.Leave();
						return startTime;
					}
					set
					{
						Logger.Enter();
						startTime = DateTime.Now.Date.Add(value.TimeOfDay);
						Logger.Leave();
					}
				}

				public DateTime EndTime
				{
					get
					{
						Logger.Enter();
						endTime = DateTime.Now.Date.Add(endTime.TimeOfDay);
						Logger.Leave();
						return endTime;
					}
					set
					{
						Logger.Enter();
						endTime = DateTime.Now.Date.Add(value.TimeOfDay);
						Logger.Leave();
					}
				}
			}
		}
	}
}