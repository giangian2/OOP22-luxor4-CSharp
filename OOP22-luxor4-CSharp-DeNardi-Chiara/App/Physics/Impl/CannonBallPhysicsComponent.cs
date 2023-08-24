using System;
using System.Linq;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.Model.Api.IWorld;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.Events.Impl.HitBallEvent;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.Events.Impl.HitBorderEvent;
using OOP22_luxor4_CSharp_Guiducci_Federica.model;
using OOP22_luxor4_CSharp_Candoli_Francesco.Model;
using OOP22_luxor4_CSharp_DeNardi_Chiara.Model;

namespace OOP22_luxor4_CSharp_DeNardi_Chiara.Physics.Impl
{
    /// <summary>
    /// This class represents the physics component for a cannon ball in the game.
    /// It extends the BallPhysicsComponent class and provides additional
    /// functionality specific to the cannon ball.
    /// </summary>
    public class CannonBallPhysicsComponent : BallPhysicsComponent
    {
        /// <summary>
        /// Updates the physics of the cannon ball GameObject.
        /// </summary>
        /// <param name="dt">The time step for the update.</param>
        /// <param name="obj">The cannon ball GameObject.</param>
        /// <param name="w">The game World.</param>
        public override void Update(long dt, GameObject obj, World w)
        {
            base.Update(dt, obj, w);

            CircleBoundingBox bbox = (CircleBoundingBox)obj.BBox;

            /// Check for collision with boundaries
            var binfo = w.CheckCollisionWithBoundaries(obj.CurrentPos, bbox);

            CircleBoundingBox cbbox = (CircleBoundingBox)obj.BBox;

            /// Check for collision with other balls
            var ball = w.CheckCollisionWithBalls(obj.CurrentPos, cbbox);

            if (binfo.HasValue && obj is Ball ballObject)
            {
                /// Notify a hit boundary event
                w.NotifyWorldEvent(new HitBorderEvent(ballObject));
            }
            else if (ball.HasValue)
            {
                /// Notify a hit ball event
                w.NotifyWorldEvent(new HitBallEvent(ball.Value, (Ball)obj));
            }
        }
    }
}
