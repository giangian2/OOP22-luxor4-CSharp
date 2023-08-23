namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api
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

    }
}