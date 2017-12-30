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

        public static void Characters(String[] List)
        {
            for (int i = 0; i < 4; i++)
            {
                String character = List[i];
                switch (character)
                {
                    case "Bartz":
                        Form1.CharacterFirstBox;
                }
            }
        }
    }
}
