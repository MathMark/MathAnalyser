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


        public int leftEdge;
        public int rightEdge;
        public int topEdge;
        public int bottomEdge;

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
                    rightEdge -= Math.Abs(value.X);
                    leftEdge -= Math.Abs(value.X);
                }
                else
                {
                    rightEdge += Math.Abs(value.X);
                    leftEdge += Math.Abs(value.X);
                }
                if(value.Y>0)
                {
                    topEdge -= Math.Abs(value.Y);
                    bottomEdge -= Math.Abs(value.Y);
                }
                else
                {
                    topEdge += Math.Abs(value.Y);
                    bottomEdge += Math.Abs(value.Y);
                }


            }
        }

        public Build(int Width,int Height)
        {
            this.Width = Width;
            this.Height = Height;

            leftEdge=-Width/2;
            rightEdge=Width/2;
            topEdge=-Height/2;
            bottomEdge=Height/2;


            Draft = new Bitmap(Width, Height);
            Painter = Graphics.FromImage(Draft);


            Painter.TranslateTransform(Width/2, Height / 2,MatrixOrder.Append);

            

            //Fast rendering:

            Painter.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low; // or NearestNeighbour
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Painter.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            Painter.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            Painter.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

        }
        public void Clear()
        {
            Painter.Clear(Color.Transparent);
        }
        public Bitmap BuildAxes(Color colorPen,int width,int dx,int dy)
        {
            Pen pen = new Pen(colorPen,width);

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
            for (float i = 0; i < bottomEdge; i += scale)
            {
                Painter.DrawLine(penNet, leftEdge, i+dy, rightEdge, i+dy);
            }
            for (float i = 0; i >= topEdge; i -= scale)
            {
                 Painter.DrawLine(penNet, leftEdge, i+dy, rightEdge, i+dy);
            }

            return Draft;
        }
        public Bitmap DrawFunction(Pen pen,int scale, string PostfixFunction)
        {

           // Painter.DrawCurve(new Pen(Color.Blue), new PointF[] { new PointF(10, 10), new PointF(10, 20), new PointF(20, 20) });
            float prototype;

            PointF[] coordinates;
            List<PointF> Coordinates = new List<PointF>();

            for (double  i= -Width/2,x=leftEdge; i < Width/2;i+=0.1, x +=0.1)
            {
     
                prototype = -Parser.GetValue(PostfixFunction, Math.Round(x / scale,2));


                if ((double.IsNaN(prototype)) || (double.IsInfinity(prototype)))
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
                        Convert.ToSingle(scale* prototype)));
                    }
                    
                }
                try
                {
                    if (Coordinates.Count != 0)
                    {
                        coordinates = new PointF[Coordinates.Count];
                        coordinates = Coordinates.ToArray();
                       //Painter.DrawLines(pen, coordinates);
                    Painter.DrawCurve(pen, coordinates);
                    }
                }
            catch (OverflowException)
            {
                Painter.DrawLine(pen, 0,0,50,50);
            }
            catch (ArgumentException)
            {
                //return;
            }

            return Draft;

        }

        public Bitmap SetCross(Bitmap d,Pen pen,float offset, float crossPoint)
        {
            Bitmap e =new Bitmap(d);
            try
            {
                
                Graphics s = Graphics.FromImage(e);
                s.TranslateTransform(Painter.Transform.OffsetX, Painter.Transform.OffsetY);

                //s.DrawLine(pen, -Width / 2, crossPoint, Width, crossPoint);
                s.DrawLine(pen, offset, 0, offset, crossPoint);
                //s.DrawLine(pen, offset, -Height / 2, offset, Height / 2);
                s.DrawLine(pen, 0, crossPoint, offset, crossPoint);
                s.Dispose();
                return e;
            }
            catch(OverflowException)
            {
                return e;
            }
        }
    }
}
