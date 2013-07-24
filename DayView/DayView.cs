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

		private ToolTip m_ToolTip;

		//private DrawTool drawTool;

		Rectangle m_rSelectionStartAt;
		DateTime m_dSelectionStartAt;
		bool m_bSelectionChanged;
		bool m_bMouseEnter = false;
		
        #endregion
        
        #region Constants
        int m_nMult = 100;
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
			
			//Fill string with data
			//String sTip = GetDateAt(e.X, e.Y).ToString();
			//Rectangle rTip = GetRectAt(e.X, e.Y);
			//if (m_ToolTip.GetToolTip(m_dataPanel) == sTip)
			//{
			//    return;
			//}
			//m_ToolTip.Show(sTip, m_dataPanel, rTip.Right - 5, rTip.Bottom - 5, int.MaxValue);
		}

		protected void OnDataMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				m_dataPanel.Capture = false;
				m_bSelectionChanged = false;

				RaiseSelectionChanged(EventArgs.Empty);

				//if (Complete != null)
				//	Complete(this, EventArgs.Empty);
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
			//m_ToolTip.Hide(m_dataPanel);
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
			// Draw the ToolTip differently depending on which 
			// control this ToolTip is for.
			// Draw a custom 3D border if the ToolTip is for button1.
			//if (e.AssociatedControl == m_dataPanel)
			//{
			//    // Draw the standard background.
			//    e.DrawBackground();

			//    // Draw the custom border to appear 3-dimensional.
			//    e.Graphics.DrawLines(SystemPens.ControlLightLight, new Point[] {
			//        new Point (0, e.Bounds.Height - 1), 
			//        new Point (0, 0), 
			//        new Point (e.Bounds.Width - 1, 0)
			//    });
			//    e.Graphics.DrawLines(SystemPens.ControlDarkDark, new Point[] {
			//        new Point (0, e.Bounds.Height - 1), 
			//        new Point (e.Bounds.Width - 1, e.Bounds.Height - 1), 
			//        new Point (e.Bounds.Width - 1, 0)
			//    });

			//    // Specify custom text formatting flags.
			//    TextFormatFlags sf = TextFormatFlags.VerticalCenter |
			//                         TextFormatFlags.HorizontalCenter |
			//                         TextFormatFlags.NoFullWidthCharacterBreak;

			//    // Draw the standard text with customized formatting options.
			//    e.DrawText(sf);
			//}
			// Draw a custom background and text if the ToolTip is for button2.
			//else if (e.AssociatedControl == button2)
			//{
			//    // Draw the custom background.
			//    e.Graphics.FillRectangle(Brushes.Azure, e.Bounds);

			//    // Draw the standard border.
			//    e.DrawBorder();

			//    // Draw the custom text.
			//    // The using block will dispose the StringFormat automatically.
			//    using (StringFormat sf = new StringFormat())
			//    {
			//        sf.Alignment = StringAlignment.Center;
			//        sf.LineAlignment = StringAlignment.Center;
			//        sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
			//        sf.FormatFlags = StringFormatFlags.NoWrap;
			//        using (Font f = new Font("Tahoma", 9))
			//        {
			//            e.Graphics.DrawString(e.ToolTipText, f,
			//                SystemBrushes.ActiveCaptionText, e.Bounds, sf);
			//        }
			//    }
			//}
			// Draw the ToolTip using default values if the ToolTip is for button3.
			//else if (e.AssociatedControl == button3)
			{
				e.DrawBackground();
				e.DrawBorder();
				e.DrawText();
			}
		}
		/*****************************************/
		
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

		//private int[] GetHeaderWidth(Rectangle rect)
		//{
		//    // Week contain 7 days + weekLabel
		//    int[] widths = new int[8];

		//    widths[0] = renderer.WeekLabelWidth;
		//    int dayWidth = (rect.Width - renderer.WeekLabelWidth) / 7;

		//    for (int n = 1; n < widths.Length; n++)
		//    {
		//        widths[n] = dayWidth;
		//    }
		//    return widths;
		//}
		
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
					infos[n].extraInfo = date;

				infos[n].sTip = "Tip:\n" + infos[n].sTitle + "\n";
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

		/*

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

		#endregion

        #region Events

        public event EventHandler SelectionChanged;
		public event EventHandler Complete;
        //public event ResolveAppointmentsEventHandler ResolveAppointments;
        //public event NewAppointmentEventHandler NewAppointment;
        //public event EventHandler<AppointmentEventArgs> AppoinmentMove;

        #endregion
    }
}

