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

        Graphics numericLinesPainter;//the variable for depiction numeric lines
        Graphics Painter;
        Bitmap Buffer;//buffer for drawing 
        Font font;
        SolidBrush solidBrush;

        int offsetXViePortZone = 15;
        int offsetYViePortZone = 30;
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
            Buffer = new Bitmap(ViewPortWidth, ViewPortHeight);
            Painter = Graphics.FromImage(Buffer);

            Painter.Clip = new Region(new RectangleF(offsetYViePortZone, 0, ViewPortWidth - offsetYViePortZone, ViewPortHeight - offsetXViePortZone));
            Painter.TranslateTransform(ViewPortWidth/2, ViewPortHeight / 2,MatrixOrder.Append);
            
            viewPortLeftEdge = (int)Painter.VisibleClipBounds.X;
            viewPortRightEdge = (int)(Painter.VisibleClipBounds.X+Painter.VisibleClipBounds.Width);
            viewPortTopEdge = (int)Painter.VisibleClipBounds.Y;
            viewPortBottomEdge = (int)(Painter.VisibleClipBounds.Height+ Painter.VisibleClipBounds.Y);

            Painter.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low; // or NearestNeighbour
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            Painter.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
            Painter.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            Painter.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

            //High quality
            //Painter.InterpolationMode = InterpolationMode.High; // or NearestNeighbour
            //Painter.SmoothingMode = SmoothingMode.HighQuality;
            //Painter.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //Painter.CompositingQuality = CompositingQuality.HighQuality;
            //Painter.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            ///
            

        }
        //public Depiction(int Width, int Height, CoordinatePlane offsets)
        //{
        //    this.ViewPortWidth = Width;
        //    this.ViewPortHeight = Height;
        //    Buffer = new Bitmap(Width, Height);
        //    Painter = Graphics.FromImage(Buffer);

        //    CoordinatePlaneLocation = offsets; 

        //    Painter.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low; // or NearestNeighbour
        //    Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        //    Painter.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
        //    Painter.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        //    Painter.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

        //}
        public void Clear(Color color)
        {
            Painter.Clear(color);
        }
        public Bitmap BuildAxes(Color colorPen,int width,int dx,int dy)
        {
            Pen pen = new Pen(colorPen,width);
            Painter.DrawLine(pen, dx, viewPortTopEdge, dx, viewPortBottomEdge);//Y
            Painter.DrawLine(pen, viewPortLeftEdge, dy, viewPortRightEdge, dy);//X

            return Buffer;
            
        }
        //Depicts coordinate net
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
        
        public Bitmap DrawCurveq(Pen pen,int scale, string PostfixFunction)
        {
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            double functionValue;

            PointF[] coordinates;
            List<PointF> coordinatesList = new List<PointF>();

            //StreamWriter w = new StreamWriter("D:\\out.txt");
            for (double  i= -ViewPortWidth/2,x=viewPortLeftEdge; i < ViewPortWidth/2;i+=0.1, x +=0.1)
            {

                functionValue = -Parser.GetValue(PostfixFunction, Math.Round(x / scale,2));
                functionValue =(float) Math.Round(functionValue, 4);
                //w.WriteLine($"{functionValue}");
                if (!double.IsNegativeInfinity(functionValue)&& functionValue < -200000)
                {
                    functionValue = -200000;
                }
                else if (!double.IsInfinity(functionValue)&&functionValue > 200000)
                {
                    functionValue = 200000;
                }

                if ((double.IsNaN(functionValue)) || (double.IsInfinity(functionValue)))
                    {
                        if (coordinatesList.Count != 0)
                        {
                            coordinates = new PointF[coordinatesList.Count];
                            coordinates = coordinatesList.ToArray();
                            try
                            {
                                Painter.DrawLines(pen, coordinates);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            coordinatesList.Clear();
                        }
                        continue;
                    }
                    else
                    {
                    coordinatesList.Add(new PointF(Convert.ToSingle(x),
                        Convert.ToSingle(scale* functionValue)));
                    }

            }
                try
                {
                    if (coordinatesList.Count != 0)
                    {
                        coordinates = new PointF[coordinatesList.Count];
                        coordinates = coordinatesList.ToArray();;
                        Painter.DrawCurve(pen, coordinates);
                    }
                }
            catch (OverflowException)
            {
                //Painter.DrawLine(pen, 0,0,50,50);
            }
            catch (ArgumentException)
            {
                //return;
            }
           // w.Close();
            Painter.SmoothingMode = SmoothingMode.HighSpeed;
            return Buffer;

        }

        public Bitmap DrawCurve(Pen pen, int scale, string PostfixFunction_1, string PostfixFunction_2)
        {
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            double functionValue_1;
            double functionValue_2;

            PointF[] coordinates;
            List<PointF> coordinatesList = new List<PointF>();

            for (double i = -ViewPortWidth/2, t = viewPortLeftEdge; i <ViewPortWidth/2; i += 0.1, t += 0.1)
            {

                functionValue_1 = -Parser.GetValue(PostfixFunction_1, Math.Round(t / scale, 2));
                functionValue_2= -Parser.GetValue(PostfixFunction_2, Math.Round(t / scale, 2));

                if ((double.IsNaN(functionValue_1)) || (double.IsInfinity(functionValue_1)))
                {
                    if (coordinatesList.Count != 0)
                    {
                        coordinates = new PointF[coordinatesList.Count];
                        coordinates = coordinatesList.ToArray();
                        try
                        {
                            Painter.DrawLines(pen, coordinates);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        coordinatesList.Clear();
                    }
                    continue;
                }
                else
                {
                    coordinatesList.Add(new PointF(Convert.ToSingle(scale*functionValue_1),
                        Convert.ToSingle(scale * functionValue_2)));
                }

            }
            try
            {
                if (coordinatesList.Count != 0)
                {
                    coordinates = new PointF[coordinatesList.Count];
                    coordinates = coordinatesList.ToArray(); ;
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

        public Bitmap DrawCurve(Pen pen,PointF[]Points)
        {
            Painter.SmoothingMode = SmoothingMode.AntiAlias;
            List<PointF> coordinatesList = new List<PointF>();
            PointF[] coordinates;
            foreach (PointF point in Points)
            {
                if ((float.IsInfinity(point.Y)) || (point.Y.ToString() == "NaN"))
                {
                    if (coordinatesList.Count != 0)
                    {
                        coordinates = new PointF[coordinatesList.Count];
                        coordinates = coordinatesList.ToArray();
                        try
                        {
                            Painter.DrawCurve(pen, coordinates);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        coordinatesList.Clear();

                    }
                    continue;
                }
                else
                {
                    coordinatesList.Add(point);
                }
            }
            if (coordinatesList.Count != 0)
            {
                coordinates = new PointF[coordinatesList.Count];
                coordinates = coordinatesList.ToArray();
                Painter.DrawCurve(pen, coordinates);
            }
            // Painter.DrawLines(pen, Points);
            Painter.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            return Buffer;
        }



        public Bitmap SetCross(Bitmap d,Pen pen,int offset, double crossPoint)
        {
            Bitmap e =new Bitmap(d);
            try
            {
                
                Graphics s = Graphics.FromImage(e);
                s.TranslateTransform(Painter.Transform.OffsetX, Painter.Transform.OffsetY);
                s.DrawLine(pen, offset, 0, offset, (float)crossPoint);
                s.DrawLine(pen, 0, (float)crossPoint, offset, (float)crossPoint);
                DrawDot(s,8, Color.Red, new PointF(offset, (float)crossPoint));
                s.Dispose();
                return e;
            }
            catch(OverflowException)
            {
                return e;
            }
        }

       
        public Bitmap SetNumericLines(float scale, int increment, float dx, float dy)
        {
            font = new Font("Consolas", 7);
            solidBrush = new SolidBrush(Color.SteelBlue);

            numericLinesPainter = Graphics.FromImage(Buffer);
            numericLinesPainter.Clip = new Region(new Rectangle(offsetXViePortZone, ViewPortHeight - offsetXViePortZone, ViewPortWidth - 2 * offsetXViePortZone, 2 * offsetXViePortZone));
            numericLinesPainter.TranslateTransform(Painter.Transform.OffsetX, 0);

            numericLinesPainter.Clear(Color.Transparent);
            
            int i = 0;
            int doubleincrement = 2 * increment;
            for (float step = dx; step < viewPortRightEdge-scale/2;)
            {
                if(i>=100)
                {
                    increment =doubleincrement;
                    numericLinesPainter.DrawString(i.ToString(), font, solidBrush, new PointF(step - 12, ViewPortHeight - offsetXViePortZone));
                }
                else if ((i >= 10)&&(i<100))
                {
                    numericLinesPainter.DrawString(i.ToString(), font, solidBrush, new PointF(step - 8, ViewPortHeight - offsetXViePortZone));
                }
                else
                {
                    numericLinesPainter.DrawString(i.ToString(), font, solidBrush, new PointF(step - 4, ViewPortHeight - offsetXViePortZone));
                }
                i+=increment;
                step += increment * scale;
            }
            i = -1*increment;
            for(float step=dx-increment*scale;step>=viewPortLeftEdge+scale/2;)
            {
                if (Math.Abs(i) >= 100)
                {
                    increment = doubleincrement;
                    numericLinesPainter.DrawString(i.ToString(), font, solidBrush, new PointF(step - 16, ViewPortHeight - offsetXViePortZone));
                }
                else if ((Math.Abs(i) >= 10)&&(Math.Abs(i)<100))
                {
                    numericLinesPainter.DrawString(i.ToString(), font, solidBrush, new PointF(step - 12, ViewPortHeight - offsetXViePortZone));
                }
                else
                {
                    numericLinesPainter.DrawString(i.ToString(), font, solidBrush, new PointF(step-8, ViewPortHeight - offsetXViePortZone));
                }
                i -= increment;
                step -= increment * scale;
            }
            numericLinesPainter.ResetTransform();
            numericLinesPainter.Clip = new Region(new Rectangle(0,  offsetYViePortZone, offsetYViePortZone, ViewPortHeight-2 * offsetYViePortZone));
            numericLinesPainter.TranslateTransform(0, Painter.Transform.OffsetY);

            numericLinesPainter.Clear(Color.Transparent);
            i = 0; 
            for (float step = dy; step < viewPortBottomEdge-scale/2;)
            {
                if (i >= 100)
                {
                    increment = doubleincrement;
                    numericLinesPainter.DrawString((-1*i).ToString(), font, solidBrush, new PointF(0, step-4));
                }
                else
                {
                    numericLinesPainter.DrawString((-1 * i).ToString(), font, solidBrush, new PointF(0, step-4));
                }
                i += increment;
                step += increment * scale;
            }
            i = increment;
            for (float step = dy-increment*scale; step > viewPortTopEdge + scale / 2;)
            {
                if (i >= 100)
                {
                    increment = doubleincrement;
                    numericLinesPainter.DrawString(i.ToString(), font, solidBrush, new PointF(0, step - 4));
                }
                else
                {
                    numericLinesPainter.DrawString(i.ToString(), font, solidBrush, new PointF(0, step - 4));
                }
                i += increment;
                step -= increment * scale;
            }
            return Buffer;
        }
        public Bitmap ClearNumericLines()
        {
            numericLinesPainter.Clear(Color.Transparent);
            numericLinesPainter.ResetTransform();
            numericLinesPainter.Clip = new Region(new Rectangle(offsetXViePortZone, ViewPortHeight - offsetXViePortZone, ViewPortWidth - 2 * offsetXViePortZone, 2 * offsetXViePortZone));
            numericLinesPainter.Clear(Color.Transparent);
            return Buffer;
        }

        public void DrawDot(Graphics s,int size, Color color, PointF position)
        {
            SolidBrush brush = new SolidBrush(color);
            RectangleF positionRectangle = new RectangleF(position.X - size / 2, position.Y - size / 2, size, size);
            s.FillEllipse(brush, positionRectangle);
        }
        public Bitmap DrawDot(int size,Color color,PointF position)
        {
            SolidBrush brush = new SolidBrush(color);
            RectangleF positionRectangle = new RectangleF(position.X - size / 2, position.Y - size / 2, size, size);
            Painter.FillEllipse(brush, positionRectangle);
            return Buffer;
        }
        public Bitmap DrawDots(Depiction p,Bitmap buffer, int size, Color color, PointF[] locations)
        {
            Pen pen = new Pen(Color.Yellow);
            Graphics s = Graphics.FromImage(buffer);
            s.TranslateTransform(p.CoordinatePlaneLocation.transform.OffsetX, 
                p.CoordinatePlaneLocation.transform.OffsetY);
            foreach (PointF location in locations)
            {
                RectangleF positionRectangle = new RectangleF(location.X - size / 2, location.Y - size / 2, size, size);
                s.DrawEllipse(pen, positionRectangle);
            }
                return buffer;
            
        }

        public Bitmap DrawRectangles(string function,float from,float to,int quantityOfRectangles,int scale,out float area)
        {
            from *= scale;
            to *= scale;
            float dx = (to -from) / quantityOfRectangles;
            float h;
             float step = from+dx/2;
            float rectangleHeight;
            area = 0;
            for(int i=0;i< quantityOfRectangles;i++)
            {
                h = -(float)Parser.GetValue(function,(step-dx/2) / scale);
                rectangleHeight = Math.Abs(h * scale);
                area += ((rectangleHeight * dx)/scale)/scale;
               // if(float.IsInfinity(h)||h.ToString()=="NaN")
                //{
                    // throw new Exception("The function has a discontinuity within selected segment.");
                    //throw new Exception(h.ToString());
               // }
                if (h<0)
                {
                    Painter.DrawRectangle(Pens.Gold, step-dx/2, h*scale, dx, rectangleHeight);
                }
                else if(h>0)
                {
                    Painter.DrawRectangle(Pens.Gold, step-dx/2, 0, dx, rectangleHeight);
                }
                step += dx;
            }
            area = (float)Math.Round(area, 4);
            return Buffer;
        }
        public Bitmap DrawPolygons(string function, float from, float to, int quantityOfRectangles, int scale, out float area)
        {
            from *= scale;
            to *= scale;
            float dx = (to - from) / quantityOfRectangles;
            float h;
            float h2;
            float step = from;
            PointF point1;
            PointF point2;
            PointF point3;
            PointF point4;

            area = 0;
            for (int i = 0; i < quantityOfRectangles; i++)
            {
                h = -(float)Parser.GetValue(function, step / scale);
                h2= -(float)Parser.GetValue(function, (step+dx) / scale);

                area += (((Math.Abs(h) + Math.Abs(h2)) / 2) * dx)/scale;
                point1 = new PointF(step, 0);
                point2= new PointF(step + dx, 0);
                point3 = new PointF(step, h * scale); 
                point4=new PointF(step + dx, h2 * scale);

                Painter.DrawLine(Pens.HotPink, point1,point3);
                Painter.DrawLine(Pens.HotPink, point3, point4);
                Painter.DrawLine(Pens.HotPink, point4, point2);
                step += dx;
            }
            area = (float)Math.Round(area, 4);
            return Buffer;
        }
        public Bitmap DrawVerticalLine(float point)
        {
            Pen pen = new Pen(Color.Moccasin);
            pen.DashStyle = DashStyle.Dot;
            Painter.DrawLine(pen, point, viewPortTopEdge, point, viewPortBottomEdge);
            return Buffer;
        }
        public Bitmap DrawRectangle(Pen pen,RectangleF rectangle)
        {
            Painter.DrawRectangle(pen, rectangle.X,rectangle.Y,rectangle.Width,rectangle.Height);
            return Buffer;
        }
       public Bitmap DrawScene(Color colorNet,Color colorAxes,int scale)
        {
            Clear(Color.Transparent);
            BuildNet(colorNet, scale, 0, 0);
            BuildAxes(colorAxes, 2, 0, 0);
            return Buffer;
        }
    }
}
