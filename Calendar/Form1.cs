using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalendarTest
{
    public partial class Form1 : Form
    {
        //List<Appointment> m_Appointments;

        public Form1()
        {
            InitializeComponent();

           // m_Appointments = new List<Appointment>();

            DateTime m_Date = DateTime.Now;

            m_Date = m_Date.AddHours(10 - m_Date.Hour);
            m_Date = m_Date.AddMinutes(-m_Date.Minute);

            dayView1.StartDate = DateTime.Now;
            dayView1.SelectionChanged += new EventHandler(dayView1_SelectionChanged);
            //dayView1.ResolveAppointments += new CalendarTest.ResolveAppointmentsEventHandler(this.dayView1_ResolveAppointments);

            dayView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dayView1_MouseMove);

            comboBox1.SelectedIndex = 1;
        }

        void dayView1_NewAppointment(object sender, NewAppointmentEventArgs args)
        {
			//Appointment m_Appointment = new Appointment();

			//m_Appointment.StartDate = args.StartDate;
			//m_Appointment.EndDate = args.EndDate;
			//m_Appointment.Title = args.Title;

			//m_Appointments.Add(m_Appointment);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dayView1.DaysToShow = int.Parse( textBox1.Text );
        }

        private void dayView1_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = dayView1.GetDateAt(e.X, e.Y).ToString();
        }

        private void dayView1_SelectionChanged(object sender, EventArgs e)
        {
            label3.Text = dayView1.SelectedDate.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			//Appointment m_App = new Appointment();
			//m_App.StartDate = dayView1.SelectionStart;
			////m_App.EndDate = dayView1.SelectionEnd;
			//m_App.BorderColor = Color.Red;

			//m_Appointments.Add(m_App);

            dayView1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
			
        }

        private void button5_Click(object sender, EventArgs e)
        {
			
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dayView1.Renderer = new DefaultRenderer();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (dayView1.SelectedAppointment != null)
            {
                colorDialog1.Color = dayView1.BackColor;

                if (colorDialog1.ShowDialog(this) == DialogResult.OK)
                {
					dayView1.BackColor = colorDialog1.Color;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (dayView1.SelectedAppointment != null)
            {
                //colorDialog1.Color = dayView1.SelectedAppointment.BorderColor;

                if (colorDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    //dayView1.SelectedAppointment.BorderColor = colorDialog1.Color;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dayView1.RowHeight = trackBar1.Value;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dayView1.StartDate = monthCalendar1.SelectionStart;
        }
    }
}