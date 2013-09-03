using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OgameFarmer
{
    class Txtout
    {
        internal static void write(string s, string filename)
        {
            FileStream fs = new FileStream("C:\\Users\\ForestSheep\\Desktop\\devlog\\" + filename, FileMode.Create);
            
            byte[] data = Encoding.GetEncoding("GB2312").GetBytes(s);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }

        internal static void writeA(string s, string filename)
        {
            FileStream fs = new FileStream("C:\\Users\\ForestSheep\\Desktop\\devlog\\" + filename, FileMode.Append);

            byte[] data = Encoding.GetEncoding("GB2312").GetBytes(s);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
    }
}
