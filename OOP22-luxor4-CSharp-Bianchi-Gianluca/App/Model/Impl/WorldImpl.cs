using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Impl
{
    /*
     * The WorldImpl class represents the game space in which all the GameObjects
     * will be present and through which you can interact with them.
     */
    public class WorldImpl : IWorld
    {
        private Cannon _cannon;
        private IWorldEventListener _listener;

        public Cannon Cannon { get { return _cannon; } }

        public WorldImpl(RectBoundingBox bbox, int nBalls,int steps, string xmlSrc,
             IWorldEventListener eventListener, Cannon cannon)
        {
            this._cannon=cannon;
            this._listener=eventListener;
        }

        public void SetEventListener(IWorldEventListener l) => this._listener = l;

        public void NotifyWorldEvent(IWorldEvent e) => this._listener.NotifyEvent(e);

        public void UpdateState(long dt)
        {
            //Shift balls
            //Update cannon fired balls
            //Update stationary ball
        }
    }
}
