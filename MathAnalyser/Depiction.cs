using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using BL;


namespace MathAnalyser
{
    public class CoordinatePlane
    {
        public Matrix transform;
        public int leftEdge;
        public int rightEdge;
        public int topEdge;
        public int bottomEdge;

        public CoordinatePlane(Matrix transform, int leftEdge, int rightEdge, int bottomEdge, int topEdge)
        {
            this.transform = transform;
            this.leftEdge = leftEdge;
            this.rightEdge = rightEdge;
            this.bottomEdge = bottomEdge;
            this.topEdge = topEdge;
        }
    }
    class Depiction
    {
        private int ViewPortWidth;
        private int ViewPortHeight;

        Graphics Painter;
        Bitmap Buffer;

        Point CoordinatePlaneCenter;

        public CoordinatePlane CoordinatePlaneLocation
        {
            get
            {
                return new CoordinatePlane(Painter.Transform, viewPortLeftEdge, viewPortRightEdge, viewPortBottomEdge, viewPortTopEdge);
            }
            set
            {
                Painter.Transform = value.transform;
                viewPortLeftEdge = value.leftEdge;
                viewPortRightEdge = value.rightEdge;
                viewPortBottomEdge = value.bottomEdge;
                viewPortTopEdge = value.topEdge;
            }
        }

        int viewPortLeftEdge;
        int viewPortRightEdge;
        int viewPortTopEdge;
        int viewPortBottomEdge;

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
                return CoordinatePlaneCenter;
            }
            set
            {
                CoordinatePlaneCenter = value;
                Painter.TranslateTransform(value.X,value.Y);

                if(value.X>0)
                {
                    viewPortRightEdge -= Math.Abs(value.X);
                    viewPortLeftEdge -= Math.Abs(value.X);
                }
                else
                {
                    viewPortRightEdge += Math.Abs(value.X);
                    viewPortLeftEdge += Math.Abs(value.X);
                }
                if(value.Y>0)
                {
                    viewPortTopEdge -= Math.Abs(value.Y);
                    viewPortBottomEdge -= Math.Abs(value.Y);
                }
                else
                {
                    viewPortTopEdge += Math.Abs(value.Y);
                    viewPortBottomEdge += Math.Abs(value.Y);
                }


            }
        }

        public Depiction(int ViewPortWidth,int ViewPortHeight)
        {
            this.ViewPortWidth = ViewPortWidth;
            this.ViewPortHeight = ViewPortHeight;

            viewPortLeftEdge=-ViewPortWidth/2;
            viewPortRightEdge=ViewPortWidth/2;
            viewPortTopEdge=-ViewPortHeight/2;
            viewPortBottomEdge=ViewPortHeight/2;


            Buffer = new Bitmap(ViewPortWidth, ViewPortHeight);
            Painter = Graphics.FromImage(Buffer);

            Painter.TranslateTransform(ViewPortWidth/2, ViewPortHeight / 2,MatrixOrder.Append);
            //Fast rendering:

            Painter.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low; // or NearestNeighbour
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            Painter.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            Painter.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            Painter.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

        }
        public Depiction(int Width, int Height, CoordinatePlane offsets)
        {
            this.ViewPortWidth = Width;
            this.ViewPortHeight = Height;
            Buffer = new Bitmap(Width, Height);
            Painter = Graphics.FromImage(Buffer);

            CoordinatePlaneLocation = offsets; 

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

            Painter.DrawLine(pen, dx, viewPortTopEdge, dx, viewPortBottomEdge);//Y
            Painter.DrawLine(pen, viewPortLeftEdge, dy, viewPortRightEdge, dy);//X

            return Buffer;
            
        }
        public Bitmap BuildNet(Color colorPen,float scale,int dx,int dy)
        {
            Pen penNet = new Pen(colorPen);

            //Vertical
            for (float i = 0; i < viewPortRightEdge; i += scale)
            {
                Painter.DrawLine(penNet, i + dx, viewPortTopEdge, i + dx, viewPortBottomEdge);
            }
            for (float i = 0; i >= viewPortLeftEdge; i -= scale)
            {
                Painter.DrawLine(penNet, i + dx, viewPortTopEdge, i + dx, viewPortBottomEdge);
            }

            //Horizontal
            for (float i = 0; i < viewPortBottomEdge; i += scale)
            {
                Painter.DrawLine(penNet, viewPortLeftEdge, i + dy, viewPortRightEdge, i + dy);
            }
            for (float i = 0; i >= viewPortTopEdge; i -= scale)
            {
                Painter.DrawLine(penNet, viewPortLeftEdge, i + dy, viewPortRightEdge, i + dy);
            }

            return Buffer;
        }
        
        public Bitmap DrawCurve(Pen pen,int scale, string PostfixFunction)
        {
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float functionValue;

            PointF[] coordinates;
            List<PointF> Coordinates = new List<PointF>();

            for (double  i= -ViewPortWidth/2,x=viewPortLeftEdge; i < ViewPortWidth/2;i+=0.1, x +=0.1)
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
            return Buffer;

        }

        public Bitmap DrawCurve(Pen pen, int scale, string PostfixFunction_1, string PostfixFunction_2)
        {
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float functionValue_1;
            float functionValue_2;

            PointF[] coordinates;
            List<PointF> Coordinates = new List<PointF>();

            for (double i = -ViewPortWidth/2, t = viewPortLeftEdge; i <ViewPortWidth/2; i += 0.1, t += 0.1)
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
            return Buffer;
        }
 

        public Bitmap SetCross(Bitmap d,Pen pen,int offset, float crossPoint)
        {
            Bitmap e =new Bitmap(d);
            try
            {
                
                Graphics s = Graphics.FromImage(e);
                s.TranslateTransform(Painter.Transform.OffsetX, Painter.Transform.OffsetY);
                s.DrawLine(pen, offset, 0, offset, crossPoint);
                s.DrawLine(pen, 0, crossPoint, offset, crossPoint);
                DrawDot(s,8, Color.Red, new PointF(offset, crossPoint));
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

            for(float step=0,i=0;step<viewPortRightEdge-offset;i++,step+=scale)
            {
                Painter.DrawString(i.ToString(), font, solidBrush, new PointF(step, viewPortBottomEdge-offset)); 
            }
            for (float step = -scale, i = -1; step >= viewPortLeftEdge+offset; i--, step -= scale)
            {
                Painter.DrawString(i.ToString(), font, solidBrush, new PointF(step, viewPortBottomEdge - offset));
            }
            for (float step = 0, i = 0; step < viewPortBottomEdge-offset; i++, step += scale)
            {
                Painter.DrawString(i.ToString(), font, solidBrush, new PointF(viewPortLeftEdge, step));
            }
            for (float step = -scale, i = 0; step >=viewPortTopEdge; i--, step -= scale)
            {
                Painter.DrawString(i.ToString(), font, solidBrush, new PointF(viewPortLeftEdge, step));
            }

            return Buffer;
        }
        
        public void DrawDot(Graphics s,int size, Color color, PointF position)
        {
            SolidBrush brush = new SolidBrush(color);
            RectangleF positionRectangle = new RectangleF(position.X - size / 2, position.Y - size / 2, size, size);
            s.FillEllipse(brush, positionRectangle);
        }
        public Bitmap DrawDot(int size,Color color,Point position)
        {
            SolidBrush brush = new SolidBrush(color);
            Rectangle positionRectangle = new Rectangle(position.X - size / 2, position.Y - size / 2, size, size);
            Painter.FillEllipse(brush, positionRectangle);
            return Buffer;
        }
    }
}
