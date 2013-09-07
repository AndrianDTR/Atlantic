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
		
		public int Min
		{
			get{ return progressComplete.Minimum; }
			set{ progressComplete.Minimum = value; }
		}

		public int Max
		{
			get { return progressComplete.Maximum; }
			set { progressComplete.Maximum = value; }
		}

		public int Step
		{
			get { return progressComplete.Step; }
			set { progressComplete.Step = value; }
		}
		
		public void StepIt()
		{
			progressComplete.PerformStep();
		}
	}
}

