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
                T = new Thread((ThreadStart)delegate
                {
                    try
                    {
                        cmd.Execute();
                    }
                    catch (CanContinueException e)
                    {
                        LoggerUtil.Logger.Warn(e.ToString());
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
                                ProgramStatic.LOGIN_FORM.b_login.Enabled = true;
                                ProgramStatic.LOGIN_FORM.Show();
                                //T.Abort();
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        LoggerUtil.Logger.Error(e.ToString());
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
