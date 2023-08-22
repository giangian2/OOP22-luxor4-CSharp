using OOP22_luxor4_CSharp_DeNardi_Chiara.Model.Impl;
using OOP22_luxor4_CSharp_DeNardi_Chiara.App.Physics.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.Model.Api.IWorld;

//MANCA GAMEOBJ

namespace OOP22_luxor4_CSharp_DeNardi_Chiara.Physics.Impl
{
    /// <summary>
    /// The BallPhysicsComponent class represents a specific implementation of the
    /// PhysicsComponent for updating the physics of a ball GameObject in the World.
    /// </summary>
    public class BallPhysicsComponent : IPhysicsComponent
    {
        /// <summary>
        /// Updates the physical state of the ball GameObject.
        /// </summary>
        /// <param name="dt">The time elapsed since the last physics update.</param>
        /// <param name="obj">The ball GameObject to update.</param>
        /// <param name="w">The world context in which the physics update occurs.</param>
        public void Update(long dt, GameObject obj, World w)
        {
            var pos = obj.CurrentPos;
            var vel = obj.CurrentVel;

            obj.SetPos(pos.Sum(vel));
        }
    }
}
