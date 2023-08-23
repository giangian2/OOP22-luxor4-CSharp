using System.Drawing;

using System;

namespace OOP22_luxor4_CSharp_Guiducci_Federica.App.model.impl
{
    // Assuming the equivalent namespaces and classes exist in the C# codebase
    public class GameObject
    {
        public enum Type
        {
            BALL,
            CANNON,
            CANNON_BALL,
            STATIONARY_BALL
        }

        private readonly Type type;
        private P2d pos;
        private V2d vel;
        private InputComponent input;
        private PhysicsComponent physics;
        private MyGraphicsComponent graph;
        private BoundingBox bbox;

        public GameObject(Type type, P2d pos, V2d vel, InputComponent input, BoundingBox bbox, MyGraphicsComponent graph, PhysicsComponent physics)
        {
            this.pos = pos;
            this.vel = new V2d(vel.X, vel.Y); // defensive copy
            this.input = input;
            this.bbox = bbox;
            this.type = type;
            this.physics = physics;
            this.graph = graph;
        }

        public InputComponent GetInput()
        {
            return input;
        }

        public void SetInput(InputComponent input)
        {
            this.input = input;
        }

        public PhysicsComponent GetPhysics()
        {
            return physics;
        }

        public void SetPhysics(PhysicsComponent physics)
        {
            this.physics = physics;
        }

        public MyGraphicsComponent GetGraph()
        {
            return graph;
        }

        public void SetGraph(MyGraphicsComponent graph)
        {
            this.graph = graph;
        }

        public BoundingBox GetBbox()
        {
            return bbox;
        }

        public void SetBbox(BoundingBox bbox)
        {
            this.bbox = bbox;
        }

        public Type GetType()
        {
            return type;
        }

        public void SetPos(P2d pos)
        {
            this.pos = pos;
        }

        public void SetVel(V2d vel)
        {
            this.vel = new V2d(vel.X, vel.Y);
        }

        public P2d GetCurrentPos()
        {
            return this.pos;
        }

        public V2d GetCurrentVel()
        {
            return new V2d(vel.X, vel.Y);
        }

        public void FlipVelOnY()
        {
            this.vel = new V2d(vel.X, -vel.Y);
        }

        public void FlipVelOnX()
        {
            this.vel = new V2d(-vel.X, vel.Y);
        }

        public BoundingBox GetBBox()
        {
            return bbox;
        }

        public void UpdatePhysics(long dt, World w)
        {
            physics.Update(dt, this, w);
        }

        public void UpdateInput(InputController c)
        {
            input.Update(this, c);
        }

        public void UpdateGraphics(java.awt.Graphics2D c)
        {
            graph.Update(this, c);
        }
    }
}
