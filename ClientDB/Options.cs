﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAssistant
{
	public partial class Options : Form
	{
		public Options()
		{
			InitializeComponent();
			Session s = Session.Instance;
		}
	}
}
