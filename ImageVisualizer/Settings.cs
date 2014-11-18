//////////////////////////////////////////////////////////////////////

using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Collections.Generic;

//////////////////////////////////////////////////////////////////////

namespace ImageVisualizer
{
    //////////////////////////////////////////////////////////////////////

    public class XmlColor
    {
        Color c;

        public XmlColor() { }
        public XmlColor(Color color) { c = color; }

        public static implicit operator Color(XmlColor x) { return x.c; }
        public static implicit operator XmlColor(Color c) { return new XmlColor(c); }

        [XmlText]
        public string Default
        {
            get
            {
                return string.Format("{0:X8}", c.ToArgb());
            }
            set
            {
                int n;
                if (int.TryParse(value, System.Globalization.NumberStyles.HexNumber, null, out n))
                {
                    c = Color.FromArgb(n);
                }
            }
        }
    }

    //////////////////////////////////////////////////////////////////////

    public class Options
    {
        public static void Save<T>(T obj, string filename)
        {
            XmlSerializer x = new XmlSerializer(typeof(T));
            try
            {
                using (TextWriter w = new StreamWriter(filename))
                {
                    x.Serialize(w, obj);
                }
            }
            catch (System.InvalidOperationException) { }
            catch (System.Xml.XmlException) { }
            catch (DirectoryNotFoundException) { }
            catch (IOException) { }
        }

        public static T Load<T>(string filename)
        {
            XmlSerializer x = new XmlSerializer(typeof(T));
            try
            {
                using(TextReader r = new StreamReader(filename))
                {
                    return (T)x.Deserialize(r);
                }
            }
            catch (System.InvalidOperationException) { }
            catch (System.Xml.XmlException) { }
            catch (FileNotFoundException) { }
            return default(T);
        }
    }
}
