using System;
using System.Windows.Forms;
using AY.Log;
using AY.db;

namespace EAssistant
{
	public partial class ChangePassword : Form
	{
		private dbDataSet.usersRow m_user = null;

		public ChangePassword()
		{
			Logger.Enter();
			InitializeComponent();
			m_user = Db.Instance.dSet.users.FindByid(Session.Instance.UserId);
			Logger.Leave();
		}

		public ChangePassword(Int64 userId)
		{
			Logger.Enter();
			InitializeComponent();
			m_user = Db.Instance.dSet.users.FindByid(userId);
			Logger.Leave();
		}

		private void change_Click(object sender, EventArgs e)
		{
			Logger.Enter();
			do
			{
				if (password.Text != confirm.Text)
				{
					message.Text = Session.GetResStr("CP_INVALID_CONFIRMATION");
					break;
				}

				if (current.Text == password.Text)
				{
					message.Text = Session.GetResStr("CP_OLD_IS_SAME");
					break;
				}

				if (password.Text.Length < Session.Instance.PassLen)
				{
					message.Text = String.Format(Session.GetResStr("CP_PASSW_IS_TO_SHORT")
						, Session.Instance.PassLen );
					break;
				}

				if (!m_user.ChangePassword(current.Text, password.Text))
				{
					message.Text = Session.GetResStr("CP_CHANGE_ERROR");
					break;
				}

				MessageBox.Show(Session.GetResStr("CP_CHANGE_OK"));
				this.DialogResult = DialogResult.OK;
				this.Close();
			} while (false);
			Logger.Leave();
		}
	}
}
