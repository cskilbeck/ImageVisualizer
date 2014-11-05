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

        public ImageForm(Image image)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            var mousePos = Cursor.Position;
            ClientSize = image.Size;
            Location = new Point(mousePos.X - this.Width / 2, mousePos.Y - this.Height / 2);
            string fmt = image.PixelFormat.ToString().Replace("Format", "");
            Text = String.Format("{0}x{1},{2}", image.Width, image.Height, fmt);
            if(Debugger.IsAttached)
            {
                this.ShowInTaskbar = true;
            }
            picturePanel1.Image = image;
        }
    }
}
