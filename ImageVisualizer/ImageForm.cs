//////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using Microsoft.Win32;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public partial class ImageForm : Form
    {
        ToolStripMenuItem   currentInterpolationModeMenuItem;
        ToolStripMenuItem   currentGridSizeMenuItem;
        bool                dragSelection;
        Image               originalImage;
        Image               sourceImage;
        Color               pixelColor = Color.Transparent;
        bool                showPixelColor;
        Color[]             gridColors = { Color.LightGray, Color.DarkGray };
        BasicPicturePanel   thumbnailPanel;
        Settings            settings;

        //////////////////////////////////////////////////////////////////////

        public ImageForm(Image image)
        {
            InitializeComponent();
            thumbnailPanel = thumbnailWindow1.PicturePanel;

            LoadSettings();

            originalImage = image;
            sourceImage = image;
            StartPosition = FormStartPosition.Manual;
            Size ms = SystemInformation.PrimaryMonitorSize;
            Location = new Point((ms.Width - Width) / 2, (ms.Height - Height) / 2);
            string fmt = sourceImage.PixelFormat.ToString().Replace("Format", "");
            detailsLabel.Text = String.Format("{0}x{1},{2}", sourceImage.Width, sourceImage.Height, fmt);
            this.ShowInTaskbar = true;
            picturePanel1.MouseMoved += picturePanel1_MouseMoved;
            picturePanel1.MouseLeave += picturePanel1_MouseLeave;
            picturePanel1.ViewChanged += picturePanel1_ViewChanged;

            picturePanel1.gridSize = settings.GridSize;
            thumbnailPanel.gridSize = 0;

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
                if(m.Tag != null)
                {
                    int s = Convert.ToInt32(m.Tag);
                    if (s == settings.GridSize)
                    {
                        currentGridSizeMenuItem = m;
                        m.Checked = true;
                    }
                }
            }
            if(currentGridSizeMenuItem == null)
            {
                currentGridSizeMenuItem = mediumToolStripMenuItem1;
                currentGridSizeMenuItem.Checked = true;
                settings.GridSize = Convert.ToInt32(currentGridSizeMenuItem.Tag);
                picturePanel1.gridSize = settings.GridSize;
            }
            BuildImage();
        }

        //////////////////////////////////////////////////////////////////////

        void BuildImage()
        {
            picturePanel1.Image = sourceImage;
            thumbnailPanel.Image = sourceImage;
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
                thumbnailPanel.InterpolationMode = (InterpolationMode)m.Tag;
            }
        }

        //////////////////////////////////////////////////////////////////////

        void picturePanel1_ViewChanged(object sender, PicturePanel.ViewChangedEventArgs e)
        {
            if(picturePanel1.Image != null && e.showIt)
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
            else
            {
                thumbnailPanel.SelectionRectangle = Rectangle.Empty;
            }
        }

        //////////////////////////////////////////////////////////////////////

        bool ApplySelectionRectangle(Rectangle rc)
        {
            thumbnailPanel.SelectionRectangle = rc;
            return true;
        }

        //////////////////////////////////////////////////////////////////////

        void picturePanel1_MouseMoved(object sender, PicturePanel.MouseMovedEventArgs e)
        {
            string m = "";
            string c = "";
            showPixelColor = false;
            if(e.position.X >= 0)
            {
                showPixelColor = true;
                m = string.Format("{0},{1}", e.position.X, e.position.Y);
                c = e.color.ToArgb().ToString("X8");
            }
            mousePositionLabel.Text = m;
            selectionDetailsLabel.Text = e.message;
            colorDetailStatusLabel.Text = c;
            pixelColor = e.color;
        }

        //////////////////////////////////////////////////////////////////////

        void picturePanel1_MouseLeave(object sender, EventArgs e)
        {
            showPixelColor = false;
            colorDetailStatusLabel.Text = "";
            mousePositionLabel.Text = "";
        }

        //////////////////////////////////////////////////////////////////////

        private void SetSelectionRectangle(Point pos)
        {
            Point p = thumbnailPanel.PixelPositionFromControlPosition(pos);
            Rectangle r = thumbnailPanel.SelectionRectangle;
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
            if(!thumbnailPanel.SelectionRectangle.IsEmpty)
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
            settings.GridSize = Convert.ToInt32(currentGridSizeMenuItem.Tag);
            picturePanel1.gridSize = settings.GridSize;
            BuildImage();
        }

        //////////////////////////////////////////////////////////////////////

        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGridSize((ToolStripMenuItem)sender);
        }

        //////////////////////////////////////////////////////////////////////

        private bool ChooseColor(ref Color color)
        {
            ColorDialog c = new ColorDialog();
            c.AllowFullOpen = true;
            c.FullOpen = true;
            c.SolidColorOnly = true;
            c.Color = color;
            if (c.ShowDialog() == DialogResult.OK)
            {
                color = c.Color;
                return true;
            }
            return false;
        }

        //////////////////////////////////////////////////////////////////////

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color c = picturePanel1.BackColor;
            if(ChooseColor(ref c))
            {
                picturePanel1.BackColor = c;
                thumbnailPanel.BackColor = c;
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

        static string SettingsFilename
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ImageVisualizer.xml");
            }
        }

        //////////////////////////////////////////////////////////////////////

        void LoadSettings()
        {
            settings = Options.Load<Settings>(SettingsFilename);
            picturePanel1.BackColor = settings.BackgroundColour;
            thumbnailPanel.BackColor = settings.BackgroundColour;
            picturePanel1.InterpolationMode = settings.InterpolationMode;
            gridColors[0] = settings.GridColor1;
            gridColors[1] = settings.GridColor2;
            picturePanel1.SetGridColors(gridColors);
            thumbnailWindow1.Visible = settings.ThumbnailVisible;
            thumbnailToolStripMenuItem.Checked = settings.ThumbnailVisible;
        }

        //////////////////////////////////////////////////////////////////////

        void SaveSettings()
        {
            settings.InterpolationMode   = picturePanel1.InterpolationMode;
            settings.BackgroundColour    = picturePanel1.BackColor;
            settings.GridColor1          = gridColors[0];
            settings.GridColor2          = gridColors[1];

            Options.Save(settings, SettingsFilename);
        }

        //////////////////////////////////////////////////////////////////////

        private void ImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        //////////////////////////////////////////////////////////////////////

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //////////////////////////////////////////////////////////////////////

        private void colorStatusLabel_Paint(object sender, PaintEventArgs e)
        {
            if(showPixelColor)
            {
                Graphics gr = e.Graphics;
                int p = pixelColor.ToArgb();
                int s = 0xff << 24;
                int t = (p >> 24) & 0xff;
                Color r = Color.FromArgb(p & 0x00ff0000 | s);
                Color g = Color.FromArgb(p & 0x0000ff00 | s);
                Color b = Color.FromArgb(p & 0x000000ff | s);
                Color a = Color.FromArgb(t | (t << 8) | (t << 16) | s);
                gr.FillRectangle(new SolidBrush(a), new Rectangle(1, 1, 15, 15));
                gr.FillRectangle(new SolidBrush(r), new Rectangle(17, 1, 15, 15));
                gr.FillRectangle(new SolidBrush(g), new Rectangle(33, 1, 15, 15));
                gr.FillRectangle(new SolidBrush(b), new Rectangle(49, 1, 15, 15));

                Brush[] brush = { new SolidBrush(gridColors[0]), new SolidBrush(gridColors[1]) };
                int yBrush = 0;
                RectangleF rc = new RectangleF(0, 0, 3, 3);
                {
                    for (float y = 0; y < 15; y += 3)
                    {
                        int xBrush = yBrush;
                        rc.Y = y + 1;
                        for (float x = 0; x < 15; x += 3)
                        {
                            rc.X = x + 78;
                            gr.FillRectangle(brush[xBrush], rc);
                            xBrush = 1 - xBrush;
                        }
                        yBrush = 1 - yBrush;
                    }
                }

                gr.FillRectangle(new SolidBrush(pixelColor), new Rectangle(78, 1, 15, 15));
            }
        }

        //////////////////////////////////////////////////////////////////////

        private static byte[] GetPixels(Bitmap b)
        {
            Rectangle r = new Rectangle(Point.Empty, b.Size);
            BitmapData d = b.LockBits(r, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int len = d.Height * d.Stride;
            byte[] pixels = new byte[len];
            Marshal.Copy(d.Scan0, pixels, 0, len);
            b.UnlockBits(d);
            return pixels;
        }

        //////////////////////////////////////////////////////////////////////

        private static void SetPixels(Bitmap b, byte[] bytes)
        {
            Rectangle r = new Rectangle(Point.Empty, b.Size);
            BitmapData d = b.LockBits(r, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int len = d.Height * d.Stride;
            if(bytes.Length < len)
            {
                throw new System.ArgumentException();
            }
            Marshal.Copy(bytes, 0, d.Scan0, len);
            b.UnlockBits(d);
        }

        //////////////////////////////////////////////////////////////////////

        private void viewChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = originalImage as Bitmap;
            if (b != null)
            {
                object t = (sender as ToolStripMenuItem).Tag;
                if(t != null)
                {
                    int m = Convert.ToInt32(t);
                    byte[] pixels = GetPixels(b);
                    int len = pixels.Length;
                    for (int i = 0; i < len; i += 4)
                    {
                        byte c = pixels[i + m];
                        pixels[i + 3] = 0xff;
                        pixels[i + 0] = pixels[i + 1] = pixels[i + 2] = c;
                    }
                    Bitmap n = new Bitmap(b.Width, b.Height, PixelFormat.Format32bppArgb);
                    SetPixels(n, pixels);
                    picturePanel1.Image = n;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void maskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap b = originalImage as Bitmap;
            if (b != null)
            {
                byte[] pixels = GetPixels(b);
                int len = pixels.Length;
                for (int i = 0; i < len; i += 4)
                {
                    int p = pixels[i + 0] + pixels[i + 1] + pixels[i + 2] + pixels[i + 3];
                    byte r = (byte)((p != 0) ? (byte)255 : 0);
                    pixels[i + 0] = pixels[i + 1] = pixels[i + 2] = pixels[i + 3] = r;
                }
                Bitmap n = new Bitmap(b.Width, b.Height, PixelFormat.Format32bppArgb);
                SetPixels(n, pixels);
                picturePanel1.Image = n;
            }
        }

        //////////////////////////////////////////////////////////////////////

        private void originalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picturePanel1.Image = originalImage;
        }

        //////////////////////////////////////////////////////////////////////

        private void selectExtentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // scan the bitmap for non-empty pixels and set the selection rectangle accordingly
            Bitmap b = originalImage as Bitmap;
            if(b != null)
            {
                int w = b.Width;
                int h = b.Height;
                int xmin = w;
                int ymin = h;
                int xmax = -1;
                int ymax = -1;
                for(int y = 0; y < h; ++y)
                {
                    for (int x = 0; x < w; ++x)
                    {
                        if(b.GetPixel(x, y).ToArgb() != 0)
                        {
                            xmin = Math.Min(xmin, x);
                            ymin = Math.Min(ymin, y);
                            xmax = Math.Max(xmax, x);
                            ymax = Math.Max(ymax, y);
                        }
                    }
                }
                if(xmin != -1)
                {
                    picturePanel1.SelectionRectangle = new Rectangle(xmin, ymin, xmax - xmin + 1, ymax - ymin + 1);
                    picturePanel1.Invalidate();
                }
            }

        }

        //////////////////////////////////////////////////////////////////////

        private void colour1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseColor(ref gridColors[0]);
            picturePanel1.SetGridColors(gridColors);
        }

        //////////////////////////////////////////////////////////////////////

        private void colour2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseColor(ref gridColors[1]);
            picturePanel1.SetGridColors(gridColors);
        }

        //////////////////////////////////////////////////////////////////////

        private void thumbnailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.ThumbnailVisible = !settings.ThumbnailVisible;
            thumbnailWindow1.Visible = settings.ThumbnailVisible;
            thumbnailToolStripMenuItem.Checked = settings.ThumbnailVisible;
        }

        //////////////////////////////////////////////////////////////////////

        private void thumbnailWindow1_VisibleChanged(object sender, EventArgs e)
        {
            settings.ThumbnailVisible = thumbnailWindow1.Visible;
            thumbnailToolStripMenuItem.Checked = settings.ThumbnailVisible;
        }

        //////////////////////////////////////////////////////////////////////

        private void ImageForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)
            {
                Close();
            }
        }
    }

    //////////////////////////////////////////////////////////////////////

    public class Settings
    {
        [XmlElement(Type = typeof(XmlColor))]
        public Color BackgroundColour = Color.Magenta;

        public int GridSize = 16;
        public InterpolationMode InterpolationMode = InterpolationMode.NearestNeighbor;
        public bool ThumbnailVisible = true;
        public int ThumbnailAlign = 0;

        [XmlElement(Type = typeof(XmlColor))]
        public Color GridColor1 = Color.LightGray;

        [XmlElement(Type = typeof(XmlColor))]
        public Color GridColor2 = Color.DarkGray;
    }
}
