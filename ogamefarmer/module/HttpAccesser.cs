using System;
using System.IO;
using System.Net;
using System.Resources;
using System.Text;
using System.Collections;
using System.Threading;

namespace GalaxyFarmer
{
    /// <summary>
    /// 单例模式
    /// </summary>
    internal class HttpAccesser
    {
        #region static
        internal static Random rtime = new Random();
        private static HttpAccesser ha;
        internal static HttpAccesser GetInstance()
        {
            if (ha == null)
            {
                return ha = new HttpAccesser();
            }
            else
            {
                return ha;
            }
        }
        #endregion

        #region 构造函数
        private HttpAccesser()
        {
        }
        #endregion

        #region 枚举
        private ACCESS_METHOD accessMethod;
        internal enum ACCESS_METHOD
        {
            GET,
            POST
        }
        #endregion

        #region Propertis

        /// <summary>
        /// accessUrl
        /// </summary>
        private string accessUrl;
        internal string AccessUrl
        {
            get
            {
                return accessUrl;
            }
            set
            {
                accessUrl = value;
            }
        }

        /// <summary>
        /// contentType
        /// like:application/x-www-form-urlencoded or text/xml ect.
        /// </summary>
        private string contentType;
        internal string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        /// <summary>
        /// host
        /// </summary>
        private string host;
        internal string Host
        {
            get { return host; }
            set { host = value; }
        }

        /// <summary>
        /// userAgent
        /// </summary>
        private string userAgent;
        internal string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }

        /// <summary>
        /// accept
        /// </summary>
        private string accept;
        internal string Accept
        {
            get { return accept; }
            set { accept = value; }
        }

        /// <summary>
        /// referer
        /// </summary>
        private string referer;
        internal string Referer
        {
            get { return referer; }
            set { referer = value; }
        }

        /// <summary>
        /// connection
        /// </summary>
        private string connection = "";
        public string Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        /// <summary>
        /// cookies
        /// </summary>
        private CookieContainer cookies = new CookieContainer();
        public CookieContainer Cookies
        {
            get { return cookies; }
            set { cookies = value; }
        }

        /// <summary>
        /// urlParam
        /// </summary>
        private string urlParam = string.Empty;
        internal string UrlParam
        {
            get { return urlParam; }
            set { urlParam = value; }
        }

        /// <summary>
        /// response date
        /// </summary>
        private string responseDate = string.Empty;
        internal string ResponseDate
        {
            get { return responseDate; }
            set { responseDate = value; }
        }

        /// <summary>
        /// response content
        /// </summary>
        private string responseText = string.Empty;
        internal string ResponseText
        {
            get { return responseText; }
        }

        /// <summary>
        /// set or get is using cookie
        /// </summary>
        private bool isUseCookie;
        internal bool IsUseCookie
        {
            get { return isUseCookie; }
            set { isUseCookie = value; }
        }

        /// <summary>
        /// webHeader
        /// </summary>
        private WebHeaderCollection webHeader = new WebHeaderCollection();
        internal WebHeaderCollection WebHeader
        {
            get { return webHeader; }
            set { webHeader = value; }
        }

        /// <summary>
        /// access method
        /// get or post
        /// default is "GET"
        /// </summary>
        internal ACCESS_METHOD AccessMethod
        {
            get { return accessMethod; }
            set { accessMethod = value; }
        }

        /// <summary>
        /// ReqEncoding
        /// </summary>
        private string reqEncoding = "utf-8";
        internal string ReqEncoding
        {
            get { return reqEncoding; }
            set { reqEncoding = value; }
        }

        /// <summary>
        /// ResEncoding
        /// </summary>
        private string resEncoding = "GB2312";
        internal string ResEncoding
        {
            get { return resEncoding; }
            set { resEncoding = value; }
        }

        #endregion

        #region Method

        internal void AddHeader(string name, string value)
        {
            webHeader.Add(name, value);
        }

        internal void AddCookie(string name, string value, string path, string domain, string expires)
        {
            Cookie c = new Cookie(name, value);
            c.Domain = domain;
            c.Path = path;
            if (expires != null && !string.Empty.Equals(expires))
            {
                c.Expires = DateTime.Parse(expires);
            }
            cookies.Add(c);
        }

        private void prepareSomething()
        {

        }

        /// <summary>
        /// 去访问网站
        /// </summary>
        internal void Access()
        {
            this.responseText = string.Empty;
            if (accessUrl == null || accessUrl.Trim().Equals(string.Empty))
            {
                throw new UncompleteSettingException();
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(accessUrl);
            req.Headers = webHeader;
            //host
            req.Host = this.host;
            req.UserAgent = this.userAgent;
            req.Accept = this.accept;
            req.Referer = this.referer;
            req.ContentType = this.contentType;
            //req.
            if (!(this.connection.Equals("keep-alive") || this.connection.Equals("close")))
            {
                req.Connection = this.connection;
            }
            if (isUseCookie)
            {
                req.CookieContainer = this.cookies;
            }

            if (accessMethod == ACCESS_METHOD.GET)
            {
                req.Method = "GET";
            }
            else if (accessMethod == ACCESS_METHOD.POST)
            {
                //if (req.ContentType == null || req.ContentType.Equals(string.Empty))
                //{
                //    throw new UncompleteSettingException("没有设定CONTENT_TYPE");
                //}
                req.Method = "POST";
                byte[] bs = Encoding.GetEncoding(reqEncoding).GetBytes(urlParam);
                req.ContentLength = bs.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                }
            }
            using (WebResponse res = req.GetResponse())
            {
                this.responseDate = res.Headers.GetValues("Date")[0];
                CookieCollection c = ((HttpWebResponse)res).Cookies;
                this.referer = this.accessUrl;
                this.cookies.Add(c);
                Stream receiveStream = res.GetResponseStream();
                Encoding encode = Encoding.GetEncoding(resEncoding);
                StreamReader sr = new StreamReader(receiveStream, encode);
                char[] readbuffer = new char[256];
                int n = sr.Read(readbuffer, 0, 256);
                while (n > 0)
                {
                    string str = new string(readbuffer, 0, n);
                    responseText += str;
                    n = sr.Read(readbuffer, 0, 256);
                }
                sr.Close();
                Txtout.write(responseText, "html.txt");
                int r = rtime.Next(1000);
                Thread.Sleep(2000 + r);
            }
        }
        #endregion

    }
}