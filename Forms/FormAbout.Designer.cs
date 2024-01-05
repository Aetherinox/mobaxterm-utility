using System.Drawing;
using System.Windows.Forms;

namespace MobaXtermKG
{
    partial class FormAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen clr_border = new Pen(Color.FromArgb(75, 75, 75));
            e.Graphics.DrawRectangle(clr_border, 0, 0, Width - 1, Height - 1);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lnk_TPB = new System.Windows.Forms.LinkLabel();
            this.lnk_Github = new System.Windows.Forms.LinkLabel();
            this.lbl_Dev_PIV_Thumbprint = new System.Windows.Forms.Label();
            this.lbl_Dev_GPG_KeyID = new System.Windows.Forms.Label();
            this.imgHeader = new System.Windows.Forms.PictureBox();
            this.lbl_HeaderSub = new System.Windows.Forms.Label();
            this.lbl_HeaderName = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.pnl_HeaderBtm = new System.Windows.Forms.PictureBox();
            this.txt_Dev_GPG_KeyID = new MobaXtermKG.AetherxTextBox();
            this.txt_Dev_PIV_Thumbprint = new MobaXtermKG.AetherxTextBox();
            this.txt_Terms = new MobaXtermKG.AetherxTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_HeaderBtm)).BeginInit();
            this.SuspendLayout();
            // 
            // lnk_TPB
            // 
            this.lnk_TPB.AutoSize = true;
            this.lnk_TPB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnk_TPB.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnk_TPB.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lnk_TPB.Location = new System.Drawing.Point(25, 104);
            this.lnk_TPB.Name = "lnk_TPB";
            this.lnk_TPB.Size = new System.Drawing.Size(74, 19);
            this.lnk_TPB.TabIndex = 1;
            this.lnk_TPB.TabStop = true;
            this.lnk_TPB.Text = "TPB Profile";
            this.lnk_TPB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_TPB_LinkClicked);
            this.lnk_TPB.Paint += new System.Windows.Forms.PaintEventHandler(this.lnk_TPB_Paint);
            this.lnk_TPB.MouseEnter += new System.EventHandler(this.lnk_TPB_MouseEnter);
            this.lnk_TPB.MouseLeave += new System.EventHandler(this.lnk_TPB_MouseLeave);
            // 
            // lnk_Github
            // 
            this.lnk_Github.AutoSize = true;
            this.lnk_Github.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnk_Github.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnk_Github.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lnk_Github.Location = new System.Drawing.Point(105, 104);
            this.lnk_Github.Name = "lnk_Github";
            this.lnk_Github.Size = new System.Drawing.Size(86, 19);
            this.lnk_Github.TabIndex = 2;
            this.lnk_Github.TabStop = true;
            this.lnk_Github.Text = "Github Repo";
            this.lnk_Github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Github_LinkClicked);
            this.lnk_Github.Paint += new System.Windows.Forms.PaintEventHandler(this.lnk_Github_Paint);
            this.lnk_Github.MouseEnter += new System.EventHandler(this.lnk_Github_MouseEnter);
            this.lnk_Github.MouseLeave += new System.EventHandler(this.lnk_Github_MouseLeave);
            // 
            // lbl_Dev_PIV_Thumbprint
            // 
            this.lbl_Dev_PIV_Thumbprint.AutoSize = true;
            this.lbl_Dev_PIV_Thumbprint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Dev_PIV_Thumbprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_Dev_PIV_Thumbprint.Location = new System.Drawing.Point(11, 346);
            this.lbl_Dev_PIV_Thumbprint.Name = "lbl_Dev_PIV_Thumbprint";
            this.lbl_Dev_PIV_Thumbprint.Size = new System.Drawing.Size(45, 19);
            this.lbl_Dev_PIV_Thumbprint.TabIndex = 10;
            this.lbl_Dev_PIV_Thumbprint.Text = "label1";
            // 
            // lbl_Dev_GPG_KeyID
            // 
            this.lbl_Dev_GPG_KeyID.AutoSize = true;
            this.lbl_Dev_GPG_KeyID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Dev_GPG_KeyID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_Dev_GPG_KeyID.Location = new System.Drawing.Point(11, 411);
            this.lbl_Dev_GPG_KeyID.Name = "lbl_Dev_GPG_KeyID";
            this.lbl_Dev_GPG_KeyID.Size = new System.Drawing.Size(45, 19);
            this.lbl_Dev_GPG_KeyID.TabIndex = 12;
            this.lbl_Dev_GPG_KeyID.Text = "label2";
            // 
            // imgHeader
            // 
            this.imgHeader.BackgroundImage = global::MobaXtermKG.Properties.Resources.bg_header;
            this.imgHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgHeader.Location = new System.Drawing.Point(1, 1);
            this.imgHeader.Name = "imgHeader";
            this.imgHeader.Size = new System.Drawing.Size(528, 129);
            this.imgHeader.TabIndex = 13;
            this.imgHeader.TabStop = false;
            this.imgHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.imgHeader_Paint);
            this.imgHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseDown);
            this.imgHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseMove);
            this.imgHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgHeader_MouseUp);
            // 
            // lbl_HeaderSub
            // 
            this.lbl_HeaderSub.AutoSize = true;
            this.lbl_HeaderSub.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.lbl_HeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lbl_HeaderSub.Location = new System.Drawing.Point(24, 56);
            this.lbl_HeaderSub.Name = "lbl_HeaderSub";
            this.lbl_HeaderSub.Size = new System.Drawing.Size(341, 17);
            this.lbl_HeaderSub.TabIndex = 15;
            this.lbl_HeaderSub.Text = "Educational purposes only. No ads, no music, no bullshit.";
            this.lbl_HeaderSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderSub_MouseDown);
            this.lbl_HeaderSub.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderSub_MouseMove);
            this.lbl_HeaderSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderSub_MouseUp);
            // 
            // lbl_HeaderName
            // 
            this.lbl_HeaderName.AutoSize = true;
            this.lbl_HeaderName.Font = new System.Drawing.Font("Myriad Pro Light", 20F);
            this.lbl_HeaderName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(41)))), ((int)(((byte)(101)))));
            this.lbl_HeaderName.Location = new System.Drawing.Point(21, 23);
            this.lbl_HeaderName.Name = "lbl_HeaderName";
            this.lbl_HeaderName.Size = new System.Drawing.Size(79, 32);
            this.lbl_HeaderName.TabIndex = 14;
            this.lbl_HeaderName.Text = "label1";
            this.lbl_HeaderName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderName_MouseDown);
            this.lbl_HeaderName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderName_MouseMove);
            this.lbl_HeaderName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_HeaderName_MouseUp);
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
            this.btn_Close.TabIndex = 16;
            this.btn_Close.Text = "";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btn_Window_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Window_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Window_Close_MouseLeave);
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Version.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Version.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_Version.Location = new System.Drawing.Point(375, 104);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(127, 19);
            this.lbl_Version.TabIndex = 17;
            this.lbl_Version.Text = "v1.2.0.0 by Aetherx";
            this.lbl_Version.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lbl_Version.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_Version_Paint);
            // 
            // pnl_HeaderBtm
            // 
            this.pnl_HeaderBtm.Location = new System.Drawing.Point(1, 98);
            this.pnl_HeaderBtm.Name = "pnl_HeaderBtm";
            this.pnl_HeaderBtm.Size = new System.Drawing.Size(528, 32);
            this.pnl_HeaderBtm.TabIndex = 18;
            this.pnl_HeaderBtm.TabStop = false;
            this.pnl_HeaderBtm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_HeaderBtm_Paint);
            this.pnl_HeaderBtm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_HeaderBtm_MouseDown);
            this.pnl_HeaderBtm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_HeaderBtm_MouseMove);
            this.pnl_HeaderBtm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_HeaderBtm_MouseUp);
            // 
            // txt_Dev_GPG_KeyID
            // 
            this.txt_Dev_GPG_KeyID.AllowFocus = true;
            this.txt_Dev_GPG_KeyID.AutoScroll = true;
            this.txt_Dev_GPG_KeyID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_Dev_GPG_KeyID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_Dev_GPG_KeyID.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_Dev_GPG_KeyID.BorderSize = 1;
            this.txt_Dev_GPG_KeyID.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Dev_GPG_KeyID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_Dev_GPG_KeyID.Location = new System.Drawing.Point(15, 432);
            this.txt_Dev_GPG_KeyID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Dev_GPG_KeyID.Multiline = false;
            this.txt_Dev_GPG_KeyID.MultilineScrollbars = true;
            this.txt_Dev_GPG_KeyID.Name = "txt_Dev_GPG_KeyID";
            this.txt_Dev_GPG_KeyID.Padding = new System.Windows.Forms.Padding(6);
            this.txt_Dev_GPG_KeyID.PasswordChar = false;
            this.txt_Dev_GPG_KeyID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_Dev_GPG_KeyID.PlaceholderText = "";
            this.txt_Dev_GPG_KeyID.ReadOnly = true;
            this.txt_Dev_GPG_KeyID.Selectable = true;
            this.txt_Dev_GPG_KeyID.Size = new System.Drawing.Size(504, 33);
            this.txt_Dev_GPG_KeyID.TabIndex = 11;
            this.txt_Dev_GPG_KeyID.UnderlineStyle = true;
            this.txt_Dev_GPG_KeyID.Value = "";
            // 
            // txt_Dev_PIV_Thumbprint
            // 
            this.txt_Dev_PIV_Thumbprint.AllowFocus = true;
            this.txt_Dev_PIV_Thumbprint.AutoScroll = true;
            this.txt_Dev_PIV_Thumbprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_Dev_PIV_Thumbprint.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_Dev_PIV_Thumbprint.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_Dev_PIV_Thumbprint.BorderSize = 1;
            this.txt_Dev_PIV_Thumbprint.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_Dev_PIV_Thumbprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_Dev_PIV_Thumbprint.Location = new System.Drawing.Point(15, 367);
            this.txt_Dev_PIV_Thumbprint.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Dev_PIV_Thumbprint.Multiline = false;
            this.txt_Dev_PIV_Thumbprint.MultilineScrollbars = true;
            this.txt_Dev_PIV_Thumbprint.Name = "txt_Dev_PIV_Thumbprint";
            this.txt_Dev_PIV_Thumbprint.Padding = new System.Windows.Forms.Padding(6);
            this.txt_Dev_PIV_Thumbprint.PasswordChar = false;
            this.txt_Dev_PIV_Thumbprint.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_Dev_PIV_Thumbprint.PlaceholderText = "";
            this.txt_Dev_PIV_Thumbprint.ReadOnly = true;
            this.txt_Dev_PIV_Thumbprint.Selectable = true;
            this.txt_Dev_PIV_Thumbprint.Size = new System.Drawing.Size(504, 33);
            this.txt_Dev_PIV_Thumbprint.TabIndex = 9;
            this.txt_Dev_PIV_Thumbprint.UnderlineStyle = true;
            this.txt_Dev_PIV_Thumbprint.Value = "";
            // 
            // txt_Terms
            // 
            this.txt_Terms.AllowFocus = false;
            this.txt_Terms.AutoScroll = true;
            this.txt_Terms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txt_Terms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(41)))), ((int)(((byte)(99)))));
            this.txt_Terms.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txt_Terms.BorderSize = 1;
            this.txt_Terms.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Terms.ForeColor = System.Drawing.Color.White;
            this.txt_Terms.Location = new System.Drawing.Point(15, 143);
            this.txt_Terms.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Terms.Multiline = true;
            this.txt_Terms.MultilineScrollbars = true;
            this.txt_Terms.Name = "txt_Terms";
            this.txt_Terms.Padding = new System.Windows.Forms.Padding(5);
            this.txt_Terms.PasswordChar = false;
            this.txt_Terms.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txt_Terms.PlaceholderText = "";
            this.txt_Terms.ReadOnly = true;
            this.txt_Terms.Selectable = false;
            this.txt_Terms.Size = new System.Drawing.Size(504, 191);
            this.txt_Terms.TabIndex = 3;
            this.txt_Terms.UnderlineStyle = false;
            this.txt_Terms.Value = "";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(530, 481);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.lnk_TPB);
            this.Controls.Add(this.lnk_Github);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_HeaderSub);
            this.Controls.Add(this.lbl_HeaderName);
            this.Controls.Add(this.lbl_Dev_GPG_KeyID);
            this.Controls.Add(this.txt_Dev_GPG_KeyID);
            this.Controls.Add(this.lbl_Dev_PIV_Thumbprint);
            this.Controls.Add(this.txt_Dev_PIV_Thumbprint);
            this.Controls.Add(this.txt_Terms);
            this.Controls.Add(this.pnl_HeaderBtm);
            this.Controls.Add(this.imgHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MobaXterm : About";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormAbout_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormAbout_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormAbout_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.imgHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_HeaderBtm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LinkLabel lnk_TPB;
        private LinkLabel lnk_Github;
        private AetherxTextBox txt_Terms;
        private AetherxTextBox txt_Dev_PIV_Thumbprint;
        private Label lbl_Dev_PIV_Thumbprint;
        private Label lbl_Dev_GPG_KeyID;
        private AetherxTextBox txt_Dev_GPG_KeyID;
        private Label lbl_HeaderSub;
        private Label lbl_HeaderName;
        private Label btn_Close;
        private Label lbl_Version;
        private PictureBox imgHeader;
        private PictureBox pnl_HeaderBtm;
    }
}