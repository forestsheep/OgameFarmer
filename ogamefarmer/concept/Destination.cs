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
    }
}
