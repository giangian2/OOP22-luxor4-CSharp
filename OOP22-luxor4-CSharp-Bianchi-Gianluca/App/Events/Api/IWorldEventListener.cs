using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api
{
    /*
     * Interface used to model the World-related event listener.
     */
    public interface IWorldEventListener
    {
        /*
         * Method used to notify a World-related event to the listener.
         */
        void NotifyEvent(IWorldEvent e);
    }
}
