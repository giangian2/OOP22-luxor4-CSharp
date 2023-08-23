
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Enums;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Model
{
    public class Ball : GameObject
    {
        private BallColor _color;
        public static readonly int IMAGE_DIAMETER = 25;

        /**
        * Constructor for an istance of Ball.
        * 
        * @param type    Specified type of game object.
        * @param pos     Position (coordinates)
        * @param color   Color
        * @param vel     Velocity vector
        * @param input   Input component
        * @param bbox    Bounding box
        * @param physics Physics component
        * @param graph   Graphic component
        */
        public Ball(Type type, P2d pos, BallColor color,
                V2d vel, InputComponent input, BoundingBox bbox,
                IPhysicsComponent physics, BallGraphicsComponent graph) {

            super(type, pos, vel, input, bbox, graph, physics);
            this.color = color;
        }

        /**
        * Set the color of the ball.
        * 
        * @param color Color to set
        * @see BallColor
        */
        public void setColor(final BallColor color) {
            this.color = color;
        }

        /**
        * Get the color of the ball.
        * 
        * @see BallColor
        * @return The color of the ball
        */
        public BallColor getColor() {
            return this.color;
        }

        /**
        * Method that return if a ball(a) if the distance beetween a and this ball
        * is less than its diameter + a little approximation).
        * 
        * @param a Ball to check if is near
        * @return True if the ball is near else false
        */
        public boolean isNear(final Ball a) {
            return Math.abs(this.getCurrentPos().sumOfAxis() - a.getCurrentPos().sumOfAxis()) < (IMAGE_DIAMETER + 2);
        }

        /**
        * Calculates the hash code for this object.
        * 
        * @return Hashcode.
        */
        @Override
        public int hashCode() {
            final int prime = 31;
            int result = 1;
            result = prime * result + ((color == null) ? 0 : color.hashCode());
            return result;
        }

        /**
        * Checks if this Ball is considerable equal to another object.
        * 
        * @return true if this Ball is equal to the argument, false otherwise.
        */
        @Override
        public boolean equals(final Object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (getClass() != obj.getClass()) {
                return false;
            }
            final Ball other = (Ball) obj;
            if (color != other.color) {
                return false;
            }
            return getCurrentPos().equals(other.getCurrentPos());

        }

    }

}
