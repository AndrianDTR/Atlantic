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
			Logger.Enter();
			InitializeComponent();

			dbDataSet.paymentsRow pr = Db.Instance.dSet.payments.FindByid(id);

			textDate.Text = pr.date.ToString();
			textUser.Text = (Db.Instance.dSet.users.FindByid(pr.creatorId)).name;
			textClient.Text = BarcodePrinter.GetCode(pr.clientId);
			textComment.Text = pr.comment;
			textSum.Text = pr.sum.ToString();
			textCount.Text = pr.count.ToString();
			textService.Text = (Db.Instance.dSet.scheduleRules.FindByid(pr.serviceId)).name;
			Logger.Leave();
		}
	}
}
