using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgameFarmer
{
    interface PageInfo
    {
        void AccessSite(ref HttpAccesser httpAccesser);

        void AnalyzResponse();
    }
}
