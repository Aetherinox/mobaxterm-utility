using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace MobaXtermKG
{
    partial class FormParent
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

        protected override bool ShowKeyboardCues => true;

        /*
            Main Form > Rectangle
        */

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParent));
            this.minimizeBtn = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mnuTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlStatusStrip = new System.Windows.Forms.Panel();
            this.aetherxRTextBox1 = new MobaXtermKG.AetherxRTextBox();
            this.txtLicense = new MobaXtermKG.AetherxTextBox();
            this.txtVersion = new MobaXtermKG.AetherxTextBox();
            this.txtUsers = new MobaXtermKG.AetherxTextBox();
            this.txtName = new MobaXtermKG.AetherxTextBox();
            this.rtxt_Desc = new MobaXtermKG.AetherxRTextBox();
            this.btnOpenFolder = new MobaXtermKG.AetherxButton();
            this.btnGenerate = new MobaXtermKG.AetherxButton();
            this.mnuTop.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBtn.Location = new System.Drawing.Point(463, 12);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(13, 32);
            this.minimizeBtn.TabIndex = 8;
            this.minimizeBtn.Text = "―";
            this.minimizeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.minimizeBtn.Click += new System.EventHandler(this.btn_Window_Minimize_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.btn_Window_Minimize_MouseEnter);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.btn_Window_Minimize_MouseLeave);
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.closeBtn.Location = new System.Drawing.Point(488, 7);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(24, 32);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "x";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeBtn.Click += new System.EventHandler(this.btn_Window_Close_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.btn_Window_Close_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.btn_Window_Close_MouseLeave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.lblTitle.Location = new System.Drawing.Point(14, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(205, 30);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "MobaXterm Patcher";
            this.lblTitle.Click += new System.EventHandler(this.lbl_Title_Click);
            // 
            // mnuTop
            // 
            this.mnuTop.AutoSize = false;
            this.mnuTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.mnuTop.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuTop.GripMargin = new System.Windows.Forms.Padding(12, 2, 0, 2);
            this.mnuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnuTop.Location = new System.Drawing.Point(1, 46);
            this.mnuTop.Name = "mnuTop";
            this.mnuTop.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.mnuTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuTop.Size = new System.Drawing.Size(528, 32);
            this.mnuTop.TabIndex = 1;
            this.mnuTop.Text = "menuStrip1";
            this.mnuTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuTop_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 28);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.aboutToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.ForeColor = System.Drawing.Color.Red;
            this.statusStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(1, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(528, 30);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.LinkVisited = true;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(139, 19);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 28);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.aboutToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem3});
            this.aboutToolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(52, 28);
            this.aboutToolStripMenuItem2.Text = "About";
            // 
            // aboutToolStripMenuItem3
            // 
            this.aboutToolStripMenuItem3.Name = "aboutToolStripMenuItem3";
            this.aboutToolStripMenuItem3.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem3.Text = "About";
            // 
            // pnlStatusStrip
            // 
            this.pnlStatusStrip.BackColor = System.Drawing.Color.Transparent;
            this.pnlStatusStrip.Controls.Add(this.statusStrip);
            this.pnlStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusStrip.Location = new System.Drawing.Point(0, 355);
            this.pnlStatusStrip.Name = "pnlStatusStrip";
            this.pnlStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.pnlStatusStrip.Size = new System.Drawing.Size(530, 31);
            this.pnlStatusStrip.TabIndex = 22;
            // 
            // aetherxRTextBox1
            // 
            this.aetherxRTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aetherxRTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.aetherxRTextBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.aetherxRTextBox1.ForeColor = System.Drawing.Color.White;
            this.aetherxRTextBox1.Location = new System.Drawing.Point(19, 210);
            this.aetherxRTextBox1.Name = "aetherxRTextBox1";
            this.aetherxRTextBox1.ReadOnly = true;
            this.aetherxRTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.aetherxRTextBox1.Selectable = false;
            this.aetherxRTextBox1.Size = new System.Drawing.Size(493, 48);
            this.aetherxRTextBox1.TabIndex = 27;
            this.aetherxRTextBox1.Text = "License key automatically added to Custom.mxtpro file. No need to copy.";
            // 
            // txtLicense
            // 
            this.txtLicense.AllowFocus = false;
            this.txtLicense.AutoScroll = true;
            this.txtLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.txtLicense.BorderFocusColor = System.Drawing.Color.White;
            this.txtLicense.BorderSize = 1;
            this.txtLicense.Enabled = false;
            this.txtLicense.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLicense.ForeColor = System.Drawing.Color.White;
            this.txtLicense.Location = new System.Drawing.Point(19, 244);
            this.txtLicense.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicense.Multiline = false;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Padding = new System.Windows.Forms.Padding(6);
            this.txtLicense.PasswordChar = false;
            this.txtLicense.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtLicense.PlaceholderText = "Generated License";
            this.txtLicense.ReadOnly = true;
            this.txtLicense.Size = new System.Drawing.Size(493, 32);
            this.txtLicense.TabIndex = 4;
            this.txtLicense.UnderlineStyle = false;
            this.txtLicense.Value = "";
            this.txtLicense._TextChanged += new System.EventHandler(this.txtLicense__TextChanged);
            // 
            // txtVersion
            // 
            this.txtVersion.AllowFocus = true;
            this.txtVersion.AutoScroll = true;
            this.txtVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtVersion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.txtVersion.BorderFocusColor = System.Drawing.Color.White;
            this.txtVersion.BorderSize = 1;
            this.txtVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVersion.ForeColor = System.Drawing.Color.White;
            this.txtVersion.Location = new System.Drawing.Point(341, 146);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtVersion.Multiline = false;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Padding = new System.Windows.Forms.Padding(6);
            this.txtVersion.PasswordChar = false;
            this.txtVersion.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtVersion.PlaceholderText = "Version";
            this.txtVersion.ReadOnly = false;
            this.txtVersion.Size = new System.Drawing.Size(77, 32);
            this.txtVersion.TabIndex = 2;
            this.txtVersion.UnderlineStyle = false;
            this.txtVersion.Value = "";
            this.txtVersion._TextChanged += new System.EventHandler(this.txtVersion__TextChanged);
            this.txtVersion.MouseEnter += new System.EventHandler(this.txtVersion_MouseEnter);
            // 
            // txtUsers
            // 
            this.txtUsers.AllowFocus = true;
            this.txtUsers.AutoScroll = true;
            this.txtUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtUsers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.txtUsers.BorderFocusColor = System.Drawing.Color.White;
            this.txtUsers.BorderSize = 1;
            this.txtUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsers.ForeColor = System.Drawing.Color.White;
            this.txtUsers.Location = new System.Drawing.Point(426, 146);
            this.txtUsers.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsers.Multiline = false;
            this.txtUsers.Name = "txtUsers";
            this.txtUsers.Padding = new System.Windows.Forms.Padding(6);
            this.txtUsers.PasswordChar = false;
            this.txtUsers.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUsers.PlaceholderText = "Users";
            this.txtUsers.ReadOnly = false;
            this.txtUsers.Size = new System.Drawing.Size(86, 32);
            this.txtUsers.TabIndex = 3;
            this.txtUsers.UnderlineStyle = false;
            this.txtUsers.Value = "";
            this.txtUsers._TextChanged += new System.EventHandler(this.txtUsers__TextChanged);
            this.txtUsers.MouseEnter += new System.EventHandler(this.txtUsers_MouseEnter);
            // 
            // txtName
            // 
            this.txtName.AllowFocus = true;
            this.txtName.AutoScroll = true;
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.txtName.BorderFocusColor = System.Drawing.Color.White;
            this.txtName.BorderSize = 1;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(19, 146);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(6);
            this.txtName.PasswordChar = false;
            this.txtName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtName.PlaceholderText = "Name";
            this.txtName.ReadOnly = false;
            this.txtName.Size = new System.Drawing.Size(314, 32);
            this.txtName.TabIndex = 1;
            this.txtName.UnderlineStyle = false;
            this.txtName.Value = "";
            this.txtName._TextChanged += new System.EventHandler(this.txtName__TextChanged);
            this.txtName.MouseEnter += new System.EventHandler(this.txtName_MouseEnter);
            // 
            // rtxt_Desc
            // 
            this.rtxt_Desc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxt_Desc.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtxt_Desc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtxt_Desc.ForeColor = System.Drawing.Color.White;
            this.rtxt_Desc.Location = new System.Drawing.Point(19, 94);
            this.rtxt_Desc.Name = "rtxt_Desc";
            this.rtxt_Desc.ReadOnly = true;
            this.rtxt_Desc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxt_Desc.Selectable = false;
            this.rtxt_Desc.Size = new System.Drawing.Size(493, 48);
            this.rtxt_Desc.TabIndex = 26;
            this.rtxt_Desc.Text = "This program will generate a Custom.mxtpro license file which will be placed insi" +
    "de the install path of MobaXterm.";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.btnOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenFolder.FlatAppearance.BorderSize = 0;
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFolder.Location = new System.Drawing.Point(249, 299);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(156, 29);
            this.btnOpenFolder.TabIndex = 6;
            this.btnOpenFolder.Text = "&Open MobaXT Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            this.btnOpenFolder.MouseEnter += new System.EventHandler(this.btnOpenFolder_MouseEnter);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(6)))), ((int)(((byte)(85)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(129, 299);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(111, 29);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "&Generate License";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            this.btnGenerate.MouseEnter += new System.EventHandler(this.btnGenerate_MouseEnter);
            // 
            // FormParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(530, 386);
            this.Controls.Add(this.aetherxRTextBox1);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.txtUsers);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.rtxt_Desc);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.pnlStatusStrip);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.mnuTop);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuTop;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormParent";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   ";
            this.Load += new System.EventHandler(this.FormParent_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.mnuTop.ResumeLayout(false);
            this.mnuTop.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlStatusStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label minimizeBtn;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MenuStrip mnuTop;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem2;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem3;
        private AetherxButton btnGenerate;
        private Panel pnlStatusStrip;
        private AetherxButton btnOpenFolder;
        private AetherxRTextBox rtxt_Desc;
        private AetherxTextBox txtName;
        private AetherxTextBox txtUsers;
        private AetherxTextBox txtVersion;
        private AetherxTextBox txtLicense;
        private AetherxRTextBox aetherxRTextBox1;
    }
}

