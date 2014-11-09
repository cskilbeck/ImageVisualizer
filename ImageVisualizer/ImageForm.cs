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
        private ToolStripMenuItem currentInterpolationModeMenuItem;
        private ToolStripMenuItem currentGridSizeMenuItem;

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

            // build the InterpolationMode menu
            string[] names = Enum.GetNames(typeof(InterpolationMode));
            Array values = Enum.GetValues(typeof(InterpolationMode));
            for (int i = 0; i < names.Length; ++i)
            {
                if ((InterpolationMode)values.GetValue(i) != InterpolationMode.Invalid) //hnf
                {
                    ToolStripMenuItem m = new ToolStripMenuItem(names[i]);
                    m.Click += interpolationMode_Click;
                    m.Tag = values.GetValue(i);
                    m.Checked = (InterpolationMode)m.Tag == picturePanel1.InterpolationMode;
                    if (m.Checked)
                    {
                        currentInterpolationModeMenuItem = m;
                    }
                    zoomModeToolStripMenuItem.DropDownItems.Add(m);
                }
            }

            // sort out what grid size is selected by default
            foreach (ToolStripMenuItem m in gridToolStripMenuItem.DropDownItems)
            {
                currentGridSizeMenuItem = m;
                if (m.Checked)
                {
                    break;
                }
            }
            currentGridSizeMenuItem.Checked = true;
            picturePanel1.GridSize = basicPicturePanel1.GridSize = Convert.ToInt32(currentGridSizeMenuItem.Tag);

            picturePanel1.Image = image;
            basicPicturePanel1.Image = image;
        }

        void interpolationMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem m = sender as ToolStripMenuItem;
            if (m != null)
            {
                if (currentInterpolationModeMenuItem != null)
                {
                    currentInterpolationModeMenuItem.Checked = false;
                }
                m.Checked = true;
                currentInterpolationModeMenuItem = m;
                picturePanel1.InterpolationMode = (InterpolationMode)m.Tag;
                basicPicturePanel1.InterpolationMode = (InterpolationMode)m.Tag;
                // !?
            }
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
//            if (rc.Left >= 0 || rc.Right < image.Width || rc.Top >= 0 || rc.Bottom < image.Height)
            {
                basicPicturePanel1.SelectionRectangle = rc;
                return true;
            }
//            else
            //{
            //    basicPicturePanel1.SelectionRectangle = Rectangle.Empty;
            //    return false;
            //}
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

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(picturePanel1.Image);
        }

        private void SetGridSize(ToolStripMenuItem m)
        {
            if (currentGridSizeMenuItem != null)
            {
                currentGridSizeMenuItem.Checked = false;
            }
            currentGridSizeMenuItem = m;
            currentGridSizeMenuItem.Checked = true;
            picturePanel1.GridSize = basicPicturePanel1.GridSize = Convert.ToInt32(currentGridSizeMenuItem.Tag);
        }

        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGridSize((ToolStripMenuItem)sender);
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGridSize((ToolStripMenuItem)sender);
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGridSize((ToolStripMenuItem)sender);
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.AllowFullOpen = true;
            c.FullOpen = true;
            c.SolidColorOnly = true;
            c.Color = picturePanel1.BackColor;
            if (c.ShowDialog() == DialogResult.OK)
            {
                picturePanel1.BackColor = basicPicturePanel1.BackColor = c.Color;
            }
        }

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picturePanel1.Zoom = 1;
        }
    }
}
