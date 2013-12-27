using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class Coordinate
    {
        private int galaxy;
        private int system;
        private int solarPosition;

        internal Coordinate(int galaxy, int system, int solarPosition)
        {
            this.galaxy = galaxy;
            this.system = system;
            this.solarPosition = solarPosition;
        }

        public override string ToString()
        {
            return galaxy.ToString() + ":" + system.ToString() + ":" + solarPosition.ToString();
        }

        public string[] ToStringArray()
        {
            string[] returnString = new string[3];
			returnString[0] = "galaxy=" + galaxy.ToString();
			returnString[1] = "system=" + system.ToString();
			returnString[2] = "planet=" + solarPosition.ToString();
            return returnString;
        }
    }
}
