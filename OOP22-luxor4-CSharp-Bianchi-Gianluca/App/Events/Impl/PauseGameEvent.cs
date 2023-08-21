using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Impl
{
    /*
     * Class representing a Pause Game Event, which extends the WorldEvent interface.
     * This event is used to indicate that the current state of the game needs to change
     * from playing to pause or vice versa.
     */
    internal class PauseGameEvent : IWorldEvent 
    {
    }
}
