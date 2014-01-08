using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.Mail;
using System.Text;

namespace OgameFarmer.module
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

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
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
    }
}
