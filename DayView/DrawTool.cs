/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CalendarTest
{
    public class DrawTool : ITool
    {
		public event EventHandler Complete;
		
		DateTime m_SelectionStartAt;
        bool m_SelectionChanged;
        
        private DayView m_DayView;

		public DayView DayView
		{
			get { return m_DayView; }
			set { m_DayView = value; }
		}
		
        public void Reset()
        {
            m_SelectionChanged = false;
        }

		public void MouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (m_SelectionChanged)
				{
					m_DayView.SelectedDate = m_DayView.GetDateAt(e.X, e.Y);
				}
			}
		}

        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_DayView.Capture = false;
                m_SelectionChanged = false;

                m_DayView.RaiseSelectionChanged(EventArgs.Empty);

                if (Complete != null)
                    Complete(this, EventArgs.Empty);
            }
        }

        public void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
				m_SelectionStartAt = m_DayView.GetDateAt(e.X, e.Y);

				m_DayView.SelectedDate = m_SelectionStartAt;
				m_SelectionChanged = true;

				m_DayView.Capture = true;
            }
        }
    }
}
