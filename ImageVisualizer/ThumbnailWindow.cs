//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public partial class ThumbnailWindow : UserControl
    {
        public delegate void ThumbnailMouseDownCallback(object sender, MouseEventArgs e);
        public delegate void ThumbnailMouseMoveCallback(object sender, MouseEventArgs e);
        public delegate void ThumbnailMouseUpCallback(object sender, MouseEventArgs e);
        public event ThumbnailMouseDownCallback ThumbnailMouseDown;
        public event ThumbnailMouseMoveCallback ThumbnailMouseMove;
        public event ThumbnailMouseUpCallback ThumbnailMouseUp;

        //////////////////////////////////////////////////////////////////////

        private Control parent;
        bool drag = false;
        Point dragOffset;

        //////////////////////////////////////////////////////////////////////

        public ThumbnailWindow()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////

        void parent_Resize(object sender, EventArgs e)
        {
            Clamp(Location, false);
        }

        //////////////////////////////////////////////////////////////////////

        void Clamp(Point pos, bool setAnchor)
        {
            int x = pos.X;
            int y = pos.Y;
            AnchorStyles a = AnchorStyles.None;
            if (x <= parent.Left)
            {
                x = parent.Left;
                a |= AnchorStyles.Left;
            }
            else if (x >= parent.Right - Width)
            {
                x = parent.Right - Width;
                a |= AnchorStyles.Right;
            }
            if (y <= parent.Top)
            {
                y = parent.Top;
                a |= AnchorStyles.Top;
            }
            else if (y >= parent.Bottom - Height)
            {
                y = parent.Bottom - Height;
                a |= AnchorStyles.Bottom;
            }
            if (setAnchor)
            {
                Anchor = a;
            }
            Location = new Point(x, y);
        }

        //////////////////////////////////////////////////////////////////////

        public BasicPicturePanel PicturePanel
        {
            get
            {
                return basicPicturePanel1;
            }
        }

        //////////////////////////////////////////////////////////////////////

        [Category("Layout")]
        public Control ContainerParent
        {
            set
            {
                parent = value;
                parent.Resize += parent_Resize;
            }
            get
            {
                return parent;
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        //////////////////////////////////////////////////////////////////////

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            panel1.Capture = true;
            dragOffset = parent.PointToClient(PointToScreen(e.Location));
            dragOffset.X -= Location.X;
            dragOffset.Y -= Location.Y;
        }

        //////////////////////////////////////////////////////////////////////

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point np = parent.PointToClient(PointToScreen(e.Location));
                if(np != dragOffset)
                {
                    int x = np.X - dragOffset.X;
                    int y = np.Y - dragOffset.Y;
                    Clamp(new Point(x, y), true);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            panel1.Capture = false;
        }

        //////////////////////////////////////////////////////////////////////

        private void basicPicturePanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ThumbnailMouseDown != null)
            {
                ThumbnailMouseDown.Invoke(basicPicturePanel1, e);
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void basicPicturePanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ThumbnailMouseMove != null)
            {
                ThumbnailMouseMove.Invoke(basicPicturePanel1, e);
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void basicPicturePanel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (ThumbnailMouseUp != null)
            {
                ThumbnailMouseUp.Invoke(basicPicturePanel1, e);
            }
        }
    }
}
