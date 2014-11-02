﻿using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageVisualizer
{
    /// <summary>
    /// ZoomPicBox does what it says on the wrapper.
    /// </summary>
    /// <remarks>
    /// PictureBox doesn't lend itself well to overriding. Why not start with something basic and do the job properly?
    /// </remarks>
    public partial class ZoomPicBox : ScrollableControl
    {

        Image _image;
        [Category("Appearance"), Description("The image to be displayed")]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                UpdateScaleFactor();
                Invalidate();
            }
        }

        float _zoom = 1.0f;
        [Category("Appearance"), Description("The zoom factor. Less than 1 to reduce. More than 1 to magnify.")]
        public float Zoom
        {
            get { return _zoom; }
            set
            {
                if (value < 0 || value < 0.00001)
                    value = 0.00001f;
                _zoom = value;
                UpdateScaleFactor();
                Invalidate();
                Debug.Print("Zoom set to {0}", _zoom);
            }
        }

        /// <summary>
        /// Calculates the effective size of the image
        ///after zooming and updates the AutoScrollSize accordingly
        /// </summary>
        private void UpdateScaleFactor()
        {
            if (_image == null)
                ;//this.AutoScrollMinSize = this.Size;
            else
            {
                this.AutoScrollMinSize = new Size(
                  (int)((this._image.Width) * _zoom),
                  (int)((this._image.Height) * _zoom)
                  );
            }
            Debug.Print("AutoScrollMinSize: {0},{1}", AutoScrollMinSize.Width, AutoScrollMinSize.Height);
        }

        InterpolationMode _interpolationMode = InterpolationMode.NearestNeighbor;
        [Category("Appearance"), Description("The interpolation mode used to smooth the drawing")]
        public InterpolationMode InterpolationMode
        {
            get { return _interpolationMode; }
            set { _interpolationMode = value; }
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // do nothing.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //if no image, don't bother
            if (_image == null)
            {
                base.OnPaintBackground(e);
                return;
            }
            //Set up a zoom/translate matrix
            Matrix mx = new Matrix(_zoom, 0, 0, _zoom, 0, 0);
            float x = AutoScrollPosition.X / _zoom;
            float y = AutoScrollPosition.Y / _zoom;

            // center the image if there are no scroll bars
            if(!HScroll)
            {
                x = (this.Width - _image.Width * _zoom) / 2 / _zoom;
            }
            if(!VScroll)
            {
                y = (this.Height - _image.Height * _zoom) / 2 / _zoom;
            }
            mx.Translate(x, y);

            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.ClipRectangle);
            e.Graphics.Transform = mx;
            e.Graphics.InterpolationMode = _interpolationMode;
            e.Graphics.DrawImage(_image, new Rectangle(0, 0, _image.Width, _image.Height), 0, 0, _image.Width, _image.Height, GraphicsUnit.Pixel);
            base.OnPaint(e);
        }


        public ZoomPicBox()
        {
            //Double buffer the control
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffer, true);

            this.AutoScroll = true;
        }
    }
}