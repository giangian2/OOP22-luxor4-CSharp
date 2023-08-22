//MANCA p2d

namespace OOP22_luxor4_CSharp_DeNardi_Chiara.Physics.Impl
{
    /// <summary>
    /// The BoundaryCollision class represents a collision with the boundaries of the game world.
    /// It provides information about the edge of the boundary and the collision position.
    /// </summary>
    public class BoundaryCollision
    {
        /// <summary>
        /// Enumerates the possible collision edges with the boundary.
        /// </summary>
        public enum CollisionEdge
        {
            TOP,
            BOTTOM,
            LEFT,
            RIGHT
        }

        private readonly CollisionEdge edge;
        private readonly P2d where;

        /// <summary>
        /// Initializes a new instance of the BoundaryCollision class.
        /// </summary>
        /// <param name="edge">The edge of the boundary where the collision occurred.</param>
        /// <param name="where">The collision position.</param>
        public BoundaryCollision(CollisionEdge edge, P2d where)
        {
            this.edge = edge;
            this.where = where;
        }

        /// <summary>
        /// Gets the edge of the boundary where the collision occurred.
        /// </summary>
        public CollisionEdge Edge => edge;

        /// <summary>
        /// Gets the collision position.
        /// </summary>
        public P2d Where => where;
    }
}
