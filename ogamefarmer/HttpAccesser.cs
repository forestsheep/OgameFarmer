using System;
using System.IO;
using System.Net;
using System.Resources;
using System.Text;
using System.Collections;
using System.Threading;

namespace OgameFarmer
{
    internal class HttpAccesser
    {
        #region static
        internal static Random rtime = new Random();
        #endregion

        #region 构造函数
        internal HttpAccesser()
        {
        }
        #endregion

        #region 枚举
        internal enum ACCESS_METHOD
        {
            GET,
            POST
        }
        #endregion

        #region members
        private ACCESS_METHOD accessMethod;
        private string accessUrl;
        private string contentType;
        private string host;

        internal string Host
        {
            get { return host; }
            set { host = value; }
        }
        private string userAgent;

        internal string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }
        private string accept;

        internal string Accept
        {
            get { return accept; }
            set { accept = value; }
        }
        private string referer;

        internal string Referer
        {
            get { return referer; }
            set { referer = value; }
        }
        private string connection = "";

        public string Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        private CookieContainer cookies = new CookieContainer();

        public CookieContainer Cookies
        {
            get { return cookies; }
            set { cookies = value; }
        }
        
        private string urlParam = string.Empty;
        private string responseDate = string.Empty;
        private string responseText = string.Empty;
        private bool isUseCookie;
        private WebHeaderCollection webHeader = new WebHeaderCollection();
        //private string reqEncoding = "GB2312";
        private string reqEncoding = "utf-8";
        private string resEncoding = "GB2312";

        #endregion

        #region Propertis

        /// <summary>
        /// access method
        /// get or post
        /// default is "GET"
        /// </summary>
        internal ACCESS_METHOD AccessMethod
        {
            get
            {
                return accessMethod;
            }
            set
            {
                accessMethod = value;
            }
        }

        /// <summary>
        /// accessUrl
        /// </summary>
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
        /// urlParmam
        /// </summary>
        internal string UrlParam
        {
            get
            {
                return urlParam;
            }
            set
            {
                urlParam = value;
            }
        }

        /// <summary>
        /// contentType
        /// like:application/x-www-form-urlencoded or text/xml ect.
        /// </summary>
        internal string ContentType
        {
            get
            {
                return contentType;
            }
            set
            {
                contentType = value;
            }
        }
        
        /// <summary>
        /// response date
        /// </summary>
        internal string ResponseDate
        {
            get { return responseDate; }
            set { responseDate = value; }
        }

        /// <summary>
        /// response content
        /// </summary>
        internal string ResponseText
        {
            get
            {
                return responseText;
            }
        }

        /// <summary>
        /// set or get is using cookie
        /// </summary>
        internal bool IsUseCookie
        {
            get
            {
                return isUseCookie;
            }
            set
            {
                isUseCookie = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal string ReqEncoding
        {
            get
            {
                return reqEncoding;
            }
            set
            {
                reqEncoding = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal string ResEncoding
        {
            get
            {
                return resEncoding;
            }
            set
            {
                resEncoding = value;
            }
        }

        internal WebHeaderCollection WebHeader
        {
            get
            {
                return webHeader;
            }
            set
            {
                 webHeader = value;
            }
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
        internal CookieCollection access()
        {
            this.responseText = string.Empty;
            if (accessUrl == null || accessUrl.Trim().Equals(string.Empty))
            {
                throw new UncompleteSettingException("没有设定url");
            }
            //WebRequest r = WebRequest.Create("http://www.163.com");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(accessUrl);
            req.Headers = webHeader;
            //host
            req.Host = host;
            req.UserAgent = userAgent;
            req.Accept = accept;
            req.Referer = referer;
            req.ContentType = contentType;
            //req.
            if (!(connection.Equals("keep-alive") || connection.Equals("close")))
            {
                req.Connection = connection;
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
                IEnumerator i = c.GetEnumerator();
                while (i.MoveNext())
                {
                    Cookie ccc = (Cookie)i.Current;
                }
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
                Thread.Sleep(3000 + r);
                return c;
            }
        }
        #endregion

        #region inner class
        internal class UncompleteSettingException : Exception
        {
            internal UncompleteSettingException(string message)
                : base(message)
            {
            }

            internal UncompleteSettingException()
            {
            }
        }
        #endregion

    }
}