/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace Calendar
{
    public class Calendar : Control
    {
        #region Variables
		
		private TableLayoutPanel m_grid;
        private TextBox editbox;
		private Button m_btnPrev;
		private Button m_btnNext;
		private Panel m_dataPanel;
		private Panel m_headerPanel;
		private Panel m_scrollPanel;
        private VScrollBar m_Scrollbar;

		private ToolTip m_ToolTip;

		Rectangle m_rSelectionStartAt;
		DateTime m_dSelectionStartAt;
		bool m_bSelectionChanged;
		bool m_bMouseEnter = false;

		public delegate CellInfo __CellInfo(DateTime date);
		private __CellInfo m_fpDefCellInfo = GetCellInfo;

		#endregion
        
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

			m_grid = new TableLayoutPanel();
			m_grid.SuspendLayout();
				
			m_grid.ColumnCount = 1;
			m_grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			m_grid.Dock = DockStyle.Fill;
			m_grid.Location = new System.Drawing.Point(0, 0);
			m_grid.Name = "tableLayoutPanel0";
			m_grid.RowCount = 3;
			m_grid.RowStyles.Add(new RowStyle());
			m_grid.RowStyles.Add(new RowStyle());
			m_grid.RowStyles.Add(new RowStyle());
			m_grid.RowStyles.Add(new RowStyle());
						
			m_btnPrev = new Button();
			m_btnPrev.Visible = true;
			m_btnPrev.Dock = DockStyle.Fill;
			m_btnPrev.Height = m_nNavButtonsHeight;
			m_btnPrev.Text = "Prev";
			m_btnPrev.Margin = Padding.Empty;
			m_grid.Controls.Add(m_btnPrev, 0, 0);
			
			m_headerPanel = new Panel();
			m_headerPanel.Visible = true;
			m_headerPanel.Height = m_nNavButtonsHeight;
			m_headerPanel.Dock = DockStyle.Fill;
			m_headerPanel.Margin = Padding.Empty;
			m_grid.Controls.Add(m_headerPanel, 0, 1);

			m_ToolTip = new ToolTip();
			m_ToolTip.AutoPopDelay = 5000;
			m_ToolTip.InitialDelay = 100;
			m_ToolTip.OwnerDraw = true;
			m_ToolTip.ReshowDelay = 10;
			m_ToolTip.IsBalloon = true;
			m_ToolTip.Draw += new DrawToolTipEventHandler(this.OnDrawStats);
			m_ToolTip.Popup += new PopupEventHandler(this.OnPopupStats);
				
			m_dataPanel = new Panel();
			m_dataPanel.Visible = true;
			m_dataPanel.Height = m_nNavButtonsHeight;
			m_dataPanel.Dock = DockStyle.None;
			m_dataPanel.Margin = Padding.Empty;
						
			m_Scrollbar = new VScrollBar();
			m_Scrollbar.Visible = true;
			m_Scrollbar.Value = RowHeight;
			
			m_scrollPanel = new Panel();
			m_scrollPanel.Visible = true;
			m_scrollPanel.Width = m_Scrollbar.Width;
			m_scrollPanel.Dock = DockStyle.Right;
			m_scrollPanel.Margin = Padding.Empty;
			m_dataPanel.Controls.Add(m_scrollPanel);
						
			m_scrollPanel.Controls.Add(m_Scrollbar);
			
            editbox = new TextBox();
            editbox.Multiline = true;
            editbox.Visible = false;
            editbox.BorderStyle = BorderStyle.None;
            editbox.KeyUp += new KeyEventHandler(editbox_KeyUp);
			editbox.Margin = Padding.Empty;
			m_dataPanel.Controls.Add(editbox);
			
			m_grid.Controls.Add(m_dataPanel, 0, 2);
			
			m_btnNext = new Button();
			m_btnNext.Visible = true;
			m_btnNext.Dock = DockStyle.Fill;
			m_btnNext.Height = m_nNavButtonsHeight;
			m_btnNext.Text = "Next";
			m_btnNext.Margin = Padding.Empty;
			m_grid.Controls.Add(m_btnNext, 0, 3);

			m_grid.ResumeLayout();
			this.Controls.Add(m_grid);
			
			m_Scrollbar.Dock = DockStyle.Fill;

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
		//[System.ComponentModel.DefaultValue(GetCellInfo)]
		public __CellInfo CellInfoDeledate
		{
			get
			{
				return m_fpDefCellInfo;
			}
			set
			{
				m_fpDefCellInfo = value;
			}
		}
		
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

        [System.ComponentModel.Browsable(false)]
        public bool CurrentlyEditing
        {
            get
            {
                return editbox.Visible;
            }
        }

        bool selectedAppointmentIsNew;

        public bool SelectedAppointmentIsNew
        {
            get
            {
                return selectedAppointmentIsNew;
            }
        }

        /*
		private bool allowScroll = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowScroll
        {
            get
            {
                return allowScroll;
            }
            set
            {
                allowScroll = value;
            }
        }
		*/
        private bool allowInplaceEditing = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowInplaceEditing
        {
            get
            {
                return allowInplaceEditing;
            }
            set
            {
                allowInplaceEditing = value;
            }
        }

        private bool allowNew = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowNew
        {
            get
            {
                return allowNew;
            }
            set
            {
                allowNew = value;
            }
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

			if (editbox.Visible)
				//scroll text box too
				editbox.Top += e.OldValue - e.NewValue;
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

			if (CurrentlyEditing)
			{
				FinishEditing(false);
			}

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
			if(m_bMouseEnter)
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
                FinishEditing(true);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                FinishEditing(false);
            }
        }

        
        internal void RaiseSelectionChanged(EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }
		
		#endregion

		#region Public Methods
		private static CellInfo GetCellInfo(DateTime date)
		{
			CellInfo ci = new CellInfo(date);
			return ci;
		}
		
		public void StartEditing()
        {
            /*if (!selectedAppointment.Locked && appointmentViews.ContainsKey(selectedAppointment))
            {
                Rectangle editBounds = appointmentViews[selectedAppointment].Rectangle;

                editBounds.Inflate(-3, -3);
				editBounds.X += editGripWidth - 2;
				editBounds.Width -= editGripWidth - 5;

                editbox.Bounds = editBounds;
                editbox.Text = selectedAppointment.Title;
                editbox.Visible = true;
                editbox.SelectionStart = editbox.Text.Length;
                editbox.SelectionLength = 0;

                editbox.Focus();
            }//*/
        }

        public void FinishEditing(bool cancel)
        {
            editbox.Visible = false;

            if (!cancel)
            {
                //if (selectedAppointment != null)
                //    selectedAppointment.Title = editbox.Text;
            }
            else
            {
                if (selectedAppointmentIsNew)
                {
                //   selectedAppointment = null;
                //   selectedAppointmentIsNew = false;
                }
            }

			Invalidate(true);
            this.Focus();
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
            
            if(x < 0 | y < 0)
				date = new DateTime();
				
            return date;
        }

		public Rectangle GetRectAt(int x, int y)
		{
			Rectangle rect = new Rectangle();

			int colWidth = (m_dataPanel.Width - RowLabelWidth - m_scrollPanel.Width) / 7;
			
			rect.Width = colWidth;
			rect.Height = RowHeight;
			
			if(x <= RowLabelWidth)
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
		
		public static T[] Shift<T>(T[] array, int positions)
		{
			T[] copy = new T[array.Length];
			Array.Copy(array, 0, copy, array.Length - positions, positions);
			Array.Copy(array, positions, copy, 0, array.Length - positions);
			return copy;
		}

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
		
		private string[] GetWeekDayNames()
		{
			int shift = 0;
			string[] names = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
			switch (System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
			{
				case (DayOfWeek.Sunday):
					shift = 0;
					break;
				case (DayOfWeek.Monday):
					shift = 1;
					break;
				case (DayOfWeek.Tuesday):
					shift = 2;
					break;
				case (DayOfWeek.Wednesday):
					shift = 3;
					break;
				case (DayOfWeek.Thursday):
					shift = 4;
					break;
				case (DayOfWeek.Friday):
					shift = 5;
					break;
				case (DayOfWeek.Saturday):
					shift = 6;
					break;
			}
			return Shift(names, shift);
		}

		#endregion 
		
		#region Drawing Methods
			
		private CellInfo[] GetWeekDays(DateTime date)
		{
			CellInfo[] infos = new CellInfo[7];

			for (int n = 0; n < infos.Length; n++)
			{
				infos[n] = m_fpDefCellInfo(date.AddDays(n));
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
			
			string[] weekDays = GetWeekDayNames();

			renderer.DrawHeaderBg(e.Graphics, rect);
			
			Rectangle rCol = rect;
			rCol.Width = RowLabelWidth;
			
			for (int nCol = 0; nCol < 7 + 1; nCol++)
			{
				if(nCol == 0)
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
					
					if(nCol == 0)
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
						weekInfo[nCol-1].bSelected = weekInfo[nCol-1].date == SelectedDate ? true : false;
						weekInfo[nCol-1].bCurMonth = weekInfo[nCol-1].date.Month == StartDate.Month ? true : false;
						weekInfo[nCol-1].sTitle = weekInfo[nCol-1].date.ToShortDateString();
						renderer.DrawCell(e.Graphics, rDraw, weekInfo[nCol-1]);
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
		public event EventHandler Complete;

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Calendar
			// 
			this.Name = "Calendar";
			this.ResumeLayout(false);

		}

        #endregion
    }
}

