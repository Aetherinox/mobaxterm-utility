using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MobaXtermKG.Msgbox
{
    public partial class FormMessageBox : Form
    {

        #region "Define: Fileinfo"

            /*
                Define > File Name
                    utilized with logging
            */

            readonly static string log_file = "FormMessageBox.cs";

        #endregion

        #region "Fields"

            private Color primaryColor  = Color.CornflowerBlue;
            readonly int borderSize     = 1;

        #endregion

        #region "Properties"

            public Color PrimaryColor
            {
                get { return primaryColor; }
                set
                {
                    primaryColor                = value;
                    this.BackColor              = primaryColor;
                    this.pnl_Titlebar.BackColor = PrimaryColor;
                }
            }

        #endregion

        #region "Constructors: FormMessageBox"

            public FormMessageBox( string text )
            {
                InitializeComponent( );
                InitializeItems( );
                this.PrimaryColor           = primaryColor;
                this.lbl_Message.Text       = text;
                this.lbl_Caption.Text       = "";
                SetFormSize( );
                SetButtons(MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            public FormMessageBox( string text, string caption )
            {
                InitializeComponent( );
                InitializeItems( );
                this.PrimaryColor           = primaryColor;
                this.lbl_Message.Text       = text;
                this.lbl_Caption.Text       = caption;
                SetFormSize( );
                SetButtons( MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
            }

            public FormMessageBox( string text, string caption, MessageBoxButtons buttons )
            {
                InitializeComponent( );
                InitializeItems( );
                this.PrimaryColor           = primaryColor;
                this.lbl_Message.Text       = text;
                this.lbl_Caption.Text       = caption;
                SetFormSize( );
                SetButtons( buttons, MessageBoxDefaultButton.Button1 );
            }

            public FormMessageBox(
                string text,
                string caption,
                MessageBoxButtons buttons,
                MessageBoxIcon icon
            )
            {
                InitializeComponent( );
                InitializeItems( );
                this.PrimaryColor           = primaryColor;
                this.lbl_Message.Text       = text;
                this.lbl_Caption.Text       = caption;
                SetFormSize( );
                SetButtons( buttons, MessageBoxDefaultButton.Button1 );
                SetIcon( icon );
            }

            public FormMessageBox(
                string text,
                string caption,
                MessageBoxButtons buttons,
                MessageBoxIcon icon,
                MessageBoxDefaultButton btnDefault
            )
            {
                InitializeComponent( );
                InitializeItems( );
                this.PrimaryColor           = primaryColor;
                this.lbl_Message.Text       = text;
                this.lbl_Caption.Text       = caption;
                SetFormSize( );
                SetButtons( buttons, btnDefault );
                SetIcon( icon );
            }

        #endregion

        #region "Initialize"

            private void InitializeItems( )
            {
                this.FormBorderStyle            = FormBorderStyle.None;
                this.Padding                    = new Padding( borderSize );
                this.lbl_Message.MaximumSize    = new Size( 430, 0 );
                this.btn_Close.DialogResult     = DialogResult.Cancel;
                this.btn_1.DialogResult         = DialogResult.OK;
                this.btn_1.Visible              = false;
                this.btn_2.Visible              = false;
                this.btn_3.Visible              = false;
            }

        #endregion

        #region "SetFormSize"

            private void SetFormSize( )
            {
                int width =
                    this.lbl_Message.Width + this.img_Icon.Width + this.pnl_Body.Padding.Left;
                int height =
                    this.pnl_Titlebar.Height
                    + this.lbl_Message.Height
                    + this.pnl_Buttons.Height
                    + this.pnl_Body.Padding.Top;
                this.Size = new Size( width, height );
            }

        #endregion

        #region "Set Buttons"

            private void SetButtons( MessageBoxButtons buttons, MessageBoxDefaultButton btn_Default )
            {
                int xCenter = ( this.pnl_Buttons.Width - btn_1.Width ) / 2;
                int yCenter = ( this.pnl_Buttons.Height - btn_1.Height ) / 2;

                switch ( buttons )
                {
                    /*
                        BUTTON > OK
                    */

                    case MessageBoxButtons.OK:
                        btn_1.Visible       = true;
                        btn_1.Location      = new Point( xCenter, yCenter );
                        btn_1.Text          = "&OK";
                        btn_1.DialogResult  = DialogResult.OK;

                        SetDefaultButton( btn_Default );
                        break;

                    /*
                        BUTTON > OK / CANCEL
                    */

                    case MessageBoxButtons.OKCancel:

                        btn_1.Visible       = true;
                        btn_1.Location      = new Point( xCenter - ( btn_1.Width / 2 ) - 5, yCenter );
                        btn_1.Text          = "&OK";
                        btn_1.DialogResult  = DialogResult.OK;

                        btn_2.Visible       = true;
                        btn_2.Location      = new Point( xCenter + ( btn_2.Width / 2 ) + 5, yCenter );
                        btn_2.Text          = "&Cancel";
                        btn_2.DialogResult  = DialogResult.Cancel;
                        btn_2.BackColor     = Color.DimGray;

                        if ( btn_Default != MessageBoxDefaultButton.Button3 )
                            SetDefaultButton( btn_Default );
                        else
                            SetDefaultButton( MessageBoxDefaultButton.Button1 );
                        break;

                    /*
                        BUTTON > RETRY / CANCEL
                    */

                    case MessageBoxButtons.RetryCancel:

                        btn_1.Visible       = true;
                        btn_1.Location      = new Point(xCenter - ( btn_1.Width / 2) - 5, yCenter );
                        btn_1.Text          = "&Retry";
                        btn_1.DialogResult  = DialogResult.Retry;

                        btn_2.Visible       = true;
                        btn_2.Location      = new Point( xCenter + ( btn_2.Width / 2 ) + 5, yCenter );
                        btn_2.Text          = "&Cancel";
                        btn_2.DialogResult  = DialogResult.Cancel;
                        btn_2.BackColor     = Color.DimGray;

                        if ( btn_Default != MessageBoxDefaultButton.Button3 )
                            SetDefaultButton( btn_Default );
                        else
                            SetDefaultButton( MessageBoxDefaultButton.Button1 );
                        break;

                    /*
                        BUTTON > YES / NO
                    */

                    case MessageBoxButtons.YesNo:

                        btn_1.Visible       = true;
                        btn_1.Location      = new Point(xCenter - ( btn_1.Width / 2) - 5, yCenter );
                        btn_1.Text          = "&Yes";
                        btn_1.DialogResult  = DialogResult.Yes;

                        btn_2.Visible       = true;
                        btn_2.Location      = new Point( xCenter + ( btn_2.Width / 2 ) + 5, yCenter );
                        btn_2.Text          = "&No";
                        btn_2.DialogResult  = DialogResult.No;
                        btn_2.BackColor     = Color.IndianRed;

                        if ( btn_Default != MessageBoxDefaultButton.Button3 )
                            SetDefaultButton( btn_Default );
                        else
                            SetDefaultButton( MessageBoxDefaultButton.Button1 );
                        break;

                    /*
                        BUTTON > YES / NO / CANCEL
                    */

                    case MessageBoxButtons.YesNoCancel:

                        btn_1.Visible       = true;
                        btn_1.Location      = new Point( xCenter - btn_1.Width - 5, yCenter );
                        btn_1.Text          = "&Yes";
                        btn_1.DialogResult  = DialogResult.Yes;

                        btn_2.Visible       = true;
                        btn_2.Location      = new Point( xCenter, yCenter );
                        btn_2.Text          = "&No";
                        btn_2.DialogResult  = DialogResult.No;
                        btn_2.BackColor     = Color.IndianRed;

                        btn_3.Visible       = true;
                        btn_3.Location      = new Point( xCenter + btn_2.Width + 5, yCenter );
                        btn_3.Text          = "&Cancel";
                        btn_3.DialogResult  = DialogResult.Cancel;
                        btn_3.BackColor     = Color.DimGray;

                        SetDefaultButton( btn_Default );

                        break;

                    /*
                        BUTTON > ABORT / RETRY / IGNORE
                    */

                    case MessageBoxButtons.AbortRetryIgnore:

                        btn_1.Visible       = true;
                        btn_1.Location      = new Point( xCenter - btn_1.Width - 5, yCenter );
                        btn_1.Text          = "&Abort";
                        btn_1.DialogResult  = DialogResult.Abort;
                        btn_1.BackColor     = Color.Goldenrod;

                        btn_2.Visible       = true;
                        btn_2.Location      = new Point(xCenter, yCenter);
                        btn_2.Text          = "&Retry";
                        btn_2.DialogResult  = DialogResult.Retry;

                        btn_3.Visible       = true;
                        btn_3.Location      = new Point( xCenter + btn_2.Width + 5, yCenter );
                        btn_3.Text          = "&Ignore";
                        btn_3.DialogResult  = DialogResult.Ignore;
                        btn_3.BackColor     = Color.IndianRed;

                        SetDefaultButton( btn_Default );

                        break;
                }
            }

        #endregion

        #region "Set Default Buttons"

            /*
                Set Default Buttons
            */

            private void SetDefaultButton( MessageBoxDefaultButton btn_Default )
            {
                switch ( btn_Default )
                {
                    /*
                        BUTTON > 1
                    */

                    case MessageBoxDefaultButton.Button1:
                        btn_1.Select( );
                        btn_1.ForeColor     = Color.White;
                        btn_1.Font          = new Font( btn_1.Font, FontStyle.Regular );
                        break;

                    /*
                        BUTTON > 2
                    */

                    case MessageBoxDefaultButton.Button2:
                        btn_2.Select( );
                        btn_2.ForeColor     = Color.White;
                        btn_2.Font          = new Font( btn_2.Font, FontStyle.Regular );
                        break;

                    /*
                        BUTTON > 3
                    */

                    case MessageBoxDefaultButton.Button3:
                        btn_3.Select( );
                        btn_3.ForeColor     = Color.White;
                        btn_3.Font          = new Font( btn_3.Font, FontStyle.Regular );
                        break;
                }
            }

        #endregion

        #region "Set Icon"

            /*
                Set Icon
            */

            private void SetIcon( MessageBoxIcon icon )
            {
                switch ( icon )
                {
                    /*
                        ERROR
                    */

                    case MessageBoxIcon.Error:
                        this.img_Icon.Image     = Properties.Resources.error;
                        PrimaryColor            = Color.FromArgb( 167, 15, 78 );

                        this.btn_Close.FlatAppearance.MouseOverBackColor = Color.Transparent;
                        break;

                    /*
                        INFORMATION
                    */

                    case MessageBoxIcon.Information:
                        this.img_Icon.Image     = Properties.Resources.information;
                        PrimaryColor            = Color.FromArgb( 41, 108, 68 );

                        this.btn_Close.FlatAppearance.MouseOverBackColor = Color.Transparent;
                        break;

                    /*
                        QUESTION
                    */

                    case MessageBoxIcon.Question:
                        this.img_Icon.Image     = Properties.Resources.question;
                        PrimaryColor            = Color.FromArgb( 51, 95, 129 );

                        this.btn_Close.FlatAppearance.MouseOverBackColor = Color.Transparent;
                        break;

                    /*
                        EXCLAIMATION
                    */

                    case MessageBoxIcon.Exclamation:
                        this.img_Icon.Image     = Properties.Resources.exclamation;
                        PrimaryColor            = Color.FromArgb( 169, 111, 40 );

                        this.btn_Close.FlatAppearance.MouseOverBackColor = Color.Transparent;
                        break;

                    /*
                        NONE
                    */

                    case MessageBoxIcon.None:
                        this.img_Icon.Image     = Properties.Resources.chat;
                        PrimaryColor            = Color.FromArgb( 70, 70, 70 );

                        this.btn_Close.FlatAppearance.MouseOverBackColor = Color.Transparent;
                        break;
                }
            }

        #endregion

        #region "Main Window Buttons"

            private void btn_Close_Click( object sender, EventArgs e )
            {
                this.Close( );
            }

            /*
                Window > Button > Close > Mouse Enter
            */

            private void btn_Close_MouseEnter( object sender, EventArgs e )
            {
                this.btn_Close.ForeColor = Color.FromArgb( 222, 31, 100 );
            }

            /*
                Window > Button > Close > Mouse Leave
            */

            private void btn_Close_MouseLeave( object sender, EventArgs e )
            {
                this.btn_Close.ForeColor = Color.FromArgb( 255, 255, 255 );
            }

        #endregion

        #region "Main Window: Dragging"

            [DllImport( "user32.DLL", EntryPoint = "SendMessage" ) ]
            private static extern void SendMessage(
                System.IntPtr hWnd,
                int wMsg,
                int wParam,
                int lParam
            );

            [ DllImport( "user32.DLL", EntryPoint = "ReleaseCapture" ) ]
            private static extern void ReleaseCapture( );

            private void pnl_Titlebar_MouseDown( object sender, MouseEventArgs e )
            {
                ReleaseCapture( );
                SendMessage( this.Handle, 0x112, 0xf012, 0 );
            }

            private void pnl_Body_MouseDown( object sender, MouseEventArgs e )
            {
                ReleaseCapture( );
                SendMessage( this.Handle, 0x112, 0xf012, 0 );
            }

            private void pnl_Buttons_MouseDown( object sender, MouseEventArgs e )
            {
                ReleaseCapture( );
                SendMessage( this.Handle, 0x112, 0xf012, 0 );
            }

            private void lbl_Message_MouseDown( object sender, MouseEventArgs e )
            {
                ReleaseCapture( );
                SendMessage( this.Handle, 0x112, 0xf012, 0 );
            }

        #endregion

    }
}
