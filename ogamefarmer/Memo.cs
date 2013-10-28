using System;
using System.Collections.Generic;
using System.Text;

namespace GrnLiteAutoLogin
{
    class Memo
    {
        private void memo1()
        {
            //string outputText = string.Empty;
            //if post use this
            //string param = "c=28zd4&_account=bxu&_password=911911f911";
            //byte[] bs = Encoding.GetEncoding("utf-8").GetBytes(param);

            //string url = "https://grn.cybozu.net.cn/cgi-bin/cbgrn/grn.cgi/index?c=28zd4&_account=bxu&_password=911911f911";
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.Method = "GET";

            //req.ContentType = "application/x-www-form-urlencoded";
            //req.CookieContainer = new CookieContainer();

            //if post use this
            //req.ContentLength = bs.Length;
            //using (Stream reqStream = req.GetRequestStream())
            //{
            //    reqStream.Write(bs, 0, bs.Length);
            //}


            //using (WebResponse res = req.GetResponse())
            //{
            //    Stream receiveStream = res.GetResponseStream();
            //    Encoding encode = Encoding.GetEncoding("utf-8");
            //    StreamReader sr = new StreamReader(receiveStream, encode);
            //    char[] readbuffer = new char[256];
            //    int n = sr.Read(readbuffer, 0, 256);
            //    while (n > 0)
            //    {
            //        string str = new string(readbuffer, 0, n);
            //        outputText += str;
            //        n = sr.Read(readbuffer, 0, 256);
            //    }
            //    if (outputText.Contains("<>"))
            //    {
            //    }
            //    outputArea.Text = outputText;
            //}

            //HttpAccesser ha = new HttpAccesser();
            //try
            //{
                // get test
                //ha.AccessUrl = "https://grn.cybozu.net.cn/cgi-bin/cbgrn/grn.cgi/index?c=28zd4&_account=bxu&_password=911911f911";
                //ha.AccessMethod = HttpAccesser.ACCESS_METHOD.GET;
                //ha.ContentType = "application/x-www-form-urlencoded";
                //ha.IsUseCookie = true;
                //ha.access();
                //outputArea.Text = ha.ResponseText;

                // post test
                //ha.AccessUrl = "https://grn.cybozu.net.cn/cgi-bin/cbgrn/grn.cgi/index";
                //ha.UrlParam = "c=28zd4&_account=bxu&_password=911911f911";
                //ha.AccessMethod = HttpAccesser.ACCESS_METHOD.POST;
                //ha.ContentType = "application/x-www-form-urlencoded";
                //ha.IsUseCookie = true;
                //ha.access();
                //outputArea.Text = ha.ResponseText;
            //}
            //catch (HttpAccesser.UncompleteSettingException unse)
            //{
            //}

            // read test
            //AccountReader ar = new AccountReader();
            //try
            //{
            //    checkedListBox_accounts.Items.Clear();
            //    ArrayList AccountList = ar.readAccount();
            //    for (int i = 0; i < AccountList.Count; i++)
            //    {
            //        outputArea.Text += "loginID: " + ((Account)AccountList[i]).LoginID;
            //        outputArea.Text += "   loginPW: " + ((Account)AccountList[i]).LoginPW + "\r\n";
            //        checkedListBox_accounts.Items.Add((Account)AccountList[i]);
            //    }
            //} catch(Exception ee)
            //{
            //    outputArea.Text = ee.ToString();
            //}

        }
    }
}
