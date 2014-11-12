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
using System.Diagnostics;
using System.Drawing.Imaging;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public partial class BasicPicturePanel : UserControl
    {
        //////////////////////////////////////////////////////////////////////

        public RectangleF drawRectangle;
        protected Image image;
        private InterpolationMode interpolationMode = InterpolationMode.NearestNeighbor;
        protected Rectangle selectionRectangle = Rectangle.Empty;
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(0xa0, 0x60, 0x60, 0x60));
        public int gridSize = 16;
        private Brush[] gridBrushes = { Brushes.DarkGray, Brushes.LightGray };

        //////////////////////////////////////////////////////////////////////

        public void SetGridColors(Color[] colours)
        {
            gridBrushes[0] = new SolidBrush(colours[0]);
            gridBrushes[1] = new SolidBrush(colours[1]);
            Invalidate();
        }

        //////////////////////////////////////////////////////////////////////

        public BasicPicturePanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }

        //////////////////////////////////////////////////////////////////////

        public Rectangle SelectionRectangle
        {
            get
            {
                return selectionRectangle;
            }
            set
            {
                selectionRectangle = value;
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
                    if (image == null || value.Width != image.Width || value.Height != image.Height)
                    {
                        CalcDrawRect(value);
                    }
                    image = value;
                    Invalidate();
                }
            }
        }

        //////////////////////////////////////////////////////////////////////

        public Point PixelPositionFromControlPosition(Point controlPosition)
        {
            float xs = (float)Image.Width / drawRectangle.Width;
            float ys = (float)Image.Height / drawRectangle.Height;
            float x = (controlPosition.X - drawRectangle.Left) * xs;
            float y = (controlPosition.Y - drawRectangle.Top) * ys;
            return new Point((int)Math.Floor(x), (int)Math.Floor(y));
        }

        //////////////////////////////////////////////////////////////////////

        protected virtual void CalcDrawRect(Image image)
        {
            if(image != null)
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
        }

        //////////////////////////////////////////////////////////////////////

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(BackColor), pevent.ClipRectangle);

            if(Image != null && gridSize > 0)
            {
                Graphics g = pevent.Graphics;

                GraphicsState s = g.Save();

                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.Default;
                g.PixelOffsetMode = PixelOffsetMode.Default;
                g.InterpolationMode = InterpolationMode.Default;
                g.SmoothingMode = SmoothingMode.None;

                RectangleF c = drawRectangle;
                c.Offset(-1, -1);
                g.Clip = new Region(c);

                float xs = (float)Math.Floor(drawRectangle.Width / Image.Width * gridSize);
                float ys = (float)Math.Floor(drawRectangle.Height / Image.Height * gridSize);
                float xorg = (float)Math.Floor(drawRectangle.X);
                float yorg = (float)Math.Floor(drawRectangle.Y);

                if (xs >= 2 && ys >= 2)
                {
                    int yBrush = 0;
                    RectangleF r = new RectangleF(0, 0, xs, ys);
                    {
                        for (float y = 0; y < drawRectangle.Height; y += ys)
                        {
                            int xBrush = yBrush;
                            r.Y = y + yorg;
                            for (float x = 0; x < drawRectangle.Width; x += xs)
                            {
                                r.X = x + xorg;
                                g.FillRectangle(gridBrushes[xBrush], r);
                                xBrush = 1 - xBrush;
                            }
                            yBrush = 1 - yBrush;
                        }
                    }
                }
                g.Restore(s);
            }
        }

        //////////////////////////////////////////////////////////////////////

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                try
                {
                    e.Graphics.InterpolationMode = interpolationMode;
                }
                catch(ArgumentException)
                {
                    e.Graphics.InterpolationMode = InterpolationMode.Default;
                }
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.SmoothingMode = SmoothingMode.None;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                e.Graphics.CompositingMode = CompositingMode.SourceOver;
                using (ImageAttributes a = new ImageAttributes())
                {
                    PointF[] p = {
                                     new PointF((float)Math.Floor(drawRectangle.X), (float)Math.Floor(drawRectangle.Y)),
                                     new PointF((float)Math.Floor(drawRectangle.Right), (float)Math.Floor(drawRectangle.Top)),
                                     new PointF((float)Math.Floor(drawRectangle.Left), (float)Math.Floor(drawRectangle.Bottom))
                                 };
                    a.SetWrapMode(WrapMode.TileFlipXY);
                    e.Graphics.DrawImage(image, p, new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel, a);
                }
                if(!selectionRectangle.IsEmpty)
                {
                    float dl = drawRectangle.Left;
                    float dt = drawRectangle.Top;
                    float xs = drawRectangle.Width / image.Width;
                    float ys = drawRectangle.Height / image.Height;
                    float l = (float)Math.Floor(selectionRectangle.Left * xs + dl); // Round() to defeat pixel offset mode shenanigans
                    float r = (float)Math.Floor(selectionRectangle.Right * xs + dl);
                    float t = (float)Math.Floor(selectionRectangle.Top * ys + dt);
                    float b = (float)Math.Floor(selectionRectangle.Bottom * ys + dt);
                    //if(l > 1 || r < Width || t > 1 || b < Height)
                    {
                        Rectangle s = new Rectangle((int)l, (int)t, (int)(r - l - 1), (int)(b - t - 1));
                        e.Graphics.SmoothingMode = SmoothingMode.None;
                        e.Graphics.PixelOffsetMode = PixelOffsetMode.None;
                        e.Graphics.FillRectangle(selectionBrush, s);
                        e.Graphics.DrawRectangle(Pens.White, s);
                    }
                }
            }
        }
    }
}
