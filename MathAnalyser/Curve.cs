using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MathAnalyser
{
    class Curve
    {
        string firstExpression;
        string secondExpression;
        string firstPostfixExpression;
        string secondPostfixExpression;
        string type;
        Pen pen;

        public string FirstPostfixExpression
        {
            get
            {
                return firstPostfixExpression;
            }
        }
        public string SecondPostfixExpression
        {
            get
            {
                return secondPostfixExpression;
            }
        }
        public Pen CurvePen
        {
            get
            {
                return pen;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }
        public string FirstExcpression
        {
            get
            {
                return firstExpression;
            }
        }
        public Curve(string firstExpression)
        {
            this.firstExpression = firstExpression;
            this.secondExpression = string.Empty;
            this.type = "explicit";
        }
        public Curve(string firstExpression,string secondExpression)
        {
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
            this.type = "parametric";
        }
        public Curve(string firstExpression,string PostfixExpression,Color color,float CurveWidth,DashStyle dashStyle)
        {
            this.firstExpression = firstExpression;
            this.secondExpression = string.Empty;
            this.firstPostfixExpression = PostfixExpression;
            this.secondPostfixExpression = string.Empty;
            pen = new Pen(color);
            pen.Width = CurveWidth;
            pen.DashStyle = dashStyle;
            this.type = "explicit";

        }
        public Curve(string firstExpression, string secondExpression,
            string firstPostfixExpression, string secondPostfixExpression, Color color, float CurveWidth, DashStyle dashStyle)
        {
            this.firstExpression = firstExpression;
            this.secondExpression = secondExpression;
            this.firstPostfixExpression = firstPostfixExpression;
            this.secondPostfixExpression = secondPostfixExpression;
            pen = new Pen(color);
            pen.Width = CurveWidth;
            pen.DashStyle = dashStyle;
            this.type = "parametric";
        }
        public override string ToString()
        {
            if(Type=="explicit")
            {
                return firstPostfixExpression;
            }
            return firstPostfixExpression+" "+secondPostfixExpression;

            
        }
        public override bool Equals(object inputFunction)
        {
            if ((inputFunction is Curve) && (inputFunction != null))
            {
                Curve tempInputFunction = (Curve)inputFunction;
                if ((this.firstExpression.Equals(tempInputFunction.firstExpression))&&
                    (this.secondExpression.Equals(tempInputFunction.secondExpression)))
                {
                    return true;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public static bool operator !=(Curve a, Curve b)
        {
            if((a.firstExpression != b.firstExpression)&&(a.secondExpression!=b.secondExpression))
            {
                return true;
            }
            return false;
        }
        public static bool operator ==(Curve a,Curve b)
        {
            if ((a.firstExpression == b.firstExpression)&&(a.secondExpression==b.secondExpression))
            {
                return true;
            }
            return false;
        }
    }
}
