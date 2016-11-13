using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MathAnalyser
{
    class Curve
    {
        private List<string> postfixNotation;
        Pen pen;

        public List<string>PostfixNotation
        {
            get
            {
                return postfixNotation;
            }
        }
        public Pen CurvePen
        {
            get
            {
                return pen;
            }
        }

        public Curve(List<string>PostfixFunction,Color color,float CurveWidth,DashStyle dashStyle)
        {
            postfixNotation = PostfixFunction;
            pen = new Pen(color);
            pen.Width = CurveWidth;
            pen.DashStyle = dashStyle;
        }
        public override string ToString()
        {
            return string.Concat<string>(postfixNotation);
        }
        public override bool Equals(object inputFunction)
        {
            if ((inputFunction is Curve) && (inputFunction != null))
            {
                Curve tempInputFunction = (Curve)inputFunction;
                if (this.postfixNotation.Equals(tempInputFunction.postfixNotation))
                {
                    return true;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return postfixNotation.GetHashCode();
        }
    }
}
