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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interpolationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomCrispToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomBlurryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new ImageVisualizer.ZoomPicBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.zoomResetToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(256, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.interpolationToolStripMenuItem,
            this.backgroundToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.largeToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.helpToolStripMenuItem.Text = "Grid";
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.CheckOnClick = true;
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.smallToolStripMenuItem.Text = "Small";
            this.smallToolStripMenuItem.Click += new System.EventHandler(this.smallToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Checked = true;
            this.mediumToolStripMenuItem.CheckOnClick = true;
            this.mediumToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.mediumToolStripMenuItem_Click);
            // 
            // largeToolStripMenuItem
            // 
            this.largeToolStripMenuItem.CheckOnClick = true;
            this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            this.largeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.largeToolStripMenuItem.Text = "Large";
            this.largeToolStripMenuItem.Click += new System.EventHandler(this.largeToolStripMenuItem_Click);
            // 
            // interpolationToolStripMenuItem
            // 
            this.interpolationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomCrispToolStripMenuItem,
            this.zoomBlurryToolStripMenuItem});
            this.interpolationToolStripMenuItem.Name = "interpolationToolStripMenuItem";
            this.interpolationToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.interpolationToolStripMenuItem.Text = "Zoom mode";
            // 
            // zoomCrispToolStripMenuItem
            // 
            this.zoomCrispToolStripMenuItem.Checked = true;
            this.zoomCrispToolStripMenuItem.CheckOnClick = true;
            this.zoomCrispToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zoomCrispToolStripMenuItem.Name = "zoomCrispToolStripMenuItem";
            this.zoomCrispToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.zoomCrispToolStripMenuItem.Text = "Crisp";
            this.zoomCrispToolStripMenuItem.Click += new System.EventHandler(this.zoomCrispToolStripMenuItem_Click);
            // 
            // zoomBlurryToolStripMenuItem
            // 
            this.zoomBlurryToolStripMenuItem.CheckOnClick = true;
            this.zoomBlurryToolStripMenuItem.Name = "zoomBlurryToolStripMenuItem";
            this.zoomBlurryToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.zoomBlurryToolStripMenuItem.Text = "Blurry";
            this.zoomBlurryToolStripMenuItem.Click += new System.EventHandler(this.zoomBlurryToolStripMenuItem_Click);
            // 
            // zoomResetToolStripMenuItem
            // 
            this.zoomResetToolStripMenuItem.Name = "zoomResetToolStripMenuItem";
            this.zoomResetToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.zoomResetToolStripMenuItem.Text = "View 1:1";
            this.zoomResetToolStripMenuItem.Click += new System.EventHandler(this.zoomResetToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AutoScroll = true;
            this.pictureBox1.AutoScrollMinSize = new System.Drawing.Size(256, 256);
            this.pictureBox1.BackColor = System.Drawing.Color.Fuchsia;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Image = null;
            this.pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 257);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.Text = "zoomPicBox1";
            this.pictureBox1.Zoom = 1F;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 281);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(170, 170);
            this.Name = "ImageForm";
            this.ShowInTaskbar = false;
            this.Text = "Image";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
        private ZoomPicBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem interpolationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomBlurryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomCrispToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
    }
}