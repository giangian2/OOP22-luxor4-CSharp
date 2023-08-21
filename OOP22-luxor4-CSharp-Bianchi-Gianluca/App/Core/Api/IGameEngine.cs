using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Events.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Graphics.Api;
using OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Core.Api
{
    internal interface IGameEngine : IWorldEventListener
    {
        /*
         * 
         * Method used to start the main game loop.
         */
        void MainLoop();

        /*
         * Method used to initialize all aspects of the game (World + Graphics).
         */
        void InitGame();

        /*
         * Method used to set the Game STate that the Engine will use to perform the
         * update operation at every cycle.
         */
        void SetGameState(IGameState gameState);

        /*
         * Method used to set the View that the Engine will use to perform the
         * rendering operation at every cycle.
         */
        void SetView(IScene view);
    }
}
