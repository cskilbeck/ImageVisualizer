//////////////////////////////////////////////////////////////////////
// Only works for POD types containing simple types (int, bool etc)

using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public static class Settings
    {
        //////////////////////////////////////////////////////////////////////

        public static void Save<T>(T t, string filename)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using(FileStream ms = new FileStream(filename, FileMode.Create))
            {
                ser.WriteObject(ms, t);
                ms.Close();
            }
        }

        //////////////////////////////////////////////////////////////////////

        public static T Load<T>(string filename) where T: new()
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            try
            {
                using (FileStream ms = new FileStream(filename, FileMode.Open))
                {
                    return (T)ser.ReadObject(ms);
                }
            }
            catch (FileNotFoundException)
            {
                return new T();
            }
        }
    }

    //////////////////////////////////////////////////////////////////////

    public class MySettings
    {
        public int BackgroundColour = Color.Magenta.ToArgb();
        public int GridSize = 16;
        public int ZoomMode = (int)InterpolationMode.NearestNeighbor;
        public int Thumbnail = 1;
        public int ThumbnailAlign = 0;
        public int GridColor1 = Color.LightGray.ToArgb();
        public int GridColor2 = Color.DarkGray.ToArgb();
    }
}
