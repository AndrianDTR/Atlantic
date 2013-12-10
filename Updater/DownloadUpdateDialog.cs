using System;
using System.ComponentModel;
using System.Net.Cache;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace AY.AutoUpdate
{
    internal partial class DownloadUpdateDialog : Form
    {
        private readonly string _downloadURL;
        private string _tempPath;

        public DownloadUpdateDialog(string downloadURL)
        {
            InitializeComponent();

            _downloadURL = downloadURL;
        }

        private void DownloadUpdateDialogLoad(object sender, EventArgs e)
        {
			WebClient webClient = new WebClient();
			Uri uri = new Uri(_downloadURL);

            _tempPath = string.Format(@"{0}{1}", Path.GetTempPath(), GetFileName(_downloadURL));

            webClient.DownloadProgressChanged += OnDownloadProgressChanged;
            webClient.DownloadFileCompleted += OnDownloadComplete;
            webClient.DownloadFileAsync(uri, _tempPath);
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void OnDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
			ProcessStartInfo processStartInfo = 
				new ProcessStartInfo{FileName = _tempPath, UseShellExecute = true };
				
            Process.Start(processStartInfo);
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        private static string GetFileName(string url)
        {
            String fileName = string.Empty;

			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            httpWebRequest.Method = "HEAD";
            httpWebRequest.AllowAutoRedirect = false;

			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpWebResponse.StatusCode.Equals(HttpStatusCode.Redirect) 
				|| httpWebResponse.StatusCode.Equals(HttpStatusCode.Moved) 
				|| httpWebResponse.StatusCode.Equals(HttpStatusCode.MovedPermanently))
            {
                if (httpWebResponse.Headers["Location"] != null)
                {
                    String location = httpWebResponse.Headers["Location"];
                    fileName = GetFileName(location);
                    return fileName;
                }
            }

            if (httpWebResponse.Headers["content-disposition"] != null)
            {
				String contentDisposition = httpWebResponse.Headers["content-disposition"];
                if (!String.IsNullOrEmpty(contentDisposition))
                {
                    const String lookForFileName = "filename=";
                    int index = contentDisposition.IndexOf(lookForFileName
						, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                        fileName = contentDisposition.Substring(index + lookForFileName.Length);
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Substring(1, fileName.Length - 2);
                    }
                }
            }
            if (string.IsNullOrEmpty(fileName))
            {
                Uri uri = new Uri(url);

                fileName = Path.GetFileName(uri.LocalPath);
            }
            return fileName;
        }
    }
}
