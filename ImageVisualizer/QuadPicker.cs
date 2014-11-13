using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ImageVisualizer
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public partial class QuadPicker : ToolStripControlHost
    {
        public class PickedEventArgs : EventArgs
        {
            int x,y;

            public PickedEventArgs(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public delegate void PickedDelegate(object sender, PickedEventArgs e);
        public event PickedDelegate Picked;

        void RaisePickedEvent(int x, int y)
        {
            if(Picked != null)
            {
                Picked.Invoke(this, new PickedEventArgs(x, y));
            }
        }

        Panel controlPanel;

        public QuadPicker() : base(new Panel())
        {
            controlPanel = (Panel)base.Control;
            controlPanel.BackColor = Color.Red;
            Width = 128;
            Height = 128;
            // add 4 buttons
        }

        private void button_Click(object sender, EventArgs e)
        {
            int m = Convert.ToInt32((sender as Button).Tag);
            int x = m & 1;
            int y = (m >> 1) & 1;
            RaisePickedEvent(x, y);
        }
    }
}
