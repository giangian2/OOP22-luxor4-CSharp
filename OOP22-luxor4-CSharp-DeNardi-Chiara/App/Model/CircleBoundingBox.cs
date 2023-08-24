using System;

namespace OOP22_luxor4_CSharp_DeNardi_Chiara.Model
{
    /// <summary>
    /// Class that models a circular bounding box, identified by its center and radius.
    /// </summary>
    public class CircleBoundingBox : BoundingBox
    {
        private readonly P2d center;
        private readonly double radius;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="center">Center of the bounding box.</param>
        /// <param name="radius">Radius of the bounding box.</param>
        public CircleBoundingBox(P2d center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        /// <summary>
        /// Gets the radius of the bounding box.
        /// </summary>
        /// <returns>Radius of the bounding box.</returns>
        public double GetRadius()
        {
            return radius;
        }

        /// <summary>
        /// Checks if there is a collision between the current instance of the CircleBoundingBox class
        /// and a circle identified by its center and radius.
        /// </summary>
        /// <param name="p">Center of the circle to check against.</param>
        /// <param name="radius">Radius of the circle to check against.</param>
        /// <returns>True if collision occurs, otherwise false.</returns>
        public override bool IsCollidingWith(P2d p, double radius)
        {
            return new V2d(p, center).Module() <= radius + this.radius;
        }
    }
}