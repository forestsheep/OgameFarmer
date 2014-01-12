using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GalaxyFarmer
{
    class ConvertUtil
    {
        internal static Coordinate String2Coordinate(string coor)
        {
            string[] gsp = coor.Split(new char[] { ':' });
            try {
                int galaxy = int.Parse(gsp[0]);
                int system = int.Parse(gsp[1]);
                int planet = int.Parse(gsp[2]);
                return new Coordinate(galaxy, system, planet);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
    }
}
