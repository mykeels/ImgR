using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ImgR
{
    internal static class BitmapExtensions
    {

        public static Byte[] ToBytes(this Bitmap b)
        {
            MemoryStream s = new MemoryStream();
            b.Save(s, System.Drawing.Imaging.ImageFormat.Bmp);
            s.Position = 0;
            byte[] bb = new byte[s.Length];
            s.Read(bb, 0, Convert.ToInt32(s.Length));
            return bb;
        }

        public static Bitmap ToBitmap(this Byte[] b)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(b, 0, Convert.ToInt32(b.Length));
            Bitmap bm = new Bitmap(ms);
            return bm;
        }

        public static Stream ToStream(this Byte[] b)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(b, 0, Convert.ToInt32(b.Length));
            return ms;
        }

        public static byte[] ToBytes(this Stream ms)
        {
            byte[] bb = new byte[ms.Length];
            ms.Read(bb, 0, Convert.ToInt32(ms.Length));
            return bb;
        }

        public static Bitmap Scale(this Bitmap source, int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y, source.PixelFormat);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, 0, 0, bmp.Width + 1, bmp.Height + 1);
            return bmp;
        }

        public static Bitmap Scale(this Bitmap source, int size)
        {
            Single scale = (Single)size / (Single)source.Width;
            Bitmap bmp = new Bitmap(Convert.ToInt32(scale * source.Width), Convert.ToInt32(scale * source.Height), source.PixelFormat);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, 0, 0, bmp.Width + 1, bmp.Height + 1);
            return bmp;
        }

        public static Bitmap GetSpectrum(this Bitmap b, ColorSpectrum cs, bool actualspectrum = false)
        {
            if (b == null) return b;
            Bitmap ret = new Bitmap(b.Width, b.Height);
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b.GetPixel(i, j);
                    switch (cs)
                    {
                        case ColorSpectrum.Red:
                            c = Color.FromArgb(c.A, c.R, c.R, c.R);
                            if (actualspectrum) c = Color.FromArgb(c.A, c.R, 0, 0);
                            break;
                        case ColorSpectrum.Green:
                            c = Color.FromArgb(c.A, c.G, c.G, c.G);
                            if (actualspectrum) c = Color.FromArgb(c.A, 0, c.G, 0);
                            break;
                        case ColorSpectrum.Blue:
                            c = Color.FromArgb(c.A, c.B, c.B, c.B);
                            if (actualspectrum) c = Color.FromArgb(c.A, 0, 0, c.B);
                            break;
                        default:
                            break;
                    }
                    ret.SetPixel(i, j, c);
                }
            }
            return ret;
        }

        public static Bitmap DrawRectangle(this Bitmap b, Rectangle r, Pen p)
        {
            Graphics g = Graphics.FromImage(b);
            g.DrawRectangle(p, r);
            return b;
        }

        public enum ColorSpectrum
        {
            Red,
            Green,
            Blue
        }
    }
}
