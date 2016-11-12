using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MathAnalyser
{
    class Preparation
    {
        private int Width;
        private int Height;
        Graphics Painter;
        Bitmap Draft;

        public Preparation(int Width,int Height)
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
    }
}
