using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GalaxyFarmer
{
    class CommandCenter
    {
        private static Thread T;

        internal static void RUN(Commander cmd)
        {
            if (T == null || ThreadState.Stopped == T.ThreadState)
            {
                T = new Thread(new ThreadStart(cmd.Execute));
                T.Start();
            }
            else
            {
                MessageBox.Show(ConstString.CANNOT_DO_MUTLTI_THINGS);
            }
        }
    }
}
