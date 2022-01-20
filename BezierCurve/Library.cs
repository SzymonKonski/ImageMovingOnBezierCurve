using System;
using System.Windows;
using Point = System.Drawing.Point;

namespace BezierCurveApp
{
    public static class Library
    {
        public static double DistanceBetweenPoints(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static double VectorLength(Vector v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        //Symbol Newtona
        public static double BinomialCoeff(int n, int k)
        {
            double result = 1;
            double N = n;
            double K = k;
            double NK = n - k;
            var m = Math.Min(K, NK);

            for (double j = Math.Max(K, NK) + 1, y = 1; j <= N; j++, y++)
            {
                result *= j;

                if (y <= m)
                    result /= y;
            }

            return result;
        }

        public static double FractionalPart(double number)
        {
            return number - Math.Truncate(number);
        }

        // wielomian Bernsteina
        public static double BernsteinBasisPolynomial(int n, int i, double t)
        {
            var bc = BinomialCoeff(n, i);
            var oneMinusTPow = Math.Pow(1 - t, n - i);
            var tPow = Math.Pow(t, i);

            return bc * oneMinusTPow * tPow;
        }
    }
}