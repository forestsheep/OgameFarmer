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
            FileStream fs = new FileStream(filename, FileMode.Create);
            
            byte[] data = Encoding.GetEncoding("GB2312").GetBytes(s);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }

        internal static void writeA(string s, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Append);

            byte[] data = Encoding.GetEncoding("GB2312").GetBytes(s);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }

        internal static string Read()
        {
            try 
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("html.txt")) 
                {
                    string returnString;
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null) 
                    {
                        returnString += line;
                    }
                }
                return returnString;
            }
            catch (Exception e) 
            {
                return null;
            }
    }
}
