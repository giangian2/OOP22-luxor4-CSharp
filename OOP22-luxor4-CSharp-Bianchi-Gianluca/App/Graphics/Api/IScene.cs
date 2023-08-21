using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP22_luxor4_CSharp_Bianchi_Gianluca.App.Graphics.Api
{
    public interface IScene
    {
        /*
         * Renders the game graphics on the screen.
         * This method should be called periodically to update the visual representation of the game elements.
         */
        void Render();

        /*
         * Renders the game over screen and transitions to the game over menu.
         */
        void RenderGameOver();

        /*
         * Renders the game menu.
         * This method is called to display the game menu, providing options for starting a new game, 
         * adjusting settings, and exiting the game.
         * Note: The implementation of this method depends on the specific game's menu design and options.
         */
        void RenderMenu();

        /*
         * Renders the win screen and transitions to the next game level or the game's victory menu.
         * This method is responsible for displaying the win screen, which congratulates 
         * the player for completing the current game level, and handling any necessary 
         * transitions to the next level or the game's victory menu.
         */
        void RenderWin();
    }
}
