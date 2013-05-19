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
		public bool bOtherMonth = false;
		public DateTime date;
		public string sTitle = "";
		public string sTip = "";
		public string sTrainer = "";
		
		
		public CellInfo(DateTime date)
		{
			this.date = date;
			sTitle = date.Day.ToString();
			bSelected = false;
			bOtherMonth = false;
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

        public abstract void DrawAppointment(Graphics g, Rectangle rect, Appointment appointment, bool isSelected, int gripWidth);

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
			  Color.FromArgb( 55,  55, 180) //1
			, Color.FromArgb( 55, 110, 180) //2
			, Color.FromArgb(110, 180,  55) //3
			, Color.FromArgb( 55, 180,  55) //4
			, Color.FromArgb( 55, 180, 110) //5
			, Color.FromArgb(180, 110,  55) //6
			, Color.FromArgb(180,  55,  55) //7
			, Color.FromArgb(180,  55, 110) //8
			, Color.FromArgb(180, 150,  55) //9
			, Color.FromArgb(150, 150,  55) //10
			, Color.FromArgb(150, 180,  55) //11
			, Color.FromArgb(110,  55, 180) //12
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
		//==========================================
		private bool drawNavBar = true;
		public virtual bool bDrawNavBar
		{
			get
			{
				return drawNavBar;
			}
			set
			{
				drawNavBar = value;
			}
		}
		
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

		private Font navBarFont = new Font("Segoe UI", 8);
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
		/******************************************/
				
		public abstract void DrawBg(Graphics g, Rectangle rect, System.Drawing.Drawing2D.SmoothingMode smooth);
		public abstract void DrawNavBarBg(Graphics g, Rectangle rect);
		public abstract void DrawNavBarPrevBtnBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect);
		public abstract void DrawNavBarNextBtnBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect);
		public abstract void DrawColLabelBg(Graphics g, Rectangle rect);
		public abstract void DrawRowLabelBg(Graphics g, Rectangle rect);
		public abstract void DrawColBg(Graphics g, Rectangle rect);
		public abstract void DrawRowBg(Graphics g, Rectangle rect);
		public abstract void DrawCellBg(Graphics g, Rectangle rect, CellInfo ci);

		public abstract void DrawNavBar(Graphics g, Rectangle rect);
		public abstract void DrawNavBarPrevBtn(System.Drawing.Graphics g, System.Drawing.Rectangle rect);
		public abstract void DrawNavBarNextBtn(System.Drawing.Graphics g, System.Drawing.Rectangle rect);
		public abstract void DrawColLabel(Graphics g, Rectangle rect, string sDay);
		public abstract void DrawRowLabel(Graphics g, Rectangle rect, string sLabel);
		public abstract void DrawCell(Graphics g, Rectangle rect, CellInfo ci);
		
    }
}
