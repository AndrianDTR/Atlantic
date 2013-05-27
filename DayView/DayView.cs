/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace CalendarTest
{
    public class DayView : Control
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
        
        private DrawTool drawTool;
        
        #endregion
        
        #region Constants
        #endregion

        #region c.tor

        public DayView()
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
			
			
			m_dataPanel = new Panel();
			m_dataPanel.Visible = true;
			m_dataPanel.Height = m_nNavButtonsHeight;
			m_dataPanel.Dock = DockStyle.Fill;
			m_dataPanel.Margin = Padding.Empty;

			m_Scrollbar = new VScrollBar();
			m_Scrollbar.SmallChange = RowHeight;
			m_Scrollbar.LargeChange = RowHeight * 5;
			m_Scrollbar.Minimum = RowHeight;
			m_Scrollbar.Maximum = 53 * RowHeight;
			m_Scrollbar.Visible = true;
			m_Scrollbar.Value = RowHeight;
			
			m_scrollPanel = new Panel();
			m_scrollPanel.Visible = true;
			m_scrollPanel.Width = m_Scrollbar.Width;
			m_scrollPanel.Dock = DockStyle.Right;
			m_scrollPanel.Margin = Padding.Empty;
			m_scrollPanel.Controls.Add(m_Scrollbar);

			m_dataPanel.Controls.Add(m_scrollPanel);
			
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
			
			drawTool = new DrawTool();
            drawTool.DayView = this;
            activeTool = drawTool;
			
			m_Scrollbar.Dock = DockStyle.Fill;

			this.Renderer = new DefaultRenderer();
			
            //UpdateWorkingHours();
            m_Scrollbar.Scroll += new ScrollEventHandler(this.OnScroll);
			m_headerPanel.Paint += new PaintEventHandler(this.OnHeaderPaint);
			m_dataPanel.Paint += new PaintEventHandler(this.OnDataPaint);

			m_scrollPanel.Paint += new PaintEventHandler(this.OnScrollPaint);
			
			m_btnPrev.Paint += new PaintEventHandler(this.OnPrevBtnPaint);
			m_btnPrev.Click += new EventHandler(this.OnPrevBtnClick);
			
			m_btnNext.Paint += new PaintEventHandler(this.OnNextBtnPaint);
			m_btnNext.Click += new EventHandler(this.OnNextBtnClick);
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
				Redraw();
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
				Redraw();
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
				Redraw();
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
				Redraw();
			}
		}
		/********************************************************/
		
		private AbstractRenderer renderer;

		private void OnRowHeightChanged()
        {
			m_Scrollbar.Minimum = 1;
			m_Scrollbar.Maximum = 52 * RowHeight;
			m_Scrollbar.Value = RowHeight * GetWeekOfYear(StartDate);
			Redraw();
        }

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
                Redraw();
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
			m_Scrollbar.Maximum = (nWeeks + 1) * RowHeight;
            m_Scrollbar.Value = GetWeekOfYear(StartDate) * RowHeight;
            m_btnPrev.Text = (startDate.Year - 1).ToString();
			m_btnNext.Text = (startDate.Year + 1).ToString();
			Redraw();
        }

        private DateTime selectedDate;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; }
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

        void selectionTool_Complete(object sender, EventArgs e)
        {
            //if (selectedAppointment != null)
            {
                //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(EnterEditMode));
            }
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
			m_dataPanel.Height = height - 2 * NavButtonsHeight - HeaderHeight;
		}

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Capture focus
            this.Focus();

            if (CurrentlyEditing)
            {
                FinishEditing(false);
            }
			
			switch(IsInRect(e.X, e.Y))
            {
				case RectType.Cell:
					selectedDate = GetDateAt(e.X, e.Y);
					break;
			}
			Redraw();
            
            if (activeTool != null)
            {
                activeTool.MouseDown(e);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (activeTool != null)
                activeTool.MouseMove(e);

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (activeTool != null)
                activeTool.MouseUp(e);

            base.OnMouseUp(e);
        }
		
		/*
        System.Collections.Hashtable cachedAppointments = new System.Collections.Hashtable();

        protected virtual void OnResolveAppointments(ResolveAppointmentsEventArgs args)
        {
			if (ResolveAppointments != null)
                ResolveAppointments(this, args);

            this.allDayEventsHeaderHeight = 0;

            // cache resolved appointments in hashtable by days.
            cachedAppointments.Clear();

            if ((selectedAppointmentIsNew) && (selectedAppointment != null))
            {
                if ((selectedAppointment.StartDate > args.StartDate) && (selectedAppointment.StartDate < args.EndDate))
                {
                    args.Appointments.Add(selectedAppointment);
                }
            }

            foreach (Appointment appointment in args.Appointments)
            {
                int key = -1;
                AppointmentList list;

                if (appointment.StartDate.Day == appointment.EndDate.Day)
                {
                    key = appointment.StartDate.Day;
                }
                else
                {
                    // use -1 for exceeding one more than day
                    key = -1;

                    //ALL DAY EVENTS IS NOT COMPLETE
                    //this.allDayEventsHeaderHeight += horizontalAppointmentHeight;
                }

                list = (AppointmentList)cachedAppointments[key];

                if (list == null)
                {
                    list = new AppointmentList();
                    cachedAppointments[key] = list;
                }

                list.Add(appointment);
            }
        }
		//*/
        internal void RaiseSelectionChanged(EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }
		/*
        internal void RaiseAppointmentMove(AppointmentEventArgs e)
        {
            if (AppoinmentMove != null)
                AppoinmentMove(this, e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((allowNew) && char.IsLetterOrDigit(e.KeyChar))
            {
                if ((this.Selection == SelectionType.DateRange))
                {
                    if (!selectedAppointmentIsNew)
                        EnterNewAppointmentMode(e.KeyChar);
                }
            }
        }

        private void EnterNewAppointmentMode(char key)
        {
            Appointment appointment = new Appointment();
            appointment.StartDate = selectionStart;
            appointment.EndDate = selectionEnd;
            appointment.Title = key.ToString();

            selectedAppointment = appointment;
            selectedAppointmentIsNew = true;

            activeTool = selectionTool;

            Refresh();

            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(EnterEditMode));
        }

        private delegate void StartEditModeDelegate(object state);

        private void EnterEditMode(object state)
        {
            if (!allowInplaceEditing)
                return;

            if (this.InvokeRequired)
            {
                Appointment selectedApp = selectedAppointment;

                System.Threading.Thread.Sleep(200);

                if (selectedApp == selectedAppointment)
                    this.Invoke(new StartEditModeDelegate(EnterEditMode), state);
            }
            else
            {
                StartEditing();
            }
        }

        internal void RaiseNewAppointment()
        {
            NewAppointmentEventArgs args = new NewAppointmentEventArgs(selectedAppointment.Title, selectedAppointment.StartDate, selectedAppointment.EndDate);

            if (NewAppointment != null)
            {
                NewAppointment(this, args);
            }

            selectedAppointment = null;
            selectedAppointmentIsNew = false;

            Refresh();
        }
		//*/
		#endregion

		#region Public Methods

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

			Redraw();
            this.Focus();
        }

        public DateTime GetDateAt(int x, int y)
        {
			DateTime date = GetFirstDateOfWeek(StartDate.Year, GetWeekOfYear(StartDate));;
			
			int dayWidth = (m_dataPanel.Width - RowLabelWidth) / 7;
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

		private int[] GetHeaderWidth(Rectangle rect)
		{
			// Week contain 7 days + weekLabel
			int[] widths = new int[8];

			widths[0] = renderer.WeekLabelWidth;
			int dayWidth = (rect.Width - renderer.WeekLabelWidth) / 7;

			for (int n = 1; n < widths.Length; n++)
			{
				widths[n] = dayWidth;
			}
			return widths;
		}
		
		public RectType IsInRect(int x, int y)
		{
			if (new Rectangle(m_dataPanel.Left + RowLabelWidth
				, m_dataPanel.Top
				, m_dataPanel.Width - RowLabelWidth
				, m_dataPanel.Height).Contains(x, y))
				return RectType.Cell;

			if (new Rectangle(m_dataPanel.Left
				, m_dataPanel.Top
				, RowLabelWidth
				, m_dataPanel.Height).Contains(x, y))
				return RectType.RowLabel;

			if (new Rectangle(m_headerPanel.Left
				, m_headerPanel.Top
				, m_headerPanel.Width - m_Scrollbar.Width
				, m_headerPanel.Height).Contains(x, y))
				return RectType.ColLabel;

			return RectType.None;
		}
		#endregion 
		
		#region Drawing Methods

		private CellInfo[] GetWeekDays(DateTime date)
		{
			CellInfo[] infos = new CellInfo[7];

			for (int n = 0; n < infos.Length; n++)
			{
				infos[n] = new CellInfo(date.AddDays(n));
				
				// TODO: Add extra info here
				if (n % 2 == 0)
					infos[n].sTrainer = "AA ddddd d fgfdgfdgf fge df AA";

				infos[n].sTip = "Tip:\n" + infos[n].sTitle + "\n" + infos[n].sTrainer + "\n";
			}

			return infos;
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
		
		/*
		private void DrawCalendarTable(PaintEventArgs e, Rectangle rect)
		{
			e.Graphics.SetClip(rect);
			int rows = rect.Height / RowHeight + 1;
			rect.Height = rows * RowHeight;
			
			int colW = (rect.Width - RowLabelWidth) / 7;
			int rowH = RowHeight;

			Rectangle rCol = rect;
			rCol.Width = RowLabelWidth;
			for (int nCol = 0; nCol < 7 + 1; nCol++)
			{
				if (nCol == 0)
				{
					renderer.DrawRowLabelBg(e.Graphics, rCol);
					rCol.X += RowLabelWidth;
				}
				else
				{
					renderer.DrawColBg(e.Graphics, rCol);
					rCol.X += colW;
				}
				rCol.Width = colW;
			}
			
			Rectangle rRow = rect;
			rRow.Height = RowHeight;
			for(int nRow = 0; nRow < rows; nRow++)
			{
				renderer.DrawRowBg(e.Graphics, rRow);
				rRow.Y += rowH;
			}
			
			e.Graphics.ResetClip();
		}//*/
		
		private void DrawWeeks(PaintEventArgs e, Rectangle rect)
		{
			e.Graphics.SetClip(rect);
			int rows = rect.Height / RowHeight + 1;
			rect.Height = rows * RowHeight;

			int nWeeks = GetWeekOfYear(new DateTime(StartDate.Year, 12, 31));
			int nWeek = m_Scrollbar.Value / RowHeight;
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
						renderer.DrawCell(e.Graphics, rDraw, weekInfo[nCol-1]);
						rCell.X += colW;
					}
				}
				rCell.Y += RowHeight;
			}
			//*/
			e.Graphics.ResetClip();
		}

		protected void Redraw()
        {
			Invalidate();
			m_headerPanel.Invalidate();
			m_dataPanel.Invalidate();
        }
        
		/*
        private Rectangle GetHourRangeRectangle(DateTime start, DateTime end, Rectangle baseRectangle)
        {
            Rectangle rect = baseRectangle;

            int startY;
            int endY;

            startY = (start.Hour * weekLabelHeight * 2) + ((start.Minute * weekLabelHeight) / 30);
            endY = (end.Hour * weekLabelHeight * 2) + ((end.Minute * weekLabelHeight) / 30);

            rect.Y = startY - scrollbar.Value + this.HeaderHeight;

            rect.Height = endY - startY;

            return rect;
        }

        private void DrawDay(PaintEventArgs e, Rectangle rect, DateTime time)
        {
            //renderer.DrawDayBackground(e.Graphics, rect);

            Rectangle workingHoursRectangle = GetHourRangeRectangle(workStart, workEnd, rect);

            if (workingHoursRectangle.Y < this.HeaderHeight)
                workingHoursRectangle.Y = this.HeaderHeight;

            if (!((time.DayOfWeek == DayOfWeek.Saturday) || (time.DayOfWeek == DayOfWeek.Sunday))) //weekends off -> no working hours
                renderer.DrawHourRange(e.Graphics, workingHoursRectangle, false, false);

            if ((selection == SelectionType.DateRange) && (time.Day == selectionStart.Day))
            {
                Rectangle selectionRectangle = GetHourRangeRectangle(selectionStart, selectionEnd, rect);

                renderer.DrawHourRange(e.Graphics, selectionRectangle, false, true);
            }

            e.Graphics.SetClip(rect);
			
            for (int week = 0; week < ShowWeeks; week++)
            {
                int y = rect.Top + (week * weekLabelHeight) - scrollbar.Value;

                Pen pen = new Pen(renderer.WeekSeperatorColor);
                e.Graphics.DrawLine(pen, rect.Left, y, rect.Right, y);

                if (y > rect.Bottom)
                    break;
            }

            renderer.DrawDayGripper(e.Graphics, rect, appointmentGripWidth);

            e.Graphics.ResetClip();
			
            DrawAppointments(e, rect, time);
        }
		//*/
        
        private void DrawAppointments(PaintEventArgs e, Rectangle rect, DateTime time)
        {
            DateTime timeStart = time.Date;
            DateTime timeEnd = timeStart.AddHours(24);
            timeEnd = timeEnd.AddSeconds(-1);

			/*
            AppointmentList appointments = null;//(AppointmentList)cachedAppointments[time.Day];

            if (appointments != null)
            {
			    HalfHourLayout[] layout = GetMaxParalelAppointments(appointments);
                List<Appointment> drawnItems = new List<Appointment>();

                for (int halfHour = 0; halfHour < 24 * 2; halfHour++)
                {
                    HalfHourLayout hourLayout = layout[halfHour];

                    if ((hourLayout != null) && (hourLayout.Count > 0))
                    {
                        for (int appIndex = 0; appIndex < hourLayout.Count; appIndex++)
                        {
                            Appointment appointment = hourLayout.Appointments[appIndex];

                            if (drawnItems.IndexOf(appointment) < 0)
                            {
                                Rectangle appRect = rect;
                                int appointmentWidth;
                                AppointmentView view;

                                appointmentWidth = rect.Width / appointment.m_ConflictCount;

                                int lastX = 0;

                                foreach (Appointment app in hourLayout.Appointments)
                                {
                                    if ((app != null) && (appointmentViews.ContainsKey(app)))
                                    {
                                        view = appointmentViews[app];

                                        if (lastX < view.Rectangle.X)
                                            lastX = view.Rectangle.X;
                                    }
                                }

                                if ((lastX + (appointmentWidth * 2)) > (rect.X + rect.Width))
                                    lastX = 0;

                                appRect.Width = appointmentWidth - 5;

                                if (lastX > 0)
                                    appRect.X = lastX + appointmentWidth;

                                appRect = GetHourRangeRectangle(appointment.StartDate, appointment.EndDate, appRect);

                                view = new AppointmentView();
                                view.Rectangle = appRect;
                                view.Appointment = appointment;

                                appointmentViews[appointment] = view;

                                e.Graphics.SetClip(rect);

                                renderer.DrawAppointment(e.Graphics, appRect, appointment, appointment == selectedAppointment, appointmentGripWidth);

                                e.Graphics.ResetClip();

                                drawnItems.Add(appointment);
                            }
                        }
                    }
                }
            }//*/
        }

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

			//DrawCalendarTable(e, rRect);
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
		
		
        #endregion

        #region Events

        public event EventHandler SelectionChanged;
        //public event ResolveAppointmentsEventHandler ResolveAppointments;
        //public event NewAppointmentEventHandler NewAppointment;
        //public event EventHandler<AppointmentEventArgs> AppoinmentMove;

        #endregion
    }
}

