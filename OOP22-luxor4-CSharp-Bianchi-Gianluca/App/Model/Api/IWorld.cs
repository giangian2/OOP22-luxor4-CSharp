using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api
{
    public  interface IWorld
    {
        /*
        * Notify an events to the WorldEventsListener.
        */
        void NotifyWorldEvent(IWorldEvent ev);

        /*
         * Sets the world event listener.
         */
        void SetEventListener(IWorldEventListener l);

        /*
        * Update the state of the World every frame:
        * The balls of the tail are scrolled.
        * The physics of each ball fired from the cannon is updated.
        * Stationary cannon ball is updated.
        * 
        */
        void UpdateState(long dt);
    }
}
