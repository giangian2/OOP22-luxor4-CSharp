﻿using System;
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
        *
        * @return true if the game is over, false otherwise.
        */
        bool IsGameOver();

        /*
         * Checks if the player has won the game.
         *
         * @return true if the player has won, false otherwise.
         */
        bool IsWin();

        /*
         * Updates the game state based on the elapsed time.
         *
         * @param dt The elapsed time since the last update.
         */
        void Update(long dt);

        /**
         * Increases the current score by 1.
         */
        void IncScore();

        /**
         * Decreases the current score by 1.
         */
        void DecScore();

        /**
         * Retrieves the current score of the game.
         *
         * @return The current score.
         */
        int GetScore();


        /**
         * Retrieves the World object representing the game world.
         *
         * @return The World.
         */
        IWorld GetWorld();

        /**
         * Toggles the pause state of the game.
         * If the game is paused, it will be resumed, and vice versa.
         */
        void ChangePauseState();
    }
}
