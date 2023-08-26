using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OOP22_luxor4_CSharp_Candoli_Francesco.App.input.api;
using OOP22_luxor4_CSharp_Candoli_Francesco.App.Model.Api;
using OOP22_luxor4_CSharp_Candoli_Francesco.Physics.Api;


namespace OOP22_luxor4_CSharp_Candoli_Francesco.App.Utils
{
    /*
    * A class representing a generic GameObject in the game.
    * This class provides methods to manage the position, velocity, input, physics,
    * graphics, and bounding box of the game object.
    */
    public class GameObject
    {
        
    /*
     * Enumeration representing the type of the game object.
     * The possible types are BALL, CANNON, CANNON_BALL, and STATIONARY_BALL.
     */
    public enum Type {
        /** standard ball. */
        BALL,
        /** cannon. */
        CANNON,
        /** ball fired by the cannon. */
        CANNON_BALL,
        /** ball displayedon thecannon object. */
        STATIONARY_BALL
    }

    private Type _typeOf;
    private P2d _pos;
    private V2d _vel;
    private IInputComponent _input;
    private IPhysicsComponent _physics;
    private IBoundingBox _bbox;

    public Type TypeOf { get => _typeOf;}
    public P2d Pos { get => _pos; set => _pos = value; }
    public V2d Vel { get => _vel; set => _vel = value; }
    public IInputComponent Input { get => _input; set => _input = value; }
    public IPhysicsComponent Physics { get => _physics; set => _physics = value; }
    public IBoundingBox Bbox { get => _bbox; set => _bbox = value; }

    /*
     * Creates a new GameObject with the specified type, position, velocity, input
     * component, bounding box, graphics component, and physics component.
     */
    public GameObject(Type type, P2d pos, V2d vel, IInputComponent input,
     IBoundingBox bbox, IPhysicsComponent physics) 
    {
        this._pos = pos;
        this._vel = new V2d(vel.X, vel.Y); // defensive copy
        this._input = input;
        this._bbox = bbox;
        this._typeOf = type;
        this._physics = physics;
    }

    /*
     * Flips the vertical velocity of the game object.
     *
     */
    public void FlipVelOnY() {
        this._vel = new V2d(_vel.X, -_vel.Y);
    }

    /*
     * Flips the horizontal velocity of the game object.
     * This method is used to change the direction of the game object in the
     * horizontal axis.
     */
    public void FlipVelOnX() {
        this._vel = new V2d(-_vel.X, _vel.Y);
    }

    /*
     * Updates the physics of the game object.
     */
    public void UpdatePhysics(long dt, IWorld w) {
        _physics.Update(dt, this, w);
    }

    /*
     * Updates the input of the game object.
     */
    public void UpdateInput(IInputController c) {
        _input.Update(this, c);
    }
    }
}