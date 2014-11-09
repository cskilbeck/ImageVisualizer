//////////////////////////////////////////////////////////////////////
// fit window to zoomed graphic if possible
// 
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

        private float[] zooms = { 1 / 5.0f, 1 / 4.0f, 1 / 3.0f, 1 / 2.0f, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int zoomLevel = 4;
        private float zoom = 1;
        private bool dragging = false;
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

        public delegate void ViewChangedCallback(object sender, ViewChangedEventArgs e);
        public event ViewChangedCallback ViewChanged;

        private void RaiseViewChangedEvent()
        {
            if(ViewChanged != null)
            {
                ViewChanged.Invoke(this, new ViewChangedEventArgs(drawRectangle));
            }
        }

        //////////////////////////////////////////////////////////////////////

        public class MouseMovedEventArgs : EventArgs
        {
            public Point mousePosition;

            public MouseMovedEventArgs(Point p)
            {
                mousePosition = p;
            }
        }
        private void RaiseMouseMovedEvent(int x, int y)
        {
            if(MouseMoved != null)
            {
                MouseMoved.Invoke(this, new MouseMovedEventArgs(new Point(x, y)));
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
            if(Image != null)
            {
                CalcDrawRect();
                Invalidate();
            }
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseLeave(object sender, System.EventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseUp(object sender, MouseEventArgs e)
        {
            Capture = false;
            dragging = false;
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(drawRectangle.Contains(e.Location))
            {
                Capture = true;
                dragging = true;
                dragStartPoint = e.Location;
                buttonHeld = e.Button;
            }
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseMove(object sender, MouseEventArgs e)
        {
            Focus();
            if (MouseMoved != null)
            {
                Point p = PixelPositionFromControlPosition(e.Location);
                if (!drawRectangle.Contains(e.Location))
                {
                    p.X = p.Y = -1;
                }
                RaiseMouseMovedEvent(p.X, p.Y);
            }
            if (dragging)
            {
                switch (buttonHeld)
                {
                    case MouseButtons.Left:
                        drawRectangle.Offset(e.X - dragStartPoint.X, e.Y - dragStartPoint.Y);
                        dragStartPoint = e.Location;
                        Invalidate();
                        RaiseViewChangedEvent();
                        break;
                    case MouseButtons.Right:
                        break;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////

        void PicturePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if(!Capture && drawRectangle.Contains(e.Location))
            {
                zoomLevel = Math.Max(0, Math.Min(zooms.Length - 1, zoomLevel + Math.Sign(e.Delta)));
                float newZoom = zooms[zoomLevel];
                float x = (float)(e.Location.X - drawRectangle.X) / drawRectangle.Width;
                float y = (float)(e.Location.Y - drawRectangle.Y) / drawRectangle.Height;
                drawRectangle.Width = Image.Width * newZoom;
                drawRectangle.Height = Image.Width * newZoom;
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
                if(Image != null)
                {
                    CalcDrawRect();
                    Invalidate();
                }
            }
        }

        //////////////////////////////////////////////////////////////////////

        protected override void CalcDrawRect()
        {
            float w = Image.Width * zoom;
            float h = Image.Height * zoom;
            float x = (float)Math.Floor((Width - w) / 2.0f);
            float y = (float)Math.Floor((Height - h) / 2.0f);
            drawRectangle = new RectangleF(x, y, w, h);
            RaiseViewChangedEvent();
        }
    }
}
