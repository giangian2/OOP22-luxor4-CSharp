using NUnit.Framework;
using OOP22_luxor4_CSharp_DeNardi_Chiara.App.Model;
using OOP22_luxor4_CSharp_DeNardi_Chiara.App.Physics.Api;

namespace OOP22_luxor4_CSharp_DeNardi_Chiara.App.Tests
{
    /// <summary>
    /// Test class for testing the behavior of the Cannon's FireBall method.
    /// </summary>
    [TestFixture]
    public class CannonBallTest
    {
        /// <summary>
        /// Test that the FireBall method adds a ball to the list of fired balls.
        /// </summary>
        [Test]
        public void FireBall_ShouldAddBallToFiredBallsList()
        {
            // Arrange
            P2d initialCannonPosition = new P2d(0, 0);
            PlayerInputComponent inputComponent = new PlayerInputComponent();
            PhysicsComponent physicsComponent = new DummyPhysicsComponent(); // Dummy implementation
            Cannon cannon = new Cannon(initialCannonPosition, new V2d(0, 0), inputComponent, physicsComponent, null);

            // Act
            cannon.FireBall();

            // Assert
            Assert.AreEqual(1, cannon.GetFiredBalls().Count);
        }
    }
}
