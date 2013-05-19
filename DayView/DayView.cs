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

        private TextBox editbox;
        private VScrollBar scrollbar;
        private DrawTool drawTool;
        private SelectionTool selectionTool;
        private int allDayEventsHeaderHeight = 20;

        private DateTime workStart;
        private DateTime workEnd;

        #endregion

        #region Constants

        private int weekLabelWidth = 50;
        private int hourLabelIndent = 2;
        private int dayHeadersHeight = 20;
        private int appointmentGripWidth = 5;
        private int horizontalAppointmentHeight = 20;

        #endregion

        #region c.tor

        public DayView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);

            /*
			scrollbar = new VScrollBar();
            scrollbar.SmallChange = weekLabelHeight;
            scrollbar.LargeChange = weekLabelHeight * 2;
            scrollbar.Dock = DockStyle.Right;
            scrollbar.Visible = allowScroll;
            scrollbar.Scroll += new ScrollEventHandler(scrollbar_Scroll);
            AdjustScrollbar();
            //scrollbar.Value = (startHour * 2 * halfHourHeight);
			
            this.Controls.Add(scrollbar);
			//*/

            editbox = new TextBox();
            editbox.Multiline = true;
            editbox.Visible = false;
            editbox.BorderStyle = BorderStyle.None;
            editbox.KeyUp += new KeyEventHandler(editbox_KeyUp);
            editbox.Margin = Padding.Empty;

            this.Controls.Add(editbox);

            drawTool = new DrawTool();
            drawTool.DayView = this;

            selectionTool = new SelectionTool();
            selectionTool.DayView = this;
            selectionTool.Complete += new EventHandler(selectionTool_Complete);

            activeTool = drawTool;

            //UpdateWorkingHours();

            this.Renderer = new Office12Renderer();
        }

        #endregion

        #region Properties
		private AbstractRenderer renderer;

		private int m_showWeeks = 6;

		[System.ComponentModel.DefaultValue(6)]
		public int ShowWeeks
		{
			get
			{
				return m_showWeeks;
			}
			set
			{
				m_showWeeks = value;
				OnWeekLabelHeightChanged();
			}
		}

		[System.ComponentModel.DefaultValue(20)]
		public int WeekLabelHeight
		{
			get
			{
				return renderer.MinWeekHeight;
			}
			set
			{
				renderer.MinWeekHeight = value;
				OnWeekLabelHeightChanged();
			}
		}
		
		private void OnWeekLabelHeightChanged()
        {

            //AdjustScrollbar();
            Invalidate();
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
                OnRendererChanged();
            }
        }

        private void OnRendererChanged()
        {
            this.Invalidate();
        }

        private SelectionType selection;

        [System.ComponentModel.Browsable(false)]
        public SelectionType Selection
        {
            get
            {
                return selection;
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

            selectedAppointment = null;
            selectedAppointmentIsNew = false;
            selection = SelectionType.DateRange;

            Invalidate();
        }

        private Appointment selectedAppointment;

        [System.ComponentModel.Browsable(false)]
        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
        }

        private DateTime selectionStart;

        public DateTime SelectionStart
        {
            get { return selectionStart; }
            set { selectionStart = value; }
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
            if (selectedAppointment != null)
            {
                //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(EnterEditMode));
            }
        }
		
		/*
        void scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();

            if (editbox.Visible)
                //scroll text box too
                editbox.Top += e.OldValue - e.NewValue;
        }
		*/
		
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
            //AdjustScrollbar();
        }

        /*
		private void AdjustScrollbar()
        {
            scrollbar.Maximum = (2 * weekLabelHeight * 25) - this.Height + this.HeaderHeight;
            scrollbar.Minimum = 0;
        }
		//*/
        
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Flicker free
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Capture focus
            this.Focus();

            if (CurrentlyEditing)
            {
                FinishEditing(false);
            }

            if (selectedAppointmentIsNew)
            {
                //RaiseNewAppointment();
            }

            ITool newTool = null;

            Appointment appointment = GetAppointmentAt(e.X, e.Y);

            if (appointment == null)
            {
                if (selectedAppointment != null)
                {
                    selectedAppointment = null;
                    Invalidate();
                }

                newTool = drawTool;
                selection = SelectionType.DateRange;
            }
            else
            {
                newTool = selectionTool;
                selectedAppointment = appointment;
                selection = SelectionType.Appointment;

                Invalidate();
            }

            if (activeTool != null)
            {
                activeTool.MouseDown(e);
            }

            if ((activeTool != newTool) && (newTool != null))
            {
                newTool.Reset();
                newTool.MouseDown(e);
            }

            activeTool = newTool;

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

            Invalidate();

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

            Invalidate();
        }
		//*/
        #endregion

        #region Public Methods

		public void StartEditing()
        {
            if (!selectedAppointment.Locked && appointmentViews.ContainsKey(selectedAppointment))
            {
                Rectangle editBounds = appointmentViews[selectedAppointment].Rectangle;

                editBounds.Inflate(-3, -3);
                editBounds.X += appointmentGripWidth - 2;
                editBounds.Width -= appointmentGripWidth - 5;

                editbox.Bounds = editBounds;
                editbox.Text = selectedAppointment.Title;
                editbox.Visible = true;
                editbox.SelectionStart = editbox.Text.Length;
                editbox.SelectionLength = 0;

                editbox.Focus();
            }
        }

        public void FinishEditing(bool cancel)
        {
            editbox.Visible = false;

            if (!cancel)
            {
                if (selectedAppointment != null)
                    selectedAppointment.Title = editbox.Text;
            }
            else
            {
                if (selectedAppointmentIsNew)
                {
                    selectedAppointment = null;
                    selectedAppointmentIsNew = false;
                }
            }

            Invalidate();
            this.Focus();
        }

        public DateTime GetDateAt(int x, int y)
        {
			DateTime date = GetFirstDateOfWeek(StartDate.Year, GetWeekOfYear(StartDate));;
			
			int dayWidth = (this.Width - renderer.WeekLabelWidth) / 7;
			int weekHeight = (this.Height - renderer.HeaderHeight - renderer.NavBarHeight) / ShowWeeks;
			
			x -= renderer.WeekLabelWidth;
			y -= renderer.HeaderHeight + renderer.NavBarHeight;
      
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

        public Appointment GetAppointmentAt(int x, int y)
        {
            if (y < this.renderer.HeaderHeight)
                return null;

            foreach (AppointmentView view in appointmentViews.Values)
                if (view.Rectangle.Contains(x, y))
                    return view.Appointment;

            return null;
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
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
			Calendar cal = dfi.Calendar;

			return cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
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

		private void DrawNavBar(PaintEventArgs e, Rectangle rect)
		{
			e.Graphics.SetClip(rect);

			renderer.DrawNavBarBg(e.Graphics, rect);
			renderer.DrawNavBar(e.Graphics, rect);

			e.Graphics.ResetClip();
		}
		
		private void DrawHeaders(PaintEventArgs e, Rectangle rect)
		{
			e.Graphics.SetClip(rect);

			int colW = (rect.Width - renderer.WeekLabelWidth) / 7;
			int rowH = (rect.Height - renderer.HeaderHeight) / ShowWeeks;
			string[] weekDays = GetWeekDayNames();

			Rectangle rCol = rect;
			rCol.Height = renderer.HeaderHeight;
			
			for (int nCol = 0; nCol < 7 + 1; nCol++)
			{
				if(nCol == 0)
				{
					rCol.Width = renderer.WeekLabelWidth;
					renderer.DrawColLabel(e.Graphics, rCol, "");
					rCol.X += renderer.WeekLabelWidth;
				}
				else
				{
					rCol.Width = colW;
					renderer.DrawColLabel(e.Graphics, rCol, weekDays[nCol-1]);
					rCol.X += colW;
				}
			}
			
			Rectangle rRow = rect;
			rRow.Width = renderer.WeekLabelWidth;
			for (int nRow = 0; nRow < ShowWeeks + 1; nRow++)
			{
				if (nRow == 0)
				{
					rRow.Height = renderer.HeaderHeight;
					renderer.DrawRowLabel(e.Graphics, rRow, "");
					rRow.Y += renderer.HeaderHeight;
				}
				else
				{
					rRow.Height = rowH;
					string weekNum = GetWeekOfYear(StartDate.AddDays((nRow-1) * 7)).ToString();
					renderer.DrawRowLabel(e.Graphics, rRow, weekNum);
					rRow.Y += rowH;
				}
			}
			
			e.Graphics.ResetClip();
		}
		
		private void DrawWeeks(PaintEventArgs e, Rectangle rect)
		{
			e.Graphics.SetClip(rect);
			
			DateTime weekStartDate = GetFirstDateOfWeek(StartDate.Year, GetWeekOfYear(StartDate));
			
			Rectangle rCal = new Rectangle(renderer.WeekLabelWidth
				, renderer.HeaderHeight + renderer.NavBarHeight
				, rect.Width - renderer.WeekLabelWidth
				, rect.Height - renderer.HeaderHeight);

			int colW = (rect.Width - renderer.WeekLabelWidth) / 7;
			int rowH = (rect.Height - renderer.HeaderHeight) / ShowWeeks;

			Rectangle rDay = new Rectangle(rCal.Left, rCal.Top, colW, rowH);
			for (int nRow = 0; nRow < ShowWeeks; nRow++)
			{
				CellInfo[] weekInfo = GetWeekDays(weekStartDate.AddDays(nRow * 7));
				rDay.X = rCal.Left;
				for (int nCol = 0; nCol < 7; nCol++)
				{
					weekInfo[nCol].bOtherMonth = weekInfo[nCol].date.Month == StartDate.Month ? false : true;
					renderer.DrawCellBg(e.Graphics, rDay, weekInfo[nCol]);
					renderer.DrawCell(e.Graphics, rDay, weekInfo[nCol]);
					rDay.X += colW;
				}
				rDay.Y += rowH;
			}
			
			e.Graphics.ResetClip();
		}

		private void DrawCalendarTable(PaintEventArgs e, Rectangle rect)
		{
			e.Graphics.SetClip(rect);

			int colW = (rect.Width - renderer.WeekLabelWidth) / 7;
			int rowH = (rect.Height - renderer.HeaderHeight) / ShowWeeks;

			Rectangle rCol = rect;
			rCol.Width = renderer.WeekLabelWidth;
			for (int nCol = 0; nCol < 7 + 1; nCol++)
			{
				if (nCol == 0)
				{
					renderer.DrawRowLabelBg(e.Graphics, rCol);
					rCol.X += renderer.WeekLabelWidth;
				}
				else
				{
					renderer.DrawColBg(e.Graphics, rCol);
					rCol.X += colW;
				}
				rCol.Width = colW;
			}
			
			Rectangle rRow = rect;
			rRow.Height = renderer.HeaderHeight;
			for(int nRow = 0; nRow < ShowWeeks + 1; nRow++)
			{
				if(nRow == 0)
				{
					renderer.DrawColLabelBg(e.Graphics, rRow);
					rRow.Y += renderer.HeaderHeight;
				}
				else
				{
					renderer.DrawRowBg(e.Graphics, rRow);
					rRow.Y += rowH;
				}
				rRow.Height = rowH;
			}

			e.Graphics.ResetClip();
		}
		
        protected override void OnPaint(PaintEventArgs e)
        {
            // resolve appointments on visible date range.
			DateTime weekStartDate = GetFirstDateOfWeek(this.StartDate.Year, GetWeekOfYear(this.StartDate));
			
			ResolveAppointmentsEventArgs args = new ResolveAppointmentsEventArgs(weekStartDate, weekStartDate.AddDays(7 * ShowWeeks));
            //OnResolveAppointments(args);
			
			renderer.DrawBg(e.Graphics, this.ClientRectangle, System.Drawing.Drawing2D.SmoothingMode.AntiAlias);
			
			if(renderer.bDrawNavBar)
            {
				Rectangle rNavBar = new Rectangle(0, 0, this.Width, renderer.NavBarHeight);
				DrawNavBar(e, rNavBar);
			}

			int nNavBarHeight = 0;
			if (renderer.bDrawNavBar)
				nNavBarHeight = renderer.NavBarHeight;
			
			Rectangle rCal = new Rectangle(0, nNavBarHeight, this.Width, this.Height - nNavBarHeight);
					
			DrawCalendarTable(e, rCal);
			DrawHeaders(e, rCal);
			DrawWeeks(e, rCal);
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
        internal Dictionary<Appointment, AppointmentView> appointmentViews = new Dictionary<Appointment, AppointmentView>();

        private void DrawAppointments(PaintEventArgs e, Rectangle rect, DateTime time)
        {
            DateTime timeStart = time.Date;
            DateTime timeEnd = timeStart.AddHours(24);
            timeEnd = timeEnd.AddSeconds(-1);

            AppointmentList appointments = null;//(AppointmentList)cachedAppointments[time.Day];

            if (appointments != null)
            {
				/*
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
				* */
            }
        }

        private void DrawDays(PaintEventArgs e, Rectangle rect)
        {
            int dayWidth = rect.Width / 7;

			/* ALL DAY EVENTS IS NOT COMPLETE
			
            AppointmentList longAppointments = (AppointmentList)cachedAppointments[-1];

            int y = dayHeadersHeight;

            if (longAppointments != null)
            {
                Rectangle backRectangle = rect;
                backRectangle.Y = y;
                backRectangle.Height = allDayEventsHeaderHeight;

                renderer.DrawAllDayBackground(e.Graphics, backRectangle);

                foreach (Appointment appointment in longAppointments)
                {
                    Rectangle appointmenRect = rect;

                    appointmenRect.Width = (dayWidth * (appointment.EndDate.Day - appointment.StartDate.Day));
                    appointmenRect.Height = horizontalAppointmentHeight;
                    appointmenRect.X += (appointment.StartDate.Day - startDate.Day) * dayWidth;
                    appointmenRect.Y = y;

                    renderer.DrawAppointment(e.Graphics, appointmenRect, appointment, appointment == selectedAppointment, appointmentGripWidth);

                    y += horizontalAppointmentHeight;
                }
            }
            */

            DateTime time = startDate;
            
            Rectangle rectangle = rect;
            rectangle.Width = dayWidth;

            appointmentViews.Clear();

            for (int day = 0; day < 7; day++)
            {
                //DrawDay(e, rectangle, time);

                rectangle.X += dayWidth;
                time = time.AddDays(1);
            }
        }
        

        #endregion

        #region Internal Utility Classes

        internal class AppointmentView
        {
            public Appointment Appointment;
            public Rectangle Rectangle;
        }

        class AppointmentList : List<Appointment>
        {
        }

        #endregion

        #region Events

        public event EventHandler SelectionChanged;
        public event ResolveAppointmentsEventHandler ResolveAppointments;
        public event NewAppointmentEventHandler NewAppointment;
        public event EventHandler<AppointmentEventArgs> AppoinmentMove;

        #endregion
    }
}
