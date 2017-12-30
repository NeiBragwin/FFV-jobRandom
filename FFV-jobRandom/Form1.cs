using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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
                    labelCheckROM.Text = "ROM is already patched";
                    OpenSRMbutton.Enabled = true;
                    RestoreROMbutton.Enabled = true;
                }
                else
                {
                    pathROMtextBox.Text = FFVROMFile;
                    labelCheckROM.Text = "You can patch the ROM";
                    patchROMbutton.Enabled = true;
                }
                ROM.Close();
            }
        }

        public void PatchROMbutton_Click(object sender, EventArgs e)
        {
            byte[] PatchBytes = { 234, 234 };
            if (File.Exists(FFVROMFile + ".bak"))
            {
                FileStream FFVBAK = new FileStream(FFVROMFile + ".bak", FileMode.Open);
                FFVBAK.Seek(193910, SeekOrigin.Current);
                if (FFVBAK.ReadByte() == 208 && FFVBAK.ReadByte() == 10)
                {
                    DialogResult BackupOverwrite = MessageBox.Show("Are you sure to overwrite the backup?", "Confirmation", MessageBoxButtons.YesNo);
                    if (BackupOverwrite == DialogResult.Yes)
                    {
                        FFVBAK.Close();
                        File.Copy(FFVROMFile, FFVROMFile + ".bak", true);
                        FileStream ROM = new FileStream(FFVROMFile, FileMode.Open);
                        ROM.Seek(193910, SeekOrigin.Current);
                        ROM.Write(PatchBytes, 0, 2);
                        labelCheckROM.Text = "File overwritted";
                        ROM.Close();
                        RestoreROMbutton.Enabled = true;
                    }
                }
            } else
            {
                File.Copy(FFVROMFile, FFVROMFile + ".bak");
                FileStream ROM = new FileStream(FFVROMFile, FileMode.Open);
                ROM.Seek(193910, SeekOrigin.Current);
                ROM.Write(PatchBytes, 0, 2);
                labelCheckROM.Text = "Patching done";
                RestoreROMbutton.Enabled = true;
                ROM.Close();
            }
        }

        private void RestoreROMbutton_Click(object sender, EventArgs e)
        {
            DialogResult Restore = MessageBox.Show("Restore ROM?", "Restore", MessageBoxButtons.YesNo);
            if (Restore == DialogResult.Yes)
            {
                File.Copy(FFVROMFile + ".bak", FFVROMFile, true);
                labelCheckROM.Text = "Restored ROM";
            }
        }

        private void OpenSRMbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog
            {
                Filter = "SRM file (*.srm)|*.srm|saveRAM (*.saveRAM)|*.saveRAM"
            };
            if (opd.ShowDialog() == DialogResult.OK)
            {
                FFVSRMFile = opd.FileName;
                FileStream SRM = new FileStream(FFVSRMFile, FileMode.Open);
                SRM.Seek(0, SeekOrigin.Begin);

                PathToSRMtextBox.Text = opd.FileName;

                string[] characters = { "Bartz", "Lenna", "Faris" };

                WhatCharacters.Characters(characters);
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
