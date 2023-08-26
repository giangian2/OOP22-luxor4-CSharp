using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils
{
    public class P2d
    {
        public double X { get;} 
        public double Y { get;} 
        public P2d(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(P2d other)
        {
            return other != null &&
                this.X == other.X &&
                this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public P2d Sum(V2d v)
        {
            return new P2d(X + v.X, Y + v.Y);
        }

        public V2d Sub(P2d v)
        {
            return new V2d(X - v.X, Y - v.Y);
        }

        public override string ToString()
        {
            return "(" + X.ToString() + "," + Y.ToString() + ")";
        }

        public double Module()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public bool IsBetween(P2d p1, P2d p2)
        {
            double epsilon = 1e-9;
            return Math.Abs(X - p1.X) < epsilon && Math.Abs(X - p2.X) < epsilon
                && (Y > p1.Y && Y < p2.Y || Y < p1.Y && Y > p2.Y);
        }

        public double SumOfAxis()
        {
            return X + Y;
        }
    }
}