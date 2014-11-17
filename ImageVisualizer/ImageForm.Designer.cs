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
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectExtentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.originalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alphaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colour1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colour2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExpando = new System.Windows.Forms.StatusStrip();
            this.detailsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mousePositionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectionDetailsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDetailStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.thumbnailWindow1 = new ImageVisualizer.ThumbnailWindow();
            this.picturePanel1 = new ImageVisualizer.PicturePanel();
            this.menuStrip2.SuspendLayout();
            this.toolStripExpando.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(660, 24);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.optionsToolStripMenuItem.Text = "&File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.selectExtentToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // selectExtentToolStripMenuItem
            // 
            this.selectExtentToolStripMenuItem.Name = "selectExtentToolStripMenuItem";
            this.selectExtentToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectExtentToolStripMenuItem.Text = "Select &Extent";
            this.selectExtentToolStripMenuItem.Click += new System.EventHandler(this.selectExtentToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetZoomToolStripMenuItem,
            this.toolStripMenuItem1,
            this.originalToolStripMenuItem,
            this.maskToolStripMenuItem,
            this.channelToolStripMenuItem,
            this.thumbnailToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            this.resetZoomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetZoomToolStripMenuItem.Text = "&Reset zoom";
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.resetZoomToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // originalToolStripMenuItem
            // 
            this.originalToolStripMenuItem.Name = "originalToolStripMenuItem";
            this.originalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.originalToolStripMenuItem.Text = "&Original";
            this.originalToolStripMenuItem.Click += new System.EventHandler(this.originalToolStripMenuItem_Click);
            // 
            // maskToolStripMenuItem
            // 
            this.maskToolStripMenuItem.Name = "maskToolStripMenuItem";
            this.maskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.maskToolStripMenuItem.Text = "&Mask";
            this.maskToolStripMenuItem.Click += new System.EventHandler(this.maskToolStripMenuItem_Click);
            // 
            // channelToolStripMenuItem
            // 
            this.channelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alphaToolStripMenuItem,
            this.redToolStripMenuItem,
            this.greebToolStripMenuItem,
            this.blueToolStripMenuItem});
            this.channelToolStripMenuItem.Name = "channelToolStripMenuItem";
            this.channelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.channelToolStripMenuItem.Text = "Channel";
            // 
            // alphaToolStripMenuItem
            // 
            this.alphaToolStripMenuItem.Name = "alphaToolStripMenuItem";
            this.alphaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.alphaToolStripMenuItem.Tag = "3";
            this.alphaToolStripMenuItem.Text = "Alpha";
            this.alphaToolStripMenuItem.Click += new System.EventHandler(this.viewChannelToolStripMenuItem_Click);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redToolStripMenuItem.Tag = "2";
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.viewChannelToolStripMenuItem_Click);
            // 
            // greebToolStripMenuItem
            // 
            this.greebToolStripMenuItem.Name = "greebToolStripMenuItem";
            this.greebToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.greebToolStripMenuItem.Tag = "1";
            this.greebToolStripMenuItem.Text = "Green";
            this.greebToolStripMenuItem.Click += new System.EventHandler(this.viewChannelToolStripMenuItem_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blueToolStripMenuItem.Tag = "0";
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.viewChannelToolStripMenuItem_Click);
            // 
            // thumbnailToolStripMenuItem
            // 
            this.thumbnailToolStripMenuItem.Checked = true;
            this.thumbnailToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.thumbnailToolStripMenuItem.Name = "thumbnailToolStripMenuItem";
            this.thumbnailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thumbnailToolStripMenuItem.Text = "&Thumbnail";
            this.thumbnailToolStripMenuItem.Click += new System.EventHandler(this.thumbnailToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.zoomModeToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem1.Text = "&Options";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offToolStripMenuItem1,
            this.smallToolStripMenuItem1,
            this.mediumToolStripMenuItem1,
            this.largeToolStripMenuItem1,
            this.colour1ToolStripMenuItem,
            this.colour2ToolStripMenuItem});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.gridToolStripMenuItem.Text = "&Grid";
            // 
            // offToolStripMenuItem1
            // 
            this.offToolStripMenuItem1.CheckOnClick = true;
            this.offToolStripMenuItem1.Name = "offToolStripMenuItem1";
            this.offToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.offToolStripMenuItem1.Tag = "0";
            this.offToolStripMenuItem1.Text = "None";
            this.offToolStripMenuItem1.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
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
            // colour1ToolStripMenuItem
            // 
            this.colour1ToolStripMenuItem.Name = "colour1ToolStripMenuItem";
            this.colour1ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.colour1ToolStripMenuItem.Text = "Colour 1";
            this.colour1ToolStripMenuItem.Click += new System.EventHandler(this.colour1ToolStripMenuItem_Click);
            // 
            // colour2ToolStripMenuItem
            // 
            this.colour2ToolStripMenuItem.Name = "colour2ToolStripMenuItem";
            this.colour2ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.colour2ToolStripMenuItem.Text = "Colour 2";
            this.colour2ToolStripMenuItem.Click += new System.EventHandler(this.colour2ToolStripMenuItem_Click);
            // 
            // zoomModeToolStripMenuItem
            // 
            this.zoomModeToolStripMenuItem.Name = "zoomModeToolStripMenuItem";
            this.zoomModeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.zoomModeToolStripMenuItem.Text = "&Zoom mode";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.backgroundColorToolStripMenuItem.Text = "&Background color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // toolStripExpando
            // 
            this.toolStripExpando.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsLabel,
            this.mousePositionLabel,
            this.selectionDetailsLabel,
            this.colorStatusLabel,
            this.colorDetailStatusLabel});
            this.toolStripExpando.Location = new System.Drawing.Point(0, 560);
            this.toolStripExpando.Name = "toolStripExpando";
            this.toolStripExpando.Size = new System.Drawing.Size(660, 22);
            this.toolStripExpando.TabIndex = 10;
            this.toolStripExpando.Text = "statusStrip1";
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = false;
            this.detailsLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(150, 17);
            // 
            // mousePositionLabel
            // 
            this.mousePositionLabel.AutoSize = false;
            this.mousePositionLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.mousePositionLabel.Name = "mousePositionLabel";
            this.mousePositionLabel.Size = new System.Drawing.Size(100, 17);
            // 
            // selectionDetailsLabel
            // 
            this.selectionDetailsLabel.AutoSize = false;
            this.selectionDetailsLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.selectionDetailsLabel.Name = "selectionDetailsLabel";
            this.selectionDetailsLabel.Size = new System.Drawing.Size(200, 17);
            // 
            // colorStatusLabel
            // 
            this.colorStatusLabel.AutoSize = false;
            this.colorStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.colorStatusLabel.Name = "colorStatusLabel";
            this.colorStatusLabel.Size = new System.Drawing.Size(102, 17);
            this.colorStatusLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.colorStatusLabel_Paint);
            // 
            // colorDetailStatusLabel
            // 
            this.colorDetailStatusLabel.AutoSize = false;
            this.colorDetailStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.colorDetailStatusLabel.Name = "colorDetailStatusLabel";
            this.colorDetailStatusLabel.Size = new System.Drawing.Size(118, 17);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.thumbnailWindow1);
            this.mainPanel.Controls.Add(this.picturePanel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(660, 536);
            this.mainPanel.TabIndex = 11;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // thumbnailWindow1
            // 
            this.thumbnailWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailWindow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnailWindow1.ContainerParent = this.picturePanel1;
            this.thumbnailWindow1.Location = new System.Drawing.Point(532, 0);
            this.thumbnailWindow1.Name = "thumbnailWindow1";
            this.thumbnailWindow1.Size = new System.Drawing.Size(128, 143);
            this.thumbnailWindow1.TabIndex = 10;
            this.thumbnailWindow1.ThumbnailMouseDown += new ImageVisualizer.ThumbnailWindow.ThumbnailMouseDownCallback(this.basicPicturePanel1_MouseDown);
            this.thumbnailWindow1.ThumbnailMouseMove += new ImageVisualizer.ThumbnailWindow.ThumbnailMouseMoveCallback(this.basicPicturePanel1_MouseMove);
            this.thumbnailWindow1.ThumbnailMouseUp += new ImageVisualizer.ThumbnailWindow.ThumbnailMouseUpCallback(this.basicPicturePanel1_MouseUp);
            this.thumbnailWindow1.VisibleChanged += new System.EventHandler(this.thumbnailWindow1_VisibleChanged);
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
            this.picturePanel1.Size = new System.Drawing.Size(660, 536);
            this.picturePanel1.TabIndex = 9;
            this.picturePanel1.Zoom = 1F;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(660, 582);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStripExpando);
            this.Controls.Add(this.menuStrip2);
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
            this.toolStripExpando.ResumeLayout(false);
            this.toolStripExpando.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectExtentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem originalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem colour1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colour2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.StatusStrip toolStripExpando;
        private System.Windows.Forms.ToolStripStatusLabel detailsLabel;
        private System.Windows.Forms.ToolStripStatusLabel mousePositionLabel;
        private System.Windows.Forms.ToolStripStatusLabel selectionDetailsLabel;
        private System.Windows.Forms.ToolStripStatusLabel colorStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel colorDetailStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem thumbnailToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private PicturePanel picturePanel1;
        private ThumbnailWindow thumbnailWindow1;
        private System.Windows.Forms.ToolStripMenuItem channelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alphaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greebToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;




    }
}