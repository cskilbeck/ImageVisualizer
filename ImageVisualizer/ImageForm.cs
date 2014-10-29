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
using System.Windows.Forms;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public partial class ImageForm : Form
    {
        private Image currentImage;
        private Bitmap alpha;
        private int gridSize = 16;
        private Point mousePos;
        private Point scrollPos;

        private float[] zooms = { 1/5.0f, 1/4.0f, 1/3.0f, 1/2.0f, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int zoomLevel = 4;

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

        private void OverlayImage(Bitmap dest, Image source)
        {
            using (Graphics g = Graphics.FromImage(dest))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.None;
                g.CompositingMode = CompositingMode.SourceOver;
                Rectangle d = new Rectangle(0, 0, dest.Width, dest.Height);
                g.DrawImage(source, d, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel);
            }
        }

        //////////////////////////////////////////////////////////////////////

        public ImageForm(Image image)
        {
            InitializeComponent();
            var borderWidth = (Width - ClientSize.Width);
            var borderHeight = (Height - ClientSize.Height) + SystemInformation.CaptionHeight + SystemInformation.BorderSize.Height;
            this.Width = image.Width + borderWidth;
            this.Height = image.Height + borderHeight;
            this.StartPosition = FormStartPosition.Manual;
            var mousePos = Cursor.Position;
            this.Location = new Point(mousePos.X - this.Width / 2, mousePos.Y - this.Height / 2);
            pictureBox1.MouseWheel += pictureBox_MouseWheel;
            pictureBox1.MouseHover += pictureBox_MouseHover;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            this.Shown += ImageForm_Shown;
            string fmt = image.PixelFormat.ToString().Replace("Format", "");
            Text = String.Format("{0}x{1},{2}", image.Width, image.Height, fmt);
            currentImage = image;
            BuildPreview();
            pictureBox1.Resize += pictureBox1_Resize;
            pictureBox1.Size = new Size(Math.Max(image.Width, 100), Math.Max(image.Height, 100));
            pictureBox1.Location = new Point((ClientSize.Width - pictureBox1.Width) / 2, (ClientSize.Height + menuStrip.Height - pictureBox1.Height) / 2);
        }

        void ImageForm_Shown(object sender, EventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePos = pictureBox1.PointToScreen(e.Location);
            scrollPos = new Point(-pictureBox1.AutoScrollPosition.X, -pictureBox1.AutoScrollPosition.Y);
            pictureBox1.Capture = true;
        }

        //////////////////////////////////////////////////////////////////////

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Capture)
            {
                Point newPos = pictureBox1.PointToScreen(e.Location);
                scrollPos.Offset(mousePos.X - newPos.X, mousePos.Y - newPos.Y);
                pictureBox1.AutoScrollPosition = scrollPos;
                pictureBox1.Invalidate();
                mousePos = newPos;
            }
        }

        //////////////////////////////////////////////////////////////////////

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Capture = false;
        }

        //////////////////////////////////////////////////////////////////////

        private void BuildPreview()
        {
            alpha = DrawCheckerboard(currentImage.Width, currentImage.Height, gridSize);
            OverlayImage(alpha, currentImage);
            pictureBox1.Image = alpha;
            pictureBox1.Refresh();
        }

        //////////////////////////////////////////////////////////////////////

        void pictureBox1_Resize(object sender, EventArgs e)
        {
            //BuildPreview();
        }

        //////////////////////////////////////////////////////////////////////

        void pictureBox_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        //////////////////////////////////////////////////////////////////////

        void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            var delta = e.Delta / 120;
            zoomLevel = Math.Max(0, Math.Min(zooms.Length - 1, zoomLevel + delta));
            pictureBox1.Zoom = zooms[zoomLevel];
        }

        //////////////////////////////////////////////////////////////////////

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 4;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            BuildPreview();
        }

        //////////////////////////////////////////////////////////////////////

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 16;
            smallToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            BuildPreview();
        }

        //////////////////////////////////////////////////////////////////////

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 64;
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            BuildPreview();
        }

        //////////////////////////////////////////////////////////////////////

        private void zoomCrispToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomBlurryToolStripMenuItem.Checked = false;
            pictureBox1.InterpolationMode = InterpolationMode.NearestNeighbor;
            pictureBox1.Invalidate();
        }

        //////////////////////////////////////////////////////////////////////

        private void zoomBlurryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomCrispToolStripMenuItem.Checked = false;
            pictureBox1.InterpolationMode = InterpolationMode.Bilinear;
            pictureBox1.Invalidate();
        }

        //////////////////////////////////////////////////////////////////////

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("!");
        }

        //////////////////////////////////////////////////////////////////////

        private void zoomResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomLevel = 4;
            pictureBox1.Zoom = zooms[zoomLevel];
        }

        //////////////////////////////////////////////////////////////////////

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.AllowFullOpen = true;
            c.FullOpen = true;
            c.SolidColorOnly = true;
            if(c.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = c.Color;
                pictureBox1.Invalidate();
            }
        }
    }
}
