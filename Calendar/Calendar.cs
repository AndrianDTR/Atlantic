using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using AY.Utils;

namespace AY
{
	namespace Calendar
	{
		public partial class Calendar : UserControl
		{
			private void InitializeComponent()
			{
				this.m_grid = new System.Windows.Forms.TableLayoutPanel();
				this.m_btnPrev = new System.Windows.Forms.Button();
				this.m_btnNext = new System.Windows.Forms.Button();
				this.m_headerPanel = new System.Windows.Forms.Panel();
				this.m_dataPanel = new System.Windows.Forms.Panel();
				this.m_scrollPanel = new System.Windows.Forms.Panel();
				this.m_Scrollbar = new System.Windows.Forms.VScrollBar();
				this.m_grid.SuspendLayout();
				this.m_dataPanel.SuspendLayout();
				this.SuspendLayout();
				// 
				// _grid
				// 
				this.m_grid.ColumnCount = 1;
				this.m_grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
				this.m_grid.Controls.Add(this.m_btnPrev, 0, 0);
				this.m_grid.Controls.Add(this.m_btnNext, 0, 3);
				this.m_grid.Controls.Add(this.m_headerPanel, 0, 1);
				this.m_grid.Controls.Add(this.m_dataPanel, 0, 2);
				this.m_grid.Dock = System.Windows.Forms.DockStyle.Fill;
				this.m_grid.Location = new System.Drawing.Point(0, 0);
				this.m_grid.Name = "_grid";
				this.m_grid.RowCount = 4;
				this.m_grid.RowStyles.Add(new System.Windows.Forms.RowStyle());
				this.m_grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
				this.m_grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
				this.m_grid.RowStyles.Add(new System.Windows.Forms.RowStyle());
				this.m_grid.Size = new System.Drawing.Size(534, 430);
				this.m_grid.TabIndex = 0;
				// 
				// _btnPrev
				// 
				this.m_btnPrev.Location = new System.Drawing.Point(3, 3);
				this.m_btnPrev.Name = "_btnPrev";
				this.m_btnPrev.Size = new System.Drawing.Size(528, 23);
				this.m_btnPrev.TabIndex = 0;
				this.m_btnPrev.Text = "button1";
				this.m_btnPrev.UseVisualStyleBackColor = true;
				// 
				// _btnNext
				// 
				this.m_btnNext.Location = new System.Drawing.Point(3, 404);
				this.m_btnNext.Name = "_btnNext";
				this.m_btnNext.Size = new System.Drawing.Size(528, 23);
				this.m_btnNext.TabIndex = 1;
				this.m_btnNext.Text = "button2";
				this.m_btnNext.UseVisualStyleBackColor = true;
				// 
				// _headerPanel
				// 
				this.m_headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
				this.m_headerPanel.Location = new System.Drawing.Point(3, 32);
				this.m_headerPanel.Name = "_headerPanel";
				this.m_headerPanel.Size = new System.Drawing.Size(528, 34);
				this.m_headerPanel.TabIndex = 2;
				// 
				// _dataPanel
				// 
				this.m_dataPanel.Controls.Add(this.m_scrollPanel);
				this.m_dataPanel.Controls.Add(this.m_Scrollbar);
				this.m_dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
				this.m_dataPanel.Location = new System.Drawing.Point(3, 72);
				this.m_dataPanel.Name = "_dataPanel";
				this.m_dataPanel.Size = new System.Drawing.Size(528, 326);
				this.m_dataPanel.TabIndex = 3;
				// 
				// _scrollPanel
				// 
				this.m_scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
				this.m_scrollPanel.Location = new System.Drawing.Point(0, 0);
				this.m_scrollPanel.Name = "_scrollPanel";
				this.m_scrollPanel.Size = new System.Drawing.Size(509, 326);
				this.m_scrollPanel.TabIndex = 5;
				// 
				// _Scrollbar
				// 
				this.m_Scrollbar.Dock = System.Windows.Forms.DockStyle.Right;
				this.m_Scrollbar.Location = new System.Drawing.Point(509, 0);
				this.m_Scrollbar.Name = "_Scrollbar";
				this.m_Scrollbar.Size = new System.Drawing.Size(19, 326);
				this.m_Scrollbar.TabIndex = 4;
				// 
				// Calendar
				// 
				this.Controls.Add(this.m_grid);
				this.Name = "Calendar";
				this.Size = new System.Drawing.Size(534, 430);
				this.m_grid.ResumeLayout(false);
				this.m_dataPanel.ResumeLayout(false);
				this.ResumeLayout(false);

			}
			
			#region Variables

			private ToolTip m_ToolTip;

			Rectangle m_rSelectionStartAt;
			DateTime m_dSelectionStartAt;
			bool m_bSelectionChanged;
			bool m_bMouseEnter = false;

			#endregion
			private TableLayoutPanel m_grid;
			private Button m_btnPrev;
			private Button m_btnNext;
			private Panel m_headerPanel;
			private Panel m_dataPanel;
			private VScrollBar m_Scrollbar;
			private Panel m_scrollPanel;

			#region Constants
			int m_nMult = 100;
			#endregion

			#region c.tor

			public Calendar()
			{
				int height = base.Height;
				SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
				SetStyle(ControlStyles.ResizeRedraw, true);
				SetStyle(ControlStyles.Selectable, true);
				
				m_grid.SuspendLayout();
				
				InitializeComponent();
				
				m_btnPrev.Height = m_nNavButtonsHeight;
				m_btnNext.Height = m_nNavButtonsHeight;
				m_headerPanel.Height = m_nNavButtonsHeight;
				m_dataPanel.Height = m_nNavButtonsHeight;
				m_Scrollbar.Value = RowHeight;
				m_scrollPanel.Width = m_Scrollbar.Width;
				
				m_grid.ResumeLayout();

				this.Renderer = new DefaultRenderer();

				m_Scrollbar.Scroll += new ScrollEventHandler(this.OnScroll);
				m_headerPanel.Paint += new PaintEventHandler(this.OnHeaderPaint);
				m_dataPanel.Paint += new PaintEventHandler(this.OnDataPaint);

				m_scrollPanel.Paint += new PaintEventHandler(this.OnScrollPaint);

				m_btnPrev.Paint += new PaintEventHandler(this.OnPrevBtnPaint);
				m_btnPrev.Click += new EventHandler(this.OnPrevBtnClick);

				m_btnNext.Paint += new PaintEventHandler(this.OnNextBtnPaint);
				m_btnNext.Click += new EventHandler(this.OnNextBtnClick);

				m_dataPanel.MouseDown += new MouseEventHandler(this.OnDataMouseDown);
				m_dataPanel.MouseUp += new MouseEventHandler(this.OnDataMouseUp);
				m_dataPanel.MouseMove += new MouseEventHandler(this.OnDataMouseMove);
				m_dataPanel.MouseEnter += new EventHandler(this.OnDataMouseEnter);
				m_dataPanel.MouseLeave += new EventHandler(this.OnDataMouseLeave);
				this.MouseWheel += new MouseEventHandler(this.OnDataMouseWheel);
			}

			#endregion

			#region Properties
			private int m_nHeaderHeight = 20;
			[System.ComponentModel.DefaultValue(20)]
			public int HeaderHeight
			{
				get
				{
					return m_nHeaderHeight;
				}
				set
				{
					m_nHeaderHeight = value;
					AdjustScrollbar();
					Invalidate(true);
				}
			}

			private int m_nNavButtonsHeight = 40;
			[System.ComponentModel.DefaultValue(40)]
			public int NavButtonsHeight
			{
				get
				{
					return m_nNavButtonsHeight;
				}
				set
				{
					m_nNavButtonsHeight = value;
					AdjustScrollbar();
					Invalidate(true);
				}
			}

			private int m_nRowHeight = 40;
			[System.ComponentModel.DefaultValue(40)]
			public int RowHeight
			{
				get
				{
					return m_nRowHeight;
				}
				set
				{
					m_nRowHeight = value;
					AdjustScrollbar();
					Invalidate(true);
				}
			}

			private int m_nRowLabelWidth = 40;
			[System.ComponentModel.DefaultValue(40)]
			public int RowLabelWidth
			{
				get
				{
					return m_nRowLabelWidth;
				}
				set
				{
					m_nRowLabelWidth = value;
					Invalidate(true);
				}
			}
			/********************************************************/

			private AbstractRenderer renderer;

			[System.ComponentModel.Browsable(false)]
			[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
			public AbstractRenderer Renderer
			{
				get
				{
					return renderer;
				}
				set
				{
					renderer = value;
					Invalidate(true);
				}
			}

			private DateTime startDate = DateTime.Now;
			public DateTime StartDate
			{
				get
				{
					return startDate;
				}
				set
				{
					startDate = value;
					OnStartDateChanged();
				}
			}

			protected virtual void OnStartDateChanged()
			{
				startDate = startDate.Date;

				int nWeeks = GetWeekOfYear(new DateTime(startDate.Year, 12, 31));
				AdjustScrollbar();
				m_Scrollbar.Value = GetWeekOfYear(StartDate) * m_nMult;

				m_btnPrev.Text = (startDate.Year - 1).ToString();
				m_btnNext.Text = (startDate.Year + 1).ToString();

				Invalidate(true);
			}

			private DateTime selectedDate;

			public DateTime SelectedDate
			{
				get { return selectedDate; }
				set
				{
					selectedDate = value;
					OnSelectedDateChanged();
				}
			}
			protected virtual void OnSelectedDateChanged()
			{
				Invalidate(true);
			}

			private ITool activeTool;

			[System.ComponentModel.Browsable(false)]
			public ITool ActiveTool
			{
				get { return activeTool; }
				set { activeTool = value; }
			}
			#endregion

			#region Event Handlers
			private void OnHeaderPaint(object sender, PaintEventArgs e)
			{
				Panel p = (Panel)sender;
				Graphics g = e.Graphics;

				Rectangle rRect = new Rectangle(0, 0, p.Width, p.Height);

				DrawHeaders(e, rRect);
			}

			private void OnDataPaint(object sender, PaintEventArgs e)
			{
				Panel p = (Panel)sender;

				DateTime weekStartDate = GetFirstDateOfWeek(this.StartDate.Year, GetWeekOfYear(this.StartDate));

				renderer.DrawBg(e.Graphics, p.ClientRectangle, System.Drawing.Drawing2D.SmoothingMode.AntiAlias);

				Rectangle rRect = new Rectangle(0, 0, p.Width - m_Scrollbar.Width, p.Height);

				DrawWeeks(e, rRect);
			}

			private void OnPrevBtnPaint(object sender, PaintEventArgs e)
			{
				Button p = (Button)sender;
				Rectangle rRect = new Rectangle(0, 0, p.Width, p.Height);
				renderer.DrawPrevBtn(e.Graphics, rRect, 0, p.Text);
			}

			private void OnNextBtnPaint(object sender, PaintEventArgs e)
			{
				Button p = (Button)sender;
				Rectangle rRect = new Rectangle(0, 0, p.Width, p.Height);
				renderer.DrawNextBtn(e.Graphics, rRect, 0, p.Text);
			}

			private void OnScrollPaint(object sender, PaintEventArgs e)
			{
				Panel p = (Panel)sender;
				Rectangle rRect = new Rectangle(0, 0, p.Width, p.Height);
				renderer.DrawScrollBar(e.Graphics, rRect, p);
			}

			private void OnPrevBtnClick(object sender, EventArgs e)
			{
				Button p = (Button)sender;
				StartDate = StartDate.AddYears(-1);
			}

			private void OnNextBtnClick(object sender, EventArgs e)
			{
				Button p = (Button)sender;
				StartDate = StartDate.AddYears(1);
			}

			void OnScroll(object sender, ScrollEventArgs e)
			{
				m_dataPanel.SuspendLayout();
				m_dataPanel.Invalidate();
				m_dataPanel.ResumeLayout();
			}

			protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
			{
				base.SetBoundsCore(x, y, width, height, specified);

				m_btnNext.Height = NavButtonsHeight;
				m_btnPrev.Height = NavButtonsHeight;
				m_headerPanel.Height = HeaderHeight;
				m_dataPanel.Location = new Point(0, NavButtonsHeight + HeaderHeight);
				m_dataPanel.Width = this.Width;
				m_dataPanel.Height = height - 2 * NavButtonsHeight - HeaderHeight;
			}

			protected void OnDataMouseDown(object sender, MouseEventArgs e)
			{
				// Capture focus
				this.Focus();

				if (e.Button == MouseButtons.Left)
				{
					m_dSelectionStartAt = GetDateAt(e.X, e.Y);
					SelectedDate = m_dSelectionStartAt;

					m_dataPanel.Invalidate(m_rSelectionStartAt);
					m_rSelectionStartAt = GetRectAt(e.X, e.Y);
					m_bSelectionChanged = true;

					m_dataPanel.Capture = true;
					m_dataPanel.Invalidate(m_rSelectionStartAt);
				}

				base.OnMouseDown(e);
			}

			protected void OnDataMouseMove(object sender, MouseEventArgs e)
			{
				base.OnMouseMove(e);

				if (e.Button == MouseButtons.Left && m_bSelectionChanged)
				{
					m_dataPanel.Invalidate(m_rSelectionStartAt);
					m_rSelectionStartAt = GetRectAt(e.X, e.Y);
					m_dataPanel.Invalidate(m_rSelectionStartAt);
					SelectedDate = GetDateAt(e.X, e.Y);
				}
			}

			protected void OnDataMouseUp(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					m_dataPanel.Capture = false;
					m_bSelectionChanged = false;

					RaiseSelectionChanged(EventArgs.Empty);

					SelectedDate = GetDateAt(e.X, e.Y);
				}

				m_dataPanel.Invalidate(m_rSelectionStartAt);
				m_rSelectionStartAt = GetRectAt(e.X, e.Y);
				m_dataPanel.Invalidate(m_rSelectionStartAt);

				base.OnMouseUp(e);
			}

			private void OnDataMouseEnter(object sender, System.EventArgs e)
			{
				m_bMouseEnter = true;
			}

			private void OnDataMouseLeave(object sender, System.EventArgs e)
			{
				m_bMouseEnter = false;
			}

			protected void OnDataMouseWheel(object sender, MouseEventArgs e)
			{
				if (m_bMouseEnter)
				{
					int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / RowHeight;
					int val = m_Scrollbar.Value;
					if (numberOfTextLinesToMove != 0)
					{
						val -= numberOfTextLinesToMove * RowHeight;
						val = val >= m_Scrollbar.Maximum ? m_Scrollbar.Maximum : val;
						val = val <= m_Scrollbar.Minimum ? m_Scrollbar.Minimum : val;

						m_Scrollbar.Value = val;
					}

					m_dataPanel.Invalidate();
				}
			}

			protected override void OnResize(EventArgs e)
			{
				base.OnResize(e);
				AdjustScrollbar();
				Invalidate(true);
			}

			private void OnPopupStats(object sender, PopupEventArgs e)
			{
				if (e.AssociatedControl == m_dataPanel)
				{
					using (Font f = new Font("Tahoma", 9))
					{
						e.ToolTipSize = TextRenderer.MeasureText(
							m_ToolTip.GetToolTip(e.AssociatedControl), f);
					}
				}
			}

			// Handles drawing the ToolTip.
			private void OnDrawStats(System.Object sender, DrawToolTipEventArgs e)
			{
				e.DrawBackground();
				e.DrawBorder();
				e.DrawText();
			}

			void editbox_KeyUp(object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Escape)
				{
					e.Handled = true;
				}
				else if (e.KeyCode == Keys.Enter)
				{
					e.Handled = true;
				}
			}

			internal void RaiseSelectionChanged(EventArgs e)
			{
				if (SelectionChanged != null)
					SelectionChanged(this, e);
			}

			#endregion

			#region Public Methods
			public virtual CellInfo GetCellInfo(DateTime date)
			{
				return new CellInfo(date);
			}

			public DateTime GetDateAt(int x, int y)
			{
				int nWeek = m_Scrollbar.Value / m_nMult;
				DateTime date = GetFirstDateOfWeek(StartDate.Year, nWeek);

				int dayWidth = (m_dataPanel.Width - RowLabelWidth - m_scrollPanel.Width) / 7;
				int weekHeight = RowHeight;

				x -= RowLabelWidth;

				if (x > 0)
				{
					date = date.AddDays(x / dayWidth);
				}
				if (y > 0)
				{
					date = date.AddDays(y / weekHeight * 7);
				}

				if (x < 0 | y < 0)
					date = new DateTime();

				return date;
			}

			public Rectangle GetRectAt(int x, int y)
			{
				Rectangle rect = new Rectangle();

				int colWidth = (m_dataPanel.Width - RowLabelWidth - m_scrollPanel.Width) / 7;

				rect.Width = colWidth;
				rect.Height = RowHeight;

				if (x <= RowLabelWidth)
				{
					rect.X = 0;
					rect.Width = RowLabelWidth;
				}
				else
					rect.X = ((x - RowLabelWidth) / colWidth) * colWidth + RowLabelWidth;
				rect.Y = (y / RowHeight) * RowHeight;

				return rect;
			}

			#endregion

			#region Help methods

			public static DateTime GetFirstDateOfWeek(int year, int weekOfYear)
			{
				DateTime jan1 = new DateTime(year, 1, 1);
				int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

				DateTime firstThursday = jan1.AddDays(daysOffset);
				var cal = CultureInfo.CurrentCulture.Calendar;
				int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

				var weekNum = weekOfYear;
				if (firstWeek <= 1)
				{
					weekNum -= 1;
				}
				var result = firstThursday.AddDays(weekNum * 7);
				return result.AddDays(-3);
			}

			public static int GetWeekOfYear(DateTime date)
			{
				return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
					date,
					CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
					CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek
				);
			}

			#endregion

			#region Drawing Methods

			private CellInfo[] GetWeekDays(DateTime date)
			{
				CellInfo[] infos = new CellInfo[7];

				for (int n = 0; n < infos.Length; n++)
				{
					infos[n] = GetCellInfo(date.AddDays(n));
				}

				return infos;
			}

			protected void AdjustScrollbar()
			{
				int nWeeks = GetWeekOfYear(new DateTime(StartDate.Year, 12, 31)) + 1;
				int nRows = m_dataPanel.Height / RowHeight;
				m_Scrollbar.SmallChange = m_nMult;
				m_Scrollbar.LargeChange = m_nMult * 5;
				m_Scrollbar.Minimum = m_nMult;
				m_Scrollbar.Maximum = (nWeeks - nRows) * m_nMult;
			}

			private void DrawHeaders(PaintEventArgs e, Rectangle rect)
			{
				e.Graphics.SetClip(rect);

				int colW = (rect.Width - RowLabelWidth - m_Scrollbar.Width) / 7;
				int rowH = RowHeight;
				int nRows = rect.Height / RowHeight;

				string[] weekDays = CultureInfoUtils.GetWeekDayNames();

				renderer.DrawHeaderBg(e.Graphics, rect);

				Rectangle rCol = rect;
				rCol.Width = RowLabelWidth;

				for (int nCol = 0; nCol < 7 + 1; nCol++)
				{
					if (nCol == 0)
					{
						rCol.Width = RowLabelWidth;
						renderer.DrawHeaderLabelBg(e.Graphics, rCol);
						renderer.DrawColLabel(e.Graphics, rCol, "");
						rCol.Width = colW;
						rCol.X += RowLabelWidth;
					}
					else
					{
						renderer.DrawColLabel(e.Graphics, rCol, weekDays[nCol - 1]);
						rCol.X += colW;
					}
				}
				e.Graphics.ResetClip();
			}

			private void DrawWeeks(PaintEventArgs e, Rectangle rect)
			{
				e.Graphics.SetClip(rect);
				int rows = rect.Height / RowHeight + 1;
				rect.Height = rows * RowHeight;

				int nWeeks = GetWeekOfYear(new DateTime(StartDate.Year, 12, 31));
				int nWeek = m_Scrollbar.Value / m_nMult;
				DateTime weekStartDate = GetFirstDateOfWeek(StartDate.Year, nWeek);

				int colW = (rect.Width - RowLabelWidth) / 7;
				int rowH = RowHeight;

				for (int nRow = 0; nRow < rows; nRow++)
				{
					Rectangle rCell = new Rectangle(
					  0
					, nRow * RowHeight
					, RowLabelWidth
					, RowHeight);

					CellInfo[] weekInfo = GetWeekDays(weekStartDate.AddDays(nRow * 7));

					for (int nCol = 0; nCol < 7 + 1; nCol++)
					{
						Rectangle rDraw = rCell;
						rDraw.Width -= 1;
						rDraw.Height -= 1;

						if (nCol == 0)
						{
							int weekNum = (nWeek + nRow);
							int overflow = weekNum % (nWeeks + 1);
							weekNum = overflow == 0 ? 1 : overflow;
							renderer.DrawRowLabel(e.Graphics, rDraw, weekNum.ToString());
							rCell.Width = colW;
							rCell.X += RowLabelWidth;
						}
						else
						{
							weekInfo[nCol - 1].bSelected = weekInfo[nCol - 1].date == SelectedDate ? true : false;
							weekInfo[nCol - 1].bCurMonth = weekInfo[nCol - 1].date.Month == StartDate.Month ? true : false;
							weekInfo[nCol - 1].sTitle = weekInfo[nCol - 1].date.ToShortDateString();
							renderer.DrawCell(e.Graphics, rDraw, weekInfo[nCol - 1]);
							rCell.X += colW;
						}
					}
					rCell.Y += RowHeight;
				}

				e.Graphics.ResetClip();
			}

			private void DrawAppointments(PaintEventArgs e, Rectangle rect, DateTime time)
			{
				DateTime timeStart = time.Date;
				DateTime timeEnd = timeStart.AddHours(24);
				timeEnd = timeEnd.AddSeconds(-1);
			}

			#endregion

			#region Events

			public event EventHandler SelectionChanged;

			#endregion
		}
	}
}