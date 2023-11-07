using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Text;
using System.IO;
using Res = MobaXtermKG.Properties.Resources;
using Cfg = MobaXtermKG.Properties.Settings;
using System.Windows.Forms;


namespace MobaXtermKG
{
    class Serial
    {

        static private string app_cli_exe = Cfg.Default.app_cli_exe;
        static private string app_loc = AppDomain.CurrentDomain.BaseDirectory + "\\" + app_cli_exe;

        /*
             To generate MobaXterm license key, we rely on our command-line tool.
             Utilize MS Powershell to run the generation command and then feed results
             back into the keygen.

             @param : str query
                      command to execute in winrar cli
         */

        public string Generate(String query)
        {

            // Export patched resource file
            File.WriteAllBytes(app_cli_exe, Res.mobaxtgen_cli);

            if (!File.Exists(app_cli_exe))
            {
                MessageBox.Show(
                    string.Format(Res.msgbox_err_libmissing_msg, Environment.NewLine, app_cli_exe, Environment.NewLine, Environment.NewLine),
                    Res.msgbox_err_libmissing_title,
                    MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }

            using (PowerShell ps = PowerShell.Create())
            {
                // Source functions
                ps.AddScript(query);

                // invoke execution on pipeline (collect output)
                Collection<PSObject> PSOutput = ps.Invoke();

                // new string
                StringBuilder sb = new StringBuilder();

                // loop through each output object item
                foreach (PSObject outputItem in PSOutput)
                {
                    // if null object dumped to pipeline during script execution; then a null object may be present here
                    if (outputItem != null)
                    {
                        #if DEBUG
                            MessageBox.Show($"Output line: [{outputItem}]");
                        #endif
                        sb.AppendLine(outputItem.ToString());
                    }
                }

                // error stream
                if (ps.Streams.Error.Count > 0)
                {
                    // Error collection
                }

                // delete file
                if (File.Exists(app_loc))
                    File.Delete(app_loc);

                return sb.ToString();
            }
        }
    }
}
