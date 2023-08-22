using OOP22_luxor4_CSharp_Bianchi_Gianluca.Model.Api.IWorld;

//MANCA IL GAMEOBJ

namespace OOP22_luxor4_CSharp_DeNardi_Chiara.Physics.Api
{
    /// <summary>
    /// Represents a physics component responsible for updating the game object's physical state.
    /// </summary>
    public interface IPhysicsComponent
    {
        /// <summary>
        /// Updates the physical state of the game object.
        /// </summary>
        /// <param name="dt">The time elapsed since the last physics update.</param>
        /// <param name="obj">The game object to update.</param>
        /// <param name="w">The world context in which the physics update occurs.</param>
        void Update(long dt, GameObject obj, World w);
    }
}
