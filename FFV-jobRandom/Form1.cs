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
            int SumBytes = 0;
            
            for (int i = 0; i < 4; i++)
            {
                FFVSRMFile.Seek(Position[i], SeekOrigin.Begin);
                FFVSRMFile.WriteByte(CurrentJob[i]);
            }

            FFVSRMFile.Position = 0;
            for (int i = 0; i < 0x601; i += 2)
            {
                byte b1 = (byte)FFVSRMFile.ReadByte();
                byte b2 = (byte)FFVSRMFile.ReadByte();
                int CombinedByte = b1 << 8 | b2;
                SumBytes += (CombinedByte);

                if (SumBytes > 0xffff)
                {
                    var Carry = SumBytes - 0xffff;
                    SumBytes = 0x0 + Carry;
                }
            }
            SumBytes &= 0xffff;
            Console.WriteLine((byte)SumBytes);
            FFVSRMFile.Seek(0x1FF0, SeekOrigin.Begin);
            FFVSRMFile.WriteByte((byte)SumBytes);

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
