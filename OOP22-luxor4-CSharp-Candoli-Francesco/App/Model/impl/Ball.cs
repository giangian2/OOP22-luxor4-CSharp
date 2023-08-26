using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Model.Api;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.input.api;
using OOP22_luxor4_CSharp_Candoli_Francesco.Physics.Api;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Enums;

namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Model
{
    /*
    * Represents a ball object in the game.
    */
    public class Ball : GameObject
    {
        private BallColor _color; //color of the ball
        public const  int IMAGE_DIAMETER = 25; //diameter of the ball

        public BallColor Color { get => _color; set => _color = value; }

        
        /*
        * Constructor for an istance of Ball.
        */
        public Ball(Type type, P2d pos, BallColor color,
                V2d vel, IInputComponent? input, IBoundingBox? bbox,
                IPhysicsComponent? physics)
                : base(type, pos, vel, input, bbox, physics)
        {
            this.Color = color;
        }

        /*
        * Method that return if a ball(a) if the distance beetween a and this ball
        * is less than its diameter + a little approximation).
        */
        public bool IsNear(Ball a) {
            return Math.Abs(this.Pos.SumOfAxis() - a.Pos.SumOfAxis()) < (IMAGE_DIAMETER + 2);
        }

        /*
        * Calculates the hash code for this object.
        */
        public override int GetHashCode()
        {
            return HashCode.Combine(Color);
        }

        /*
        * Checks if this Ball is considerable equal to another object.
        */
        public bool Equals(Ball other)
        {
            return other != null &&
                this.Color == other.Color &&
                this.Pos == other.Pos;
        }

    }

}
