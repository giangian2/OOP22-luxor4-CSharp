
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Enums;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Model
{
    /*
    * Represents a ball object in the game.
    */
    public class Ball : GameObject
    {
        private BallColor Color {get; set;} //color of the ball
        public const  int IMAGE_DIAMETER = 25; //diameter of the ball

        
        /*
        * Constructor for an istance of Ball.
        */
        public Ball(Type type, P2d pos, BallColor color,
                V2d vel, InputComponent input, BoundingBox bbox,
                PhysicsComponent physics, BallGraphicsComponent graph)
                : base(type, pos, vel, input, bbox, graph, physics)
        {
            this.Color = color;
        }

        /*
        * Method that return if a ball(a) if the distance beetween a and this ball
        * is less than its diameter + a little approximation).
        */
        public bool IsNear(Ball a) {
            return Math.Abs(this.Pos.SumOfAxis() - a.Pos.SumOfAxis()) < (IMAGE_DIAMETER + 2);
        }

        /*
        * Calculates the hash code for this object.
        */
        public override int GetHashCode()
        {
            return HashCode.Combine(Color);
        }

        /*
        * Checks if this Ball is considerable equal to another object.
        */
        public bool Equals(Ball other)
        {
            return other != null &&
                this.Color == other.Color &&
                this.Pos == other.Pos;
        }

    }

}
