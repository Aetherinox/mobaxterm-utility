namespace MobaXtermKG.Forms
{
    partial class FormContribute
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContribute));
            this.imgHeader = new System.Windows.Forms.PictureBox();
            this.lbl_Contrib_Intro = new System.Windows.Forms.Label();
            this.txt_BTC = new MobaXtermKG.AetherxTextBox();
            this.btn_Close = new System.Windows.Forms.Label();
            this.txt_ETH = new MobaXtermKG.AetherxTextBox();
            this.txt_BCH = new MobaXtermKG.AetherxTextBox();
            this.pic_BCH = new System.Windows.Forms.PictureBox();
            this.pic_ETH = new System.Windows.Forms.PictureBox();
            this.pic_BTC = new System.Windows.Forms.PictureBox();
            this.lbl_BCH = new System.Windows.Forms.Label();
            this.lbl_ETH = new System.Windows.Forms.Label();
            this.lbl_BTC = new System.Windows.Forms.Label();
            this.lbl_HeaderName = new System.Windows.Forms.Label();
            this.lbl_HeaderSub = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ETH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BTC)).BeginInit();
            this.SuspendLayout();
            // 
            // imgHeader
            // 
            this.imgHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.imgHeader.BackgroundImage = global::MobaXtermKG.Properties.Resources.bg_header;
            this.imgHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgHeader.Location = new System.Drawing.Point(1, 1);
            this.imgHeader.Name = "imgHeader";
            this.imgHeader.Size = new System.Drawing.Size(528, 129);
            this.imgHeader.TabIndex = 0;
            this.imgHeader.TabStop = false;
            this.imgHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.imgHeader_Paint);
            this.imgHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseDown);
            this.imgHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseMove);
            this.imgHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseUp);
            // 
            // lbl_Contrib_Intro
            // 
            this.lbl_Contrib_Intro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Contrib_Intro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Contrib_Intro.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Contrib_Intro.Location = new System.Drawing.Point(15, 136);
            this.lbl_Contrib_Intro.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Contrib_Intro.Name = "lbl_Contrib_Intro";
            this.lbl_Contrib_Intro.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lbl_Contrib_Intro.Size = new System.Drawing.Size(503, 137);
            this.lbl_Contrib_Intro.TabIndex = 0;
            this.lbl_Contrib_Intro.Text = resources.GetString("lbl_Contrib_Intro.Text");
            this.lbl_Contrib_Intro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_Contrib_Intro_MouseDown);
            this.lbl_Contrib_Intro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_Contrib_Intro_MouseMove);
            this.lbl_Contrib_Intro.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_Contrib_Intro_MouseUp);
            // 
            // txt_BTC
            // 
            this.txt_BTC.AllowFocus = false;
            this.txt_BTC.AutoScroll = true;
            this.txt_BTC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txt_BTC.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_BTC.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_BTC.BorderSize = 1;
            this.txt_BTC.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_BTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_BTC.Location = new System.Drawing.Point(15, 316);
            this.txt_BTC.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BTC.Multiline = false;
            this.txt_BTC.MultilineScrollbars = false;
            this.txt_BTC.Name = "txt_BTC";
            this.txt_BTC.Padding = new System.Windows.Forms.Padding(36, 6, 6, 6);
            this.txt_BTC.PasswordChar = false;
            this.txt_BTC.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_BTC.PlaceholderText = "";
            this.txt_BTC.ReadOnly = true;
            this.txt_BTC.Selectable = false;
            this.txt_BTC.Size = new System.Drawing.Size(503, 33);
            this.txt_BTC.TabIndex = 1;
            this.txt_BTC.UnderlineStyle = true;
            this.txt_BTC.Value = "1QGTXH5gdkWDueFU46fQiZEwkjtHk1yriy";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btn_Close.Location = new System.Drawing.Point(490, 7);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(24, 32);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btn_Window_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Window_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Window_Close_MouseLeave);
            // 
            // txt_ETH
            // 
            this.txt_ETH.AllowFocus = false;
            this.txt_ETH.AutoScroll = true;
            this.txt_ETH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txt_ETH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_ETH.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_ETH.BorderSize = 1;
            this.txt_ETH.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_ETH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_ETH.Location = new System.Drawing.Point(15, 376);
            this.txt_ETH.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ETH.Multiline = false;
            this.txt_ETH.MultilineScrollbars = false;
            this.txt_ETH.Name = "txt_ETH";
            this.txt_ETH.Padding = new System.Windows.Forms.Padding(36, 6, 6, 6);
            this.txt_ETH.PasswordChar = false;
            this.txt_ETH.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_ETH.PlaceholderText = "";
            this.txt_ETH.ReadOnly = true;
            this.txt_ETH.Selectable = false;
            this.txt_ETH.Size = new System.Drawing.Size(503, 33);
            this.txt_ETH.TabIndex = 2;
            this.txt_ETH.UnderlineStyle = true;
            this.txt_ETH.Value = "0xC6A9cA5B17265f41636a45dF165a5821f9d26445";
            // 
            // txt_BCH
            // 
            this.txt_BCH.AllowFocus = false;
            this.txt_BCH.AutoScroll = true;
            this.txt_BCH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txt_BCH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_BCH.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_BCH.BorderSize = 1;
            this.txt_BCH.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_BCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_BCH.Location = new System.Drawing.Point(15, 435);
            this.txt_BCH.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BCH.Multiline = false;
            this.txt_BCH.MultilineScrollbars = false;
            this.txt_BCH.Name = "txt_BCH";
            this.txt_BCH.Padding = new System.Windows.Forms.Padding(36, 6, 6, 6);
            this.txt_BCH.PasswordChar = false;
            this.txt_BCH.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_BCH.PlaceholderText = "";
            this.txt_BCH.ReadOnly = true;
            this.txt_BCH.Selectable = false;
            this.txt_BCH.Size = new System.Drawing.Size(503, 33);
            this.txt_BCH.TabIndex = 3;
            this.txt_BCH.UnderlineStyle = true;
            this.txt_BCH.Value = "bitcoincash:qrf53klxwhh6t74cfdkv3u3knvhdtpwaku4qgdapja";
            // 
            // pic_BCH
            // 
            this.pic_BCH.BackColor = System.Drawing.Color.Transparent;
            this.pic_BCH.Image = global::MobaXtermKG.Properties.Resources.bch;
            this.pic_BCH.Location = new System.Drawing.Point(21, 439);
            this.pic_BCH.Name = "pic_BCH";
            this.pic_BCH.Size = new System.Drawing.Size(25, 25);
            this.pic_BCH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_BCH.TabIndex = 41;
            this.pic_BCH.TabStop = false;
            // 
            // pic_ETH
            // 
            this.pic_ETH.BackColor = System.Drawing.Color.Transparent;
            this.pic_ETH.Image = global::MobaXtermKG.Properties.Resources.eth;
            this.pic_ETH.Location = new System.Drawing.Point(21, 380);
            this.pic_ETH.Name = "pic_ETH";
            this.pic_ETH.Size = new System.Drawing.Size(25, 25);
            this.pic_ETH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ETH.TabIndex = 40;
            this.pic_ETH.TabStop = false;
            // 
            // pic_BTC
            // 
            this.pic_BTC.BackColor = System.Drawing.Color.Transparent;
            this.pic_BTC.Image = global::MobaXtermKG.Properties.Resources.btc;
            this.pic_BTC.Location = new System.Drawing.Point(21, 320);
            this.pic_BTC.Name = "pic_BTC";
            this.pic_BTC.Size = new System.Drawing.Size(25, 25);
            this.pic_BTC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_BTC.TabIndex = 39;
            this.pic_BTC.TabStop = false;
            // 
            // lbl_BCH
            // 
            this.lbl_BCH.AutoSize = true;
            this.lbl_BCH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_BCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_BCH.Location = new System.Drawing.Point(11, 414);
            this.lbl_BCH.Name = "lbl_BCH";
            this.lbl_BCH.Size = new System.Drawing.Size(36, 19);
            this.lbl_BCH.TabIndex = 44;
            this.lbl_BCH.Text = "BCH";
            // 
            // lbl_ETH
            // 
            this.lbl_ETH.AutoSize = true;
            this.lbl_ETH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_ETH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_ETH.Location = new System.Drawing.Point(11, 355);
            this.lbl_ETH.Name = "lbl_ETH";
            this.lbl_ETH.Size = new System.Drawing.Size(33, 19);
            this.lbl_ETH.TabIndex = 43;
            this.lbl_ETH.Text = "ETH";
            // 
            // lbl_BTC
            // 
            this.lbl_BTC.AutoSize = true;
            this.lbl_BTC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_BTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_BTC.Location = new System.Drawing.Point(11, 295);
            this.lbl_BTC.Name = "lbl_BTC";
            this.lbl_BTC.Size = new System.Drawing.Size(31, 19);
            this.lbl_BTC.TabIndex = 42;
            this.lbl_BTC.Text = "BTC";
            // 
            // lbl_HeaderName
            // 
            this.lbl_HeaderName.AutoSize = true;
            this.lbl_HeaderName.Font = new System.Drawing.Font("Myriad Pro Light", 20F);
            this.lbl_HeaderName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(41)))), ((int)(((byte)(101)))));
            this.lbl_HeaderName.Location = new System.Drawing.Point(21, 36);
            this.lbl_HeaderName.Name = "lbl_HeaderName";
            this.lbl_HeaderName.Size = new System.Drawing.Size(129, 32);
            this.lbl_HeaderName.TabIndex = 45;
            this.lbl_HeaderName.Text = "Contribute";
            this.lbl_HeaderName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderName_MouseDown);
            this.lbl_HeaderName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderName_MouseMove);
            this.lbl_HeaderName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderName_MouseUp);
            // 
            // lbl_HeaderSub
            // 
            this.lbl_HeaderSub.AutoSize = true;
            this.lbl_HeaderSub.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.lbl_HeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_HeaderSub.Location = new System.Drawing.Point(24, 69);
            this.lbl_HeaderSub.Name = "lbl_HeaderSub";
            this.lbl_HeaderSub.Size = new System.Drawing.Size(51, 17);
            this.lbl_HeaderSub.TabIndex = 46;
            this.lbl_HeaderSub.Text = "Version";
            this.lbl_HeaderSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderSub_MouseDown);
            this.lbl_HeaderSub.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderSub_MouseMove);
            this.lbl_HeaderSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderSub_MouseUp);
            // 
            // FormContribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(530, 481);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_HeaderSub);
            this.Controls.Add(this.lbl_HeaderName);
            this.Controls.Add(this.lbl_BCH);
            this.Controls.Add(this.lbl_ETH);
            this.Controls.Add(this.lbl_BTC);
            this.Controls.Add(this.pic_BCH);
            this.Controls.Add(this.pic_ETH);
            this.Controls.Add(this.pic_BTC);
            this.Controls.Add(this.txt_BCH);
            this.Controls.Add(this.txt_ETH);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.txt_BTC);
            this.Controls.Add(this.lbl_Contrib_Intro);
            this.Controls.Add(this.imgHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormContribute";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MobaXterm : Contribute";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormContribute_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormContribute_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormContribute_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormContribute_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ETH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BTC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgHeader;
        private System.Windows.Forms.Label lbl_Contrib_Intro;
        private AetherxTextBox txt_BTC;
        private System.Windows.Forms.Label btn_Close;
        private AetherxTextBox txt_ETH;
        private AetherxTextBox txt_BCH;
        private System.Windows.Forms.PictureBox pic_BCH;
        private System.Windows.Forms.PictureBox pic_ETH;
        private System.Windows.Forms.PictureBox pic_BTC;
        private System.Windows.Forms.Label lbl_BCH;
        private System.Windows.Forms.Label lbl_ETH;
        private System.Windows.Forms.Label lbl_BTC;
        private System.Windows.Forms.Label lbl_HeaderName;
        private System.Windows.Forms.Label lbl_HeaderSub;
    }
}