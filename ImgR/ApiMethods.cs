using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ImgR
{
    internal class Api
    {
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
                cert.Subject,
                error.ToString());

            return false;
        }

        public static string Get(string url, Dictionary<string, string> headers = null, NetworkCredential credentials = null)
        {
            WebClient client = new WebClient();
            if ((headers != null))
            {
                foreach (var h_loopVariable in headers)
                {
                    var h = h_loopVariable;
                    client.Headers.Add(h.Key, h.Value);
                }
            }
            if (credentials != null)
            {
                client.Credentials = credentials;
                client.Headers.Add("Authorization", "Basic " +
                    Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(credentials.UserName + ":" +
                    credentials.Password)));
            }
            client.BaseAddress = url;
            Stream stream = new MemoryStream();
            stream = client.OpenRead(url);
            string b = "";
            using (System.IO.StreamReader br = new System.IO.StreamReader(stream, Encoding.UTF8))
            {
                try
                {
                    b = br.ReadToEnd();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return b;
        }

        public static T Get<T>(string url, Dictionary<string, string> headers = null, NetworkCredential credentials = null)
        {
            string response = Get(url, headers, credentials);
            T ret = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            return ret;
        }

        public static Promise<string> GetAsync(string url, Dictionary<string, string> headers = null, NetworkCredential credentials = null)
        {
            return new Promise<string>(() => Get(url, headers, credentials));
        }

        public static Promise<T> GetAsync<T>(string url, Dictionary<string, string> headers = null, NetworkCredential credentials = null)
        {
            return Promise<T>.Create(() =>
            {
                return Get<T>(url, headers, credentials);
            });
        }

        public static Bitmap GetImage(string url)
        {
            WebClient client = new WebClient();
            client.BaseAddress = url;

            try
            {
                byte[] b = client.DownloadData(url);
                return b.ToBitmap();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Promise<Bitmap> GetImageAsync(string url)
        {
            return new Promise<Bitmap>(() => GetImage(url));
        }

        public static string Post(string url, string value, string contenttype = "text/xml",
            Dictionary<string, string> headers = null, bool useSsl = false, NetworkCredential credentials = null)
        {
            if (useSsl)
            {
                ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }
            WebClient w = new WebClient();
            if ((headers != null))
            {
                foreach (var h_loopVariable in headers)
                {
                    var h = h_loopVariable;
                    w.Headers.Add(h.Key, h.Value);
                }
            }
            if (credentials != null)
            {
                w.Credentials = credentials;
                w.Headers.Add("Authorization", "Basic " +
                    Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(credentials.UserName + ":" +
                    credentials.Password)));
            }
            w.Headers.Add("Content-Type", contenttype);
            w.Headers.Add("Accept", "text/plain, " + contenttype);
            return w.UploadString(url, value);
        }

        public static T Post<T>(string url, string value, string contenttype = "text/xml", Dictionary<string, string> headers = null, bool useSsl = false, NetworkCredential credentials = null)
        {
            string response = Post(url, value, contenttype, headers, useSsl, credentials);
            T ret = default(T);
            if (contenttype == "text/xml")
            {
                ret = System.Xml.Linq.XElement.Parse(response).ToObject<T>();
            }
            else
            {
                ret = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            }

            return ret;
        }

        public static Promise<string> PostAsync(string url, string value, string contenttype = "text/xml", Dictionary<string, string> headers = null, bool useSsl = false, NetworkCredential credentials = null)
        {
            return new Promise<string>(() => Post(url, value, contenttype, headers, useSsl, credentials));
        }

        public static Promise<T> PostAsync<T>(string url, string value, string contenttype = "text/xml", Dictionary<string, string> headers = null, bool useSsl = false, NetworkCredential credentials = null)
        {
            return new Promise<T>(() => Post<T>(url, value, contenttype, headers, useSsl, credentials));
        }

        private static void browserWait(WebBrowser browser)
        {
            bool completed = false;
            ((WebBrowser)browser).DocumentCompleted += (sender, e) => completed = true;

            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            while (!completed) ;
        }

        /// <summary>
        /// This returns a promise whose return type is a Web Browser. Use the browser as you wish.
        /// browser.DocumentCompleted delegate might help you here.
        /// browser.DocumentText will give you the executed html text
        /// </summary>
        /// <param name="path"></param>
        /// <param name="browserwidth"></param>
        /// <param name="browserheight"></param>
        /// <returns>A Promise to return a WebBrowser object</returns>
        public static Promise<WebBrowser> Execute(string path, BrowserType type = BrowserType.WebBrowser, int browserwidth = 1024, int browserheight = 768)
        {
            return Promise<WebBrowser>.Create(() =>
            {
                WebBrowser browser;
                browser = new WebBrowser();
                browser.ScrollBarsEnabled = false;
                browser.AllowNavigation = true;
                browser.Width = browserwidth;
                browser.Height = browserheight;
                browser.ScriptErrorsSuppressed = true;
                browser.Url = new Uri(path);
                browser.DocumentText = Api.Get(path);
                browserWait(browser);
                return browser;
            });
        }

        public enum BrowserType
        {
            WebBrowser,
            MobileWebBrowser
        }

        public static List<string> GetGoogleImages(string query)
        {
            string path = "https://www.google.com.ng/search?q=" + query + "&tbm=isch";
            List<string> ret = new List<string>();
            string regtext = "src=\"(.+?)\"";
            Regex regex = new Regex(regtext);
            Execute(path).Success((browser) =>
            {
                string doctext = ((WebBrowser)browser).DocumentText;
                if (!string.IsNullOrEmpty(doctext))
                {
                    MatchCollection matches = regex.Matches(doctext);
                    for (int i = 0; i <= Math.Min(matches.Count - 1, 30); i++)
                    {
                        Match match = matches[i];
                        ret.Add(match.Value.Replace("src=", "").Replace("\"", "").Split(new string[] { "&amp" }, StringSplitOptions.None)[0]);
                    }
                }
            }).current.Join();
            return ret;
        }
    }
}
