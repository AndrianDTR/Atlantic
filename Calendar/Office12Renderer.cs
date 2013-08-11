using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;

namespace AY
{
	namespace Calendar
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
				
				using (Pen backBrush = new Pen(GridColor))
				{
					g.DrawLine(backBrush, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
				}
				
				rect.Offset(2, 1);

				g.DrawString(sLabel, WeekLabelFont, SystemBrushes.WindowText, rect, m_Format);
			}

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
				
				Rectangle rText = rect;
				rText.Offset(2, 1);
				rect.Inflate(1, 1);
				rect.Offset(1, 0);
				
				if (ci.bSelected)
				{
					using (SolidBrush backBrush = new SolidBrush(SelectionColor))
						g.FillRectangle(backBrush, rect);
						
					using (Pen borderPen = new Pen(SelectionBorderColor))
						g.DrawRectangle(borderPen, rect);
				
					g.DrawString(ci.sTitle, CellDataBoldFont, SystemBrushes.HighlightText, rText, m_Format);
				}
				else
				{
					g.DrawString(ci.sTitle, CellDataBoldFont, SystemBrushes.WindowText, rText, m_Format);
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
}