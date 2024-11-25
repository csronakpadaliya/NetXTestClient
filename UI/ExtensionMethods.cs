using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Neuron.UI
{
    public static class ColorExtensions
    {
        public static Color Apply(this Color o, ColorMatrix m)
        {
            var r = ((o.R * m[0, 0]) + (o.G * m[1, 0]) + (o.B * m[2, 0]) + (o.A * m[3, 0]) + m[4, 0]);
            var g = ((o.R * m[0, 1]) + (o.G * m[1, 1]) + (o.B * m[2, 1]) + (o.A * m[3, 1]) + m[4, 1]);
            var b = ((o.R * m[0, 2]) + (o.G * m[1, 2]) + (o.B * m[2, 2]) + (o.A * m[3, 2]) + m[4, 2]);
            var a = ((o.R * m[0, 3]) + (o.G * m[1, 3]) + (o.B * m[2, 3]) + (o.A * m[3, 3]) + m[4, 3]);

            return Color.FromArgb((int)Math.Min(255, a), (int)Math.Min(255, r), (int)Math.Min(255, g), (int)Math.Min(255, b));
        }
    }
    public static class PointExtensions
    {
        public static double Angle(this Point p1, Point p2)
        {
            double XDiff;
            double YDiff;
            double TempAngle;

            YDiff = Math.Abs(p2.Y - p1.Y);

            if (p1.X == p2.X && p1.Y == p2.Y)
            {
                return 0;
            }

            if (YDiff == 0 && p1.X < p2.X)
            {
                return 0;
            }
            else if (YDiff == 0 && p1.X > p2.X)
            {
                return Math.PI;
            }
            XDiff = Math.Abs(p2.X - p1.X);

            TempAngle = Math.Atan(XDiff / YDiff);

            if (p2.Y > p1.Y) TempAngle = Math.PI - TempAngle;
            if (p2.X < p1.X) TempAngle = -TempAngle;
            TempAngle = (Math.PI / 2) - TempAngle;
            if (TempAngle < 0) TempAngle = (Math.PI * 2) + TempAngle;
            return TempAngle;
        }
        public static double DistanceTo(this Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }

    public static class ColorMatrixes
    {
        public static ColorMatrix Saturate(float sat)
        {
            return Saturate(sat, 0.299F, 0.587F, 0.114F);
        }

        public static ColorMatrix Saturate(float sat, float rweight, float gweight, float bweight)
        {
            ColorMatrix cMatrix = new ColorMatrix(new float[][] {
    new float[] { (1.0f-sat)*rweight+sat, 
        (1.0f-sat)*rweight, (1.0f-sat)*rweight, 0.0f, 0.0f },
    new float[] { (1.0f-sat)*gweight, 
        (1.0f-sat)*gweight+sat, (1.0f-sat)*gweight, 0.0f, 0.0f },
    new float[] { (1.0f-sat)*bweight, 
        (1.0f-sat)*bweight, (1.0f-sat)*bweight+sat, 0.0f, 0.0f },
    new float[] { 0.0f, 0.0f, 0.0f, 1.0f, 0.0f },
    new float[] { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f }
        });
            return cMatrix;
        }

        public static readonly ColorMatrix Grayscale = new ColorMatrix(new Single[][] { 
                           
                                new Single[] {0.299F, 0.299F, 0.299F, 0, 0}, 
                                new Single[] {0.587F, 0.587F, 0.587F, 0, 0}, 
                                new Single[] {0.114F, 0.114F, 0.114F, 0, 0}, 
                                new Single[] {0, 0, 0, 1, 0}, 
                                new Single[] {0, 0, 0, 0, 1}
                           });

        public static readonly ColorMatrix Transparent = new ColorMatrix(new Single[][] { 
                           
                                new Single[] 
                                { 
                                    1.0F,   0.0F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   1.0F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   0.0F,   1.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0,      0,      0,      .5F,    0
                                }, 
                                new Single[] 
                                {
                                    0,      0,      0,      0,      1}
                           });

        public static readonly ColorMatrix Darken = new ColorMatrix(new Single[][] { 
                           
                                new Single[] 
                                { 
                                    .8F,   0.0F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   .8F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   0.0F,   .8F,   0,      0
                                }, 
                                new Single[] 
                                {   
                                    0,      0,      0,      1.0F,   0
                                }, 
                                new Single[] 
                                {
                                    0,      0,      0,      0,      1
                                }
                           });

        public static readonly ColorMatrix BlackOut = new ColorMatrix(new Single[][] { 
                           
                                new Single[] 
                                { 
                                    .2F,   0.0F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   .2F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   0.0F,   .2F,   0,      0
                                }, 
                                new Single[] 
                                {   
                                    0,      0,      0,      1.0F,   0
                                }, 
                                new Single[] 
                                {
                                    0,      0,      0,      0,      1
                                }
                           });


        public static readonly ColorMatrix Brighten = new ColorMatrix(new Single[][] { 
                           
                                new Single[] 
                                { 
                                    1.2F,   0.0F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   1.2F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   0.0F,   1.2F,   0,      0
                                }, 
                                new Single[] 
                                {   
                                    0,      0,      0,      1.0F,   0
                                }, 
                                new Single[] 
                                {
                                    0,      0,      0,      0,      1
                                }
                           });

        public static readonly ColorMatrix BrightenSmall = new ColorMatrix(new Single[][] { 
                           
                                new Single[] 
                                { 
                                    1.05F,   0.0F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   1.05F,   0.0F,   0,      0
                                }, 
                                new Single[] 
                                {
                                    0.0F,   0.0F,   1.05F,   0,      0
                                }, 
                                new Single[] 
                                {   
                                    0,      0,      0,      1.0F,   0
                                }, 
                                new Single[] 
                                {
                                    0,      0,      0,      0,      1
                                }
                           });
    }

    public static class GraphicsExtensions
    {
        public static void DrawBezierSafe(this Graphics g, Pen pen, Point p1, Point p2, Point p3, Point p4)
        {
            try
            {
                g.DrawBezier(pen, p1, p2, p3, p4);
            }
            catch (OverflowException)
            {
            }
            catch (OutOfMemoryException)
            {
            }
        }
    }

    public static class ImageExtensions
    {
        public static Image CreateTreeViewImage(this Image image)
        {
            Bitmap b = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, image.Width, image.Height));
                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, null);
            }
            return b;
        }
    }

    public static class RectangleExtensions
    {
        public static Point GetCenter(this Rectangle rect)
        {
            return new Point((rect.Left + rect.Right) / 2, (rect.Top + rect.Bottom) / 2);
        }
    }

}
