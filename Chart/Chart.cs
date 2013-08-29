using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace AY.ChartControll
{
	public partial class MyChart : Chart
	{
		private Series m_series = null;
		
		public MyChart():base()
		{
			Init();
		}
		
		private void Init()
		{
			ChartArea chartArea = new ChartArea();
			Legend legend = new Legend();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();

			chartArea.Name = "ChartArea1";
			this.ChartAreas.Add(chartArea);
			legend.Name = "Legend1";
			this.Legends.Add(legend);
			
			Series.Clear();
			m_series = new Series
			{
				Name = "Series1",
				Color = System.Drawing.Color.Green,
				IsVisibleInLegend = false,
				IsXValueIndexed = true,
				ChartType = SeriesChartType.Line
			};
			Series.Add(m_series);

			for (int i = 10; i < 23; i++)
			{
				m_series.Points.AddXY(i, f(i));
			}
		}
		
		private double f(int i)
		{
			double f1 = 59894 - (8128 * i) + (262 * i * i) - (1.6 * i * i * i);
			return f1;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
			Invalidate();
		}

		
	}
}
