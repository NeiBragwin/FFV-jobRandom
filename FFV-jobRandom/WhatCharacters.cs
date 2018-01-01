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

    public class WhatCharacters
    {
        public static Bitmap Bartz = FFV_jobRandom.Properties.Resources.bartz;
        public static Bitmap Faris = FFV_jobRandom.Properties.Resources.faris;
        public static Bitmap Galuf = FFV_jobRandom.Properties.Resources.galuf;
        public static Bitmap Krile = FFV_jobRandom.Properties.Resources.krile;
        public static Bitmap Lenna = FFV_jobRandom.Properties.Resources.lenna;

        public static byte[] CharacterPosition = { 0, 80, 160, 240 };
        public static byte[] JobsPosition = { 1, 81, 161, 241 };

        public static Bitmap[] CurrentCharacters = new Bitmap[4];
        public static Bitmap[] Characters(FileStream SRMfile)
        {
            for (int i = 0; i < 4; i++)
            {
                SRMfile.Seek(CharacterPosition[i], SeekOrigin.Begin);
                switch (SRMfile.ReadByte())
                {
                    case 0:
                    case 8:
                    case 16:
                    case 128:
                        CurrentCharacters[i] = Bartz;
                        break;
                    case 1:
                    case 9:
                    case 17:
                    case 129:
                        CurrentCharacters[i] = Lenna;
                        break;
                    case 2:
                    case 10:
                    case 18:
                    case 130:
                        CurrentCharacters[i] = Galuf;
                        break;
                    case 3:
                    case 11:
                    case 19:
                    case 131:
                        CurrentCharacters[i] = Faris;
                        break;
                    case 4:
                    case 12:
                    case 20:
                    case 132:
                        CurrentCharacters[i] = Krile;
                        break;
                }
            }
            return CurrentCharacters;
        }

        public static int[] Jobs(byte[] JobValue)
        {
            int[] JobSprites = new int[4];
            for (int i = 0; i < 4; i++)
            {
                switch (JobValue[i])
                {
                    case 21: // Freelance
                        JobSprites[i] = 0;
                        break;
                    case 0:
                        JobSprites[i] = 150;
                        break;
                    case 1:
                        JobSprites[i] = 150*2;
                        break;
                    case 2:
                        JobSprites[i] = 150*3;
                        break;
                    case 3:
                        JobSprites[i] = 150*4;
                        break;
                    case 4:
                        JobSprites[i] = 150*5;
                        break;
                    case 5:
                        JobSprites[i] = 150*6;
                        break;
                    case 6:
                        JobSprites[i] = 150*7;
                        break;
                    case 7:
                        JobSprites[i] = 150*8;
                        break;
                    case 8:
                        JobSprites[i] = 150*9;
                        break;
                    case 9:
                        JobSprites[i] = 150*10;
                        break;
                    case 10:
                        JobSprites[i] = 150*11;
                        break;
                    case 11:
                        JobSprites[i] = 150*12;
                        break;
                    case 12:
                        JobSprites[i] = 150*13;
                        break;
                    case 13:
                        JobSprites[i] = 150*14;
                        break;
                    case 14:
                        JobSprites[i] = 150*15;
                        break;
                    case 15:
                        JobSprites[i] = 150*16;
                        break;
                    case 16:
                        JobSprites[i] = 150*17;
                        break;
                    case 17:
                        JobSprites[i] = 150*18;
                        break;
                    case 18:
                        JobSprites[i] = 150*19;
                        break;
                    case 19:
                        JobSprites[i] = 150*20;
                        break;
                    case 20:
                        JobSprites[i] = 150*21;
                        break;
                }
            }
            return JobSprites;
        }

        public static byte[] RandJob()
        {
            Random rnd = new Random();
            byte[] JobsPosition = { 1, 81, 161, 241 };
            byte[] Jobs = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                byte RandomJob = (byte)rnd.Next(22);
                Jobs[i] = RandomJob;
            }
            return Jobs;
        }
    }
}
