using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class License
    {
        internal static string GenerateLicense(string date)
        {
            string cpuid = HardwareUtil.GetCPUSerialNumber();
            string mac = HardwareUtil.GetMac();
            if (StringUtil.IsEmpty(cpuid) || StringUtil.IsEmpty(mac))
            {
                return null;
            }
            else
            {
                return AES.Encrypt(date, cpuid, mac);
            }
        }

        internal static string DecryptLicense(string license)
        {
            string cpuid = HardwareUtil.GetCPUSerialNumber();
            string mac = HardwareUtil.GetMac();
            if (StringUtil.IsEmpty(cpuid) || StringUtil.IsEmpty(mac))
            {
                return null;
            }
            else
            {
                return AES.Decrypt(license, cpuid, mac);
            }
        }

        internal static bool IsLegitimate(string license)
        {
            string dateString = DecryptLicense(license);
            if (StringUtil.IsEmpty(dateString))
            {
                return false;
            }
            DateTime dt;
            try
            {
                dt = DateTime.Parse(dateString);
            }
            catch (FormatException)
            {
                return false;
            }
            if (dt.CompareTo(DateUtil.GetBeijingTime()) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
