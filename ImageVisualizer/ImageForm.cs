//////////////////////////////////////////////////////////////////////
// Zoom in on the mouse position
// Sort out the zoom modes (list the enum in the menu?)
// Save/restore options
// Allow background colour option? \
// Allow zoom out as well as in \
// 

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public partial class ImageForm : Form
    {
        private PicturePanel pic;

        //////////////////////////////////////////////////////////////////////

        private Bitmap DrawCheckerboard(int width, int height, int gridSize)
        {
            Bitmap bmp = new Bitmap(width, height);
            Brush[] brush = { Brushes.LightGray, Brushes.DarkGray };
            int yBrush = 0;
            Rectangle r = new Rectangle(0, 0, gridSize, gridSize);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int y = 0; y < height; y += gridSize)
                {
                    int xBrush = yBrush;
                    r.Y = y;
                    for (int x = 0; x < width; x += gridSize)
                    {
                        r.X = x;
                        g.FillRectangle(brush[xBrush], r);
                        xBrush = 1 - xBrush;
                    }
                    yBrush = 1 - yBrush;
                }
            }
            return bmp;
        }
        
        //////////////////////////////////////////////////////////////////////

        public ImageForm(Image image)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            var mousePos = Cursor.Position;
            ClientSize = image.Size;
            Location = new Point(mousePos.X - this.Width / 2, mousePos.Y - this.Height / 2);
            string fmt = image.PixelFormat.ToString().Replace("Format", "");
            Text = String.Format("{0}x{1},{2}", image.Width, image.Height, fmt);
            if(Debugger.IsAttached)
            {
                this.ShowInTaskbar = true;
            }

            pic = new PicturePanel();
            pic.ZoomChanged += pic_ZoomChanged;
            pic.Image = image;
            pic.Dock = DockStyle.Fill;
            Controls.Add(pic);
        }

        void pic_ZoomChanged(object o, EventArgs e)
        {
            PicturePanel p = o as PicturePanel;
            ClientSize = new Size((int)(p.Image.Width * p.Zoom), (int)(p.Image.Height * p.Zoom));
        }

    }
}
