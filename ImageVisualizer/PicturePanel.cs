//////////////////////////////////////////////////////////////////////

using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System;
using System.Linq;
using System.Diagnostics;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public partial class PicturePanel : BasicPicturePanel
    {
        //////////////////////////////////////////////////////////////////////

        private float[] zooms = { 1 / 5.0f, 1 / 4.0f, 1 / 3.0f, 1 / 2.0f, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        private int zoomLevel = 4;
        private float zoom = 1;
        private bool dragging = false;
        private bool selecting = false;
        private Point dragStartPoint;
        private MouseButtons buttonHeld = MouseButtons.None;

        //////////////////////////////////////////////////////////////////////

        public class ViewChangedEventArgs : EventArgs
        {
            public RectangleF drawRectangle;

            public ViewChangedEventArgs(RectangleF r)
            {
                drawRectangle = r;
            }
        }

        private void RaiseViewChangedEvent()
        {
            if(ViewChanged != null)
            {
                ViewChanged.Invoke(this, new ViewChangedEventArgs(drawRectangle));
            }
        }

        public delegate void ViewChangedCallback(object sender, ViewChangedEventArgs e);
        public event ViewChangedCallback ViewChanged;

        //////////////////////////////////////////////////////////////////////

        public class MouseMovedEventArgs : EventArgs
        {
            public Point position;
            public string message;
            public Color color;

            public MouseMovedEventArgs(Point p, string m, Color c)
            {
                color = c;
                position = p;
                message = m;
            }
        }

        private void RaiseMouseMovedEvent(Point position, string message, Color color)
        {
            if(MouseMoved != null)
            {
                MouseMoved.Invoke(this, new MouseMovedEventArgs(position, message, color));
            }
        }

        public delegate void MouseMovedCallback(object sender, MouseMovedEventArgs e);
        public event MouseMovedCallback MouseMoved;

        //////////////////////////////////////////////////////////////////////

        public PicturePanel()
        {
            InitializeComponent();
            MouseWheel += PicturePanel_MouseWheel;
            MouseMove += PicturePanel_MouseMove;
            MouseDown += PicturePanel_MouseDown;
            MouseUp += PicturePanel_MouseUp;
            MouseLeave += PicturePanel_MouseLeave;
            MouseDoubleClick += PicturePanel_MouseDoubleClick;
            Resize += PicturePanel_Resize;
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Zoom = 1;
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_Resize(object sender, EventArgs e)
        {
            CalcDrawRect(Image);
            Invalidate();
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseLeave(object sender, System.EventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    if (drawRectangle.Contains(e.Location))
                    {
                        Capture = true;
                        dragging = true;
                        dragStartPoint = e.Location;
                        buttonHeld = e.Button;
                    }
                    break;
                case MouseButtons.Left:
                    if (drawRectangle.Contains(e.Location))
                    {
                        dragStartPoint = PixelPositionFromControlPosition(e.Location);
                        Capture = true;
                        selecting = true;
                        selectionRectangle = Rectangle.Empty;
                        Invalidate();
                    }
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Image != null)
            {
                Color c = Color.Transparent;
                string msg = "";
                Focus();
                Point p = PixelPositionFromControlPosition(e.Location);
                if (!drawRectangle.Contains(e.Location))
                {
                    p.X = p.Y = -1;
                }
                else
                {
                    Bitmap b = Image as Bitmap;
                    c = b.GetPixel(p.X, p.Y);
                }
                if (dragging)
                {
                    switch (buttonHeld)
                    {
                        case MouseButtons.Right:
                            drawRectangle.Offset(e.X - dragStartPoint.X, e.Y - dragStartPoint.Y);
                            dragStartPoint = e.Location;
                            Invalidate();
                            RaiseViewChangedEvent();
                            break;
                        case MouseButtons.Left:
                            break;
                    }
                }
                else if(selecting)
                {
                    Point pixelPos = PixelPositionFromControlPosition(e.Location);
                    int left = Math.Max(0, Math.Min(pixelPos.X, dragStartPoint.X));
                    int top = Math.Max(0, Math.Min(pixelPos.Y, dragStartPoint.Y));
                    int right = Math.Min(Image.Width - 1, Math.Max(pixelPos.X, dragStartPoint.X));
                    int bottom = Math.Min(Image.Height - 1, Math.Max(pixelPos.Y, dragStartPoint.Y));
                    selectionRectangle = new Rectangle(left, top, right - left + 1, bottom - top + 1);
                    if (selectionRectangle.Height == 0 || selectionRectangle.Width == 0)
                    {
                        selectionRectangle = Rectangle.Empty;
                    }
                    Invalidate();
                }
                
                if(!selectionRectangle.IsEmpty)
                {
                    msg = string.Format("{0},{1} - {2},{3} ({4},{5})", selectionRectangle.Left, selectionRectangle.Top, selectionRectangle.Right - 1, selectionRectangle.Bottom - 1, selectionRectangle.Width, selectionRectangle.Height);
                }
                RaiseMouseMovedEvent(p, msg, c);
            }
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseUp(object sender, MouseEventArgs e)
        {
            Capture = false;
            dragging = false;
            if (selecting)
            {
                selecting = false;
            }
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if(Image != null && !Capture && drawRectangle.Contains(e.Location))
            {
                zoomLevel = Math.Max(0, Math.Min(zooms.Length - 1, zoomLevel + Math.Sign(e.Delta)));
                float newZoom = zooms[zoomLevel];
                float x = (float)(e.Location.X - drawRectangle.X) / drawRectangle.Width;
                float y = (float)(e.Location.Y - drawRectangle.Y) / drawRectangle.Height;
                drawRectangle.Width = Image.Width * newZoom;
                drawRectangle.Height = Image.Height * newZoom;
                drawRectangle.X = e.Location.X - drawRectangle.Width * x;
                drawRectangle.Y = e.Location.Y - drawRectangle.Height * y;
                zoom = newZoom;
                Invalidate();
                RaiseViewChangedEvent();
            }
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
                for (int i = 0; i < zooms.Length; ++i)
                {
                    zoomLevel = i;
                    if(zooms[i] >= value)
                    {
                        break;
                    }
                }
                CalcDrawRect(Image);
                Invalidate();
            }
        }

        //////////////////////////////////////////////////////////////////////

        protected override void CalcDrawRect(Image image)
        {
            if(image != null)
            {
                float w = image.Width * zoom;
                float h = image.Height * zoom;
                float x = (float)Math.Floor((Width - w) / 2.0f);
                float y = (float)Math.Floor((Height - h) / 2.0f);
                drawRectangle = new RectangleF(x, y, w, h);
                RaiseViewChangedEvent();
            }
        }
    }
}
