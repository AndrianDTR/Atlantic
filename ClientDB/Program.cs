using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClientDB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			DbAdapter ad = new DbAdapter();
			if( !ad.CheckTables())
			{
				DialogResult res = UIMessages.Error("Database is corrupt.", MessageBoxButtons.YesNo);
				if(res == DialogResult.Yes)
				{
					DbAdapter.ClearDB();
				}
			}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
