using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using BL;

namespace MathAnalyser
{
    class Build
    {
        private int Width;
        private int Height;
        Graphics Painter;
        Bitmap Draft;

        public Build(int Width,int Height)
        {
            this.Width = Width;
            this.Height = Height;

            Draft = new Bitmap(Width, Height);
            Painter = Graphics.FromImage(Draft);
        }
        public Bitmap BuildAxes(Color colorPen,int width)
        {
            Pen pen = new Pen(colorPen,width);
            Painter.DrawLine(pen, Width / 2, 0, Width / 2, Draft.Height);
            Painter.DrawLine(pen, 0, Draft.Height / 2, Draft.Width, Draft.Height / 2);
            return Draft;
        }
        public Bitmap BuildNet(Color colorPen,float scale)
        {
            Pen penNet = new Pen(colorPen);
            float start = Convert.ToSingle(Draft.Width / 2);
            for (float i = 0; i < Draft.Width; i += scale)
            {
                Painter.DrawLine(penNet, start + i, 0, start + i, Draft.Height);
                Painter.DrawLine(penNet, start - i, 0, start - i, Draft.Height);
            }
            start = Convert.ToSingle(Draft.Height / 2);
            for (float i = 0; i < Draft.Height / 2; i += scale)
            {
                Painter.DrawLine(penNet, 0, start + i, Draft.Width, start + i);
                Painter.DrawLine(penNet, 0, start - i, Draft.Width, start - i);
            }
            return Draft;
        }
        public Bitmap DrawFunction(List<string> PostfixFunction,Color color,int width,DashStyle dashStyle,int scale)
        {
            double prototype;
            Pen pen = new Pen(color, width);
            pen.DashStyle = dashStyle;

            PointF[] coordinates;
            List<PointF> Coordinates = new List<PointF>();

                for (double x = -Draft.Width / 2; x < Draft.Width / 2; x += 1)
                {
     
                    prototype = Converter.GetValue(PostfixFunction, x / scale);
                    if (prototype > Draft.Height / 2)
                    {
                        prototype = Draft.Height / 2;
                    }
                    else if (prototype < -Draft.Height / 2)
                    {
                        prototype = -Draft.Height / 2;
                    }
                    else if ((double.IsNaN(prototype)) || (double.IsInfinity(prototype)))
                    {
                        if (Coordinates.Count != 0)
                        {
                            coordinates = new PointF[Coordinates.Count];
                            coordinates = Coordinates.ToArray();
                            try
                            {
                                Painter.DrawLines(pen, coordinates);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            Coordinates.Clear();
                        }
                        continue;
                    }
                    else
                    {
                        Coordinates.Add(new PointF(Convert.ToSingle(Draft.Width / 2 + x),
                            Convert.ToSingle(Draft.Height / 2 - scale * prototype)));
                    }
                }
                try
                {
                    if (Coordinates.Count != 0)
                    {
                        coordinates = new PointF[Coordinates.Count];
                        coordinates = Coordinates.ToArray();
                        Painter.DrawLines(pen, coordinates);
                    }
                }
                catch (OverflowException)
                {
                    ;
                }
                catch (ArgumentException)
                {
                    //return;
                }
            return Draft;

        }
    }
}
