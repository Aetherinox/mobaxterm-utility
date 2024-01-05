using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using MobaXtermKG.Forms;
using Lng = MobaXtermKG.Properties.Resources;
using Cfg = MobaXtermKG.Properties.Settings;

namespace MobaXtermKG
{

    public partial class FormParent : Form, IReceiver
    {

        #region "Declarations"

            /*
                Define > Classes
            */

            private Helpers Helpers         = new Helpers();
            readonly private Serial Serial  = new Serial();

            /*
                Define > Internal > Helper
            */

            internal Helpers Helper
            {
                set     { Helpers = value;  }
                get     { return Helpers;   }
            }

            /*
                Define > Mouse
            */

            private bool mouseDown;
            private Point lastLocation;

            /*
                variables > current keygen path / folder
            */

            static private string app_base_path         = AppDomain.CurrentDomain.BaseDirectory;

            static private string app_cli_exe           = Cfg.Default.app_cli_exe;
            static private string app_cli_path          = Path.Combine( app_base_path, app_cli_exe );

            readonly private string cfg_def_version     = Cfg.Default.app_def_version;
            readonly private string cfg_def_users       = Cfg.Default.app_def_users;

        #endregion

        #region "Main Window: Initialize"

            /*
                Frame > Parent
            */

            public FormParent()
            {

                InitializeComponent( );
                StatusBar.InitializeReceiver( this );

                this.status_Strip.Renderer  = new StatusBar_Renderer( );

                /*
                    Product, trademark, etc.
                */

                string ver                  = AppInfo.ProductVersionCore.ToString( );
                string product              = AppInfo.Title;
                string tm                   = AppInfo.Trademark;

                /*
                    Form Control Buttons
                */

                btn_Close.Parent            = imgHeader;
                btn_Close.BackColor         = Color.Transparent;

                btn_Minimize.Parent         = imgHeader;
                btn_Minimize.BackColor      = Color.Transparent;

                /*
                    Headers
                */

                lbl_HeaderName.Parent       = imgHeader;
                lbl_HeaderName.BackColor    = Color.Transparent;
                lbl_HeaderName.Text         = product;

                lbl_HeaderSub.Parent        = imgHeader;
                lbl_HeaderSub.BackColor     = Color.Transparent;
                lbl_HeaderSub.Text          = "v" + ver + " by " + tm;

                /*
                    Richtext in body of interface
                */

                string l1                   = Lng.program_will_generate;
                string l2                   = Cfg.Default.app_def_mxtpro;
                string l3                   = Lng.license_file_inside_mobaxterm;

                rtxt_Desc.Text              = "";

                rtxt_Desc.AppendText        ( l1 );
                rtxt_Desc.Select            ( 0, l1.Length);
                rtxt_Desc.SelectionColor    = Color.White;

                rtxt_Desc.AppendText        ( " " );

                rtxt_Desc.AppendText        ( l2 );
                rtxt_Desc.Select            ( l1.Length + 1, l2.Length );
                rtxt_Desc.SelectionColor    = Color.FromArgb( 31, 133, 222 );

                rtxt_Desc.AppendText        ( " " );

                rtxt_Desc.AppendText        ( l3 );
                rtxt_Desc.Select            ( l1.Length + 1 + l2.Length + 1, l3.Length );
                rtxt_Desc.SelectionColor    = Color.White;
            }

            /*
                Frame > Parent > Load
            */

            private void FormParent_Load( object sender, EventArgs e )
            {
                mnu_Main.Renderer       = new ToolStripProfessionalRenderer( new mnu_Main_ColorTable( ) );
                StatusBar.Update( Lng.status_genlicense );
            }

            /*
                Tweak to fix frame flickering
            */

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x02000000;  // enable WS_EX_COMPOSITED
                    return cp;
                }
            }

        #endregion

        #region "Main Window: Control Buttons"

            /*
                Control Buttons
                    ->  Minimize
                    ->  Maximize
                    ->  Close

                Icons:  http://modernicons.io/segoe-mdl2/cheatsheet/
                Font:   Segoe MDL2 Assets
            */

            /*
                Window > Button > Minimize > Click
            */

            private void btn_Window_Minimize_Click( object sender, EventArgs e )
            {
                this.WindowState = FormWindowState.Minimized;
            }

            /*
                Window > Button > Minimize > Mouse Enter
            */

            private void btn_Window_Minimize_MouseEnter( object sender, EventArgs e )
            {
                btn_Minimize.ForeColor = Color.FromArgb(222, 31, 100);
            }

            /*
                Window > Button > Minimize > Mouse Leave
            */

            private void btn_Window_Minimize_MouseLeave( object sender, EventArgs e )
            {
                btn_Minimize.ForeColor = Color.FromArgb(255, 255, 255);
            }

            /*
                Window > Button > Close > Click
            */

            private void btn_Window_Close_Click( object sender, EventArgs e )
            {

                /*
                    delete the cli exe as we no longer need it
                */

                if ( File.Exists( app_cli_exe ) )
                    File.Delete( app_cli_exe );

                /*
                    kill app
                */

                Application.Exit( );
            }

            /*
                Window > Button > Close > Mouse Enter
            */

            private void btn_Window_Close_MouseEnter( object sender, EventArgs e )
            {
                btn_Close.ForeColor = Color.FromArgb(222, 31, 100);
            }

            /*
                Window > Button > Close > Mouse Leave
            */

            private void btn_Window_Close_MouseLeave( object sender, EventArgs e )
            {
                btn_Close.ForeColor = Color.FromArgb(255, 255, 255);
            }


        #endregion

        #region "Main Window: Dragging"

            /*
                Main Form > Mouse Down
                deals with moving form around on screen
            */

            private void MainForm_MouseDown( object sender, MouseEventArgs e )
            {
                mouseDown       = true;
                lastLocation    = e.Location;
            }

            /*
                Main Form > Mouse Up
                deals with moving form around on screen
            */

            private void MainForm_MouseUp( object sender, MouseEventArgs e )
            {
                mouseDown       = false;
            }

            /*
                Main Form > Mouse Move
                deals with moving form around on screen
            */

            private void MainForm_MouseMove( object sender, MouseEventArgs e )
            {
                if ( mouseDown )
                {
                    this.Location = new Point(
                        ( this.Location.X - lastLocation.X ) + e.X,
                        ( this.Location.Y - lastLocation.Y ) + e.Y
                    );

                    this.Update( );
                }
            }

        #endregion

        #region "Header"

        /*
            Header Image
        */

            private void imgHeader_MouseDown( object sender, MouseEventArgs e )
            {
                mouseDown = true;
                lastLocation = e.Location;
            }

            private void imgHeader_MouseUp( object sender, MouseEventArgs e )
            {
                mouseDown       = false;
            }

            private void imgHeader_MouseMove( object sender, MouseEventArgs e )
            {
                if ( mouseDown )
                {
                    this.Location = new Point(
                        ( this.Location.X - lastLocation.X ) + e.X,
                        ( this.Location.Y - lastLocation.Y ) + e.Y
                    );

                    this.Update( );
                }
            }

        /*
            Header > Name Label
        */

            private void lbl_HeaderName_MouseDown( object sender, MouseEventArgs e )
            {
                mouseDown = true;
                lastLocation = e.Location;
            }

            private void lbl_HeaderName_MouseUp( object sender, MouseEventArgs e )
            {
                mouseDown = false;
            }

            private void lbl_HeaderName_MouseMove( object sender, MouseEventArgs e )
            {
                if ( mouseDown )
                {
                    this.Location = new Point(
                        ( this.Location.X - lastLocation.X ) + e.X,
                        ( this.Location.Y - lastLocation.Y ) + e.Y
                    );

                    this.Update( );
                }
            }

        /*
            Header > Sub Label
        */

            private void lbl_HeaderSub_MouseDown( object sender, MouseEventArgs e )
            {
                mouseDown = true;
                lastLocation = e.Location;
            }

            private void lbl_HeaderSub_MouseUp( object sender, MouseEventArgs e )
            {
                mouseDown = false;
            }

            private void lbl_HeaderSub_MouseMove( object sender, MouseEventArgs e )
            {
                if ( mouseDown )
                {
                    this.Location = new Point(
                        ( this.Location.X - lastLocation.X ) + e.X,
                        ( this.Location.Y - lastLocation.Y ) + e.Y
                    );

                    this.Update( );
                }
            }

        #endregion

        #region "Top Menu"

            /*
                Top Menu > Color Overrides
            */

            public class mnu_Main_ColorTable : ProfessionalColorTable
            {
                /*
                    Gets the starting color of the gradient used when
                    a top-level System.Windows.Forms.ToolStripMenuItem is pressed.
                */

                public override Color MenuItemPressedGradientBegin => Color.FromArgb( 255, 55, 55, 55 );

                /*
                    Gets the end color of the gradient used when a top-level
                    System.Windows.Forms.ToolStripMenuItem is pressed.
                */

                public override Color MenuItemPressedGradientEnd => Color.FromArgb( 255, 55, 55, 55 );

                /*
                    Gets the border color to use with a
                    System.Windows.Forms.ToolStripMenuItem.
                */

                public override Color MenuItemBorder => Color.FromArgb( 0, 45, 45, 45 );

                /*
                    Gets the starting color of the gradient used when the
                    System.Windows.Forms.ToolStripMenuItem is selected.
                */

                public override Color MenuItemSelectedGradientBegin => Color.FromArgb( 255, 222, 31, 103 );

                /*
                    Gets the end color of the gradient used when the
                    System.Windows.Forms.ToolStripMenuItem is selected.
                */

                public override Color MenuItemSelectedGradientEnd => Color.FromArgb( 255, 222, 31, 103 );

                /*
                    Gets the solid background color of the
                    System.Windows.Forms.ToolStripDropDown.
                */

                public override Color ToolStripDropDownBackground => Color.FromArgb( 255, 40, 40, 40 );

                /*
                    Top Menu > Image > Start Gradient Color
                */

                public override Color ImageMarginGradientBegin => Color.FromArgb( 255, 222, 31, 103 );

                /*
                    Top Menu > Image > Middle Gradient Color
                */

                public override Color ImageMarginGradientMiddle => Color.FromArgb( 0, 222, 31, 103 );

                /*
                    Top Menu > Image > End Gradient Color
                */

                public override Color ImageMarginGradientEnd => Color.FromArgb( 0, 222, 31, 103 );

                /*
                    Top Menu > Shadow Effect
                */

                public override Color SeparatorDark => Color.FromArgb( 0, 255, 255, 255 );

                /*
                    Top Menu > Border Color
                */

                public override Color MenuBorder => Color.FromArgb( 0, 45, 45, 45 );

                /*
                    Top Menu > Item Hover BG Color
                */

                public override Color MenuItemSelected => Color.FromArgb( 255, 222, 31, 103 );
            }

            /*
                Top Menu > Paint
            */

            private void mnu_Main_Paint( object sender, PaintEventArgs e )
            {
                Graphics g                  = e.Graphics;
                Color backColor             = Color.FromArgb( 35, 255, 255, 255 );
                var imgSize                 = mnu_Main.ClientSize;
                e.Graphics.FillRectangle( new SolidBrush( backColor ), 1, 1, imgSize.Width - 2, 1 );
                e.Graphics.FillRectangle( new SolidBrush( backColor ), 1, imgSize.Height - 2, imgSize.Width - 2, 1 );
            }

            /*
                Top Menu > File > Exit
            */

            private void mnu_Sub_Exit_Click( object sender, EventArgs e )
            {

                /*
                    delete the cli exe as we no longer need it
                */

                if ( File.Exists( app_cli_exe ) )
                    File.Delete( app_cli_exe );

                /*
                    kill app
                */

                Application.Exit( );
            }

            /*
                Top Menu > Contribute
            */

            private void mnu_Cat_Contribute_Click( object sender, EventArgs e )
            {
                this.Hide( );

                FormContribute to   = new FormContribute( );
                to.TopMost          = true;
                to.Show( );
            }

            /*
               Top Menu > Help > Check for Updates
            */

            private void mnu_Sub_Updates_Click( object sender, EventArgs e )
            {
                System.Diagnostics.Process.Start( Cfg.Default.app_url_github );
            }

            /*
               Top Menu > Help > x509 Certificate Validation
            */

            private void mnu_Sub_Validate_Click( object sender, EventArgs e )
            {
                string exe_target = System.AppDomain.CurrentDomain.FriendlyName;
                if ( !File.Exists( exe_target ) )
                {

                    MessageBox.Show( string.Format( "Could not find executable's location. Aborting validation\n\nFilename: \n{0}", exe_target ),
                        "Integrity Check: Aborted",
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                    );

                    return;
                }

                string x509_cert    = Helper.x509_Thumbprint( exe_target );

                /*
                    x509 certificate

                    Add integrity validation. Ensure the resource DLL has been signed by the developer,
                    otherwise cancel the patching step.
                */

                if ( x509_cert != "0" )
                {

                    /* certificate: resource file  signed */

                    if ( x509_cert.ToLower( ) == Cfg.Default.app_dev_piv_thumbprint.ToLower( ) )
                    {

                        /* certificate: resource file signed and authentic */

                        MessageBox.Show( string.Format( "Successfully validated that this patch is authentic, continuing...\n\nCertificate Thumbprint: \n{0}", x509_cert ),
                            "Integrity Check Successful",
                            MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        /* certificate: resource file signed but not by developer */

                        MessageBox.Show( string.Format( "The fails associated to this patch have a signature, however, it is not by the developer who wrote the patch, aborting...\n\nCertificate Thumbprint: \n{0}", x509_cert ),
                            "Integrity Check Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    /* certificate: resource file not signed at all */

                    MessageBox.Show( string.Format( "The files for this activator are not signed and may be fake from another source. Files from this activator's developer will ALWAYS be signed.\n\nEnsure you downloaded this patch from the developer.\n\nFailed File(s):\n     {0}", exe_target ),
                        "Integrity Check Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                }
            }

            /*
                Top Menu > Separator
                Separates "Exit" from the other items in "About" dropdown.
            */

            private void mnu_Help_Sep_1_Paint( object sender, PaintEventArgs e )
            {
                ToolStripSeparator toolStripSeparator = (ToolStripSeparator)sender;

                int width           = toolStripSeparator.Width;
                int height          = toolStripSeparator.Height;
                Color backColor     = Color.FromArgb( 255, 222, 31, 103 );

                // Fill the background.
                e.Graphics.FillRectangle( new SolidBrush( backColor ), 0, 0, width, height );
            }

            /*
                Top Menu > Help > About
            */

            private void mnu_Sub_About_Click( object sender, EventArgs e )
            {
                this.Hide( );

                FormAbout to    = new FormAbout( );
                to.TopMost      = true;
                to.Show( );
            }

        #endregion

        #region "Body: Generate Button"

                   /*
                 button > generate > mouse enter
             */

            private void btn_Generate_MouseEnter( object sender, EventArgs e )
            {
                StatusBar.Update( Lng.status_genlicense );
            }

            /*
                 button > generate > mouse click
             */

            private void btn_Generate_Click( object sender, EventArgs e )
            {

                string fval_name    = txt_Name.Value;
                string fval_ver     = txt_Version.Value;
                string fval_users   = txt_Users.Value;

                //  Name Missing
                if ( string.IsNullOrEmpty( fval_name ) )
                {
                    MessageBox.Show
                    (
                        Lng.msgbox_err_generate_noname_msg, Lng.msgbox_err_generate_noname_title,
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                    );

                    return;
                }

                //  Default version textbox value
                if ( String.IsNullOrEmpty( fval_ver ) || fval_ver == "0" )
                {
                    txt_Version.isPlaceholder   = false;
                    txt_Version.Value           = cfg_def_version;
                    fval_ver                    = cfg_def_version;
                }

                //  Default user textbox value
                if ( String.IsNullOrEmpty( fval_users ) || fval_users == "0" )
                {
                    txt_Users.isPlaceholder     = false;
                    txt_Users.Value             = cfg_def_users;
                    fval_users                  = cfg_def_users;
                }


                /*
                        Do you wish to generate a new license key for MobaXterm?
                */

                var result      = MessageBox.Show(
                                    Lng.msgbox_ok_generate_msg,
                                    Lng.msgbox_ok_generate_title,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                );

                string answer   = result.ToString( );

                //  Confirmation - Answer YES
                if ( answer == "Yes" )
                {

                    string target_exe_where         = Helper.FindApp( );        //  Locate MobaXterm.exe

                    //  Check if the MobaXterm.exe file path really exists

                    if ( !String.IsNullOrEmpty( target_exe_where ) && Directory.Exists( target_exe_where ) )
                    {

                        string mxtpro_target_to     = target_exe_where + @"\" + Cfg.Default.app_def_mxtpro;
                        string mxtpro_filename      = Cfg.Default.app_def_mxtpro;
                        string mxtpro_filename_bak  = target_exe_where + @"\" + Cfg.Default.app_def_mxtpro + ".bak";

                        /*
                            Look for existing mxtpro file
                            can either be in:

                                -> C:\Program Files (x86)\Mobatek\MobaXterm
                                -> MobaXterm Portable
                        */

                        if ( File.Exists( mxtpro_target_to ) )
                        {
                            //  Delete existing .bak
                            if ( File.Exists( mxtpro_filename_bak ) )
                                File.Delete( mxtpro_filename_bak );

                            //  Move new .bak
                            if ( File.Exists( mxtpro_target_to ) )
                                File.Move( mxtpro_target_to, mxtpro_filename_bak );
                        }

                        /*
                            Generate new license
                        */

                        string app_cli_result = Serial.Generate("& \"" + app_cli_path + "\"" + " -s " + fval_name + " " + fval_ver + " " + fval_users);

                        //  Move new Custom.mxtpro from keygen folder to folder where MobaXterm.exe found
                        if ( File.Exists( mxtpro_filename ) )
                            File.Move( mxtpro_filename, mxtpro_target_to );

                        //  Delete the cli exe as we no longer need it
                        if ( File.Exists( app_cli_exe ) )
                            File.Delete( app_cli_exe );

                        //  New license successfully saved
                        if ( File.Exists( mxtpro_target_to ) )
                        {

                            //  Update textbox with new license
                            txt_LicenseKey.isPlaceholder    = false;
                            txt_LicenseKey.Value            = app_cli_result;

                            MessageBox.Show(
                                string.Format( Lng.msgbox_ok_generate_finished_msg, Environment.NewLine, Environment.NewLine, mxtpro_target_to ),
                                Lng.msgbox_ok_generate_finished_title,
                                MessageBoxButtons.OK, MessageBoxIcon.None
                            );
                        }
                    }
                    else
                    {

                        /*
                            Could not find MobaXterm.exe

                            patch_launch_fullpath       : Full path to exe
                            patch_launch_dir            : Directory only
                            patch_launch_exe            : Patcher exe filename only
                        */

                        string patch_launch_fullpath    = Process.GetCurrentProcess( ).MainModule.FileName;
                        string patch_launch_dir         = Path.GetDirectoryName( patch_launch_fullpath );
                        string patch_launch_exe         = Path.GetFileName( patch_launch_fullpath );
                        string app_target_exe           = Cfg.Default.app_mobaxterm_exe;

                        MessageBox.Show
                        (
                            string.Format( Lng.msgbox_err_locate_msg, Cfg.Default.app_mobaxterm_exe, patch_launch_exe, Cfg.Default.app_def_mxtpro ),
                            Lng.msgbox_err_locate_title,
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );

                        /*
                            The next series of code will open a Save Dialog and allows the user to pick where the Mxtpro.custom
                            license file should be saved.
                        */

                        string result_license           = Serial.SaveKeyfile( fval_name, fval_ver, fval_users );

                        /*  Update textbox with new license */
                        txt_LicenseKey.isPlaceholder    = false;
                        txt_LicenseKey.Value            = result_license;

                    }

                }// Confirmation: Yes
            }

        #endregion

        #region "Body: Open Folder Button"

            /*
                button > hover
            */

            private void btn_OpenFolder_MouseEnter( object sender, EventArgs e )
            {
                StatusBar.Update( Lng.status_btn_openfolder );
            }

            /*
                button > open folder where mirc "should" be
            */

            private void btn_OpenFolder_Click( object sender, EventArgs e )
            {
                string src_file_path        = Helper.FindApp( );
                string src_list             = Helper.GetAppFindList( );

                if ( String.IsNullOrEmpty( src_file_path ) )
                {
                    MessageBox.Show(
                        string.Format( Lng.msgbox_nolocopen_msg, Cfg.Default.app_mobaxterm_exe, src_list ),
                        string.Format( Lng.msgbox_nolocopen_title, Cfg.Default.app_mobaxterm_exe ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                /*
                    target directory
                */

                if ( Directory.Exists( src_file_path ) )
                    Process.Start( "explorer.exe", src_file_path );

                /*
                    cannot locate mobaxterm program. Open dialog in Program Files(86)
                */

                else
                {
                    string path_progfiles = Helpers.ProgramFiles( );
                    Process.Start( "explorer.exe", path_progfiles );

                    MessageBox.Show(
                        string.Format( Lng.msgbox_nolocopen_msg, Cfg.Default.app_mobaxterm_exe, src_list ),
                        string.Format( Lng.msgbox_nolocopen_title, Cfg.Default.app_mobaxterm_exe ),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

        #endregion

        #region "Body: Text Fields"

            /*
                Name
            */

            private void txt_Name_MouseEnter( object sender, EventArgs e )
            {
                StatusBar.Update( Lng.status_txt_name_mouseover );
            }

            /*
                Number of Users
            */

            private void txt_Users_MouseEnter( object sender, EventArgs e )
            {
                StatusBar.Update( string.Format( "{0} {1}", Lng.status_txt_users_mouseover, Cfg.Default.app_def_users ) );
            }

            /*
                Version
            */

            private void txt_Version_MouseEnter( object sender, EventArgs e )
            {
                StatusBar.Update( string.Format( "{0} {1}", Lng.status_txt_version_mouseover, Cfg.Default.app_def_version ) );
            }

        #endregion

        #region "Status Bar"

            /*
                status bar in lower part of the main interface.
                updated when certain actions are completed to inform the user.
            */

            /*
                Status Bar > Color Table (Override)
            */

            public class StatusBar_ClrTable : ProfessionalColorTable
            {
                public override Color StatusStripGradientBegin => Color.FromArgb( 35, 35, 35 );
                public override Color StatusStripGradientEnd => Color.FromArgb( 35, 35, 35 );
            }

            /*
                Status Bar > Renderer
                Override colors
            */

            public class StatusBar_Renderer : ToolStripProfessionalRenderer
            {
                public StatusBar_Renderer( )
                    : base( new StatusBar_ClrTable( ) ) { }

                protected override void OnRenderToolStripBorder( ToolStripRenderEventArgs e )
                {
                    if ( !( e.ToolStrip is StatusStrip ) )
                        base.OnRenderToolStripBorder( e );
                }
            }

            /*
                Statusbar > Paint
            */

            private void status_Strip_Paint( object sender, PaintEventArgs e )
            {
                Graphics g                  = e.Graphics;
                Color backColor             = Color.FromArgb( 35, 255, 255, 255 );
                var imgSize                 = status_Strip.ClientSize;
                e.Graphics.FillRectangle    ( new SolidBrush( backColor ), 1, 1, imgSize.Width - 2, 2 );
            }

            private void status_Strip_MouseDown( object sender, MouseEventArgs e )
            {
                mouseDown = true;
                lastLocation = e.Location;
            }

            private void status_Strip_MouseUp( object sender, MouseEventArgs e )
            {
                mouseDown = false;
            }

            private void status_Strip_MouseMove( object sender, MouseEventArgs e )
            {
                if ( mouseDown )
                {
                    this.Location = new Point(
                        ( this.Location.X - lastLocation.X ) + e.X,
                        ( this.Location.Y - lastLocation.Y ) + e.Y
                    );

                    this.Update( );
                }
            }

            /*
                Receiver > Update Status
            */

            public void Status( string message )
            {
                lbl_StatusOutput.Text = message;
                status_Strip.Refresh( );
            }

        #endregion

    }
}
