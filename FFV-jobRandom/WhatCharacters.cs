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
        public static short[] JobsPosition;
        public static short[] CharacterPosition = new short[4];

        public static Bitmap[] CurrentCharacters = new Bitmap[4];

        public static Bitmap[] Characters(FileStream SRMfile, int index)
        {
            switch (index)
            {
                case 0:
                    CharacterPosition[0] = 0x0;
                    CharacterPosition[1] = 0x50;
                    CharacterPosition[2] = 0xA0;
                    CharacterPosition[3] = 0xF0;
                    break;
                case 1:
                    CharacterPosition[0] = 0x700;
                    CharacterPosition[1] = 0x750;
                    CharacterPosition[2] = 0x7A0;
                    CharacterPosition[3] = 0x7F0;
                    break;
                case 2:
                    CharacterPosition[0] = 0xE00;
                    CharacterPosition[1] = 0xE50;
                    CharacterPosition[2] = 0xEA0;
                    CharacterPosition[3] = 0xEF0;
                    break;
                case 3:
                    CharacterPosition[0] = 0x1500;
                    CharacterPosition[1] = 0x1550;
                    CharacterPosition[2] = 0x15A0;
                    CharacterPosition[3] = 0x15F0;
                    break;
            }

            for (int i = 0; i < 4; i++)
            {
                SRMfile.Position = CharacterPosition[i];
                string BinaryValue = Convert.ToString(SRMfile.ReadByte(), 2).PadLeft(8, '0').Remove(0, 5);
                switch (BinaryValue)
                {
                    case "000":
                        CurrentCharacters[i] = FFV_jobRandom.Properties.Resources.bartz;
                        break;
                    case "001":
                        CurrentCharacters[i] = FFV_jobRandom.Properties.Resources.faris;
                        break;
                    case "010":
                        CurrentCharacters[i] = FFV_jobRandom.Properties.Resources.galuf;
                        break;
                    case "011":
                        CurrentCharacters[i] = FFV_jobRandom.Properties.Resources.faris;
                        break;
                    case "100":
                        CurrentCharacters[i] = FFV_jobRandom.Properties.Resources.krile;
                        break;
                }
            }
            return CurrentCharacters;
        }

        public static int[] Jobs(byte[] JobValue, int index)
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
            byte[] Jobs = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                int RandomJob = rnd.Next(0x16);
                Jobs[i] = (byte)RandomJob;
            }
            return Jobs;
        }

        public static short[] SaveFile(int index)
        {
            short[] Position = new short[4];
            switch (index)
            {
                case 0:
                    Position[0] = 0x1;
                    Position[1] = 0x51;
                    Position[2] = 0xA1;
                    Position[3] = 0xF1;
                    break;
                case 1:
                    Position[0] = 0x701;
                    Position[1] = 0x751;
                    Position[2] = 0x7A1;
                    Position[3] = 0x7F1;
                    break;
                case 2:
                    Position[0] = 0xE01;
                    Position[1] = 0xE51;
                    Position[2] = 0xEA1;
                    Position[3] = 0xEF1;
                    break;
                case 3:
                    Position[0] = 0x1501;
                    Position[1] = 0x1551;
                    Position[2] = 0x15A1;
                    Position[3] = 0x15F1;
                    break;
            }
            return Position;
        }

        public static void CorrectChecksum(FileStream SRM, int index)
        {
            int SumBytes = 0;
            int CheckPosition = 0;

            switch (index)
            {
                case 0:
                    SRM.Position = 0;
                    CheckPosition = 0x1FF0;
                    break;
                case 1:
                    SRM.Position = 0x700;
                    CheckPosition = 0x1FF2;
                    break;
                case 2:
                    SRM.Position = 0xE00;
                    CheckPosition = 0x1FF4;
                    break;
                case 3:
                    SRM.Position = 0x1500;
                    CheckPosition = 0x1FF6;
                    break;
            }

            for (int i = 0; i < 0x601; i += 2)
            {
                byte b1 = (byte)SRM.ReadByte();
                byte b2 = (byte)SRM.ReadByte();
                int CombinedByte = b1 << 8 | b2;
                SumBytes += (CombinedByte);

                if (SumBytes > 0xffff)
                {
                    var Carry = SumBytes - 0xffff;
                    SumBytes = 0x0 + Carry;
                }
            }

            // edit checksum
            byte[] Checksum = new byte[2];
            Checksum[0] = Convert.ToByte(SumBytes % 256);
            Checksum[1] = Convert.ToByte((SumBytes - Checksum[0]) >> 8);

            SRM.Position = CheckPosition;
            SRM.WriteByte(Checksum[1]);
            SRM.WriteByte(Checksum[0]);
        }
    }
}
