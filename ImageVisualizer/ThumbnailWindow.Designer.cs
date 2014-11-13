namespace ImageVisualizer
{
    partial class ThumbnailWindow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.basicPicturePanel1 = new ImageVisualizer.BasicPicturePanel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 15);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // basicPicturePanel1
            // 
            this.basicPicturePanel1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.basicPicturePanel1.BackColor = System.Drawing.Color.Magenta;
            this.basicPicturePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basicPicturePanel1.Image = null;
            this.basicPicturePanel1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.basicPicturePanel1.Location = new System.Drawing.Point(0, 15);
            this.basicPicturePanel1.Name = "basicPicturePanel1";
            this.basicPicturePanel1.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.basicPicturePanel1.Size = new System.Drawing.Size(128, 128);
            this.basicPicturePanel1.TabIndex = 1;
            this.basicPicturePanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.basicPicturePanel1_MouseDown);
            this.basicPicturePanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.basicPicturePanel1_MouseMove);
            this.basicPicturePanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.basicPicturePanel1_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(113, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 15);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ThumbnailWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.basicPicturePanel1);
            this.Controls.Add(this.panel1);
            this.Name = "ThumbnailWindow";
            this.Size = new System.Drawing.Size(128, 143);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BasicPicturePanel basicPicturePanel1;
        private System.Windows.Forms.Button button1;
    }
}
