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
						showTrainer = value ? 1 : 0;
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
						showClientCount = value ? 1 : 0;
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
						storeMainWindowState = value ? 1 : 0;
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
						mainWindowState = (int)value;
					}
				}
				
				public Color ColorPresent
				{
					get
					{
						Color clr = Color.FromArgb(0, 255, 0);
						
						Trigger tClr = new Trigger(colors);
						if (tClr.HasAttribute(TriggerFields.ColorPresent))
						{
							clr = tClr[TriggerFields.ColorPresent];
						}
						
						return clr;
					}
					set
					{
						Trigger tClr = new Trigger(colors);
						tClr[TriggerFields.ColorPresent] = value;
						colors = tClr.ToString();
					}
				}

				public Color ColorOvertime
				{
					get
					{
						Color clr = Color.FromArgb(255, 200, 50);

						Trigger tClr = new Trigger(colors);
						if (tClr.HasAttribute(TriggerFields.ColorOvertime))
						{
							clr = tClr[TriggerFields.ColorOvertime];
						}

						return clr;
					}
					set
					{
						Trigger tClr = new Trigger(colors);
						tClr[TriggerFields.ColorOvertime] = value;
						colors = tClr.ToString();
					}
				}

				public Color ColorDelayed
				{
					get
					{
						Color clr = Color.FromArgb(255, 255, 0);

						Trigger tClr = new Trigger(colors);
						if (tClr.HasAttribute(TriggerFields.ColorDelayed))
						{
							clr = tClr[TriggerFields.ColorDelayed];
						}

						return clr;
					}
					set
					{
						Trigger tClr = new Trigger(colors);
						tClr[TriggerFields.ColorDelayed] = value;
						colors = tClr.ToString();
					}
				}

				public Color ColorMissed
				{
					get
					{
						Color clr = Color.FromArgb(255, 50, 0);

						Trigger tClr = new Trigger(colors);
						if (tClr.HasAttribute(TriggerFields.ColorMissed))
						{
							clr = tClr[TriggerFields.ColorMissed];
						}

						return clr;
					}
					set
					{
						Trigger tClr = new Trigger(colors);
						tClr[TriggerFields.ColorMissed] = value;
						colors = tClr.ToString();
					}
				}

				public DateTime StartTime
				{
					get
					{
						startTime = DateTime.Now.Date.Add(startTime.TimeOfDay);
						return startTime;
					}
					set
					{
						startTime = DateTime.Now.Date.Add(value.TimeOfDay);
					}
				}

				public DateTime EndTime
				{
					get
					{
						endTime = DateTime.Now.Date.Add(endTime.TimeOfDay);
						return endTime;
					}
					set
					{
						endTime = DateTime.Now.Date.Add(value.TimeOfDay);
					}
				}
			}
		}
	}
}