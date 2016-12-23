using System;

namespace BL
{
    static class Functions
    {
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
            double e = Math.Round(Math.E, 1);
            return (Math.Pow(e,x)-Math.Pow(e,-x))/2;
        }
    }
}
