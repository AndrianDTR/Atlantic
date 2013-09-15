using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class PaymentDetail : Form
	{
		public PaymentDetail(Int64 id)
		{
			InitializeComponent();
			
			Payment p = new Payment(id);
			
			textDate.Text = p.Date.ToString();
			textUser.Text = new User(p.CreatorId).Name;
			textClient.Text = p.ClientId.ToString();
			textComment.Text = p.Comment;
			textSum.Text = p.Sum.ToString();
			textService.Text = new ScheduleRule(p.ScheduleId).Name;
		}
	}
}
