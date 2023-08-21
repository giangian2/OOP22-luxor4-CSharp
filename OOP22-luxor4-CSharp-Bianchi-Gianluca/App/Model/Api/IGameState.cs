using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Model.Api
{
    public interface IGameState
    {
        /*
        * Checks if the game is over.
        */
        bool IsGameOver();

        /*
         * Checks if the player has won the game.
         */
        bool IsWin();

        /*
         * Updates the game state based on the elapsed time.
         */
        void Update(long dt);

        /*
         * Increases the current score by 1.
         */
        void IncScore();

        /*
         * Decreases the current score by 1.
         */
        void DecScore();

        /*
         * Retrieves the current score of the game.
         */
        int Score
        {
            get;
        }


        /*
         * Retrieves the World object representing the game world.
         */
        IWorld World
        {
            get;
        }

        /*
         * Toggles the pause state of the game.
         * If the game is paused, it will be resumed, and vice versa.
         */
        void ChangePauseState();
    }
}
