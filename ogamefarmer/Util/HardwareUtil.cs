using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace GalaxyFarmer
{
    class HardwareUtil
    {
        public static string GetCPUSerialNumber()
        {
            string cpuSerialNumber = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuSerialNumber = mo["ProcessorId"].ToString();
                break;
            }
            mc.Dispose();
            moc.Dispose();
            return cpuSerialNumber;
        }

        public static string GetMac()
        {
            string mac = string.Empty;
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            return mac;
        }
    }
}
