﻿using System.Windows.Forms;

namespace GameOfLife
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form()); // or whatever
        }
    }
}