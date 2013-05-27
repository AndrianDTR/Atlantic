using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;

namespace CalendarTest
{
    public class DefaultRenderer : AbstractRenderer
    {
        public override Color SelectionColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(41, 76, 122);
            }
        }

        /*
		public override void DrawAppointment(System.Drawing.Graphics g, System.Drawing.Rectangle rect, Appointment appointment, bool isSelected, int gripWidth)
        {
            StringFormat m_Format = new StringFormat();
            m_Format.Alignment = StringAlignment.Near;
            m_Format.LineAlignment = StringAlignment.Near;

            Color start = InterpolateColors(appointment.Color, Color.White, 0.4f);
            Color end = InterpolateColors(appointment.Color, Color.FromArgb(191, 210, 234), 0.7f);

            if ((appointment.Locked))
            {
                // Draw back
                using (Brush m_Brush = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.LargeConfetti, Color.Blue, appointment.Color))
                    g.FillRectangle(m_Brush, rect);

                // little transparent
                start = Color.FromArgb(230, start);
                end = Color.FromArgb(180, end);

                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(rect);

                using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Vertical))
                    g.FillRectangle(aGB, rect);
            }
            else
            {
                // Draw back
                using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Vertical))
                    g.FillRectangle(aGB, rect);
            }

            if (isSelected)
            {
                Rectangle m_BorderRectangle = rect;

                using (Pen m_Pen = new Pen(appointment.BorderColor, 4))
                    g.DrawRectangle(m_Pen, rect);

                m_BorderRectangle.Inflate(2, 2);

                using (Pen m_Pen = new Pen(SystemColors.WindowFrame, 1))
                    g.DrawRectangle(m_Pen, m_BorderRectangle);

                m_BorderRectangle.Inflate(-4, -4);

                using (Pen m_Pen = new Pen(SystemColors.WindowFrame, 1))
                    g.DrawRectangle(m_Pen, m_BorderRectangle);
            }
            else
            {
                // Draw gripper
                Rectangle m_GripRectangle = rect;

                m_GripRectangle.Width = gripWidth + 1;

                start = InterpolateColors(appointment.BorderColor, appointment.Color, 0.2f);
                end = InterpolateColors(appointment.BorderColor, Color.White, 0.6f);

                using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Vertical))
                    g.FillRectangle(aGB, m_GripRectangle);

                using (Pen m_Pen = new Pen(SystemColors.WindowFrame, 1))
                    g.DrawRectangle(m_Pen, rect);

                // Draw shadow lines
                int xLeft = rect.X + 6;
                int xRight = rect.Right + 1;
                int yTop = rect.Y + 1;
                int yButton = rect.Bottom + 1;

                for (int i = 0; i < 5; i++)
                {
                    using (Pen shadow_Pen = new Pen(Color.FromArgb(70 - 12 * i, Color.Black)))
                    {
                        g.DrawLine(shadow_Pen, xLeft + i, yButton + i, xRight + i - 1, yButton + i); //horisontal lines
                        g.DrawLine(shadow_Pen, xRight + i, yTop + i, xRight + i, yButton + i); //vertical
                    }
                }

            }

            rect.X += gripWidth;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            //g.DrawString(appointment.Title, this.BaseFont, SystemBrushes.WindowText, rect, m_Format);
            g.TextRenderingHint = TextRenderingHint.SystemDefault;

        }
		//*/
        /************************************************/
        public override void DrawBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect, System.Drawing.Drawing2D.SmoothingMode smooth)
		{
			using (SolidBrush backBrush = new SolidBrush(BgColor))
				g.FillRectangle(backBrush, rect);

			g.SmoothingMode = smooth;
		}

		public override void DrawHeaderLabelBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect)
		{
			if (HeaderBgGradient)
			{
				using (LinearGradientBrush aGB = new LinearGradientBrush(rect, HeaderBgColor, HeaderBgColor2, LinearGradientMode.ForwardDiagonal))
					g.FillRectangle(aGB, rect);
			}
			else
			{
				using (SolidBrush backBrush = new SolidBrush(HeaderBgColor))
					g.FillRectangle(backBrush, rect);
			}

			if (HasHorizontalLine)
			{
				using (Pen aPen = new Pen(GridColor))
					g.DrawLine(aPen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
			}
		}
		
		public override void DrawHeaderBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect)
		{
			if (HeaderBgGradient)
			{
				using (LinearGradientBrush aGB = new LinearGradientBrush(rect, HeaderBgColor, HeaderBgColor2, LinearGradientMode.Vertical))
					g.FillRectangle(aGB, rect);
			}
			else
			{
				using (SolidBrush backBrush = new SolidBrush(HeaderBgColor))
					g.FillRectangle(backBrush, rect);
			}

			if (HasHorizontalLine)
			{
				using (Pen aPen = new Pen(GridColor))
					g.DrawLine(aPen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
			}
		}

		//public override void DrawColBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect)
		//{
		//    if (HasVerticalLine)
		//    {
		//        using (Pen aPen = new Pen(SystemColors.ControlDark))
		//            g.DrawLine(aPen, rect.Right, rect.Top, rect.Right, rect.Bottom);
		//    }
		//}
		
		//public override void DrawRowBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect)
		//{
		//    if (HasHorizontalLine)
		//    {
		//        using (Pen aPen = new Pen(SystemColors.ControlDark))
		//            g.DrawLine(aPen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
		//    }
		//}
		
		public override void DrawColLabel(System.Drawing.Graphics g, System.Drawing.Rectangle rect, string sDay)
		{
			StringFormat m_Format = new StringFormat();
			m_Format.Alignment = StringAlignment.Center;
			m_Format.FormatFlags = StringFormatFlags.NoWrap;
			m_Format.LineAlignment = StringAlignment.Center;

			if(HasVerticalLine)
			{
				using (Pen aPen = new Pen(HeaderTitleSplitLineColor))
					g.DrawLine(aPen, rect.Right, rect.Top, rect.Right, rect.Bottom);
			}
			
			rect.Offset(2, 1);

			g.DrawString(sDay, HeaderTitleFont, SystemBrushes.WindowText, rect, m_Format);
		}

		//public override void DrawRowLabelBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect)
		//{
		//    if (HeaderBgGradient)
		//    {
		//        using (LinearGradientBrush aGB = new LinearGradientBrush(rect, HeaderBgColor, HeaderBgColor2, LinearGradientMode.Horizontal))
		//            g.FillRectangle(aGB, rect);
		//    }
		//    else
		//    {
		//        using (SolidBrush backBrush = new SolidBrush(HeaderBgColor))
		//            g.FillRectangle(backBrush, rect);
		//    }
		//	
		//    if (HasVerticalLine)
		//    {
		//        using (Pen aPen = new Pen(VerticalLineColor))
		//            g.DrawLine(aPen, rect.Right, rect.Top, rect.Right, rect.Bottom);
		//    }
		//}

		public override void DrawRowLabel(System.Drawing.Graphics g, System.Drawing.Rectangle rect, String sLabel)
		{
			StringFormat m_Format = new StringFormat();
			m_Format.Alignment = StringAlignment.Center;
			m_Format.FormatFlags = StringFormatFlags.NoWrap;
			m_Format.LineAlignment = StringAlignment.Center;

			Rectangle r = rect;
			r.Inflate(1,1);
			
			if (HeaderBgGradient)
			{
				using (LinearGradientBrush aGB = new LinearGradientBrush(rect, HeaderBgColor, HeaderBgColor2, LinearGradientMode.ForwardDiagonal))
					g.FillRectangle(aGB, r);
			}
			else
			{
				using (SolidBrush backBrush = new SolidBrush(HeaderBgColor))
					g.FillRectangle(backBrush, r);
			}
			
			//using (SolidBrush backBrush = new SolidBrush(InterpolateColors(HeaderBgColor, HeaderBgColor2, 0.35F)))
			//	g.FillRectangle(backBrush, r);
			
			using (Pen backBrush = new Pen(GridColor))
			{
				//g.DrawLine(backBrush, rect.Left, rect.Top, rect.Left, rect.Bottom);
				g.DrawLine(backBrush, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
			}
			
			rect.Offset(2, 1);

			g.DrawString(sLabel, WeekLabelFont, SystemBrushes.WindowText, rect, m_Format);
		}

		//public override void DrawCellBg(System.Drawing.Graphics g, System.Drawing.Rectangle rect, CellInfo ci)
		//{
		//    //rect.Inflate(-1, -1);
		//    Color bg = MonthColorMap[ci.date.Month];
		//    if (ci.bCurMonth)
		//    {
		//        bg = MonthColorMap[0];
		//    }
		//    using (SolidBrush backBrush = new SolidBrush(bg))
		//        g.FillRectangle(backBrush, rect);
        //    
		//    if (ci.bSelected)
		//    {
		//        using (SolidBrush backBrush = new SolidBrush(SelectionColor))
		//            g.FillRectangle(backBrush, rect);
		//			
		//        using (Pen borderPen = new Pen(SelectionBorderColor))
		//        {
		//			
		//            g.DrawRectangle(borderPen, rect);
		//        }
		//    }
		//}

		public override void DrawCell(System.Drawing.Graphics g, System.Drawing.Rectangle rect, CellInfo ci)
		{
			StringFormat m_Format = new StringFormat();
			m_Format.Alignment = StringAlignment.Center;
			m_Format.FormatFlags = StringFormatFlags.FitBlackBox;
			m_Format.LineAlignment = StringAlignment.Center;

			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			Color bg = MonthColorMap[ci.date.Month];
			if (ci.bCurMonth)
			{
				bg = MonthColorMap[0];
			}
			using (SolidBrush backBrush = new SolidBrush(bg))
				g.FillRectangle(backBrush, rect);
			using (Pen backBrush = new Pen(GridColor))
			{
				g.DrawLine(backBrush, rect.Left, rect.Top, rect.Left, rect.Bottom);
				g.DrawLine(backBrush, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
			}
			
			rect.Offset(2, 1);

			if (ci.bSelected)
			{
				g.DrawString(ci.sTitle, CellDataBoldFont, SystemBrushes.HighlightText, rect, m_Format);
			}
			else
			{
				g.DrawString(ci.sTitle, CellDataBoldFont, SystemBrushes.WindowText, rect, m_Format);
			}
			
			g.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public override void DrawPrevBtn(Graphics g, Rectangle rect, int state, String text)
		{
			StringFormat m_Format = new StringFormat();
			m_Format.Alignment = StringAlignment.Center;
			m_Format.FormatFlags = StringFormatFlags.FitBlackBox;
			m_Format.LineAlignment = StringAlignment.Center;

			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			
			using(SolidBrush backBrush = new SolidBrush(BgColor))
				g.FillRectangle(backBrush, rect);
			using (Pen aPen = new Pen(GridColor))
				g.DrawLine(aPen, rect.Left, rect.Bottom-1, rect.Right, rect.Bottom-1);
				
			rect.Offset(2, 1);

			g.DrawString(text, CellDataBoldFont, SystemBrushes.WindowText, rect, m_Format);

			g.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public override void DrawNextBtn(Graphics g, Rectangle rect, int state, String text)
		{
			StringFormat m_Format = new StringFormat();
			m_Format.Alignment = StringAlignment.Center;
			m_Format.FormatFlags = StringFormatFlags.FitBlackBox;
			m_Format.LineAlignment = StringAlignment.Center;

			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			using (SolidBrush backBrush = new SolidBrush(BgColor))
				g.FillRectangle(backBrush, rect);
			using (Pen aPen = new Pen(GridColor))
				g.DrawLine(aPen, rect.Left, rect.Top, rect.Right, rect.Top);
				
			rect.Offset(2, 1);

			g.DrawString(text, CellDataBoldFont, SystemBrushes.WindowText, rect, m_Format);
			
			g.TextRenderingHint = TextRenderingHint.SystemDefault;
		}

		public override void DrawScrollBar(Graphics g, Rectangle rect, Panel obj)
		{
			using (SolidBrush backBrush = new SolidBrush(BgColor))
				g.FillRectangle(backBrush, rect);

			StringFormat m_Format = new StringFormat();
			m_Format.Alignment = StringAlignment.Center;
			m_Format.FormatFlags = StringFormatFlags.FitBlackBox;
			m_Format.LineAlignment = StringAlignment.Center;
			
			Rectangle rTop = rect;
			rTop.Height = rTop.Width;
			using (SolidBrush backBrush = new SolidBrush(Color.Coral))
				g.FillRectangle(backBrush, rTop);
			g.DrawString(">", CellDataBoldFont, SystemBrushes.WindowText, rTop, m_Format);

			Rectangle rBot = rect;
			rBot.Height = rBot.Width;
			rBot.Y = rect.Bottom - rBot.Width;
			using (SolidBrush backBrush = new SolidBrush(Color.Coral))
				g.FillRectangle(backBrush, rBot);
			g.DrawString("<", CellDataBoldFont, SystemBrushes.WindowText, rBot, m_Format);
		}
    }
}
