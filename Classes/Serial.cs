using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using Lng   = MobaXtermKG.Properties.Resources;
using Cfg   = MobaXtermKG.Properties.Settings;

namespace MobaXtermKG
{
    class Serial
    {

        /*
            variables > current keygen path / folder
        */

        static private string app_base_path         = AppDomain.CurrentDomain.BaseDirectory;

        static private string app_cli_exe           = Cfg.Default.app_cli_exe;
        static private string app_cli_path          = app_base_path + "\\" + app_cli_exe;

        /*
             To generate MobaXterm license key, we rely on our command-line tool.
             Utilize MS Powershell to run the generation command and then feed results
             back into the keygen.

             @param : str query
                      command to execute in winrar cli
         */

        public string Generate( String query )
        {

            // Export patched resource file
            File.WriteAllBytes( app_cli_exe, Lng.mobaxtgen_cli );

            if (!File.Exists( app_cli_exe ) )
            {
                MessageBox.Show(
                    string.Format( Lng.msgbox_err_libmissing_msg, Environment.NewLine, app_cli_exe, Environment.NewLine, Environment.NewLine),
                    Lng.msgbox_err_libmissing_title,
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }

            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript(query);

                Collection<PSObject> PSOutput = ps.Invoke();
                StringBuilder sb = new StringBuilder();

                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {
                        #if DEBUG
                            MessageBox.Show($"Output line: [{outputItem}]");
                        #endif
                        sb.AppendLine(outputItem.ToString());
                    }
                }

                if (ps.Streams.Error.Count > 0)
                {
                    // Error collection
                }

                if (File.Exists( app_cli_path ))
                    File.Delete( app_cli_path );

                return sb.ToString();
            }
        }

        public string SaveKeyfile( String name, String ver, String users )
        {

            /*
                Give the user one last chance to manually define where the program executable is at.
                If this doesnt work, something has gone wrong or the program is not installed at all.
            */

            SaveFileDialog dlg      = new SaveFileDialog( );

            dlg.FileName            = "Custom";
            dlg.Title               = "Save License File";
            dlg.CheckPathExists     = true;
            dlg.InitialDirectory    = app_base_path;
            dlg.DefaultExt          = "mxtpro";
            dlg.Filter              = @"MobaXterm License (*.mxtpro)|*.mxtpro|All files (*.*)|*.*";
            DialogResult result     = dlg.ShowDialog( );

            //  Dialog > Cancelled
            if ( result == DialogResult.Cancel )
            {
                StatusBar.Update( Lng.status_diag_cancelled );
                return "Error";
            }

            //  Dialog > Save
            if ( result == DialogResult.OK )
            {
                string path_saveto_full         = dlg.FileName;                             // x:\Path\To\Save\Custom.mxtpro
                string path_saveto_fol          = Path.GetDirectoryName( dlg.FileName );    // x:\Path\To\Save
                string path_saveto_ext          = Path.GetExtension( dlg.FileName );        // .mxtpro
                string mxtpro_file              = Cfg.Default.app_def_mxtpro;               // Custom.mxtpro

                string app_cli_result           = this.Generate("& \"" + app_cli_path + "\"" + " -s " + name + " " + ver + " " + users );

                /*   Move new Custom.mxtpro from keygen folder to C:\Program Files (x86)\Mobatek\MobaXterm */
                if ( File.Exists( mxtpro_file ) )
                    File.Move( mxtpro_file, path_saveto_full );

                /*  Delete the cli exe as we no longer need it */
                if ( File.Exists( app_cli_exe ) )
                    File.Delete( app_cli_exe );

                /* Confirmation */
                if ( File.Exists( path_saveto_full ) )
                {
                    MessageBox.Show(
                        string.Format( Lng.msgbox_ok_generate_finished_msg, Environment.NewLine, Environment.NewLine, path_saveto_full ),
                        Lng.msgbox_ok_generate_finished_title,
                        MessageBoxButtons.OK, MessageBoxIcon.None
                    );

                    return app_cli_result;
                }

                return "Error";

            }

            return "Error";
        }
    }
}
