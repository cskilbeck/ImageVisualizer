﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageVisualizer;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(64, 64);
            using(Graphics g = Graphics.FromImage(b))
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, 128, 255, 64));
                g.FillRectangle(brush, new Rectangle(0, 0, b.Width, b.Height));
                g.FillEllipse(Brushes.Black, new Rectangle(1, 1, b.Width - 2, b.Height - 2));
            }
            ImageVisualizer.Visualizer.TestShowVisualizer(b, this);
        }
    }
}
