using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Text;

namespace MobaXtermKG
{
    class Serial
    {

        /*
             To generate WinRAR license key, we rely on our command-line tool.
             Utilize MS Powershell to run the generation command and then feed results
             back into the keygen.

             @param : str query
                      command to execute in winrar cli
         */

        public string Generate(String query)
        {
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

                return sb.ToString();
            }
        }
    }
}
