using System;
using System.Drawing;
using System.Windows.Forms;
using Lng = MobaXtermKG.Properties.Resources;
using Cfg = MobaXtermKG.Properties.Settings;

namespace MobaXtermKG.Forms
{
    public partial class FormContribute : Form
    {

        #region "Declarations"

            /*
                Define
            */

            private Helpers Helpers     = new Helpers( );

            private bool mouseDown;
            private Point lastLocation;

        #endregion

        #region "Main Window: Initialize"

            public FormContribute( )
            {
                InitializeComponent( );

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
                    Intro
                */

                lbl_Contrib_Intro.Text      = Lng.txt_contrib_intro;
                lbl_BTC.Text                = Lng.lbl_contrib_btc; 
                lbl_ETH.Text                = Lng.lbl_contrib_eth; 
                lbl_BCH.Text                = Lng.lbl_contrib_bch; 

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

        #region "Main Window: Paint"

            private void FormContribute_Paint( object sender, PaintEventArgs e )
            {
                Pen clr_border = new Pen(Color.FromArgb(75, 75, 75));
                e.Graphics.DrawRectangle(clr_border, 0, 0, Width - 1, Height - 1);
            }

        #endregion

        #region "Main Window: Control Buttons"

            private void btn_Window_Close_Click( object sender, EventArgs e )
            {
                FormParent to   = new FormParent( );
                to.Show         ( );
                this.Close      ( );
            }

            /*
                Window > Button > Close > Mouse Enter
            */

            private void btn_Window_Close_MouseEnter( object sender, EventArgs e )
            {
                btn_Close.ForeColor = Color.FromArgb( 222, 31, 100 );
            }

            /*
                Window > Button > Close > Mouse Leave
            */

            private void btn_Window_Close_MouseLeave( object sender, EventArgs e )
            {
                btn_Close.ForeColor = Color.FromArgb( 255, 255, 255 );
            }

        #endregion

        #region "Main Window: Dragging"

            /*
                Main Form > Mouse Down
                deals with moving form around on screen
            */

            private void FormContribute_MouseDown( object sender, MouseEventArgs e )
            {
                mouseDown = true;
                lastLocation = e.Location;
            }

            /*
                Main Form > Mouse Up
                deals with moving form around on screen
            */

            private void FormContribute_MouseUp( object sender, MouseEventArgs e )
            {
                mouseDown = false;
            }

            /*
                Main Form > Mouse Move
                deals with moving form around on screen
            */

            private void FormContribute_MouseMove( object sender, MouseEventArgs e )
            {
                if (mouseDown)
                {
                    this.Location = new Point(
                        (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                    this.Update( );
                }
            }

        #endregion

        #region "Header"

        /*
            Header Image
        */

            private void imgHeader_Paint( object sender, PaintEventArgs e )
            {
                Graphics g          = e.Graphics;
                Color backColor     = Color.FromArgb( 65, 255, 255, 255 );
                var imgSize         = imgHeader.ClientSize;

                e.Graphics.FillRectangle( new SolidBrush( backColor ), 1, imgSize.Height - 2, imgSize.Width - 2, 2 );
            }

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
                mouseDown       = false;
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
                mouseDown       = false;
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

        #region "Body: Intro"

            private void lbl_Contrib_Intro_MouseDown( object sender, MouseEventArgs e )
            {
                mouseDown = true;
                lastLocation = e.Location;
            }

            private void lbl_Contrib_Intro_MouseUp( object sender, MouseEventArgs e )
            {
                mouseDown = false;
            }

            private void lbl_Contrib_Intro_MouseMove( object sender, MouseEventArgs e )
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

    }
}
