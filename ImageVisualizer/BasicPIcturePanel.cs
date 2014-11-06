using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImageVisualizer
{
    public partial class BasicPicturePanel : UserControl
    {
        protected RectangleF drawRectangle;
        protected Image image;
        protected Image sourceImage;
        private InterpolationMode interpolationMode = InterpolationMode.NearestNeighbor;
        protected int gridSize = 16;

        public BasicPicturePanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }

        //////////////////////////////////////////////////////////////////////

        protected Bitmap Checkerboard(int width, int height, int gridSize)
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

        protected Image OverlayImage(Image dest, Image source)
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

        [Category("Appearance"), Description("The grid size")]
        public int GridSize
        {
            get
            {
                return gridSize;
            }
            set
            {
                gridSize = value;
                Rebuild();
                Invalidate();
            }
        }

        //////////////////////////////////////////////////////////////////////

        [Category("Appearance"), Description("The interpolation mode used to smooth the drawing")]
        public InterpolationMode InterpolationMode
        {
            get { return interpolationMode; }
            set
            {
                interpolationMode = value;
                Invalidate();
            }
        }

        //////////////////////////////////////////////////////////////////////

        [Category("Appearance"), Description("The image to be displayed")]
        public Image Image
        {
            get { return image; }
            set
            {
                if (value != null)
                {
                    sourceImage = (Image)value.Clone();
                    Rebuild();
                    CalcDrawRect();
                    Invalidate();
                }
            }
        }

        //////////////////////////////////////////////////////////////////////

        protected void Rebuild()
        {
            if(sourceImage != null)
            {
                image = OverlayImage(Checkerboard(sourceImage.Width, sourceImage.Height, gridSize), sourceImage);
            }
        }

        //////////////////////////////////////////////////////////////////////

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(BackColor), pevent.ClipRectangle);
        }

        //////////////////////////////////////////////////////////////////////
        // standard is to fit the image to the control, maintaining aspect ratio

        protected virtual void CalcDrawRect()
        {
            float w = image.Width;
            float h = image.Height;
            float scale = Math.Min(1, Math.Min(Width / w, Height / h));
            w *= scale;
            h *= scale;
            float x = (float)Math.Floor((Width - w) / 2.0f);
            float y = (float)Math.Floor((Height - h) / 2.0f);
            drawRectangle = new RectangleF(x, y, w, h);
        }

        //////////////////////////////////////////////////////////////////////

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                e.Graphics.InterpolationMode = interpolationMode;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                e.Graphics.DrawImage(image, drawRectangle);
            }
        }

    }
}
