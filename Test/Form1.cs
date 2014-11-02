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
            Bitmap b = new Bitmap(128, 128);
            using(Graphics g = Graphics.FromImage(b))
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(128, 128, 255, 64));
                g.FillRectangle(brush, new Rectangle(0, 0, 128, 128));
                g.FillEllipse(Brushes.Black, new Rectangle(1, 1, 126, 126));
            }
            ImageVisualizer.Visualizer.TestShowVisualizer(b, this);
        }
    }
}
