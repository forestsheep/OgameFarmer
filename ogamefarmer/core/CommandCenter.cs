using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OgameFarmer
{
    class CommandCenter
    {
        private static Thread T;

        internal void run(Commander cmd)
        {
            if (T == null || ThreadState.Stopped == T.ThreadState)
            {
                T = new Thread(new ThreadStart(cmd.Execute));
                T.Start(cmd);
            }
            else
            {
                MessageBox.Show(ConstString.CANNOT_DO_MUTLTI_THINGS);
            }
        }

    }
}
