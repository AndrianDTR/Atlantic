using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAssistant
{
	public partial class WaitDialog : Form
	{
		public WaitDialog(int min, int max, int step)
		{
			InitializeComponent();
			progressComplete.Minimum = min;
			progressComplete.Maximum = max;
			progressComplete.Step = step;
		}
		
		public void StepIt()
		{
			progressComplete.PerformStep();
		}
	}
}

