using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CalendarTest
{
	public class CellInfo
	{
		public bool bSelected = false;
		public bool bCurMonth = false;
		public DateTime date;
		public string sTitle = "";
		public string sTip = "";
		public string sTrainer = "";
		
		
		public CellInfo(DateTime date)
		{
			this.date = date;
			sTitle = date.Day.ToString();
			bSelected = false;
			bCurMonth = false;
			sTip = "";
			sTrainer = "";
		}
	};
	
    public abstract class AbstractRenderer
    {
		public virtual Color SelectionColor
        {
            get
            {
                return SystemColors.Highlight;
            }
        }

		public virtual Color SelectionBorderColor
		{
			get
			{
				return SystemColors.ActiveBorder;
			}
		}
		
        //public abstract void DrawAppointment(Graphics g, Rectangle rect, Appointment appointment, bool isSelected, int gripWidth);

        public static Color InterpolateColors(Color color1, Color color2, float percentage)
        {
            int num1 = ((int)color1.R);
            int num2 = ((int)color1.G);
            int num3 = ((int)color1.B);
            int num4 = ((int)color2.R);
            int num5 = ((int)color2.G);
            int num6 = ((int)color2.B);
            byte num7 = Convert.ToByte(((float)(((float)num1) + (((float)(num4 - num1)) * percentage))));
            byte num8 = Convert.ToByte(((float)(((float)num2) + (((float)(num5 - num2)) * percentage))));
            byte num9 = Convert.ToByte(((float)(((float)num3) + (((float)(num6 - num3)) * percentage))));
            return Color.FromArgb(num7, num8, num9);
        }
        
        /******************************************/
        private Color[] monthColorMap = new Color[]{
              Color.FromArgb(245, 245, 245) //current
			, Color.FromArgb(230, 230, 255) //1
			, Color.FromArgb(230, 230, 255) //2
			, Color.FromArgb(230, 255, 230) //3
			, Color.FromArgb(230, 255, 230) //4
			, Color.FromArgb(230, 255, 230) //5
			, Color.FromArgb(255, 230, 230) //6
			, Color.FromArgb(255, 230, 230) //7
			, Color.FromArgb(255, 230, 230) //8
			, Color.FromArgb(255, 255, 230) //9
			, Color.FromArgb(255, 255, 230) //10
			, Color.FromArgb(255, 255, 230) //11
			, Color.FromArgb(230, 230, 255) //12
			};
		public virtual Color[] MonthColorMap
		{
			get
			{
				return monthColorMap;
			}
			// TODO: Add set functional
			//set
			//{
			//	monthColorMap = value;
			//}
		}
		
		private Color bgColor = Color.FromArgb(228, 236, 246);
		public virtual Color BgColor
		{
			get
			{
				return bgColor;
			}
			set
			{
				bgColor = value;
			}
		}

		private bool hasVerticalLine = true;
		public virtual bool HasVerticalLine
		{
			get
			{
				return hasVerticalLine;
			}
			set
			{
				hasVerticalLine = value;
			}
		}
		
		private Color verticalLineColor = Color.FromArgb(141, 174, 217);
		public virtual Color VerticalLineColor
		{
			get
			{
				return verticalLineColor;
			}
			set
			{
				verticalLineColor = value;
			}
		}

		private bool hasHorizontalLine = true;
		public virtual bool HasHorizontalLine
		{
			get
			{
				return hasHorizontalLine;
			}
			set
			{
				hasHorizontalLine = value;
			}
		}
		private Color horisontalLineColor = Color.FromArgb(141, 174, 217);
		public virtual Color HorisontalLineColor
		{
			get
			{
				return horisontalLineColor;
			}
			set
			{
				horisontalLineColor = value;
			}
		}
			
		//======================================
		
		private Font headerTitleFont = new Font("Segoe UI", 8, FontStyle.Bold);
		public virtual Font HeaderTitleFont
		{
			get
			{
				return headerTitleFont;
			}
			set
			{
				headerTitleFont = value;
			}
		}
		
		private bool headerBgGradient = true;
		public virtual bool HeaderBgGradient
		{
			get
			{
				return headerBgGradient;
			}
			set
			{
				headerBgGradient = value;
			}
		}
		
		private Color headerBgColor = Color.FromArgb(228, 236, 246);
		public virtual Color HeaderBgColor
		{
			get
			{
				return headerBgColor;
			}
			set
			{
				headerBgColor = value;
			}
		}
		
		private Color headerBgColor2 = Color.FromArgb(174, 186, 201);
		public virtual Color HeaderBgColor2
		{
			get
			{
				return headerBgColor2;
			}
			set
			{
				headerBgColor2 = value;
			}
		}

		private Color headerTitleSplitLineColor = Color.FromArgb(141, 174, 217);
		public virtual Color HeaderTitleSplitLineColor
		{
			get
			{
				return headerTitleSplitLineColor;
			}
			set
			{
				headerTitleSplitLineColor = value;
			}
		}
		
		private int headerHeight = 20;
		public virtual int HeaderHeight
		{
			get
			{
				return headerHeight;
			}
			set
			{
				headerHeight = value;
			}
		}

		private int minHeaderWidth = 20;
		public virtual int MinHeaderWidth
		{
			get
			{
				return minHeaderWidth;
			}
			set
			{
				minHeaderWidth = value;
			}
		}
		
		//======================================
			
		private Font weekLabelFont = new Font("Segoe UI", 8, FontStyle.Bold);
		public virtual Font WeekLabelFont
		{
			get
			{
				return weekLabelFont;
			}
			set
			{
				weekLabelFont = value;
			}
		}
		
		private int weekLabelWidth = 60;
		public virtual int WeekLabelWidth
		{
			get
			{
				return weekLabelWidth;
			}
			set
			{
				weekLabelWidth = value;
			}
		}

		private int minWeekHeight = 20;
		public virtual int MinWeekHeight
		{
			get
			{
				return minWeekHeight;
			}
			set
			{
				minWeekHeight = value;
			}
		}
		//=======================================
		private Font cellDataFont = new Font("Segoe UI", 8);
		public virtual Font CellDataFont
		{
			get
			{
				return cellDataFont;
			}
			set
			{
				cellDataFont = value;
			}
		}

		private Font cellDataBoldFont = new Font("Segoe UI", 10, FontStyle.Bold);
		public virtual Font CellDataBoldFont
		{
			get
			{
				return cellDataBoldFont;
			}
			set
			{
				cellDataBoldFont = value;
			}
		}
		
		private bool dayHasHorizontalLine = true;
		public virtual bool DayHasHorizontalLine
		{
			get
			{
				return dayHasHorizontalLine;
			}
			set
			{
				dayHasHorizontalLine = value;
			}
		}
		
		private float dayHorisontalLinePercentWidth = 80;
		public virtual float DayHorisontalLinePercentWidth
		{
			get
			{
				return dayHorisontalLinePercentWidth;
			}
			set
			{
				if (value >= 0.001 && value <= 100.000)
				{
					dayHorisontalLinePercentWidth = value;
				}
				else
				{
					throw new System.Exception("Error! Percentage value must be in range 0.001 - 100.000.");
				}
			}
		}
		
		private Color dayHorisontalLineColor = Color.FromArgb(200, 200, 255);
		public virtual Color DayHorisontalLineColor
		{
			get
			{
				return dayHorisontalLineColor;
			}
			set
			{
				dayHorisontalLineColor = value;
			}
		}
		
		#region Navigation bar
		#region Navigation bar common
		private int navBarHeight = 60;
		public virtual int NavBarHeight
		{
			get
			{
				return navBarHeight;
			}
			set
			{
				navBarHeight = value;
			}
		}

		private Color navBarBgColor = Color.FromArgb(200, 200, 255);
		public virtual Color NavBarBgColor
		{
			get
			{
				return navBarBgColor;
			}
			set
			{
				navBarBgColor = value;
			}
		}

		private Font navBarFont = new Font("Segoe UI", 20, FontStyle.Bold);
		public virtual Font NavBarFont
		{
			get
			{
				return navBarFont;
			}
			set
			{
				navBarFont = value;
			}
		}

		private String navBarTextFormat = "{0:d}, {1:s}";
		public virtual String NavBarTextFormat
		{
			get
			{
				return navBarTextFormat;
			}
			set
			{
				navBarTextFormat = value;
			}
		}

		public abstract void DrawNavBarBg(Graphics g, Rectangle rect);
		public abstract void DrawNavBar(Graphics g, Rectangle rect, String sText);
		
		#endregion
		
		#region Navigation bar Prev button
		private int navBarPrevBtnWidth = 60;
		public virtual int NavBarPrevBtnWidth
		{
			get
			{
				return navBarPrevBtnWidth;
			}
			set
			{
				navBarPrevBtnWidth = value;
			}
		}

		private Color navBarPrevBtnBgColor = Color.FromArgb(200, 200, 255);
		public virtual Color NavBarPrevBtnBgColor
		{
			get
			{
				return navBarPrevBtnBgColor;
			}
			set
			{
				navBarPrevBtnBgColor = value;
			}
		}

		private Bitmap navBarPrevBtnImage = null;
		public virtual Bitmap NavBarPrevBtnImage
		{
			get
			{
				return navBarPrevBtnImage;
			}
			set
			{
				navBarPrevBtnImage = value;
			}
		}
		private String navBarPrevBtnText = "<<";
		public virtual String NavBarPrevBtnText
		{
			get
			{
				return navBarPrevBtnText;
			}
			set
			{
				navBarPrevBtnText = value;
			}
		}

		public abstract void DrawNavBarPrevBtnBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect, bool bPressed);
		public abstract void DrawNavBarPrevBtn(System.Drawing.Graphics g, System.Drawing.Rectangle rect, String sText, bool bPressed);
		
		#endregion
		
		#region Navigation bar Next button
		private int navBarNextBtnWidth = 60;
		public virtual int NavBarNextBtnWidth
		{
			get
			{
				return navBarNextBtnWidth;
			}
			set
			{
				navBarNextBtnWidth = value;
			}
		}

		private Color navBarNextBtnBgColor = Color.FromArgb(200, 200, 255);
		public virtual Color NavBarNextBtnBgColor
		{
			get
			{
				return navBarNextBtnBgColor;
			}
			set
			{
				navBarNextBtnBgColor = value;
			}
		}

		private Bitmap navBarNextBtnImage = null;
		public virtual Bitmap NavBarNextBtnImage
		{
			get
			{
				return navBarNextBtnImage;
			}
			set
			{
				navBarNextBtnImage = value;
			}
		}
		
		private String navBarNextBtnText = ">>";
		public virtual String NavBarNextBtnText
		{
			get
			{
				return navBarNextBtnText;
			}
			set
			{
				navBarNextBtnText = value;
			}
		}

		public abstract void DrawNavBarNextBtnBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect, bool bPressed);
		public abstract void DrawNavBarNextBtn(System.Drawing.Graphics g, System.Drawing.Rectangle rect, String sText, bool bPressed);
		
		#endregion
		#endregion
		/******************************************/
				
		public abstract void DrawBg(Graphics g, Rectangle rect, System.Drawing.Drawing2D.SmoothingMode smooth);
		
		public abstract void DrawColLabelBg(Graphics g, Rectangle rect);
		public abstract void DrawRowLabelBg(Graphics g, Rectangle rect);
		public abstract void DrawColBg(Graphics g, Rectangle rect);
		public abstract void DrawRowBg(Graphics g, Rectangle rect);
		public abstract void DrawCellBg(Graphics g, Rectangle rect, CellInfo ci);

		public abstract void DrawColLabel(Graphics g, Rectangle rect, string sDay);
		public abstract void DrawRowLabel(Graphics g, Rectangle rect, string sLabel);
		public abstract void DrawCell(Graphics g, Rectangle rect, CellInfo ci);
		
    }
}


/*
 * RowHeight
 * RowLabelWidth
 * NavBtnHeight
 * 
 * PrevBtn
 * NextBth
 * Calendar
 * ScrollBar
 * 
 * OnChangeSelection
 * OnYearChange
 * 
 * ---------------------
 * |       2012        |
 * ---------------------
 * | W |M|T|W|T|F|S|S|^|
 * | 1 |1|2|3|4|5|6|7| |
 * | 2 |8|9| | | | | |X|
 * | 3 | | | | | | | | |
 * | 4 | | | | | | | |_|
 * ---------------------
 * |       2014        |
 * ---------------------
 
*/