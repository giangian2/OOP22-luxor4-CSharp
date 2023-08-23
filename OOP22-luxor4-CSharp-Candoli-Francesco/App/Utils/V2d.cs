
namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils
{
    public class V2d
    {
        public double X { get;}
        public double Y { get;}

        public V2d(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public V2d(P2d to, P2d from)
        {
            this.X = to.X - from.X;
            this.Y = to.Y - from.Y;
        }

        public V2d Sum(V2d v)
        {
            return new V2d(X + v.X, Y + v.Y);
        }

        public double Module()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public V2d Mul(double fact)
        {
            return new V2d(X * fact, Y * fact);
        }

        public override string ToString()
        {
            return "(" + X.ToString() + "," + Y.ToString() + ")";
        }
    }
}