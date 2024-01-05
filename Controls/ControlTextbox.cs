using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/*

    Aetherx > Control > Textbox

    Textbox customization is absolutely horrible. So we're
    creating our own.

        >   borderColor
        >   borderSize
        >   underlineStyle

*/

namespace MobaXtermKG
{

    [DefaultEvent("_TextChanged")]
    public partial class AetherxTextBox : UserControl
    {

        /*
            Fields
        */

        private Color borderColor           = Color.MediumSlateBlue;
        private int borderSize              = 1;
        private bool underlineStyle         = false;
        private Color borderFocusColor      = Color.HotPink;
        private bool bAllowFocus            = true;
        private bool isFocused              = false;
        private bool bEnableScrollbars      = true;
        private Color placeholderColor      = Color.DarkGray;
        private string placeholderText      = "";
        public bool isPlaceholder           = false;
        private bool isPasswordChar         = false;

        /*
            Constructor
        */

        public AetherxTextBox( )
        {
            InitializeComponent( );

            Selectable              = true;
            this.ActiveControl      = null;
            this.Padding            = new System.Windows.Forms.Padding( 3, 3, 3, 3 );
        }


        const int WM_SETFOCUS       = 0x0007;
        const int WM_KILLFOCUS      = 0x0008;

        /*
            Events
        */

        public event EventHandler _TextChanged;

        /*
            Properties > Scrollbars
        */

        /*
        [
            Category    ( "Aetherx" ),
            Description ( "Display scrollbars if text box set to Multiline" ),
        ] 

        public enum ArrowColor { Red, Green, Magenta, Pink, Orange, Black, Yellow };
        private ArrowColor _foreColor;

        [ Browsable( true ) ]
        public ArrowColor ArrowColr
        {
            get { return _foreColor; }
            set { _foreColor = value; }
        }
        */

        /*
            Enables or disables selection highlight. 
            If you set `Selectable` to `false` then the selection highlight will be disabled.

            enabled by default.
        */

        [
            Category    ( "Aetherx" ),
            Description ( "Display scrollbars if text box set to Multiline" ),
        ] 

        public bool Selectable { get; set; }

        protected override void WndProc( ref Message m )
        {
            if ( m.Msg == WM_SETFOCUS && !Selectable )
            {
                m.Msg           = WM_KILLFOCUS;
                this.Cursor     = Cursors.Default;
            }

            base.WndProc( ref m );
        }

        /*
            Properties > Scrollbars
        */

        [
            Category    ( "Aetherx" ),
            Description ( "Display scrollbars if text box set to Multiline" ),
        ] 

        public bool MultilineScrollbars
        {
            get
            {
                return bEnableScrollbars;
            }

            set
            {
                bEnableScrollbars = value;

                if ( bEnableScrollbars )
                    textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                else if ( !bEnableScrollbars )
                    textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;

                UpdateControlHeight( );
            }
        }

        /*
            Properties > Border Color
        */

        [ Category( "Aetherx" ) ]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }

            set
            {
                borderColor = value;
                this.Invalidate( );
            }
        }

        /*
            Properties > Border Size
        */

        [ Category( "Aetherx" ) ]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }

            set
            {
                borderSize = value;
                this.Invalidate( );
            }
        }

        /*
            Properties > Underline Style
        */

        [ Category( "Aetherx" ) ]
        public bool UnderlineStyle
        {
            get
            {
                return underlineStyle;
            }

            set
            {
                underlineStyle = value;
                this.Invalidate( );
            }
        }

        /*
            Properties > Password Char
        */

        [ Category( "Aetherx" ) ]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value;
            }
        }

        /*
            Properties > Multiline
        */

        [ Category( "Aetherx" ) ]
        public bool Multiline
        {
            get
            {
                return textBox1.Multiline;
            }

            set
            {
                textBox1.Multiline = value;

                if ( bEnableScrollbars == true )
                {
                    textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                }
                else if ( bEnableScrollbars == false )
                {
                    textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
                }

                UpdateControlHeight( );
            }
        }

        /*
            Properties > Readonly
        */

        [Category("Aetherx")]
        public bool ReadOnly
        {
            get
            {
                return textBox1.ReadOnly;
            }

            set
            {
                textBox1.ReadOnly = value;
            }
        }

        /*
            Properties > Background Color
        */

        [Category("Aetherx")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor      = value;
                textBox1.BackColor  = value;
            }
        }

        /*
            Properties > Foreground Color
        */

        [Category("Aetherx")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor      = value;
                textBox1.ForeColor  = value;
            }
        }

        /*
            Properties > Font
        */

        [Category("Aetherx")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font       = value;
                textBox1.Font   = value;

                if (this.DesignMode)
                {
                    UpdateControlHeight( );
                }
            }
        }

        /*
            Properties > Value (replaces Text)
        */

        [Category("Aetherx")]
        public string Value
        {
            get
            {
                if ( isPlaceholder )
                    return "";
                else
                    return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
                SetPlaceholder( );
            }
        }

        /*
            Properties > Lines
        */

        public string[] Lines
        {
            get
            {
                string[] lines = textBox1.Lines;
                return lines;
            }
        }

        /*
            Properties > Allow Focus
        */

        [Category("Aetherx")]
        public bool AllowFocus
        {
            get
            {
                return bAllowFocus;
            }

            set
            {
                bAllowFocus = value;
            }
        }

        /*
            Properties > Focus Border Color
        */

        [Category("Aetherx")]
        public Color BorderFocusColor
        {
            get
            {
                return borderFocusColor;
            }

            set
            {
                borderFocusColor = value;
            }
        }

        [Category("Aetherx")]
        public Color PlaceholderColor
        {
            get
            {
                return placeholderColor;
            }

            set
            {
                placeholderColor = value;

                if ( isPasswordChar )
                    textBox1.ForeColor = value;
            }
        }

        [Category("Aetherx")]
        public string PlaceholderText
        {
            get
            {
                return placeholderText;
            }

            set
            {
                placeholderText     = value;
                textBox1.Text       = "";
                SetPlaceholder( );
            }
        }

        private void SetPlaceholder( )
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder           = true;
                textBox1.Text           = placeholderText;
                textBox1.ForeColor      = placeholderColor;

                if ( isPasswordChar )
                    textBox1.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceholder( )
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder           = false;
                textBox1.Text           = "";
                textBox1.ForeColor      = this.ForeColor;

                if ( isPasswordChar )
                    textBox1.UseSystemPasswordChar = true;
            }
        }


        /*
            Override Methods > onPaint
        */

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint( e );
            Graphics graph = e.Graphics;

            // Border
            if (borderSize > 0 )
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (!isFocused)
                    {
                        if (underlineStyle)
                        {
                            // underline
                            graph.DrawLine( penBorder, 0, this.Height - 1, this.Width, this.Height - 1 );
                        }
                        else
                        {
                            // normal style
                            graph.DrawRectangle( penBorder, 0, 0, this.Width - 1, this.Height - 1 );
                        }
                    }
                    else
                    {

                        penBorder.Color = borderFocusColor;

                        if (underlineStyle)
                        {
                            // underline
                            graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                        }
                        else
                        {
                            // normal style
                            graph.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1 );
                        }
                    }
                }
            }
        }

        /*
            Override Methods > onResize
        */

        protected override void OnResize( EventArgs e )
        {
            base.OnResize( e );
            if ( this.DesignMode )
            {
                UpdateControlHeight( );
            }
        }

        /*
            Override Methods > onLoad
        */

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            UpdateControlHeight( );
        }

        /*
            Override Methods > Update Control Height
        */

        private void UpdateControlHeight( )
        {
            if ( textBox1.Multiline == false )
            {
                int txtHeight           = TextRenderer.MeasureText( "Text", this.Font ).Height + 1;
                textBox1.Multiline      = true;
                textBox1.MinimumSize    = new Size( 0, txtHeight );
                textBox1.Multiline      = false;
                this.Height             = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {
            if (_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void textBox1_MouseDown( object sender, MouseEventArgs e )
        {
            this.OnMouseDown( e );
        }

        private void textBox1_MouseUp( object sender, MouseEventArgs e )
        {
            this.OnMouseUp( e );
        }

        private void textBox1_MouseMove( object sender, MouseEventArgs e )
        {
            this.OnMouseMove( e );
        }

        private void textBox1_Click( object sender, EventArgs e )
        {
            this.OnClick( e );
        }

        private void textBox1_MouseEnter( object sender, EventArgs e )
        {
            this.OnMouseEnter( e );
        }

        private void textBox1_MouseLeave( object sender, EventArgs e )
        {
            this.OnMouseLeave( e );
        }

        private void textBox1_KeyPress( object sender, KeyPressEventArgs e )
        {
            this.OnKeyPress( e );
        }

        private void textBox1_Enter( object sender, EventArgs e )
        {
            if (bAllowFocus)
            {
                isFocused = true;
                this.Invalidate();
                RemovePlaceholder();
            }
        }

        private void textBox1_Leave( object sender, EventArgs e )
        {
            isFocused = false;
            this.Invalidate( );
            SetPlaceholder( );
        }
    }
}
