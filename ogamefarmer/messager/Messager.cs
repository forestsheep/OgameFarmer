using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    enum TaskRunStatus
    {
        dead,
        start,
        running,
        end
    }
    class Messager
    {
        internal TaskRunStatus Status = TaskRunStatus.dead;
    }
}
