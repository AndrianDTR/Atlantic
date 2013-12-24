using System;
using System.Globalization;
using System.Net;
using System.IO;
using System.Net.Cache;
using System.Xml;
using System.Reflection;
using Microsoft.Win32;
using System.ComponentModel;
using System.Threading;

namespace AY.Updater
{
    /// <summary>
    /// Main class that lets you auto update applications by setting some static fields and executing its Start method.
    /// </summary>
    public static class Updater
    {
        internal static String DialogTitle;

        internal static String ChangeLogURL;

        internal static String DownloadURL;

        internal static String AppTitle;

        internal static Version CurrentVersion;

        internal static Version InstalledVersion;

        /// <summary>
        /// URL of the xml file that contains information about latest version of the application.
        /// </summary>
        /// 
        public static String LatestAppVersionXmlUrl;

        /// <summary>
        /// Start checking for new version of application and display dialog to the user if update is available.
        /// </summary>
        public static void CheckNewVersion()
        {
            CheckNewVersion(LatestAppVersionXmlUrl);
        }

        /// <summary>
        /// Start checking for new version of application and display dialog to the user if update is available.
        /// </summary>
        /// <param name="appCast">URL of the xml file that contains information about latest version of the application.</param>
        public static void CheckNewVersion(String latestVersionXmlUrl)
        {
            LatestAppVersionXmlUrl = latestVersionXmlUrl;
            
            var backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += BackgroundWorkerDoWork;

            backgroundWorker.RunWorkerAsync();
        }

        private static void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk");
			Assembly mainAssembly = Assembly.GetEntryAssembly();
			AssemblyCompanyAttribute companyAttribute = 
				(AssemblyCompanyAttribute)GetAttribute(mainAssembly, typeof(AssemblyCompanyAttribute));
				
			AssemblyTitleAttribute titleAttribute = 
				(AssemblyTitleAttribute)GetAttribute(mainAssembly, typeof(AssemblyTitleAttribute));
				
            AppTitle = titleAttribute != null ? titleAttribute.Title : mainAssembly.GetName().Name;
            String appCompany = companyAttribute != null ? companyAttribute.Company : "";

            InstalledVersion = mainAssembly.GetName().Version;

            WebRequest webRequest = WebRequest.Create(LatestAppVersionXmlUrl);
            webRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            WebResponse webResponse;

            try
            {
                webResponse = webRequest.GetResponse();
            }
            catch (Exception)
            {
                return;
            }

            Stream xmlStream = webResponse.GetResponseStream();

            XmlDocument receivedAppVerDocument = new XmlDocument();

            if (xmlStream != null) 
				receivedAppVerDocument.Load(xmlStream);
            else 
				return;

            XmlNodeList appVerItems = receivedAppVerDocument.SelectNodes("item");

            if (appVerItems == null)
				return;
            
            foreach (XmlNode item in appVerItems)
            {
                XmlNode xmlAppVersion = item.SelectSingleNode("version");
                if (xmlAppVersion != null)
                {
                    String appVersion = xmlAppVersion.InnerText;
                    Version version = new Version(appVersion);
                    if (version <= InstalledVersion)
                        continue;
                    CurrentVersion = version;
                }
                else
                    continue;

                XmlNode xmlAppTitle = item.SelectSingleNode("title");
                DialogTitle = xmlAppTitle != null ? xmlAppTitle.InnerText : "";

                XmlNode xmlChangeLogUrl = item.SelectSingleNode("changelogUrl");
                ChangeLogURL = xmlChangeLogUrl != null ? xmlChangeLogUrl.InnerText : "";

                XmlNode xmlDownloadUrl = item.SelectSingleNode("downloadUrl");
                DownloadURL = xmlDownloadUrl != null ? xmlDownloadUrl.InnerText : "";
            }
            
            if (CurrentVersion == null)
                return;

            if (CurrentVersion > InstalledVersion)
            {
                Thread thrd = new Thread(ShowUI);
                thrd.SetApartmentState(ApartmentState.STA);
                thrd.Start();
            }
        }

        private static void ShowUI()
        {
            UpdateForm updateForm = new UpdateForm();
            updateForm.ShowDialog();
        }

        private static Attribute GetAttribute (Assembly assembly,Type attributeType)
        {
            object[] attributes = assembly.GetCustomAttributes(attributeType, false);
            if (attributes.Length == 0)
            {
                return null;
            }

            return (Attribute) attributes[0];
        }
    }
}
