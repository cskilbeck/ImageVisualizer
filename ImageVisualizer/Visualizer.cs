//////////////////////////////////////////////////////////////////////

using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

//////////////////////////////////////////////////////////////////////

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(ImageVisualizer.Visualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(Image),
    Description = "My First Visualizer")]

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    [DebuggerVisualizer(typeof(Image))]
    public class Visualizer : DialogDebuggerVisualizer
    {
        //////////////////////////////////////////////////////////////////////

        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
            {
                throw new ArgumentNullException("windowService");
            }
            if (objectProvider == null)
            {
                throw new ArgumentNullException("objectProvider");
            }
            using (ImageForm imageForm = new ImageForm((Image)objectProvider.GetObject()))
            {
                windowService.ShowDialog(imageForm);
            }
        }

        //////////////////////////////////////////////////////////////////////

        public static void TestShowVisualizer(Image imageToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(imageToVisualize, typeof(Visualizer));
            visualizerHost.ShowVisualizer();
        }
    }
}
