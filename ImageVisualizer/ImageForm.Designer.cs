namespace ImageVisualizer
{
    partial class ImageForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.detailsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mousePositionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picturePanel1 = new ImageVisualizer.PicturePanel();
            this.basicPicturePanel1 = new ImageVisualizer.BasicPicturePanel();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(898, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.optionsToolStripMenuItem.Text = "&File";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picturePanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.basicPicturePanel1);
            this.splitContainer1.Size = new System.Drawing.Size(898, 734);
            this.splitContainer1.SplitterDistance = 733;
            this.splitContainer1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsLabel,
            this.mousePositionLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 758);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(898, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = false;
            this.detailsLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(150, 17);
            this.detailsLabel.Text = "details";
            // 
            // mousePositionLabel
            // 
            this.mousePositionLabel.AutoSize = false;
            this.mousePositionLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.mousePositionLabel.Name = "mousePositionLabel";
            this.mousePositionLabel.Size = new System.Drawing.Size(200, 17);
            this.mousePositionLabel.Text = "mousePosition";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.zoomModeToolStripMenuItem,
            this.resetZoomToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem1.Text = "&Options";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallToolStripMenuItem1,
            this.mediumToolStripMenuItem1,
            this.largeToolStripMenuItem1});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.gridToolStripMenuItem.Text = "&Grid";
            // 
            // smallToolStripMenuItem1
            // 
            this.smallToolStripMenuItem1.Name = "smallToolStripMenuItem1";
            this.smallToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.smallToolStripMenuItem1.Tag = "4";
            this.smallToolStripMenuItem1.Text = "&Small";
            this.smallToolStripMenuItem1.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem1
            // 
            this.mediumToolStripMenuItem1.Checked = true;
            this.mediumToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mediumToolStripMenuItem1.Name = "mediumToolStripMenuItem1";
            this.mediumToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.mediumToolStripMenuItem1.Tag = "16";
            this.mediumToolStripMenuItem1.Text = "&Medium";
            this.mediumToolStripMenuItem1.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // largeToolStripMenuItem1
            // 
            this.largeToolStripMenuItem1.Name = "largeToolStripMenuItem1";
            this.largeToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.largeToolStripMenuItem1.Tag = "64";
            this.largeToolStripMenuItem1.Text = "&Large";
            this.largeToolStripMenuItem1.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // zoomModeToolStripMenuItem
            // 
            this.zoomModeToolStripMenuItem.Name = "zoomModeToolStripMenuItem";
            this.zoomModeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.zoomModeToolStripMenuItem.Text = "&Zoom mode";
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            this.resetZoomToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.resetZoomToolStripMenuItem.Text = "&Reset zoom";
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.resetZoomToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.backgroundColorToolStripMenuItem.Text = "&Background color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // picturePanel1
            // 
            this.picturePanel1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.picturePanel1.BackColor = System.Drawing.Color.Magenta;
            this.picturePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePanel1.Image = null;
            this.picturePanel1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.picturePanel1.Location = new System.Drawing.Point(0, 0);
            this.picturePanel1.Margin = new System.Windows.Forms.Padding(0);
            this.picturePanel1.Name = "picturePanel1";
            this.picturePanel1.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.picturePanel1.Size = new System.Drawing.Size(733, 734);
            this.picturePanel1.TabIndex = 1;
            this.picturePanel1.Zoom = 1F;
            // 
            // basicPicturePanel1
            // 
            this.basicPicturePanel1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.basicPicturePanel1.BackColor = System.Drawing.Color.Magenta;
            this.basicPicturePanel1.Image = null;
            this.basicPicturePanel1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.basicPicturePanel1.Location = new System.Drawing.Point(0, 0);
            this.basicPicturePanel1.Name = "basicPicturePanel1";
            this.basicPicturePanel1.SelectionRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.basicPicturePanel1.Size = new System.Drawing.Size(161, 161);
            this.basicPicturePanel1.TabIndex = 1;
            this.basicPicturePanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.basicPicturePanel1_MouseDown);
            this.basicPicturePanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.basicPicturePanel1_MouseMove);
            this.basicPicturePanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.basicPicturePanel1_MouseUp);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 780);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "ImageForm";
            this.ShowInTaskbar = false;
            this.Text = "Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageForm_FormClosing);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PicturePanel picturePanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel detailsLabel;
        private System.Windows.Forms.ToolStripStatusLabel mousePositionLabel;
        private BasicPicturePanel basicPicturePanel1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zoomModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;




    }
}