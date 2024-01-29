/*
    @app        : MobaXterm Keygen
    @repo       : https://github.com/Aetherinox/MobaXtermKeygen
    @author     : Aetherinox
*/

#region "Using"

using MobaXtermKG;
using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Res = MobaXtermKG.Properties.Resources;
using Cfg = MobaXtermKG.Properties.Settings;

#endregion

namespace MobaXtermKG
{

    /*
        Global Settings

        app_bDevmode        : bool
        Determines if debug mode is enabled

        bShowedUpdates      : bool
        This determines if the app should show the update notification. This value must be set otherwise,
        every time the user goes from the About / Contribute WinForm back to Parent, the update notification will appear over and over.
    */

    public static class Settings
    {
        public static bool bShowedUpdates = false;
        public static bool app_bDevmode = false;
    }

    /*
        Main Program
    */

    public sealed class Program
    {

        #region "Define: Fileinfo"

            /*
                Define > File Name
                    utilized with logging
            */

            readonly static string log_file = "Program.cs";

        #endregion

        #region "Define: Classes"

            private AppInfo AppInfo             = new AppInfo( );

        #endregion

        #region "Define: Misc"

            readonly static Action<string> wl   = Console.WriteLine;

        #endregion

        #region "Method: Main"

            [STAThread]
            static void Main( string[] args )
            {
                Application.EnableVisualStyles( );
                Application.SetCompatibleTextRenderingDefault( false );

                /*
                    The program needs to run as admin (Further below). As soon as the program runs as admin,
                    all arguments and user settings will be gone since it's no longer the same user running the program.

                    Utilize stringbuilder below to loop through the original arguments and set them up to be passed
                    to the process below.

                    arguments will be formatted into a single string space separated

                    --arg1 --arg2 --arg3
                */

                string args_runAs       = "";
                StringBuilder sb        = new StringBuilder( );

                foreach ( string file in args )
                {
                    sb.Append( file + " " );
                    args_runAs = sb.ToString( );
                }

                /*
                     Elevate to admin so we can modify the windows host file.
                */

                if ( !IsAdmin( ) )
                {
                    ProcessStartInfo ProcAdmin  = new ProcessStartInfo( );
                    ProcAdmin.UseShellExecute   = true;
                    ProcAdmin.Verb              = "runas";
                    ProcAdmin.FileName          = Application.ExecutablePath;
                    ProcAdmin.Arguments         = args_runAs;

                    try
                    {
                        Process.Start( ProcAdmin );
                    }
                    catch
                    {
                        MessageBox.Show
                        (
                            new Form( ) { TopMost = true, TopLevel = true, StartPosition = FormStartPosition.CenterScreen },
                            Res.msgbox_core_runas_msg,
                            Res.msgbox_core_runas_title,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );

                        return;
                    }

                    return;
                }

                /*
                     ensure debug mode is turned off by default as we don't want presistence
                */

                Settings.app_bDevmode = false;
                Cfg.Default.Save( ) ;

                /*
                     utilize arguments

                        args start at index args[ 0 ]
                        args.Length will return the number of args provided
                */

                if ( args.Length > 0 && args[ 0 ] == Cfg.Default.app_argid_debug )
                {
                    Settings.app_bDevmode = true;
                    EnableDebugConsole( );

                    Log.Send( log_file, new System.Diagnostics.StackTrace( true ).GetFrame( 0 ).GetFileLineNumber( ), "[ App.Debug ]", String.Format( "User defined {0} argument", Cfg.Default.app_argid_debug ) );
                }

                /*
                     launch app with FormParent
                */

                Application.Run( new FormParent( ) );

            }

        #endregion

        #region "Method: (void) Debug Enable"

            /*
                Debug Console > Enable

                @arg        : void
                @ret        : void
            */

            public static void EnableDebugConsole( )
            {
                string log_filename     = Log.GetStorageFile( );
                Log.Initialize cf       = new Log.Initialize( log_filename, Console.Out );
                Console.SetOut( cf );

                Log.Send( log_file, new System.Diagnostics.StackTrace( true ).GetFrame( 0 ).GetFileLineNumber( ), "[ App.Debug ]", String.Format( "Enter Debug Mode" ) );
            }

        #endregion

        #region "Method: (void) Debug Disable"

            /*
                Console > Disable
                    we dont really need the cole for any other reason; just null it.
                    better ways to do this, but  enough time has been spent on this.

                @arg        : void
                @ret        : void
            */

            public static void DisableDebugConsole( )
            {
                Log.Send( log_file, new System.Diagnostics.StackTrace( true ).GetFrame( 0 ).GetFileLineNumber( ), "[ App.Debug ]", String.Format( "Exit Debug Mode" ) );
                Console.SetOut( new Log.Initialize.SetNull( ) ) ;
            }

        #endregion

        #region "Method: (bool) Is Admin"

            /*
                Check running as admin

                @arg        : void
                @ret        : bool
            */

            private static bool IsAdmin( )
            {
                WindowsIdentity id          = WindowsIdentity.GetCurrent( );
                WindowsPrincipal principal  = new WindowsPrincipal( id );

                return principal.IsInRole( WindowsBuiltInRole.Administrator );
            }

        #endregion

    }
}
