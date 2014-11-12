using System;
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
            Bitmap b = new Bitmap(171, 301);
            using(Graphics g = Graphics.FromImage(b))
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, 128, 255, 64));
                g.FillEllipse(brush, new Rectangle(2, 2, b.Width - 4, b.Height - 4));
                g.FillEllipse(Brushes.Black, new Rectangle(10, 10, b.Width - 20, b.Height - 20));
                g.FillEllipse(Brushes.Red, new Rectangle(20, 20, b.Width - 40, b.Height - 40));
            }
            ImageVisualizer.Visualizer.TestShowVisualizer(b, this);
        }
    }
}
