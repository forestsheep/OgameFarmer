using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    class ConstructionInfo : CommonInfo
    {
        private MetalMine metalMine;

        internal MetalMine MetalMine
        {
            get { return metalMine; }
            set { metalMine = value; }
        }

    }

    class MetalMine
    {
        internal int level = 0;
        internal int nextMetal = 0;
        internal int nextCystal = 0;
        internal bool canbuild = false;
    }
    
}
