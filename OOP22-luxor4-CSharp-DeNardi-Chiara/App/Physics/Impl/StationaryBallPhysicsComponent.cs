using OOP22_luxor4_CSharp_DeNardi_Chiara.Model.Impl; 
using OOP22_luxor4_CSharp_DeNardi_Chiara.App.Physics.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.Model.Api.IWorld;


//MANCA gameobj

namespace OOP22_luxor4_CSharp_DeNardi_Chiara.Physics.Impl
{
    /// <summary>
    /// A PhysicsComponent implementation that updates the position of a given
    /// GameObject to match the position of a stationary ball in the World.
    /// The update is performed based on the time elapsed since the last update (dt).
    /// </summary>
    public class StationaryBallPhysicsComponent : IPhysicsComponent
    {
        /// <summary>
        /// Updates the position of the GameObject to match the position of a stationary ball in the World.
        /// </summary>
        /// <param name="dt">The time step for the update.</param>
        /// <param name="obj">The GameObject to update.</param>
        /// <param name="w">The game World.</param>
        public void Update(long dt, GameObject obj, World w)
        {
            var pos = w.Cannon.GetStationaryBallPos();
            obj.SetPos(pos);
        }
    }
}
