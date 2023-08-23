/*using it.unibo.enums;
using it.unibo.graphics.impl;
using it.unibo.input.impl;
using it.unibo.model.collisions.impl;
using it.unibo.model.impl;
using it.unibo.physics.impl;
using it.unibo.utils;*/
using System;

namespace OOP22_luxor4_CSharp_Guiducci_Federica.App.core.impl
{
    // Assuming the equivalent namespaces and classes exist in the C# codebase
    public class GameObjectsFactory
    {
        private static GameObjectsFactory instance;

        public static GameObjectsFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new GameObjectsFactory();
            }
            return instance;
        }

        public Ball CreateBall(P2d pos, V2d vel, BallColor color)
        {
            return new Ball(Type.BALL, pos, color, new V2d(10, 10),
                new NullInputComponent(),
                new CircleBoundingBox(new P2d(pos.X, pos.Y), 10),
                new BallPhysicsComponent(),
                new BallGraphicsComponent());

        }

        public Cannon CreateCannon(P2d pos)
        {
            return new Cannon(pos, new V2d(pos, pos),
                new PlayerInputComponent(),
                null,
                new CannonGraphicsComponent());
        }

        public Ball CreateCannonBall(P2d pos, V2d vel, BallColor color)
        {
            int initialVelocity = -10;
            return new Ball(Type.CANNON_BALL, pos, color, new V2d(0, initialVelocity),
                new NullInputComponent(),
                new CircleBoundingBox(new P2d(pos.X, pos.Y), 10),
                new CannonBallPhysicsComponent(),
                new BallGraphicsComponent());
        }

        public Ball CreateStationaryBall(P2d cannonPos, V2d vel, BallColor color)
        {
            return new Ball(Type.STATIONARY_BALL, cannonPos, color, new V2d(0, 0),
                new NullInputComponent(),
                new CircleBoundingBox(new P2d(cannonPos.X, cannonPos.Y), 10),
                new StationaryBallPhysicsComponent(),
                new BallGraphicsComponent());
        }
    }
}
