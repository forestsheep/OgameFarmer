using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class BallProductivity : Ball
    {
        internal int MetalHour;
        internal int Metal;
        internal int MetalStore;

        internal int CrystalHour;
        internal int Crystal;
        internal int CrystalStore;

        internal int HHHour;
        internal int HH;
        internal int HHStore;

        internal int Energy;
        internal int EnergyStroe;

        internal BallProductivity(Ball ball)
        {
            ball.Location = this.Location;
            ball.Name = this.Name;
            ball.Prama = this.Prama;
            ball.Type = this.Type;
        }
    }

}
