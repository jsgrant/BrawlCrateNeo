﻿using System;
using Eto.Forms;

namespace BrawlCrate.UI.Mac
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Mac64).Run(MainForm.Instance);
        }
    }
}