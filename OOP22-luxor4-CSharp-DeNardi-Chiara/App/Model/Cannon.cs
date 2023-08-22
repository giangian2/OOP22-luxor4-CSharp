using System;
using System.Collections.Generic;
using OOP22_luxor4_CSharp_DeNardi_Chiara.App.Physics.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.Model.Api.IWorld;

//MANCANO playerinputcomponent, p2d, v2d, gameobjfactory
//ball color, cannongraphicscomp


namespace OOP22_luxor4_CSharp_DeNardi_Chiara.App.Model
{
    /// <summary>
    /// Represents a Cannon GameObject in the game.
    /// Extends the base GameObject class to include cannon-specific behavior.
    /// </summary>
    public class Cannon : GameObject
    {
        private readonly List<Ball> cannonBalls;
        private readonly Ball stationaryBall;
        private const int ADJUST_FIRED_BALL_POS = 37;
        private const int ADJUST_STATIONARY_XPOS = 37;
        private const int BALL_SPEED_Y = -10;
        private const int ADJUST_STATIONARY_YPOS = 50;

        /// <summary>
        /// Creates a new Cannon instance.
        /// </summary>
        /// <param name="pos">Initial position of the Cannon.</param>
        /// <param name="vel">Initial velocity of the Cannon.</param>
        /// <param name="input">Player input component for controlling the Cannon.</param>
        /// <param name="physics">Physics component for simulating Cannon's physics.</param>
        /// <param name="graph">Graphics component for rendering the Cannon.</param>
        public Cannon(P2d pos, V2d vel, PlayerInputComponent input,
            PhysicsComponent physics, CannonGraphicsComponent graph)
            : base(Type.CANNON, pos, vel, input, null, graph, physics)
        {
            this.cannonBalls = new List<Ball>();
            this.stationaryBall = CreateStationaryBall();
        }

        /// <summary>
        /// Creates a stationary ball with a random color.
        /// </summary>
        /// <returns>The created stationary ball.</returns>
        private Ball CreateStationaryBall()
        {
            BallColor randomColor = BallColor.GetRandomColor();
            return GameObjectsFactory.Instance.CreateStationaryBall(GetStationaryBallPos(),
                new V2d(0, 0), randomColor);
        }

        /// <summary>
        /// Gets the stationary ball associated with the Cannon.
        /// </summary>
        /// <returns>The stationary ball.</returns>
        public Ball GetStationaryBall()
        {
            return GameObjectsFactory.Instance.CreateStationaryBall(GetStationaryBallPos(),
                GetCurrentVel(), this.stationaryBall.Color);
        }

        /// <summary>
        /// Gets the list of fired balls from the Cannon.
        /// </summary>
        /// <returns>The list of fired balls.</returns>
        public List<Ball> GetFiredBalls()
        {
            return new List<Ball>(this.cannonBalls);
        }

        /// <summary>
        /// Removes a fired ball from the list of fired balls.
        /// </summary>
        /// <param name="b">The ball to remove.</param>
        public void RemoveFiredBall(Ball b)
        {
            this.cannonBalls.Remove(b);
        }

        /// <summary>
        /// Fires a new ball from the Cannon.
        /// </summary>
        public void FireBall()
        {
            P2d ballPos = new P2d(GetCurrentPos().X + ADJUST_FIRED_BALL_POS, GetCurrentPos().Y);
            BallColor bColor = stationaryBall.Color;
            Ball ball = GameObjectsFactory.Instance.CreateCannonBall(ballPos, new V2d(0, BALL_SPEED_Y),
                bColor);
            this.cannonBalls.Add(ball);
            stationaryBall.Color = BallColor.GetRandomColor();
        }

        /// <summary>
        /// Gets the position of the stationary ball associated with the Cannon.
        /// </summary>
        /// <returns>The position of the stationary ball.</returns>
        public P2d GetStationaryBallPos()
        {
            return new P2d(GetCurrentPos().X + ADJUST_STATIONARY_XPOS,
                GetCurrentPos().Y + ADJUST_STATIONARY_YPOS);
        }
    }
}
