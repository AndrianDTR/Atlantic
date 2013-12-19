using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using AY.Utils;
using AY.Log;

namespace EAssistant
{
	partial class About : Form
	{
		public About()
		{
			Logger.Enter();
			
			InitializeComponent();
			this.Text = String.Format("About {0}", AssemblyTitle);
			this.labelName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
			this.labelCopy.Text = AssemblyCopyright;
			this.textRegInfo.Text = AppReginfo;

			Logger.Leave();
		}

		public string AssemblyTitle
		{
			get
			{
				Logger.Enter();
				string title = "";
				do
				{
					object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
					if (attributes.Length > 0)
					{
						AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
						if (titleAttribute.Title != "")
						{
							title = titleAttribute.Title;
							break;
						}
					}
					title = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
				}while(false);
				Logger.Leave();
				
				return title;
			}
		}

		public string AssemblyVersion
		{
			get
			{
				Logger.Enter();
				String ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
				Logger.Leave();

				return ver;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				Logger.Enter();
				String product = "";
				do 
				{
					object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
					if (attributes.Length == 0)
					{
						break;
					}
					product = ((AssemblyProductAttribute)attributes[0]).Product;
				} while (false);
				Logger.Leave();
				return product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				Logger.Enter();
				String copy = "";
				do
				{
					object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
					if (attributes.Length == 0)
					{
						break;
					}
					copy = ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
				} while (false);
				Logger.Leave();
				return copy;
			}
		}

		public String AppReginfo
		{
			get
			{
				Logger.Enter();
				String info = "This copy of application is not registered.";
				do
				{
					byte[] data = RegUtils.Instance.SavedData;
					if (null != data)
					{
						try
						{
							info = RegUtils.Instance.RegInfo.Replace("\r", "").Replace("\n", "\r\n");
						}
						catch (System.Exception)
						{
						}
					}
				} while (false);
				Logger.Leave();
				return info;
			}
		}
	}
}
