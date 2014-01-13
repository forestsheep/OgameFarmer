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

        internal static void RUN(Commander cmd, Form f)
        {
            if (T == null || ThreadState.Stopped == T.ThreadState)
            {
                T = new Thread(new ThreadStart(cmd.Execute));

                T = new Thread((ThreadStart)delegate
                {
                    try
                    {
                        cmd.Execute();  
                    }
                    catch (CannotContinueException e)
                    {
                        LoggerUtil.Logger.Error(e.ToString());
                        f.BeginInvoke((Action)delegate
                        {
                            if (typeof(LoginForm) == f.GetType())
                            {
                                ((LoginForm)f).b_login.Enabled = true;
                            }
                            else
                            {
                                f.Dispose();
                                Profile.LOGIN_FORM.Show();
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        f.BeginInvoke((Action)delegate
                        {
                            MessageBox.Show(e.ToString());
                        });
                    }
                });

                T.Start();
            }
            else
            {
                MessageBox.Show(ConstString.CANNOT_DO_MUTLTI_THINGS);
            }
        }
    }
}
