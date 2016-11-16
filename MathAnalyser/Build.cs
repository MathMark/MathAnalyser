using System;
using System.Collections.Generic;
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

        Point start;


        private int leftEdge;
        private int rightEdge;
        private int topEdge;
        private int bottomEdge;

        public Point StartPosition
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
                Painter.TranslateTransform(value.X,value.Y);

                if(value.X>0)
                {
                    rightEdge += value.X;
                    leftEdge -= value.X;
                }
                else
                {
                    rightEdge -= value.X;
                    leftEdge += value.X;
                }
                if(value.Y>0)
                {
                    topEdge += value.Y;
                    bottomEdge -= value.Y;
                }
                else
                {
                    topEdge -= value.Y;
                    bottomEdge += value.Y;
                }

               // Xedge += Math.Abs(value.X);
               // Yedge += Math.Abs(value.Y);

            }
        }

        public Build(int Width,int Height)
        {
            this.Width = Width;
            this.Height = Height;

            leftEdge=-Width/2;
            rightEdge=Width/2;
            topEdge=Height/2;
            bottomEdge=-Height/2;


            Draft = new Bitmap(Width, Height);
            Painter = Graphics.FromImage(Draft);

            Painter.SmoothingMode = SmoothingMode.HighQuality;
            Painter.TranslateTransform(Width/2, Height / 2);

        }

        public Bitmap BuildAxes(Color colorPen,int width,int dx,int dy)
        {
            Pen pen = new Pen(colorPen,width);
            Painter.Clear(Color.Transparent);

            Painter.DrawLine(pen, dx, topEdge, dx, bottomEdge);//Y
            Painter.DrawLine(pen, leftEdge, dy, rightEdge, dy);//X

            return Draft;
            
        }
        public Bitmap BuildNet(Color colorPen,float scale,int dx,int dy)
        {
            Pen penNet = new Pen(colorPen);

            //Vertical
            for (float i = 0; i <rightEdge ; i += scale)
            {
                Painter.DrawLine(penNet, i+dx, topEdge, i+dx, bottomEdge);
            }
            for (float i = 0; i >= leftEdge; i -= scale)
            {
                 Painter.DrawLine(penNet, i+dx, topEdge, i+dx, bottomEdge);
            }

            //Horizontal
            for (float i = 0; i < topEdge; i += scale)
            {
                Painter.DrawLine(penNet, leftEdge, i+dy, rightEdge, i+dy);
            }
            for (float i = 0; i >= bottomEdge; i -= scale)
            {
                 Painter.DrawLine(penNet, leftEdge, i+dy, rightEdge, i+dy);
            }

            return Draft;
        }
        public Bitmap DrawFunction(Pen pen,int scale, List<string>PostfixFunction)
        {
            double prototype;

            PointF[] coordinates;
            List<PointF> Coordinates = new List<PointF>();

                for (double x = leftEdge; x < rightEdge; x += 1)
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
                        Coordinates.Add(new PointF(Convert.ToSingle(x),
                            Convert.ToSingle(-scale * prototype)));
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
