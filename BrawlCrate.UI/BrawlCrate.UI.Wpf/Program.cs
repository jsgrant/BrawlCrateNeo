﻿using System;
using Eto.Forms;

namespace BrawlCrate.UI.Wpf
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Wpf).Run(MainForm.Instance);
        }
    }
}