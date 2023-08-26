using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Enums;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Model;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils;

namespace tempchecco;

[TestClass]
public class BallTest
{
    [TestMethod]
        public void IsNear_ShouldReturnTrue_WhenBallsAreNear()
        {
            // Arrange
            Ball ball1 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(0, 0), BallColor.RED, new V2d(0, 0), null, null, null);
            Ball ball2 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(Ball.IMAGE_DIAMETER, 0), BallColor.RED, new V2d(0, 0), null, null, null);

            // Act
            bool result = ball1.IsNear(ball2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNear_ShouldReturnFalse_WhenBallsAreNotNear()
        {
            // Arrange
            Ball ball1 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(0, 0), BallColor.RED, new V2d(0, 0), null, null, null);
            Ball ball2 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(Ball.IMAGE_DIAMETER*2, 0), BallColor.RED, new V2d(0, 0), null, null, null);

            // Act
            bool result = ball1.IsNear(ball2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCode_ShouldReturnSameHashCode_ForBallsWithSameColor()
        {
            // Arrange
            Ball ball1 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(0, 0), BallColor.RED, new V2d(0, 0), null, null, null);
            Ball ball2 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(0, 0), BallColor.RED, new V2d(0, 0), null, null, null);

            // Act
            int hashCode1 = ball1.GetHashCode();
            int hashCode2 = ball2.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Equals_ShouldReturnTrue_ForEqualBalls()
        {
            // Arrange
            Ball ball1 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(0, 0), BallColor.RED, new V2d(0, 0), null, null, null);
            Ball ball2 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(0, 0), BallColor.RED, new V2d(0, 0), null, null, null);

            // Act
            bool result = ball1.Equals(ball2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_ShouldReturnFalse_ForDifferentBalls()
        {
            // Arrange
            Ball ball1 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(0, 0), BallColor.RED, new V2d(0, 0), null, null, null);
            Ball ball2 = new(OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils.GameObject.Type.BALL, new P2d(0, 0), BallColor.BLUE, new V2d(0, 0), null, null, null);

            // Act
            bool result = ball1.Equals(ball2);

            // Assert
            Assert.IsFalse(result);
        }
}