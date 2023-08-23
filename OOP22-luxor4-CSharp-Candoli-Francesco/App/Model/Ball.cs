
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Enums;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Model
{
    public class Ball : GameObject
    {
        private BallColor Color {get; set;}
        public const  int IMAGE_DIAMETER = 25;

        
        /// <summary>
        /// Constructor for an instance of Ball.
        /// </summary>
        /// <param name="type">Specified type of game object.</param>
        /// <param name="pos">Position (coordinates).</param>
        /// <param name="color">Color.</param>
        /// <param name="vel">Velocity vector.</param>
        /// <param name="input">Input component.</param>
        /// <param name="bbox">Bounding box.</param>
        /// <param name="physics">Physics component.</param>
        /// <param name="graph">Graphic component.</param>
        public Ball(Type type, P2d pos, BallColor color,
                V2d vel, InputComponent input, BoundingBox bbox,
                IPhysicsComponent physics, BallGraphicsComponent graph)
                : base(type, pos, vel, input, bbox, graph, physics)
        {
            this.Color = color;
        }

        /// <summary>
        /// Method that returns if a ball (a) if the distance between a and this ball
        /// is less than its diameter + a little approximation).
        /// </summary>
        /// <param name="a">Ball to check if is near</param>
        /// <returns>True if the ball is near else false</returns>
        public bool isNear(Ball a) {
            return Math.Abs(this.getCurrentPos().sumOfAxis() - a.getCurrentPos().sumOfAxis()) < (IMAGE_DIAMETER + 2);
        }

        /**
        * Calculates the hash code for this object.
        * 
        * @return Hashcode.
        */
        public override int GetHashCode()
        {
            return HashCode.Combine(Color);
        }

        /**
        * Checks if this Ball is considerable equal to another object.
        * 
        * @return true if this Ball is equal to the argument, false otherwise.
        */
        public bool Equals(Ball other)
        {
            return other != null &&
                this.Color == other.Color &&
                this.getCurrentPos() == other.getCurrentPos();
        }

    }

}
