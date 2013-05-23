/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CalendarTest
{
    public interface ITool
    {
        DayView DayView
        {
            get;
            set;
        }

        void Reset();

        void MouseMove( MouseEventArgs e );
        void MouseUp( MouseEventArgs e );
        void MouseDown( MouseEventArgs e );
    }
    
    public enum RectType
    {
		None = 0,
		PrevBtn,
		NextBtn,
		NavBar,
		Cell,
		RowLabel,
		ColLabel
    }
}
