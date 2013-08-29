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
            
            byte[] data = Encoding.GetEncoding("GB2312").GetBytes(s);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
    }
}
