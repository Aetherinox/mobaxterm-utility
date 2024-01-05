
namespace MobaXtermKG.Msgbox
{
    partial class FormMessageBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageBox));
            this.pnl_Titlebar = new System.Windows.Forms.Panel();
            this.lbl_Caption = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pnl_Buttons = new System.Windows.Forms.Panel();
            this.btn_3 = new MobaXtermKG.AetherxButton();
            this.btn_2 = new MobaXtermKG.AetherxButton();
            this.btn_1 = new MobaXtermKG.AetherxButton();
            this.pnl_Body = new System.Windows.Forms.Panel();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.img_Icon = new System.Windows.Forms.PictureBox();
            this.pnl_Titlebar.SuspendLayout();
            this.pnl_Buttons.SuspendLayout();
            this.pnl_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Titlebar
            // 
            this.pnl_Titlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnl_Titlebar.Controls.Add(this.lbl_Caption);
            this.pnl_Titlebar.Controls.Add(this.btn_Close);
            this.pnl_Titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Titlebar.Location = new System.Drawing.Point(2, 2);
            this.pnl_Titlebar.Name = "pnl_Titlebar";
            this.pnl_Titlebar.Size = new System.Drawing.Size(376, 28);
            this.pnl_Titlebar.TabIndex = 0;
            this.pnl_Titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Titlebar_MouseDown);
            // 
            // lbl_Caption
            // 
            this.lbl_Caption.AutoSize = true;
            this.lbl_Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Caption.ForeColor = System.Drawing.Color.White;
            this.lbl_Caption.Location = new System.Drawing.Point(9, 5);
            this.lbl_Caption.Name = "lbl_Caption";
            this.lbl_Caption.Size = new System.Drawing.Size(96, 17);
            this.lbl_Caption.TabIndex = 4;
            this.lbl_Caption.Text = "Message Title";
            // 
            // btn_Close
            // 
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(79)))), ((int)(((byte)(95)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(346, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btn_Close.Size = new System.Drawing.Size(30, 28);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            // 
            // pnl_Buttons
            // 
            this.pnl_Buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.pnl_Buttons.Controls.Add(this.btn_3);
            this.pnl_Buttons.Controls.Add(this.btn_2);
            this.pnl_Buttons.Controls.Add(this.btn_1);
            this.pnl_Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Buttons.Location = new System.Drawing.Point(2, 88);
            this.pnl_Buttons.Name = "pnl_Buttons";
            this.pnl_Buttons.Size = new System.Drawing.Size(376, 60);
            this.pnl_Buttons.TabIndex = 1;
            this.pnl_Buttons.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Buttons_MouseDown);
            // 
            // btn_3
            // 
            this.btn_3.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_3.FlatAppearance.BorderSize = 0;
            this.btn_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_3.Location = new System.Drawing.Point(231, 12);
            this.btn_3.Name = "btn_3";
            this.btn_3.Size = new System.Drawing.Size(100, 28);
            this.btn_3.TabIndex = 2;
            this.btn_3.Text = "button3";
            this.btn_3.UseVisualStyleBackColor = false;
            // 
            // btn_2
            // 
            this.btn_2.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_2.FlatAppearance.BorderSize = 0;
            this.btn_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_2.Location = new System.Drawing.Point(125, 12);
            this.btn_2.Name = "btn_2";
            this.btn_2.Size = new System.Drawing.Size(100, 28);
            this.btn_2.TabIndex = 1;
            this.btn_2.Text = "button2";
            this.btn_2.UseVisualStyleBackColor = false;
            // 
            // btn_1
            // 
            this.btn_1.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_1.FlatAppearance.BorderSize = 0;
            this.btn_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_1.Location = new System.Drawing.Point(19, 12);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(100, 28);
            this.btn_1.TabIndex = 0;
            this.btn_1.Text = "button1";
            this.btn_1.UseVisualStyleBackColor = false;
            // 
            // pnl_Body
            // 
            this.pnl_Body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnl_Body.Controls.Add(this.lbl_Message);
            this.pnl_Body.Controls.Add(this.img_Icon);
            this.pnl_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Body.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pnl_Body.Location = new System.Drawing.Point(2, 30);
            this.pnl_Body.Name = "pnl_Body";
            this.pnl_Body.Padding = new System.Windows.Forms.Padding(18, 13, 5, 0);
            this.pnl_Body.Size = new System.Drawing.Size(376, 58);
            this.pnl_Body.TabIndex = 2;
            this.pnl_Body.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Body_MouseDown);
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbl_Message.ForeColor = System.Drawing.Color.White;
            this.lbl_Message.Location = new System.Drawing.Point(58, 13);
            this.lbl_Message.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lbl_Message.MaximumSize = new System.Drawing.Size(700, 0);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Padding = new System.Windows.Forms.Padding(5, 5, 22, 15);
            this.lbl_Message.Size = new System.Drawing.Size(195, 35);
            this.lbl_Message.TabIndex = 1;
            this.lbl_Message.Text = "This is a notification message";
            this.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Message.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_Message_MouseDown);
            // 
            // img_Icon
            // 
            this.img_Icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.img_Icon.Image = ((System.Drawing.Image)(resources.GetObject("img_Icon.Image")));
            this.img_Icon.Location = new System.Drawing.Point(18, 13);
            this.img_Icon.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.img_Icon.Name = "img_Icon";
            this.img_Icon.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.img_Icon.Size = new System.Drawing.Size(40, 45);
            this.img_Icon.TabIndex = 0;
            this.img_Icon.TabStop = false;
            // 
            // FormMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(380, 150);
            this.Controls.Add(this.pnl_Body);
            this.Controls.Add(this.pnl_Buttons);
            this.Controls.Add(this.pnl_Titlebar);
            this.MinimumSize = new System.Drawing.Size(380, 150);
            this.Name = "FormMessageBox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.pnl_Titlebar.ResumeLayout(false);
            this.pnl_Titlebar.PerformLayout();
            this.pnl_Buttons.ResumeLayout(false);
            this.pnl_Body.ResumeLayout(false);
            this.pnl_Body.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Titlebar;
        private System.Windows.Forms.Panel pnl_Buttons;
        private AetherxButton btn_3;
        private AetherxButton btn_2;
        private AetherxButton btn_1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel pnl_Body;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.PictureBox img_Icon;
        private System.Windows.Forms.Label lbl_Caption;
    }
}

