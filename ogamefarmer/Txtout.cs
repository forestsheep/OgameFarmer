using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OgameFarmer
{
    class Txtout
    {
        internal static void write(String s)
        {
            FileStream fs = new FileStream("C:\\Users\\ForestSheep\\Desktop\\devlog\\1.txt", FileMode.Create);
            //byte[] data = new UTF8Encoding().GetBytes("\r\n-------------------------\r\n");
            //fs.Write(data, 0, data.Length);
            byte[] data = new UTF8Encoding().GetBytes(s);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
    }
}
