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
using System.ComponentModel;

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
            variables > current keygen path / folder
        */

        static private string app_base_path = AppDomain.CurrentDomain.BaseDirectory;

        /*
            variables > resource (cli exe)

            [x] app_cli_exe         mobaxtgen_cli.exe
            [x] app_cli_path        keygen current path\mobaxtgen_cli.exe
        */

        static private string app_cli_exe           = Cfg.Default.app_cli_exe;
        static private string app_cli_path          = app_base_path + "\\" + app_cli_exe;

        /*
            variables > default form values
        */

        readonly private string cfg_def_version     = Cfg.Default.app_def_version;
        readonly string cfg_def_users               = Cfg.Default.app_def_users;

        /*
            variables > default values
        */

        readonly string target_exe_name = Cfg.Default.src_res_moba_exe;

        /*
            Frame > Parent
        */

        public FormParent()
        {

            InitializeComponent();

            this.statusStrip.Renderer = new StatusBar_Renderer();

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
            File.WriteAllBytes(app_cli_exe, MobaXtermKG.Properties.Resources.mobaxtgen_cli);

            if (!File.Exists(app_cli_exe))
            {

                MessageBox.Show(
                    string.Format(Lng.msgbox_err_libmissing_msg, Environment.NewLine, app_cli_exe, Environment.NewLine, Environment.NewLine),
                    Lng.msgbox_err_libmissing_title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                toolStripStatusLabel1.Text = string.Format(Lng.statusbar_libmissing, app_cli_exe);
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
                 no errors > proceed to patch
            */

            else
            {

                /*
                     Do you wish to generate a new license key for MobaXterm?
                */

                var result = MessageBox.Show(
                     Lng.msgbox_ok_generate_msg,
                     Lng.msgbox_ok_generate_title,
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question
                 );

                string answer = result.ToString();

                /*
                     MessageBox Confirmation > yes
                */

                if (answer == "Yes")
                {

                    string fval_name = txtName.Value;
                    string fval_ver = txtVersion.Value;
                    string fval_users = txtUsers.Value;

                    /*
                         default version textbox value
                    */

                    if (String.IsNullOrEmpty(fval_ver) || fval_ver == "0")
                    {
                        txtVersion.isPlaceholder = false;
                        txtVersion.Value = cfg_def_version;
                        fval_ver = cfg_def_version;
                    }

                    /*
                         default user textbox value
                    */

                    if (String.IsNullOrEmpty(fval_users) || fval_users == "0")
                    {
                        txtUsers.isPlaceholder = false;
                        txtUsers.Value = cfg_def_users;
                        fval_users = cfg_def_users;
                    }

                    /*
                         find out where the mobaxterm.exe is located
                         Will either be in Program Files, or in the portable directory.
                    */

                    string target_exe_where = Helpers.FindApp(target_exe_name);

                    /*
                        [x] target_exe_where
                            C:\Program Files (x86)\Mobatek\MobaXterm

                        [x] cfg_def_mxtpro
                            X:\Apps\MobaXterm\source\bin\Release\Custom.mxtpro
                    */

                    /*
                        license key generator creates mxpro file in same directory as keygen exe.
                        Need to do the following:
                            - First check the install folder for MobaXterm and see if an existing mxpro file exists.
                            - Rename that mxpro file to mxpro.bak
                            - Generate the new license key
                            - Move that new license key to the installed path for moba
                    */

                    if (Directory.Exists(target_exe_where))
                    {

                        string a1 = target_exe_where + @"\" + Cfg.Default.app_def_mxtpro;
                        string a2 = Cfg.Default.app_def_mxtpro;
                        string b1 = target_exe_where + @"\" + Cfg.Default.app_def_mxtpro + ".bak";

                        /*
                            Look for existing mxtpro file
                            can either be in:

                                -> C:\Program Files (x86)\Mobatek\MobaXterm
                                OR
                                -> MobaXterm Portable
                        */

                        if (File.Exists(a1))
                        {
                            // delete extra .bak otherwise we will error out
                            if (File.Exists(b1))
                                File.Delete(b1);

                            if (File.Exists(a1))
                                File.Move(a1, b1);
                        }

                        /*
                            Generate new license
                        */

                        string app_cli_result = Serial.Generate("& \"" + app_cli_path + "\"" + " -s " + fval_name + " " + fval_ver + " " + fval_users);

                        /*
                            Move new Custom.mxtpro from keygen folder to C:\Program Files (x86)\Mobatek\MobaXterm
                        */

                        if (File.Exists(a2))
                            File.Move(a2, a1);

                        /*
                            Update textbox with new license
                        */

                        txtLicense.isPlaceholder = false;
                        txtLicense.Value = app_cli_result;

                        /*
                            delete the cli exe as we no longer need it
                        */

                        if (File.Exists(app_cli_exe))
                            File.Delete(app_cli_exe);

                        /*
                            confirmation
                        */

                        if (File.Exists(a1))
                        {
                            MessageBox.Show(
                                string.Format(Lng.msgbox_ok_generate_finished_msg, Environment.NewLine, Environment.NewLine, a1),
                                Lng.msgbox_ok_generate_finished_title,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.None
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format(Lng.msgbox_err_locate_msg, Environment.NewLine, Environment.NewLine),
                            Lng.msgbox_err_locate_title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }

                }
            }
        }

        /*
            button > hover
        */

        private void btnOpenFolder_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format(Lng.statusbar_btn_openfolder);
            statusStrip.Refresh();
        }

        /*
            button > open folder where mirc "should" be
        */

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string src_target_where = Helpers.FindApp(target_exe_name);

            /*
                mirc found
            */

            if (Directory.Exists(src_target_where))
                Process.Start("explorer.exe", src_target_where);

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
