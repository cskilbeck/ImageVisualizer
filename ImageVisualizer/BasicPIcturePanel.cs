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

namespace ImageVisualizer
{
    public partial class BasicPicturePanel : UserControl
    {
        public RectangleF drawRectangle;
        protected Image image;
        private InterpolationMode interpolationMode = InterpolationMode.NearestNeighbor;
        protected Rectangle selectionRectangle = Rectangle.Empty;
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(0xa0, 0, 0, 0));

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

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(BackColor), pevent.ClipRectangle);
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
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                e.Graphics.DrawImage(image, drawRectangle);
                if(!selectionRectangle.IsEmpty)
                {
                    float dl = drawRectangle.Left;
                    float dt = drawRectangle.Top;
                    float xs = drawRectangle.Width / image.Width;
                    float ys = drawRectangle.Height / image.Height;
                    float l = selectionRectangle.Left * xs + dl;
                    float r = selectionRectangle.Right * xs + dl;
                    float t = selectionRectangle.Top * ys + dt;
                    float b = selectionRectangle.Bottom * ys + dt;
                    if(l >= 0 || r < Width || t >= 0 || b < Height)
                    {
                        Rectangle s = new Rectangle((int)l, (int)t, (int)(r - l), (int)(b - t));
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
