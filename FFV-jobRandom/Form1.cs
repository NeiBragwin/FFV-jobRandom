using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FFV_jobRandom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public FileStream FFVROMFile;
        public FileStream FFVSRMFile;
        public byte[] CurrentJob = new byte[4];

        public void OpenROMbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog
            {
                Filter = "FFV SNES ROM (*.smc)|*.smc"
            };
            if (opd.ShowDialog() == DialogResult.OK)
            {
                FFVROMFile = new FileStream(opd.FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                FFVROMFile.Seek(193910, SeekOrigin.Current);
                if (FFVROMFile.ReadByte() == 234 && FFVROMFile.ReadByte() == 234)
                {
                    pathROMtextBox.Text = opd.FileName;
                    labelCheckROM.Text = "ROM is already patched";
                    OpenSRMbutton.Enabled = true;
                    RestoreROMbutton.Enabled = true;
                }
                else
                {
                    pathROMtextBox.Text = opd.FileName;
                    labelCheckROM.Text = "You can patch the ROM";
                    patchROMbutton.Enabled = true;
                }
                FFVROMFile.Position = 0;
            }
            FFVROMFile.Close();
        }

        public void PatchROMbutton_Click(object sender, EventArgs e)
        {
            byte[] PatchBytes = { 234, 234 };
            if (File.Exists(FFVROMFile.Name + ".bak"))
            {
                FileStream FFVBAK = new FileStream(FFVROMFile.Name + ".bak", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                FFVBAK.Seek(193910, SeekOrigin.Current);
                if (FFVBAK.ReadByte() == 208 && FFVBAK.ReadByte() == 10)
                {
                    DialogResult BackupOverwrite = MessageBox.Show("Are you sure to overwrite the backup?", "Confirmation", MessageBoxButtons.YesNo);
                    if (BackupOverwrite == DialogResult.Yes)
                    {
                        FFVBAK.Close();
                        File.Copy(FFVROMFile.Name, FFVROMFile + ".bak", true);
                        FileStream ROM = new FileStream(FFVROMFile.Name, FileMode.Open);
                        ROM.Seek(193910, SeekOrigin.Current);
                        ROM.Write(PatchBytes, 0, 2);
                        labelCheckROM.Text = "File overwritted";
                        ROM.Close();
                        RestoreROMbutton.Enabled = true;
                    }
                }
            } else
            {
                File.Copy(FFVROMFile.Name, FFVROMFile + ".bak");
                FileStream ROM = new FileStream(FFVROMFile.Name, FileMode.Open);
                ROM.Seek(193910, SeekOrigin.Current);
                ROM.Write(PatchBytes, 0, 2);
                labelCheckROM.Text = "Patching done";
                RestoreROMbutton.Enabled = true;
                ROM.Close();
            }
            GC.Collect();
        }

        public void RestoreROMbutton_Click(object sender, EventArgs e)
        {
            DialogResult Restore = MessageBox.Show("Restore ROM?", "Restore", MessageBoxButtons.YesNo);
            if (Restore == DialogResult.Yes)
            {
                File.Copy(FFVROMFile.Name + ".bak", FFVROMFile.Name, true);
                labelCheckROM.Text = "Restored ROM";
            }
            GC.Collect();
        }

        public void OpenSRMbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog
            {
                Filter = "SRM file (*.srm)|*.srm|saveRAM (*.saveRAM)|*.saveRAM"
            };
            if (opd.ShowDialog() == DialogResult.OK)
            {
                FFVSRMFile = new FileStream(opd.FileName, FileMode.Open);

                SaveFileList.Enabled = true;
                SaveFileList.SelectedIndex = 0;
                int index = SaveFileList.SelectedIndex;

                short[] Position = WhatCharacters.SaveFile(index);
                PathToSRMtextBox.Text = opd.FileName;

                Bitmap[] TheCharacters = WhatCharacters.Characters(FFVSRMFile, index);
                
                for (int i = 0; i < 4; i++)
                {
                    FFVSRMFile.Seek(Position[i], SeekOrigin.Begin);
                    CurrentJob[i] = (byte)FFVSRMFile.ReadByte();
                }

                int[] SpritePosition = WhatCharacters.Jobs(CurrentJob, index);

                CharacterFirstBox.Image = TheCharacters[0].Clone(new RectangleF(new Point(0, SpritePosition[0]), new SizeF(80, 120)), TheCharacters[0].PixelFormat);
                CharacterSecondBox.Image = TheCharacters[1].Clone(new RectangleF(new Point(0, SpritePosition[1]), new SizeF(80, 120)), TheCharacters[1].PixelFormat);
                CharacterThirdBox.Image = TheCharacters[2].Clone(new RectangleF(new Point(0, SpritePosition[2]), new SizeF(80, 120)), TheCharacters[2].PixelFormat);
                CharacterFourthBox.Image = TheCharacters[3].Clone(new RectangleF(new Point(0, SpritePosition[3]), new SizeF(80, 120)), TheCharacters[3].PixelFormat);
            }

            FFVSRMFile.Position = 0;
            RestoreSRMbutton.Enabled = true;
            GC.Collect();
        }


        public void RandomizeButton_Click(object sender, EventArgs e)
        {
            int index = SaveFileList.SelectedIndex;

            Bitmap[] TheCharacters = WhatCharacters.Characters(FFVSRMFile, index);
            CurrentJob = WhatCharacters.RandJob(index);
            int[] SpritePosition = WhatCharacters.Jobs(CurrentJob, index);

            CharacterFirstBox.Image = TheCharacters[0].Clone(new RectangleF(new Point(0, SpritePosition[0]), new SizeF(80, 120)), TheCharacters[0].PixelFormat);
            CharacterSecondBox.Image = TheCharacters[1].Clone(new RectangleF(new Point(0, SpritePosition[1]), new SizeF(80, 120)), TheCharacters[1].PixelFormat);
            CharacterThirdBox.Image = TheCharacters[2].Clone(new RectangleF(new Point(0, SpritePosition[2]), new SizeF(80, 120)), TheCharacters[2].PixelFormat);
            CharacterFourthBox.Image = TheCharacters[3].Clone(new RectangleF(new Point(0, SpritePosition[3]), new SizeF(80, 120)), TheCharacters[3].PixelFormat);

            FFVSRMFile.Position = 0;
            SaveMessage.Text = "";
            GC.Collect();
        }

        private void SaveSRMbutton_Click(object sender, EventArgs e)
        {
            int index = SaveFileList.SelectedIndex;
            short[] Position = WhatCharacters.SaveFile(index);
            
            for (int i = 0; i < 4; i++)
            {
                FFVSRMFile.Seek(Position[i], SeekOrigin.Begin);
                FFVSRMFile.WriteByte(CurrentJob[i]);
            }
            SaveMessage.Text = "Saved!";

            FFVSRMFile.Position = 0;
            RestoreSRMbutton.Enabled = true;
            GC.Collect();
        }

        private void RestoreSRMbutton_Click(object sender, EventArgs e)
        {
            int index = SaveFileList.SelectedIndex;
            short[] Position = WhatCharacters.SaveFile(index);

            FFVSRMFile.Close();
            File.Copy(FFVSRMFile.Name + ".bak", FFVSRMFile.Name, true);
            RestoreSRMbutton.Enabled = false;
            SaveMessage.Text = "Restored!";
            FFVSRMFile = new FileStream(FFVSRMFile.Name, FileMode.Open);

            Bitmap[] TheCharacters = WhatCharacters.Characters(FFVSRMFile, index);

            for (int i = 0; i < 4; i++)
            {
                FFVSRMFile.Seek(Position[i], SeekOrigin.Begin);
                CurrentJob[i] = (byte)FFVSRMFile.ReadByte();
            }

            int[] SpritePosition = WhatCharacters.Jobs(CurrentJob, index);

            CharacterFirstBox.Image = TheCharacters[0].Clone(new RectangleF(new Point(0, SpritePosition[0]), new SizeF(80, 120)), TheCharacters[0].PixelFormat);
            CharacterSecondBox.Image = TheCharacters[1].Clone(new RectangleF(new Point(0, SpritePosition[1]), new SizeF(80, 120)), TheCharacters[1].PixelFormat);
            CharacterThirdBox.Image = TheCharacters[2].Clone(new RectangleF(new Point(0, SpritePosition[2]), new SizeF(80, 120)), TheCharacters[2].PixelFormat);
            CharacterFourthBox.Image = TheCharacters[3].Clone(new RectangleF(new Point(0, SpritePosition[3]), new SizeF(80, 120)), TheCharacters[3].PixelFormat);
        }

        private void SaveFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = SaveFileList.SelectedIndex;
            short[] Position = WhatCharacters.SaveFile(index);

            for (int i = 0; i < 4; i++)
            {
                FFVSRMFile.Seek(Position[i], SeekOrigin.Begin);
                CurrentJob[i] = (byte)FFVSRMFile.ReadByte();
            }

            Bitmap[] TheCharacters = WhatCharacters.Characters(FFVSRMFile, index);
            int[] SpritePosition = WhatCharacters.Jobs(CurrentJob, index);

            CharacterFirstBox.Image = TheCharacters[0].Clone(new RectangleF(new Point(0, SpritePosition[0]), new SizeF(80, 120)), TheCharacters[0].PixelFormat);
            CharacterSecondBox.Image = TheCharacters[1].Clone(new RectangleF(new Point(0, SpritePosition[1]), new SizeF(80, 120)), TheCharacters[1].PixelFormat);
            CharacterThirdBox.Image = TheCharacters[2].Clone(new RectangleF(new Point(0, SpritePosition[2]), new SizeF(80, 120)), TheCharacters[2].PixelFormat);
            CharacterFourthBox.Image = TheCharacters[3].Clone(new RectangleF(new Point(0, SpritePosition[3]), new SizeF(80, 120)), TheCharacters[3].PixelFormat);
        }
    }
}
