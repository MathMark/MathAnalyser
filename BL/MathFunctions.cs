using System;

namespace BL
{
    static class MathFunctions
    {
        public static double Sin(double x)
        {
            //return Math.Round(Math.Sin(x),2);
            return Math.Sin(x);
        }
        public static double Cos(double x)
        {
            // return Math.Round(Math.Cos(x),2);
            return Math.Cos(x);
        }
        public static double Tan(double x)
        {
            return Math.Sin(x) / Math.Round(Math.Cos(x), 2);
        }
        public static double Cotan(double x)
        {
            return Math.Cos(x) / Math.Round(Math.Sin(x), 2);
        }
        public static double Sec(double x)
        {
           return 1 / Math.Round(Math.Cos(x), 2);
        }
        public static double Csc(double x)
        {
            return 1 / Math.Round(Math.Sin(x), 2);
        }
        public static double Arcsec(double x)
        {
            return Math.Acos(1 / x);
        }
        public static double Sinh(double x)
        {
            double e = Math.Round(Math.E, 2);
            return (Math.Pow(e,x)-Math.Pow(e,-x))/2;
        }
        public static double Sign(double x)
        {
            if(x>0)
            {
                return 1;
            }
            else if(x<0)
            {
                return -1;
            }
            return double.NaN;
            
        }
        public static double Cth(double x)
        {
            return (1 / Math.Tanh(x));
        }
        public static double Arsinh(double x)
        {
            return Math.Log(x + Math.Sqrt(x * x + 1));
        }
        public static double Arcosh(double x)
        {
            return Math.Log(x + Math.Sqrt(x + 1) * Math.Sqrt(x - 1));
        }
        public static double Artanh(double x)
        {
            return (Math.Log((x + 1) / (x - 1)) / 2);
        }
        public static double Acot(double x)
        {
            return (Math.Atan(-1 * x) + Math.PI / 2);
        }
        public static double Arcth(double x)
        {
            return (Math.Log((x + 1) / (1 - x)) / 2);
        }
        public static double Acsc(double x)
        {
            return Math.Asin(1 / x);
        }



        public static double Sech(double x)
        {
            return (1 / Math.Cosh(x));
        }
        public static double Csch(double x)
        {
            return (1 / Math.Sinh(x));
        }
        public static double Arsech(double x)
        {
            return Math.Log(1 / x + Math.Sqrt(1 / x + 1) * Math.Sqrt(1 / x - 1));
        }
        public static double Arcsch(double x)
        {
            if(x<0)
            {
                return Math.Log((1 - Math.Sqrt(1+x*x))/x);
            }
            if(x>0)
            {
                return Math.Log((1 + Math.Sqrt(1 + x * x)) / x); 
            }
            return double.NaN;
        }
        public static double Rem(double Quotient,double Divident)
        {
            if(Quotient%Divident==0)
            {
                return double.NaN;
            }
            return Quotient % Divident;
        }
        public static double Trun(double x)
        {
            if(Math.Truncate(x)==x)
            {
                return double.NaN;
            }
            return Math.Truncate(x);
        }

    }
}
