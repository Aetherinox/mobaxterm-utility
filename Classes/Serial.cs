﻿/*
    @app        : MobaXterm Keygen
    @repo       : https://github.com/Aetherinox/MobaXtermKeygen
    @author     : Aetherinox
*/

#region "Using"

using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Res   = MobaXtermKG.Properties.Resources;
using Cfg   = MobaXtermKG.Properties.Settings;
using System.Diagnostics;

#endregion

namespace MobaXtermKG
{
    class Serial
    {

        #region "Define: Fileinfo"

            /*
                Define > File Name
                    utilized with logging
            */

            readonly static string log_file = "Serial.cs";

        #endregion

        #region "Define: Classes"

            private AppInfo AppInfo     = new AppInfo( );

        #endregion

        #region "Define: Base Paths"

            /*
                Could not find MobaXterm.exe

                patch_launch_fullpath       : Full path to exe
                patch_launch_dir            : Directory only
                patch_launch_exe            : Patcher exe filename only
            */

            static private string patch_launch_fullpath     = Process.GetCurrentProcess( ).MainModule.FileName;
            static private string patch_launch_dir          = Path.GetDirectoryName( patch_launch_fullpath );
            static private string patch_launch_exe          = Path.GetFileName( patch_launch_fullpath );
            static private string app_target_exe            = Cfg.Default.app_mobaxterm_exe;

        #endregion

        #region "Define: Base Paths > CLI"

            /*
                variables > current keygen path / folder
            */

            static private string app_cli_exe               = Cfg.Default.app_cli_exe;
            static private string app_cli_path              = Path.Combine( patch_launch_dir, app_cli_exe );

            static private string cfg_def_version           = Cfg.Default.app_def_version;
            static private string cfg_def_users             = Cfg.Default.app_def_users;

        #endregion

        #region "Method: (str) Generate"

            /*
                 To generate MobaXterm license key, we rely on our command-line tool.
                 Utilize MS Powershell to run the generation command and then feed results
                 back into the keygen.

                 @arg   : str query
                            command to execute in mobaxterm cli
             */

            public string Generate( String query )
            {

                if ( AppInfo.bIsDebug( ) )
                {
                    MessageBox.Show(
                        string.Format( Res.msgbox_debug_callfunc_msg, "Generate" ),
                        string.Format( Res.msgbox_debug_callfunc_title ),
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                    );
                }

                //  Export patched resource file
                File.WriteAllBytes( app_cli_exe, Res.mobaxterm_cli );

                /*
                    CRITICAL ERROR

                        Missing the MobaXterm cli exe. Cannot continue.
                */

                if ( !File.Exists( app_cli_exe ) )
                {
                    MessageBox.Show( string.Format( Res.msgbox_err_misslib_msg, app_cli_exe ),
                        Res.msgbox_err_misslib_title,
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                    );

                    StatusBar.Update( Res.status_misslib_critical_fail );

                    return "Error";
                }

                /*
                    run powershell query for mobaxterm cli exe
                    query   =   "& \"" + mobaxtgen_cli.exe + "\"" + " -s " + Your Name + " " + Version + " " + Users
                                "mobaxtgen_cli.exe -s Aetherx 24.2 4"
                */

                using ( PowerShell ps = PowerShell.Create( ) )
                {
                    ps.AddScript( query );

                    Collection<PSObject> PSOutput = ps.Invoke( );
                    StringBuilder sb = new StringBuilder( );

                    foreach ( PSObject PSItem in PSOutput )
                    {
                        if ( PSItem != null )
                        {
                            if ( AppInfo.bIsDebug( ) )
                            {
                                MessageBox.Show( String.Format( Res.msgbox_debug_ps_output_msg, PSItem ),
                                    Res.msgbox_debug_ps_output_title,
                                    MessageBoxButtons.OK, MessageBoxIcon.None
                                );
                            }

                            sb.AppendLine( PSItem.ToString( ) );
                        }
                    }

                    if ( ps.Streams.Error.Count > 0 )
                    {
                        // Error collection
                    }

                    //  Delete the cli exe as we no longer need it
                    if ( File.Exists( app_cli_path ) )
                        File.Delete( app_cli_path );

                    return sb.ToString();
                }
            }

        #endregion

        #region "Method: (str) Save Key Dialog"

            /*
                Save Key > Dialog
                    Open a save dialog and prompt the user to selection a location for saving the license file.

                @arg    : str name          (required)
                @arg    : str version       (optional)
                @arg    : str users         (optional)
            */

            public string SaveKey_Dialog( String name, String ver = "24.2", String users = "1" )
            {

                if ( AppInfo.bIsDebug( ) )
                {
                    MessageBox.Show(
                        string.Format( Res.msgbox_debug_callfunc_msg, "SaveKey_Dialog" ),
                        string.Format( Res.msgbox_debug_callfunc_title ),
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                    );
                }

                SaveFileDialog dlg      = new SaveFileDialog( );

                dlg.FileName            = "Custom";
                dlg.Title               = "Save License File";
                dlg.CheckPathExists     = true;
                dlg.InitialDirectory    = patch_launch_dir;
                dlg.DefaultExt          = "mxtpro";
                dlg.Filter              = @"MobaXterm License (*.mxtpro)|*.mxtpro|All files (*.*)|*.*";
                DialogResult result     = dlg.ShowDialog( );

                //  Dialog > Cancelled
                if ( result == DialogResult.Cancel )
                {
                    StatusBar.Update( Res.status_diag_cancelled );
                    return "Error";
                }

                //  Dialog > Save
                if ( result == DialogResult.OK )
                {
                    string path_saveto_full         = dlg.FileName;                             // x:\Path\To\Save\Custom.mxtpro
                    string path_saveto_fol          = Path.GetDirectoryName( dlg.FileName );    // x:\Path\To\Save
                    string path_saveto_ext          = Path.GetExtension( dlg.FileName );        // .mxtpro
                    string mxtpro_file              = Cfg.Default.app_def_mxtpro;               // Custom.mxtpro

                    /*
                        Generate new license, assign results to var
                    */

                    string app_cli_result           = this.Generate( "& \"" + app_cli_path + "\"" + " -s " + name + " " + ver + " " + users );

                    /*
                        Move newly generated Custom.mxtpro license file to the location the user selected in the Save Dialog
                    */

                    if ( File.Exists( mxtpro_file ) )
                        File.Move( mxtpro_file, path_saveto_full );

                    //  Delete the cli exe as we no longer need it
                    if ( File.Exists( app_cli_exe ) )
                        File.Delete( app_cli_exe );

                    /* Confirmation */
                    if ( File.Exists( path_saveto_full ) )
                    {

                        StatusBar.Update( Res.status_action_generated );

                        MessageBox.Show(
                            string.Format( Res.msgbox_ok_generate_finished_msg, path_saveto_full ),
                            Res.msgbox_ok_generate_finished_title,
                            MessageBoxButtons.OK, MessageBoxIcon.None
                        );

                        return app_cli_result;
                    }

                    return "Error";

                }

                return "Error";
            }

        #endregion

        #region "Method: (str) Save Key"

            /*
                Save Key > Auto Detected

                @arg    : str path          (required)
                @arg    : str name          (required)
                @arg    : str version       (optional)
                @arg    : str users         (optional)
            */

            public string SaveKey( String path, String name, String ver = "24.2", String users = "1" )
            {

                if ( AppInfo.bIsDebug( ) )
                {
                    MessageBox.Show(
                        string.Format( Res.msgbox_debug_callfunc_msg, "SaveKey" ),
                        string.Format( Res.msgbox_debug_callfunc_title ),
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                    );
                }

                //  Set vars where mxtpro license file will be extracted from activator and determine the name
                //  of the Custom.mxtpro.bak
                string mxtpro_target_to     = path + @"\" + Cfg.Default.app_def_mxtpro;
                string mxtpro_filename      = Cfg.Default.app_def_mxtpro;
                string mxtpro_filename_bak  = path + @"\" + Cfg.Default.app_def_mxtpro + ".bak";

                /*
                    Look for existing custom.mxtpro.bak file
                    Delete old, create new
                */

                if ( File.Exists( mxtpro_target_to ) )
                {

                    /*
                        Delete existing Custom.mxtpro.BAK
                     */

                    if ( File.Exists( mxtpro_filename_bak ) )
                        File.Delete( mxtpro_filename_bak );

                    /*
                        Move new .bak
                            Custom.mxtpro -> Custom.mxtpro.BAK
                     */

                    if ( File.Exists( mxtpro_target_to ) )
                        File.Move( mxtpro_target_to, mxtpro_filename_bak );
                }

                /*
                    Generate new license, assign results to var
                */

                string app_cli_result = this.Generate( "& \"" + app_cli_path + "\"" + " -s " + name + " " + ver + " " + users );

                //  Move new Custom.mxtpro from keygen folder to folder where MobaXterm.exe found
                if ( File.Exists( mxtpro_filename ) )
                    File.Move( mxtpro_filename, mxtpro_target_to );

                //  Delete the cli exe as we no longer need it
                if ( File.Exists( app_cli_exe ) )
                    File.Delete( app_cli_exe );

                //  New license successfully saved
                if ( File.Exists( mxtpro_target_to ) )
                {

                    StatusBar.Update( Res.status_action_generated );

                    MessageBox.Show(
                        string.Format( Res.msgbox_ok_generate_finished_msg, mxtpro_target_to ),
                        Res.msgbox_ok_generate_finished_title,
                        MessageBoxButtons.OK, MessageBoxIcon.None
                    );

                    return app_cli_result;
                }

                return "Error";

            }

        #endregion

    }
}
