using NUnit.Framework;
using OOP22_luxor4_CSharp_DeNardi_Chiara.Model; 
using OOP22_luxor4_CSharp_DeNardi_Chiara.App.Physics.API;
using OOP22_luxor4_CSharp_Candoli_Francesco.Utils;
using OOP22_luxor4_CSharp_Guiducci_Federica.input.impl;

namespace OOP22_luxor4_CSharp_DeNardi_Chiara.App.Tests
{
    /// <summary>
    /// Test class for testing the behavior of the Cannon class.
    /// </summary>
    [TestFixture]
    public class CannonTest
    {
        private Cannon cannon;
        private P2d position;
        private V2d vel;
        private PlayerInputComponent input;
        private PhysicsComponent physics;

        [SetUp]
        public void SetUp()
        {
            position = new P2d(x, y);
            vel = new V2d(x, y);
             // Create an instance of InputController
            InputController inputController = new InputController();

            // Instantiate the PlayerInputComponent with the inputController
            input = new PlayerInputComponent(inputController);

            physics = new PhysicsComponent();

            cannon = new Cannon(position, vel, input, physics);
        }

        /// <summary>
        /// Test that the MoveRight method updates the cannon's position correctly.
        /// </summary>
        [Test]
        public void MoveRight_ShouldUpdateCannonPosition()
        {
            // Arrange
            P2d initialPosition = cannon.GetCurrentPos();
            
            // Act
            cannon.MoveRight();
            
            // Assert
            Assert.AreEqual(initialPosition.X + Cannon.MOVE_AMOUNT, cannon.GetCurrentPos().X);
        }

        /// <summary>
        /// Test that the MoveLeft method updates the cannon's position correctly.
        /// </summary>
        [Test]
        public void MoveLeft_ShouldUpdateCannonPosition()
        {
            // Arrange
            P2d initialPosition = cannon.GetCurrentPos();
            
            // Act
            cannon.MoveLeft();
            
            // Assert
            Assert.AreEqual(initialPosition.X - Cannon.MOVE_AMOUNT, cannon.GetCurrentPos().X);
        }
    }
}
