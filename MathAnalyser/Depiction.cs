using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using BL;


namespace MathAnalyser
{
    class Depiction
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

        public float Scale
        {
            get
            {
                return Painter.PageScale;
            }
            set
            {
                Painter.PageScale = value;
            }
        }
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

        public Depiction(int Width,int Height)
        {
            this.Width = Width;
            this.Height = Height;

            leftEdge=-Width/2;
            rightEdge=Width/2;
            topEdge=-Height/2;
            bottomEdge=Height/2;


            Draft = new Bitmap(Width, Height);
            Painter = Graphics.FromImage(Draft);

            //The drawing area restriction
            int offset = 20;
            //Painter.Clip = new Region(new RectangleF(offset, offset, Width-2*offset, Height-2*offset));


            Painter.TranslateTransform(Width/2, Height / 2,MatrixOrder.Append);
            //Fast rendering:

            Painter.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low; // or NearestNeighbour
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
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
        
        public Bitmap DrawCurve(Pen pen,int scale, string PostfixFunction)
        {
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float functionValue;

            PointF[] coordinates;
            List<PointF> Coordinates = new List<PointF>();

            for (double  i= -Width/2,x=leftEdge; i < Width/2;i+=0.1, x +=0.1)
            {
     
                functionValue = -Parser.GetValue(PostfixFunction, Math.Round(x / scale,2));

                if ((double.IsNaN(functionValue)) || (double.IsInfinity(functionValue)))
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
                        Convert.ToSingle(scale* functionValue)));
                    }
                    
                }
                try
                {
                    if (Coordinates.Count != 0)
                    {
                        coordinates = new PointF[Coordinates.Count];
                        coordinates = Coordinates.ToArray();;
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
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            return Draft;

        }

        public Bitmap DrawCurve(Pen pen, int scale, string PostfixFunction_1, string PostfixFunction_2)
        {
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float functionValue_1;
            float functionValue_2;

            PointF[] coordinates;
            List<PointF> Coordinates = new List<PointF>();

            for (double i = -Width/2, t = leftEdge; i <Width/2; i += 0.1, t += 0.1)
            {

                functionValue_1 = -Parser.GetValue(PostfixFunction_1, Math.Round(t / scale, 2));
                functionValue_2= -Parser.GetValue(PostfixFunction_2, Math.Round(t / scale, 2));

                if ((double.IsNaN(functionValue_1)) || (double.IsInfinity(functionValue_1)))
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
                    Coordinates.Add(new PointF(Convert.ToSingle(scale*functionValue_1),
                        Convert.ToSingle(scale * functionValue_2)));
                }

            }
            try
            {
                if (Coordinates.Count != 0)
                {
                    coordinates = new PointF[Coordinates.Count];
                    coordinates = Coordinates.ToArray(); ;
                    Painter.DrawCurve(pen, coordinates);
                }
            }
            catch (OverflowException)
            {
                Painter.DrawLine(pen, 0, 0, 50, 50);
            }
            catch (ArgumentException)
            {
                //return;
            }
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
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

        public Bitmap SetNumberNet(float scale)
        {
            Font font = new Font("Consolas", 8);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 121, 120, 122));
            int offset = 15;

            for(float step=0,i=0;step<rightEdge-offset;i++,step+=scale)
            {
                Painter.DrawString(i.ToString(), font, solidBrush, new PointF(step, bottomEdge-offset)); 
            }
            for (float step = -scale, i = -1; step >= leftEdge+offset; i--, step -= scale)
            {
                Painter.DrawString(i.ToString(), font, solidBrush, new PointF(step, bottomEdge - offset));
            }
            for (float step = 0, i = 0; step < bottomEdge-offset; i++, step += scale)
            {
                Painter.DrawString(i.ToString(), font, solidBrush, new PointF(leftEdge, step));
            }
            for (float step = -scale, i = 0; step >=topEdge; i--, step -= scale)
            {
                Painter.DrawString(i.ToString(), font, solidBrush, new PointF(leftEdge, step));
            }

            return Draft;
        }
        
    }
}
