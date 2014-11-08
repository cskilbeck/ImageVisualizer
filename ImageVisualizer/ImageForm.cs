//////////////////////////////////////////////////////////////////////
// Zoom in on the mouse position
// Sort out the zoom modes (list the enum in the menu?)
// Save/restore options
// Allow background colour option? \
// Allow zoom out as well as in \
// 

using System;
using System.Drawing;
using Microsoft.Win32;
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
        //////////////////////////////////////////////////////////////////////

        private bool dragSelection;

        public ImageForm(Image image)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            var mousePos = Cursor.Position;
            Location = new Point(mousePos.X - this.Width / 2, Math.Max(0, mousePos.Y - this.Height / 2));
            string fmt = image.PixelFormat.ToString().Replace("Format", "");
            detailsLabel.Text = String.Format("{0}x{1},{2}", image.Width, image.Height, fmt);
            this.ShowInTaskbar = true;
            picturePanel1.MouseMoved += picturePanel1_MouseMoved;
            picturePanel1.ViewChanged += picturePanel1_ViewChanged;
            picturePanel1.Image = image;
            basicPicturePanel1.Image = image;
        }

        void picturePanel1_ViewChanged(object sender, PicturePanel.ViewChangedEventArgs e)
        {
            RectangleF d = e.drawRectangle;

            float xs = (float)picturePanel1.Image.Width / d.Width;
            float ys = (float)picturePanel1.Image.Height / d.Height;

            float l = -d.Left * xs;
            float t = -d.Top * ys;
            float w = picturePanel1.Width * xs + 1;
            float h = picturePanel1.Height * ys + 1;

            ApplySelectionRectangle(new Rectangle((int)l, (int)t, (int)w, (int)h));
        }

        bool ApplySelectionRectangle(Rectangle rc)
        {
            Image image = picturePanel1.Image;
            if (rc.Left >= 0 || rc.Right < image.Width || rc.Top >= 0 || rc.Bottom < image.Height)
            {
                basicPicturePanel1.SelectionRectangle = rc;
                return true;
            }
            else
            {
                basicPicturePanel1.SelectionRectangle = Rectangle.Empty;
                return false;
            }
        }

        void picturePanel1_MouseMoved(object sender, PicturePanel.MouseMovedEventArgs e)
        {
            if(e.mousePosition.X >= 0)
            {
                mousePositionLabel.Text = string.Format("{0},{1}", e.mousePosition.X, e.mousePosition.Y);
            }
            else
            {
                mousePositionLabel.Text = "";
            }
        }

        private void SetSelectionRectangle(Point pos)
        {
            Point p = basicPicturePanel1.PixelPositionFromControlPosition(pos);
            Rectangle r = basicPicturePanel1.SelectionRectangle;
            p.X -= r.Width / 2;
            p.Y -= r.Height / 2;
            r.Location = p;
            if(ApplySelectionRectangle(r))
            {
                RectangleF d = picturePanel1.drawRectangle;
                float xs = d.Width / picturePanel1.Image.Width;
                float ys = d.Height / picturePanel1.Image.Height;
                picturePanel1.drawRectangle = new RectangleF(-p.X * xs, -p.Y * ys, d.Width, d.Height);
                picturePanel1.Invalidate();
            }
            else
            {
                picturePanel1.Zoom = 1;
                dragSelection = false;
            }
        }

        private void basicPicturePanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!basicPicturePanel1.SelectionRectangle.IsEmpty)
            {
                dragSelection = true;
                SetSelectionRectangle(e.Location);
            }
        }

        private void basicPicturePanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(dragSelection)
            {
                SetSelectionRectangle(e.Location);
            }
        }

        private void basicPicturePanel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragSelection = false;
        }
    }
}
