using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Drawing;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Globalization;
using System.Threading;
using Microsoft.VisualBasic.Logging;
using Lng = MobaXtermKG.Properties.Resources;
using Cfg = MobaXtermKG.Properties.Settings;

namespace MobaXtermKG
{

    public partial class FormParent : Form
    {

        /*
            Classes
        */

        readonly Serial Serial = new Serial();
        readonly Helpers Helpers = new Helpers();

        /*
            variables > resource (cli exe)
        */

        static private string app_exe = Cfg.Default.app_def_exe;
        static private string app_loc = AppDomain.CurrentDomain.BaseDirectory + "\\" + app_exe;
        readonly private string app_cli = "& \"" + app_loc + "\"";

        /*
            variables > default values
        */

        readonly private string cfg_def_mxtpro = AppDomain.CurrentDomain.BaseDirectory + @"\" + Cfg.Default.app_def_mxtpro;
        readonly private string cfg_def_version = Properties.Settings.Default.app_def_version;
        readonly string cfg_def_users = Properties.Settings.Default.app_def_users;

        /*
            variables > default values
        */

        private string app_base_path = AppDomain.CurrentDomain.BaseDirectory;
        readonly string src_target_exe = Properties.Settings.Default.src_res_moba_exe;

        /*
            Frame > Parent
        */

        public FormParent()
        {

            InitializeComponent();

            this.statusStrip.Renderer   = new StatusBar_Renderer();

            /*
                Richtext box at top of interface
            */

            string l1 = Lng.program_will_generate;
            string l2 = Cfg.Default.app_def_mxtpro;
            string l3 = Lng.license_file_inside_mobaxterm;

            rtxt_Desc.Text = "";

            rtxt_Desc.AppendText(l1);
            rtxt_Desc.Select(0, l1.Length);
            rtxt_Desc.SelectionColor = Color.White;

            rtxt_Desc.AppendText(" ");

            rtxt_Desc.AppendText(l2);
            rtxt_Desc.Select(l1.Length + 1, l2.Length);
            rtxt_Desc.SelectionColor = Color.FromArgb(31, 133, 222);

            rtxt_Desc.AppendText(" ");

            rtxt_Desc.AppendText(l3);
            rtxt_Desc.Select(l1.Length + 1 + l2.Length + 1, l3.Length);
            rtxt_Desc.SelectionColor = Color.White;

            string ver = AppInfo.ProductVersionCore.ToString();
            string product = AppInfo.Title;
            string tm = AppInfo.Trademark;
  
            lblTitle.Text = product;

            // Export patched resource file
            File.WriteAllBytes(app_exe, MobaXtermKG.Properties.Resources.mobaxtgen_cli);

            if (!File.Exists(app_exe))
            {

                MessageBox.Show(
                    string.Format(Lng.msgbox_err_libmissing_msg, Environment.NewLine, app_exe, Environment.NewLine, Environment.NewLine),
                    Lng.msgbox_err_libmissing_title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                toolStripStatusLabel1.Text = string.Format(Lng.statusbar_libmissing, app_exe);
                statusStrip.Refresh();
            }
        }

        /*
            Frame > Parent > Load
        */

        private void FormParent_Load(object sender, EventArgs e)
        {
            mnuTop.Renderer = new ToolStripProfessionalRenderer(new mnuTop_ColorTable());
            toolStripStatusLabel1.Text = string.Format(Lng.statusbar_genlicense);
            statusStrip.Refresh();
        }

        /*
            Window > Button > Minimize > Click
        */

        private void btn_Window_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*
            Window > Button > Minimize > Mouse Enter
        */

        private void btn_Window_Minimize_MouseEnter(object sender, EventArgs e)
        {
            minimizeBtn.ForeColor = Color.FromArgb(222, 31, 100);
        }

        /*
            Window > Button > Minimize > Mouse Leave
        */

        private void btn_Window_Minimize_MouseLeave(object sender, EventArgs e)
        {
            minimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);
        }

        /*
            Window > Button > Close > Click
        */

        private void btn_Window_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*
            Window > Button > Close > Mouse Enter
        */

        private void btn_Window_Close_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.ForeColor = Color.FromArgb(222, 31, 100);
        }

        /*
            Window > Button > Close > Mouse Leave
        */

        private void btn_Window_Close_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.ForeColor = Color.FromArgb(255, 255, 255);
        }

        /*
            Main Form > Mouse Down
            deals with moving form around on screen
        */

        private bool mouseDown;
        private Point lastLocation;

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        /*
            Main Form > Mouse Up
            deals with moving form around on screen
        */

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /*
            Main Form > Mouse Move
            deals with moving form around on screen
        */

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y
                );

                this.Update();
            }
        }

        /*
            Label > Window Title
        */

        private void lbl_Title_Click(object sender, EventArgs e) { }

        /*
            Top Menu > File > Exit
        */

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*
            Top Menu > Help > About
        */

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAbout to = new FormAbout();
            to.TopMost = true;
            to.Show();
        }

        /*
            Top Menu > Click Item
        */

        private void mnuTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        /*
            Status Bar > Color Table
        */

        public class ClrTable : ProfessionalColorTable
        {
            public override Color StatusStripGradientBegin => Color.FromArgb(35, 35, 35);
            public override Color StatusStripGradientEnd => Color.FromArgb(35, 35, 35);
        }

        /*
            Status Bar > Renderer
            Override colors
        */

        public class StatusBar_Renderer : ToolStripProfessionalRenderer
        {
            public StatusBar_Renderer()
                : base(new ClrTable()) { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                if (!(e.ToolStrip is StatusStrip))
                    base.OnRenderToolStripBorder(e);
            }
        }

        /*
            Top Menu > Override Render Colors
        */

        public class mnuTop_ColorTable : ProfessionalColorTable
        {
            /*
                Gets the starting color of the gradient used when
                a top-level System.Windows.Forms.ToolStripMenuItem is pressed.
            */

            public override Color MenuItemPressedGradientBegin => Color.FromArgb(55, 55, 55);

            /*
                Gets the end color of the gradient used when a top-level
                System.Windows.Forms.ToolStripMenuItem is pressed.
            */

            public override Color MenuItemPressedGradientEnd => Color.FromArgb(55, 55, 55);

            /*
                Gets the border color to use with a
                System.Windows.Forms.ToolStripMenuItem.
            */

            public override Color MenuItemBorder => Color.FromArgb(0, 45, 45, 45);

            /*
                Gets the starting color of the gradient used when the
                System.Windows.Forms.ToolStripMenuItem is selected.
            */

            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(222, 31, 103);

            /*
                Gets the end color of the gradient used when the
                System.Windows.Forms.ToolStripMenuItem is selected.
            */

            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(222, 31, 103);

            /*
                Gets the solid background color of the
                System.Windows.Forms.ToolStripDropDown.
            */

            public override Color ToolStripDropDownBackground => Color.FromArgb(40, 40, 40);

            /*
                Top Menu > Image > Start Gradient Color
            */

            public override Color ImageMarginGradientBegin => Color.FromArgb(222, 31, 103);

            /*
                Top Menu > Image > Middle Gradient Color
            */

            public override Color ImageMarginGradientMiddle => Color.FromArgb(222, 31, 103);

            /*
                Top Menu > Image > End Gradient Color
            */

            public override Color ImageMarginGradientEnd => Color.FromArgb(222, 31, 103);

            /*
                Top Menu > Shadow Effect
            */

            public override Color SeparatorDark => Color.FromArgb(0, 45, 45, 45);

            /*
                Top Menu > Border Color
            */

            public override Color MenuBorder => Color.FromArgb(0, 45, 45, 45);

            /*
                 Top Menu > Item Hover BG Color
             */

            public override Color MenuItemSelected => Color.FromArgb(222, 31, 103);
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        /*
             button > generate > mouse enter
         */

        private void btnGenerate_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format(Lng.statusbar_genlicense);
            statusStrip.Refresh();
        }

        /*
             button > generate > mouse click
         */

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            /*
                 name not provided
            */

            if (string.IsNullOrEmpty(txtName.Value))
            {
                MessageBox.Show(
                    Lng.msgbox_err_generate_noname_msg,
                    Lng.msgbox_err_generate_noname_title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            /*
                 proceed to patch
            */

            else
            {
                var result = MessageBox.Show(
                     Lng.msgbox_ok_generate_msg,
                     Lng.msgbox_ok_generate_title,
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question
                 );

                string answer = result.ToString();

                // proceed with patch
                if (answer == "Yes")
                {

                    string fval_name = txtName.Value;
                    string fval_ver = txtVersion.Value;
                    string fval_users = txtUsers.Value;

                    /*
                         default version
                    */

                    if (String.IsNullOrEmpty(fval_ver) || fval_ver == "0")
                    {
                        txtVersion.isPlaceholder = false;
                        txtVersion.Value = cfg_def_version;
                        fval_ver = cfg_def_version;
                    }

                    /*
                         default user
                    */

                    if (String.IsNullOrEmpty(fval_users) || fval_users == "0")
                    {
                        txtUsers.isPlaceholder = false;
                        txtUsers.Value = cfg_def_users;
                        fval_users = cfg_def_users;
                    }

                    /*
                         python execution

                         grabs all entered values and communicates with the python script
                         to generate a license key + license key file.

                         license key file will be placed in whatever folder the keygen is in.
                    */

                    string app_qry = Serial.Generate(app_cli + " -s " + fval_name + " " + fval_ver + " " + fval_users );

                    txtLicense.isPlaceholder = false;
                    txtLicense.Value = app_qry;

                    /*
                         move generated license key file
                    */

                    string path_installed_app = Helpers.FindApp(src_target_exe);

                    /*
                        path_installed_app
                        C:\Program Files (x86)\Mobatek\MobaXterm

                        cfg_def_mxtpro
                        X:\Apps\MobaXterm\source\bin\Release\Custom.mxtpro
                    */

                    //  if FILE exists
                    //      X:\Apps\MobaXterm\source\bin\Release\Custom.mxtpro
                    if (File.Exists(cfg_def_mxtpro))
                    {

                        //  if directory exists
                        //      C:\Program Files (x86)\Mobatek\MobaXterm
                        if (Directory.Exists(path_installed_app))
                        {
                            string file_mtx = Properties.Settings.Default.app_def_mxtpro;

                            // an extra check if a license key already exists
                            // move C:\Program Files (x86)\Mobatek\MobaXterm\Custom.mxtpro -> C:\Program Files (x86)\Mobatek\MobaXterm\Custom.mxtpro.bak

                            string a1 = @path_installed_app + @"\" + file_mtx;
                            string b1 = @path_installed_app + @"\" + file_mtx + ".bak";

                            // delete extra .bak otherwise we will error out
                            if (File.Exists(b1))
                                File.Delete(b1);

                            if (File.Exists(a1))
                                File.Move(a1, b1);

                            // move new Custom.mxtpro to C:\Program Files (x86)\Mobatek\MobaXterm
                            string a2 = file_mtx;
                            string b2 = @path_installed_app + @"\" + file_mtx;

                            if (File.Exists(a2))
                                File.Move(a2, b2);

                        }

                    }
                }
            }
        }

        /*
            button > hover
        */

        private void btnOpenFolder_MouseEnter( object sender, EventArgs e )
        {
            toolStripStatusLabel1.Text = string.Format(Lng.statusbar_btn_openfolder);
            statusStrip.Refresh();
        }

        /*
            button > open folder where mirc "should" be
        */

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string path_mirc = Helpers.FindApp(src_target_exe);

            /*
                mirc found
            */

            if (Directory.Exists(path_mirc))
            {
                Process.Start("explorer.exe", @path_mirc);
            }

            /*
                cannot locate mobaxterm program. Open dialog in Program Files(86)
            */

            else
            {
                string path_86 = Helpers.ProgramFilesx86();
                Process.Start("explorer.exe", path_86);
            }
        }

        private void txtLicense__TextChanged(object sender, EventArgs e)
        {

        }

        /*
            txtbox > version > text changed
        */

        private void txtVersion__TextChanged(object sender, EventArgs e)
        {

        }

        /*
            txtbox > version > mouse enter
        */

        private void txtVersion_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format(Lng.statusbar_txt_version_mouseover + " " + Cfg.Default.app_def_version);
            statusStrip.Refresh();
        }

        /*
            txtbox > users > text changed
        */

        private void txtUsers__TextChanged(object sender, EventArgs e)
        {

        }

        /*
            txtbox > users > mouse enter
        */

        private void txtUsers_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format(Lng.statusbar_txt_users_mouseover + " " + Cfg.Default.app_def_users);
            statusStrip.Refresh();
        }

        /*
            txtbox > name > text changed
        */

        private void txtName__TextChanged(object sender, EventArgs e)
        {

        }

        /*
            txtbox > name > mouse enter
        */

        private void txtName_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format(Lng.statusbar_txt_name_mouseover);
            statusStrip.Refresh();
        }
    }
}
