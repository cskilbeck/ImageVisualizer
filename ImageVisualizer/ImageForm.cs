//////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using Microsoft.Win32;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public partial class ImageForm : Form
    {
        ToolStripMenuItem currentInterpolationModeMenuItem;
        ToolStripMenuItem currentGridSizeMenuItem;
        bool dragSelection;
        int gridSize;
        Image sourceImage;

        //////////////////////////////////////////////////////////////////////

        public ImageForm(Image sourceImage)
        {
            InitializeComponent();
            this.sourceImage = sourceImage;
            StartPosition = FormStartPosition.Manual;
            var mousePos = Cursor.Position;
            Location = new Point(mousePos.X - this.Width / 2, Math.Max(0, mousePos.Y - this.Height / 2));
            string fmt = sourceImage.PixelFormat.ToString().Replace("Format", "");
            detailsLabel.Text = String.Format("{0}x{1},{2}", sourceImage.Width, sourceImage.Height, fmt);
            this.ShowInTaskbar = true;
            picturePanel1.MouseMoved += picturePanel1_MouseMoved;
            picturePanel1.MouseLeave += picturePanel1_MouseLeave;
            picturePanel1.ViewChanged += picturePanel1_ViewChanged;

            gridSize = Properties.Settings.Default.GridSize;
            picturePanel1.gridSize = gridSize;
            basicPicturePanel1.gridSize = 0;
            picturePanel1.BackColor = Properties.Settings.Default.BackgroundColour;
            basicPicturePanel1.BackColor = Properties.Settings.Default.BackgroundColour;
            picturePanel1.InterpolationMode = Properties.Settings.Default.ZoomMode;

            // build the InterpolationMode menu
            string[] names = Enum.GetNames(typeof(InterpolationMode));
            Array values = Enum.GetValues(typeof(InterpolationMode));
            for (int i = 0; i < names.Length; ++i)
            {
                if ((InterpolationMode)values.GetValue(i) != InterpolationMode.Invalid) //hmph
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
            currentGridSizeMenuItem = null;
            foreach (ToolStripMenuItem m in gridToolStripMenuItem.DropDownItems)
            {
                int s = Convert.ToInt32(m.Tag);
                if(s == gridSize)
                {
                    currentGridSizeMenuItem = m;
                    m.Checked = true;
                }
            }
            if(currentGridSizeMenuItem == null)
            {
                currentGridSizeMenuItem = mediumToolStripMenuItem1;
                currentGridSizeMenuItem.Checked = true;
                gridSize = Convert.ToInt32(currentGridSizeMenuItem.Tag);
                picturePanel1.gridSize = gridSize;
            }
            BuildImage();
        }

        //////////////////////////////////////////////////////////////////////

        void BuildImage()
        {
            picturePanel1.Image = sourceImage;
            basicPicturePanel1.Image = sourceImage;
        }

        //////////////////////////////////////////////////////////////////////

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

        //////////////////////////////////////////////////////////////////////

        void picturePanel1_ViewChanged(object sender, PicturePanel.ViewChangedEventArgs e)
        {
            if(picturePanel1.Image != null)
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
        }

        //////////////////////////////////////////////////////////////////////

        bool ApplySelectionRectangle(Rectangle rc)
        {
            Image image = picturePanel1.Image;
            {
                basicPicturePanel1.SelectionRectangle = rc;
                return true;
            }

        }

        //////////////////////////////////////////////////////////////////////

        void picturePanel1_MouseMoved(object sender, PicturePanel.MouseMovedEventArgs e)
        {
            if(e.position.X >= 0)
            {
                mousePositionLabel.Text = string.Format("{0},{1}", e.position.X, e.position.Y);
            }
            selectionDetailsLabel.Text = e.message;
        }

        //////////////////////////////////////////////////////////////////////

        void picturePanel1_MouseLeave(object sender, EventArgs e)
        {
            mousePositionLabel.Text = "";
        }

        //////////////////////////////////////////////////////////////////////

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

        //////////////////////////////////////////////////////////////////////

        private void basicPicturePanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!basicPicturePanel1.SelectionRectangle.IsEmpty)
            {
                dragSelection = true;
                SetSelectionRectangle(e.Location);
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void basicPicturePanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(dragSelection)
            {
                SetSelectionRectangle(e.Location);
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void basicPicturePanel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragSelection = false;
        }

        //////////////////////////////////////////////////////////////////////

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle r = picturePanel1.SelectionRectangle;
            if(r.IsEmpty)
            {
                Clipboard.SetImage(picturePanel1.Image);
            }
            else
            {
                Bitmap b = new Bitmap(r.Width, r.Height);
                using(Graphics g = Graphics.FromImage(b))
                {
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.CompositingMode = CompositingMode.SourceCopy;
                    g.SmoothingMode = SmoothingMode.None;
                    Rectangle destRect = new Rectangle(0, 0, r.Width, r.Height);
                    g.DrawImage(picturePanel1.Image, destRect, r, GraphicsUnit.Pixel);
                }
                Clipboard.SetImage(b);
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void SetGridSize(ToolStripMenuItem m)
        {
            if (currentGridSizeMenuItem != null)
            {
                currentGridSizeMenuItem.Checked = false;
            }
            currentGridSizeMenuItem = m;
            currentGridSizeMenuItem.Checked = true;
            gridSize = Convert.ToInt32(currentGridSizeMenuItem.Tag);
            picturePanel1.gridSize = gridSize;
            BuildImage();
        }

        //////////////////////////////////////////////////////////////////////

        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGridSize((ToolStripMenuItem)sender);
        }

        //////////////////////////////////////////////////////////////////////

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

        //////////////////////////////////////////////////////////////////////

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picturePanel1.Zoom = 1;
        }

        //////////////////////////////////////////////////////////////////////

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.CheckPathExists = true;
            d.AutoUpgradeEnabled = true;
            d.AddExtension = true;
            d.DefaultExt = "png";
            d.Filter = "png|*.png";
            d.OverwritePrompt = true;
            if(d.ShowDialog() == DialogResult.OK)
            {
                picturePanel1.Image.Save(d.FileName, ImageFormat.Png);
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void ImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ZoomMode = picturePanel1.InterpolationMode;
            Properties.Settings.Default.GridSize = gridSize;
            Properties.Settings.Default.BackgroundColour = picturePanel1.BackColor;
            Properties.Settings.Default.Save();
        }

        //////////////////////////////////////////////////////////////////////

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
