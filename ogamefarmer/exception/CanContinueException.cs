using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    class CanContinueException : GalaxyFarmerException
    {
        internal CanContinueException()
        {
        }

        private Exception e;
        internal CanContinueException(Exception e)
        {
            this.e = e;
        }

        public override string ToString()
        {
            return e == null ? base.ToString() : e.ToString() + base.ToString();
        }
    }
}
