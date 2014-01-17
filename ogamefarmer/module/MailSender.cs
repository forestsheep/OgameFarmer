using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.Mail;
using System.Text;

namespace GalaxyFarmer
{
    class MailSender
    {
        private void mail()
        {
            string mac = string.Empty;
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            Console.WriteLine(mac);

            MailMessage message = new MailMessage();
            message.To.Add("galaxyfarmer@163.com");
            message.Subject = "galaxyfarmer test";
            message.From = new MailAddress("galaxyfarmer@163.com");
            //message.Body = "mac:" + mac;
            SmtpClient client = new SmtpClient("smtp.163.com");
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("galaxyfarmer@163.com", "911911f911");
            client.EnableSsl = true;
            try
            {
                client.Send(message);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }
        public MailSender(string from, string smtpServer, string mailusername, string pw)
        {
            this.From = from;
            this.setSmtpClient(smtpServer);
            this.smtpClient.UseDefaultCredentials = true;
            this.smtpClient.Credentials = new System.Net.NetworkCredential(mailusername, pw);
            this.smtpClient.EnableSsl = true;
        }

        private MailAddress from;
        public string From
        {
            get
            {
                return from.ToString();
            }
            set
            {
                from = new MailAddress(value);
            }
        }

        private SmtpClient smtpClient;
        public void setSmtpClient(string smtpServer)
        {
            this.smtpClient = new SmtpClient(smtpServer);
        }

        public void Mailto(string[] tos, string[] ccs, string[] bccs, string subject, string body)
        {
            MailMessage message = new MailMessage();
            try
            {
                if (tos != null && tos.Length > 0)
                {
                    foreach (string to in tos)
                    {
                        if (to != null)
                            message.To.Add(to);
                    }
                }
                if (ccs != null && ccs.Length > 0)
                {
                    foreach (string cc in ccs)
                    {
                        if (cc != null)
                        message.CC.Add(cc);
                    }
                }
                if (bccs != null && bccs.Length > 0)
                {
                    foreach (string bcc in bccs)
                    {
                        if (bcc != null)
                        message.Bcc.Add(bcc);
                    }
                }
                message.Subject = subject;
                message.Body = body;
                message.From = from;
                this.smtpClient.Send(message);
            }
            catch (Exception e)
            {
                LoggerUtil.Logger.Error(e.ToString());
            }
        }

        public void Mailto(string to, string subject, string body)
        {
            string[] tos = new string[1];
            tos[0] = to;
            Mailto(tos, null, null, subject, body);
        }
    }
}
