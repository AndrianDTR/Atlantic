using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AY.Log;

namespace EAssistant
{
	class UIMessages
	{
		public static DialogResult Error(String message, MessageBoxButtons buttons)
		{
			Logger.Error(message);
			return MessageBox.Show(message, "Error", buttons, MessageBoxIcon.Error);
		}

		public static DialogResult Error(String message)
		{
			return UIMessages.Error(message, MessageBoxButtons.OK);
		}

		public static DialogResult Warning(String message, MessageBoxButtons buttons)
		{
			Logger.Warning(message);
			return MessageBox.Show(message, "Warning", buttons, MessageBoxIcon.Warning);
		}

		public static DialogResult Warning(String message)
		{
			return UIMessages.Warning(message, MessageBoxButtons.OK);
		}

		public static DialogResult Info(String message, MessageBoxButtons buttons)
		{
			Logger.Info(message);
			return MessageBox.Show(message, "Information", buttons, MessageBoxIcon.Information);
		}

		public static DialogResult Info(String message)
		{
			return UIMessages.Info(message, MessageBoxButtons.OK);
		}

		public static DialogResult NotImplementedFeature()
		{
			return UIMessages.Info("This feature is not implemented yet.");
		}
		
		public static DialogResult DisabledFeature()
		{
			return UIMessages.Info("This feature is disabled.");
		}
	}
}
