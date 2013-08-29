using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using AY.Utils;

namespace GAssistant
{
	partial class About : Form
	{
		public About()
		{
			InitializeComponent();
			this.Text = String.Format("About {0}", AssemblyTitle);
			this.labelName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
			this.labelCopy.Text = AssemblyCopyright;
			this.textRegInfo.Text = AppReginfo;
		}

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public String AppReginfo
		{
			get
			{
				String info = "This copy of application is not registered.";
				byte[] data = RegUtils.RegData;
				if (null != data)
				{
					info = RegUtils.GetRegInfo(data).Replace("\r", "").Replace("\n", "\r\n");
				}
				
				return info;
			}
		}
		#endregion

	}
}
