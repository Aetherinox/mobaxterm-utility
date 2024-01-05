/*
    @app        : MobaXterm Keygen
    @repo       : https://github.com/Aetherinox/MobaXtermKeygen
    @author     : Aetherinox
*/

using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace MobaXtermKG
{

    static class Program
    {
        [STAThread]
        static void Main( )
        {
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault(false);

            /*
                 Elevate to admin so we can modify the windows host file.

                 @note      Not needed for the MobaXterm keygen. No need to write to any host file.
            */

            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool administrativeMode = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!administrativeMode)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.Verb = "runas";
                startInfo.FileName = Application.ExecutablePath;
                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                    return;
                }
                return;
            }

            Application.Run(new FormParent());

        }

    }
}
