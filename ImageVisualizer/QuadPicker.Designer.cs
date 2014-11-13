namespace ImageVisualizer
{
    partial class QuadPicker
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
            this.TLbutton = new System.Windows.Forms.Button();
            this.TRbutton = new System.Windows.Forms.Button();
            this.BLbutton = new System.Windows.Forms.Button();
            this.BRbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TLbutton
            // 
            this.TLbutton.Location = new System.Drawing.Point(0, 0);
            this.TLbutton.Name = "TLbutton";
            this.TLbutton.Size = new System.Drawing.Size(32, 32);
            this.TLbutton.TabIndex = 0;
            this.TLbutton.Tag = "0";
            this.TLbutton.UseVisualStyleBackColor = true;
            this.TLbutton.Click += new System.EventHandler(this.button_Click);
            // 
            // TRbutton
            // 
            this.TRbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TRbutton.Location = new System.Drawing.Point(64, 0);
            this.TRbutton.Name = "TRbutton";
            this.TRbutton.Size = new System.Drawing.Size(32, 32);
            this.TRbutton.TabIndex = 1;
            this.TRbutton.Tag = "1";
            this.TRbutton.UseVisualStyleBackColor = true;
            this.TRbutton.Click += new System.EventHandler(this.button_Click);
            // 
            // BLbutton
            // 
            this.BLbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BLbutton.Location = new System.Drawing.Point(0, 64);
            this.BLbutton.Name = "BLbutton";
            this.BLbutton.Size = new System.Drawing.Size(32, 32);
            this.BLbutton.TabIndex = 2;
            this.BLbutton.Tag = "2";
            this.BLbutton.UseVisualStyleBackColor = true;
            this.BLbutton.Click += new System.EventHandler(this.button_Click);
            // 
            // BRbutton
            // 
            this.BRbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BRbutton.Location = new System.Drawing.Point(64, 64);
            this.BRbutton.Name = "BRbutton";
            this.BRbutton.Size = new System.Drawing.Size(32, 32);
            this.BRbutton.TabIndex = 3;
            this.BRbutton.Tag = "3";
            this.BRbutton.UseVisualStyleBackColor = true;
            this.BRbutton.Click += new System.EventHandler(this.button_Click);
            // 
            // QuadPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BRbutton);
            this.Controls.Add(this.BLbutton);
            this.Controls.Add(this.TRbutton);
            this.Controls.Add(this.TLbutton);
            this.Name = "QuadPicker";
            this.Size = new System.Drawing.Size(96, 96);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TLbutton;
        private System.Windows.Forms.Button TRbutton;
        private System.Windows.Forms.Button BLbutton;
        private System.Windows.Forms.Button BRbutton;
    }
}
