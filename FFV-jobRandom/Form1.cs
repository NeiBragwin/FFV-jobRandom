using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFV_jobRandom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string FFVROMFile = "";
        public static string FFVSRMFile = "";

        public void OpenROMbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog
            {
                Filter = "FFV SNES ROM (*.smc)|*.smc"
            };
            if (opd.ShowDialog() == DialogResult.OK)
            {
                FFVROMFile = opd.FileName;
                FileStream ROM = new FileStream(FFVROMFile, FileMode.Open);
                ROM.Seek(193910, SeekOrigin.Current);
                if (ROM.ReadByte() == 234 && ROM.ReadByte() == 234)
                {
                    pathROMtextBox.Text = FFVROMFile;
                    labelCheckROM.Text = "wow the rom is already patched gud job";
                    patchROMbutton.Enabled = false;
                }
                else
                {
                    pathROMtextBox.Text = FFVROMFile;
                    labelCheckROM.Text = "u can patch it with the patch button";
                    patchROMbutton.Enabled = true;
                }
                ROM.Close();
            }
        }

        public void PatchROMbutton_Click(object sender, EventArgs e)
        {
            if (File.Exists(FFVROMFile + ".bak"))
            {
                FileStream FFVBAK = new FileStream(FFVROMFile + ".bak", FileMode.Open);
                FFVBAK.Seek(193910, SeekOrigin.Current);
                if (FFVBAK.ReadByte() == 208 && FFVBAK.ReadByte() == 10)
                {
                    DialogResult BackupOverwrite = MessageBox.Show("already backed-up, and it's the original ROM. r u sure u want to overwrite?", "poop", MessageBoxButtons.YesNo);
                    if (BackupOverwrite == DialogResult.Yes)
                    {
                        File.Copy(FFVROMFile, FFVROMFile + ".bak", true);
                        labelCheckROM.Text = "overwrited file alright";
                    }
                }

            } else
            {
                File.Copy(FFVROMFile, FFVROMFile + ".bak");
                labelCheckROM.Text = "done alright";
            }
        }

        private void RestoreROMbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("restore ROM?", "restore", MessageBoxButtons.YesNo);
        }
    }
}
