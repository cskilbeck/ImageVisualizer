//////////////////////////////////////////////////////////////////////
// fit window to zoomed graphic if possible
// 
//////////////////////////////////////////////////////////////////////

using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;
using System.Diagnostics;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public partial class PicturePanel : UserControl
    {
        //////////////////////////////////////////////////////////////////////

        private RectangleF drawRectangle;
        private Image image;
        private Image sourceImage;
        private float zoom = 1;
        private InterpolationMode interpolationMode = InterpolationMode.NearestNeighbor;
        private ToolStripMenuItem currentInterpolationModeMenuItem;
        private ToolStripMenuItem currentGridSizeMenuItem;
        private float[] zooms = { 1 / 5.0f, 1 / 4.0f, 1 / 3.0f, 1 / 2.0f, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int zoomLevel = 4;
        private int gridSize = 16;

        //////////////////////////////////////////////////////////////////////

        public delegate void ZoomChangedHandler(object o, EventArgs e);
        public event ZoomChangedHandler ZoomChanged;

        //////////////////////////////////////////////////////////////////////

        public PicturePanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            MouseWheel += PicturePanel_MouseWheel;
            MouseMove += PicturePanel_MouseMove;
            MouseDown += PicturePanel_MouseDown;
            MouseUp += PicturePanel_MouseUp;
            MouseLeave += PicturePanel_MouseLeave;
            Resize += PicturePanel_Resize;

            // build the InterpolationMode menu
            string[] names = Enum.GetNames(typeof(InterpolationMode));
            Array values = Enum.GetValues(typeof(InterpolationMode));
            for (int i = 0; i < names.Length; ++i)
            {
                ToolStripMenuItem m = new ToolStripMenuItem(names[i]);
                m.Click += interpolationMode_Click;
                m.Tag = values.GetValue(i);
                m.Checked = (InterpolationMode)m.Tag == interpolationMode;
                if (m.Checked)
                {
                    currentInterpolationModeMenuItem = m;
                }
                interpolationToolStripMenuItem.DropDownItems.Add(m);
            }

            // sort out what grid size is selected by default
            foreach (ToolStripMenuItem m in gridToolStripMenuItem.DropDownItems)
            {
                currentGridSizeMenuItem = m;
                if(m.Checked)
                {
                    break;
                }
            }
            currentGridSizeMenuItem.Checked = true;
            gridSize = Convert.ToInt32(currentGridSizeMenuItem.Tag);
        }

        //////////////////////////////////////////////////////////////////////

        void interpolationMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem m = sender as ToolStripMenuItem;
            if(m != null)
            {
                if (currentInterpolationModeMenuItem != null)
                {
                    currentInterpolationModeMenuItem.Checked = false;
                }
                m.Checked = true;
                currentInterpolationModeMenuItem = m;
                InterpolationMode = (InterpolationMode)m.Tag;
                Rebuild();
                Invalidate();
            }
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_Resize(object sender, EventArgs e)
        {
            drawRectangle = DrawRect();
            Invalidate();
        }

        //////////////////////////////////////////////////////////////////////

        private Bitmap Checkerboard(int width, int height, int gridSize)
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

        private Image OverlayImage(Image dest, Image source)
        {
            using (Graphics g = Graphics.FromImage(dest))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.None;
                g.CompositingMode = CompositingMode.SourceOver;
                Rectangle d = new Rectangle(0, 0, dest.Width, dest.Height);
                g.DrawImage(source, d, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel);
            }
            return dest;
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseLeave(object sender, System.EventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseUp(object sender, MouseEventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseDown(object sender, MouseEventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseMove(object sender, MouseEventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            zoomLevel = Math.Max(0, Math.Min(zooms.Length - 1, zoomLevel + Math.Sign(e.Delta)));
            Zoom = zooms[zoomLevel];
        }

        //////////////////////////////////////////////////////////////////////

        public float Zoom
        {
            get
            {
                return zoom; 
            }
            set
            {
                zoom = value;
                ZoomChanged.Invoke(this, new EventArgs());
            }
        }

        //////////////////////////////////////////////////////////////////////

        [Category("Appearance"), Description("The interpolation mode used to smooth the drawing")]
        public InterpolationMode InterpolationMode
        {
            get { return interpolationMode; }
            set { interpolationMode = value; }
        }

        //////////////////////////////////////////////////////////////////////

        [Category("Appearance"), Description("The image to be displayed")]
        public Image Image
        {
            get { return image; }
            set
            {
                sourceImage = (Image)value.Clone();
                Rebuild();
                Invalidate();
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void Rebuild()
        {
            image = OverlayImage(Checkerboard(sourceImage.Width, sourceImage.Height, gridSize), sourceImage);
            drawRectangle = DrawRect();
        }

        //////////////////////////////////////////////////////////////////////

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(BackColor), pevent.ClipRectangle);
        }

        //////////////////////////////////////////////////////////////////////

        private RectangleF DrawRect()
        {
            float w = image.Width * zoom;
            float h = image.Height * zoom;
            float scale = Math.Min(Width / w, Height / h);
            w *= scale;
            h *= scale;
            float x = (float)Math.Floor((Width - w) / 2.0f);
            float y = (float)Math.Floor((Height - h) / 2.0f);
            return new RectangleF(x, y, w, h);
        }

        //////////////////////////////////////////////////////////////////////

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = interpolationMode;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawImage(image, drawRectangle);
        }

        //////////////////////////////////////////////////////////////////////

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.AllowFullOpen = true;
            c.FullOpen = true;
            c.SolidColorOnly = true;
            c.Color = BackColor;
            if (c.ShowDialog() == DialogResult.OK)
            {
                BackColor = c.Color;
                Invalidate();
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(Image);
        }

        //////////////////////////////////////////////////////////////////////

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentGridSizeMenuItem != null)
            {
                currentGridSizeMenuItem.Checked = false;
            }
            currentGridSizeMenuItem = (ToolStripMenuItem)sender;
            currentGridSizeMenuItem.Checked = true;
            gridSize = Convert.ToInt32(currentGridSizeMenuItem.Tag);
            Rebuild();
            Invalidate();
        }

        //////////////////////////////////////////////////////////////////////

        private void resetZoomMenuItem_Click(object sender, EventArgs e)
        {
            Zoom = 1;
        }
    }
}
